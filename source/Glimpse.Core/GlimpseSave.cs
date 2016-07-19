// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlimpseSave.cs" company="Alliance Global Services">
//   Copyright 2016
// </copyright>
// <summary>
//   The GlimpseSave.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Glimpse.Core
{
    using System.Configuration;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Class  GlimpseSave
    /// </summary>
    public class GlimpseSave
    {
        static MySqlConnection connection;
        static MySqlCommand cmd;
        static GlimpseSave()
        {
            string con = ConfigurationManager.ConnectionStrings["GlimpseConnection"].ToString();
            connection = new MySqlConnection(con);
            cmd = new MySqlCommand();
            cmd.Connection = connection;
        }
        public static int SaveGlimpseData(string type, string query, string parameters, int count, int durationInSeconds, string asyncValue, string errors)
        {
            connection.Open();
            cmd.CommandText = "INSERT INTO transactions (Type,Query, CountOfRecords, Duration, Async, Parameters) VALUES (@Type,@Query, @CountOfRecords, @Duration, @Async, @Parameters)";
            cmd.Parameters.AddWithValue("@Type", type);
            cmd.Parameters.AddWithValue("@Query", query);
            cmd.Parameters.AddWithValue("@Parameters", parameters);
            cmd.Parameters.AddWithValue("@CountOfRecords", count);
            cmd.Parameters.AddWithValue("@Duration", durationInSeconds);
            cmd.Parameters.AddWithValue("@Async", asyncValue);
            cmd.Parameters.AddWithValue("@Errors", errors);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
}