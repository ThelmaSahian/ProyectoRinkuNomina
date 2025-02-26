USE [DispositivosIoT]

/*
* Query para obtener el promedio de valor por dispositivo.
*/
SELECT D.Nombre, AVG(Valor) AS Promedio
FROM Eventos E JOIN Dispositivos D 
ON E.IdDispositivo = D.DispositivoID
GROUP BY D.DispositivoID, D.Nombre; 