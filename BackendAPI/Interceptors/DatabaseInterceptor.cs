using System;
using BackendAPI.Middleware;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace BackendAPI.Interceptors
{
    public class DatabaseInterceptor : DbCommandInterceptor
    {
        private readonly ILogService _logger;

        public DatabaseInterceptor(ILogService logger)
        {
            _logger = logger;
        }

        public DatabaseInterceptor()
        {
            _logger = new LogService();
        }
        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            _logger.LogDatabase(command.CommandText);
            if (result.HasResult) _logger.LogDatabase(result.Result.ToString());

            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command,CommandEventData eventData,InterceptionResult<DbDataReader> result,CancellationToken cancellationToken = default)
        {
            _logger.LogDatabase(command.CommandText);
            if (result.HasResult) _logger.LogDatabase(result.Result.ToString());

            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }
    }
}
