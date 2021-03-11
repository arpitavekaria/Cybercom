using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseConfig
/// </summary>
public static class DatabaseConfig
{
    public static string ConnectionString = ConfigurationManager.ConnectionStrings["VehicleService"].ConnectionString;
}