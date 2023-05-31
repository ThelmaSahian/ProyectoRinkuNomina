using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace RinkuNomina.Infrastructure.Interceptors
{
    public class RinkuInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            var consulta = command.CommandText;
            return result;
        }
    }
}
