using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Debugging;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;


public class Logging
{
    public static LoggerConfiguration GetElasticSearchConfig(string elasticSearchUri, string indexFormat = "")
    {
        if (indexFormat == "") {
            indexFormat = $"AutomationLog-{DateTime.UtcNow:yyyy-MM}";
        }
        var config = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(new ElasticsearchJsonFormatter())
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticSearchUri))
            {
                AutoRegisterTemplate = true,
                IndexFormat = indexFormat
            });

        return config;
    }

}

