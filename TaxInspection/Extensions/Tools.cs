
namespace TaxInspection.Extensions
{
    using System;
    using System.Text.RegularExpressions;
    using Finisar.SQLite;

    public static class Tools
    {
        public static void ExecuteQuery(string query)
        {
            try
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                sqlite_conn = new SQLiteConnection(SQLDataLoader.DatabaseConnection);
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = query;
                sqlite_cmd.ExecuteNonQuery();

                sqlite_conn.Close();
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString());
            }
        }

        public static string ConvertDayTimeToSqlDate(DateTime date)
        {
            string month = date.Month < 10 ? '0' + date.Month.ToString() : date.Month.ToString();
            string day = date.Day < 10 ? '0' + date.Day.ToString() : date.Day.ToString();
            string rez = date.Year + "-" + month + "-" + day;

            return rez;
        }

        public static string ConvertDayTimeToSqlDate(DateTime? date)
        {
            string month = date.Value.Month < 10 ? '0' + date.Value.Month.ToString() : date.Value.Month.ToString();
            string day = date.Value.Day < 10 ? '0' + date.Value.Day.ToString() : date.Value.Day.ToString();
            string rez = date.Value.Year + "-" + month + "-" + day;

            return rez;
        }
        
        public static DateTime GetDateTimeFromSql(string date)
        {
            string[] dateArray = date.Split('.');
            DateTime dateTime = new DateTime(int.Parse(dateArray[2].Split(' ')[0]), int.Parse(dateArray[1]), int.Parse(dateArray[0]));

            return dateTime;
        }

        public static readonly Regex OnlyNumbersRegex = new Regex("[^0-9]+");
        public static bool TextContainsOnlyNumbers(string text)
        {
            return OnlyNumbersRegex.IsMatch(text);
        }
    }
}
