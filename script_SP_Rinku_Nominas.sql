USE [DBProjectRinku]
GO
/****** Object:  StoredProcedure [dbo].[CreateEmpleado]    Script Date: 15/08/2023 07:19:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Thelma Rojas
-- Create date: 30/05/2023
-- Description:	Proceso para crear un empleado
-- =============================================
CREATE PROCEDURE [dbo].[CreateEmpleado]
	-- Add the parameters for the stored procedure here
	@Nombre varchar(200), 
	@ApellidoPaterno varchar(200),
	@ApellidoMaterno varchar(200),
	@NumeroEmpleado int,
	@IdRol uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @IdUsuario uniqueidentifier
			,@SueldoBaseHora decimal = 30;
	SELECT TOP 1 @IdUsuario = IdUsuario FROM Usuario;

	DECLARE @TableId TABLE (
		ColGuid uniqueidentifier
	)

    -- Insert statements for procedure here
	INSERT [dbo].[Empleado]
           ([Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[Activo]
           ,[FechaCreacion]
           ,[IdRol]
           ,[IdUsuarioCreacion]
           ,[NumeroEmpleado])
	OUTPUT inserted.IdEmpleado
	INTO @TableId
     VALUES
           (@Nombre
           ,@ApellidoPaterno
           ,@ApellidoMaterno
           ,1
           ,GETDATE()
           ,@IdRol
           ,@IdUsuario
           ,@NumeroEmpleado)

	INSERT INTO [dbo].[SueldoBase]
           ([IdEmpleado]
           ,[CantidadPorHora]
           ,[FechaCreacion]
           ,[IdUsuarioCreacion])
     VALUES
           ((SELECT TOP 1 ColGuid FROM @TableId)
           ,@SueldoBaseHora
           ,GETDATE()
           ,@IdUsuario)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateEntregasEmpleado]    Script Date: 15/08/2023 07:19:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Thelma Rojas
-- Create date: 31/05/2023
-- Description:	Proceso para crear entregas por empleado
-- =============================================
CREATE PROCEDURE [dbo].[CreateEntregasEmpleado]
	-- Add the parameters for the stored procedure here
	@IdEmpleado uniqueidentifier,
	@FechaEntrega datetime2,
	@CantidadEntregas decimal
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @IdUsuario uniqueidentifier, @IdRol uniqueidentifier;
	DECLARE @ADate DATETIME, @TotalDaysMonth int
	, @Hours int = 8, @Days int = 6, @Semanas int = 4, @HorasTrabajadasMes int
	, @SueldoBase decimal, @BonoEntregas decimal, @BonoHorasTrabajadas decimal
	, @TotalBonos decimal, @Retencion decimal, @SueldoConRetencion decimal
	, @Vales decimal, @SueldoTotal decimal;
	DECLARE @TableId TABLE(id uniqueidentifier);
	SELECT TOP 1 @IdUsuario = IdUsuario FROM Usuario;

	SELECT @IdRol = IdRol FROM Empleado 
	WHERE IdEmpleado = @IdEmpleado;

	SET @HorasTrabajadasMes = @Days * @Hours * @Semanas;

	SELECT @SueldoBase = (CantidadPorHora * @HorasTrabajadasMes) FROM SueldoBase WHERE IdEmpleado = @IdEmpleado;
	--print @SueldoBase + ''
	--SET @ADate = GETDATE()
	--SELECT @TotalDaysMonth = DAY(EOMONTH(@FechaEntrega));


    -- Insert statements for procedure here
	INSERT [dbo].[EntregasPorEmpleado]
           ([IdEmpleado]
           ,[FechaEntrega]
           ,[IdClienteEntrega]
           ,[FechaCreacion]
           ,[IdUsuarioCreacion]
		   ,[CantidadEntregas])
	OUTPUT inserted.IdEntrega
	INTO @TableId
    VALUES
           (@IdEmpleado
           ,@FechaEntrega
           ,NULL
           ,GETDATE()
           ,@IdUsuario
		   ,@CantidadEntregas)

	SET @BonoEntregas = @CantidadEntregas * 5;
	SET @BonoHorasTrabajadas = 
	CASE WHEN @IdRol = 'F528D4CC-A2FE-ED11-A6FA-A029193DAC9C' THEN @HorasTrabajadasMes * 10 
		 WHEN @IdRol = 'F628D4CC-A2FE-ED11-A6FA-A029193DAC9C' THEN @HorasTrabajadasMes * 5 
		 WHEN @IdRol = 'F728D4CC-A2FE-ED11-A6FA-A029193DAC9C' THEN 0
		 END 

	SET @TotalBonos = @BonoEntregas + @BonoHorasTrabajadas;
		--print @TotalBonos + ''

	SET @Retencion = CASE WHEN @SueldoBase + @TotalBonos > 10000 THEN (@SueldoBase + @TotalBonos)*0.12 ELSE (@SueldoBase + @TotalBonos)*0.09 END;
	--print @Retencion + ''
	
	SET @SueldoConRetencion = @SueldoBase + @TotalBonos - @Retencion;
	--print @SueldoConRetencion + ''

	SET @Vales = @SueldoConRetencion * 0.04;
	SET @SueldoTotal = @SueldoConRetencion + @Vales;

	INSERT INTO [dbo].[BitacoraSueldo]
           ([IdEmpleado]
           ,[Vales]
           ,[FechaCreacion]
           ,[IdUsuarioCreacion]
           ,[HorasTrabajadas]
           ,[PagoTotalBonos]
           ,[Retencion]
           ,[SueldoTotal]
		   ,[IdEntregaEmpleado])
     VALUES
           (@IdEmpleado
           ,@Vales
           ,GETDATE()
           ,@IdUsuario
		   ,@HorasTrabajadasMes
           ,@TotalBonos
           ,@Retencion
           ,@SueldoTotal
		   ,(SELECT TOP 1 id FROM @TableId))
END
GO
/****** Object:  StoredProcedure [dbo].[GetEntregasEmpleados]    Script Date: 15/08/2023 07:19:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Thelma Rojas
-- Create date: 30/05/2023
-- Description:	Proceso para consultar los movimientos/entregas de los empleados
-- =============================================
CREATE PROCEDURE [dbo].[GetEntregasEmpleados]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	SET LANGUAGE SPANISH;

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT EE.IdEntrega, E.NumeroEmpleado, CONCAT(E.Nombre, ' ', E.ApellidoPaterno, ' ', E.ApellidoMaterno) AS Nombre
	, R.Descripcion AS Rol, DATENAME(MONTH, DATEADD(MONTH, MONTH(EE.FechaEntrega), - 0 ) - 1) as Mes, EE.CantidadEntregas, BS.HorasTrabajadas
	, BS.PagoTotalBonos, BS.Retencion AS Retenciones, BS.Vales, BS.SueldoTotal
	FROM EntregasPorEmpleado EE
	INNER JOIN Empleado E ON EE.IdEmpleado = E.IdEmpleado
	INNER JOIN RolEmpleado R ON E.IdRol = R.IdRol
	INNER JOIN BitacoraSueldo BS ON EE.IdEntrega = BS.IdEntregaEmpleado

	--SELECT * FROM @TblTempEntregasEmpleados
END
GO
