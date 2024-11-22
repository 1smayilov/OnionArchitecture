using Core.CrossCuttingConcerns.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Serilog.Loggers;

public class MsSqlLogger:LoggerServiceBase
{
    
    public MsSqlLogger(IConfiguration configuration)
    {
        MsSqlConfiguration logConfiguration =
            configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        MSSqlServerSinkOptions sinkOptions = new()
        {
            TableName = logConfiguration.TableName,
            AutoCreateSqlDatabase = logConfiguration.AutoCreateSqlTable, 
        };

        ColumnOptions columnOptions = new();

        global::Serilog.Core.Logger serilogConfig = new LoggerConfiguration().WriteTo
            .MSSqlServer(logConfiguration.ConnectionString,sinkOptions,columnOptions:columnOptions).CreateLogger();

        Logger = serilogConfig;

    }
}

// Sink problemi üçün (Logs table - ı yaranmır)

//CREATE TABLE[Logs] (
//[Id] int IDENTITY(1,1) NOT NULL,
//[Message] nvarchar(max) NULL,
//   [MessageTemplate] nvarchar(max) NULL,
//   [Level] nvarchar(max) NULL,
//   [TimeStamp]
//datetime NULL,
//   [Exception] nvarchar(max) NULL,
//   [Properties] nvarchar(max) NULL
//   CONSTRAINT[PK_Logs] PRIMARY KEY CLUSTERED([Id] ASC)
//); 
