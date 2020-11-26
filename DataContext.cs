using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddha
{
    class DataContext
    {
        private static string database = "data.db";
        //数据库连接
        private static SQLiteConnection dbConnection;


        //创建一个连接到指定数据库
        public static void Connect()
        {
            if (!File.Exists(database))
            {
                SQLiteConnection.CreateFile(database);
            }
            dbConnection = new SQLiteConnection($"Data Source={database};Version=3;");
            dbConnection.Open();

            CreateTable();
        }

        public static void DisConnect()
        {
            dbConnection.Close();
        }

        #region 住户操作
        public static void CreateTable()
        {
            string sql = "create table if not exists Record (startDateTime LONG, duration LONG,count INT ,summury TEXT, type INT)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public static void AddRecord(Record model)
        {
            string sql = $"insert into Record (startDateTime, duration,count, summury,type) " +
                $"values ('{Utils.ConvertDateTimeToLong(model.startDateTime)}','{model.duration}','{model.count}','{model.summury}','{model.type}')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public static void AddRecords(List<Record> models)
        {
            foreach (var model in models)
            {
                string sql = $"insert into Record (startDateTime, duration,count, summury,type) " +
                    $"values ('{Utils.ConvertDateTimeToLong(model.startDateTime)}','{model.duration}','{model.count}','{model.summury}','{model.type}')";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();
            }
        }

        public static List<Record> GetRecords(DateTime date)
        {
            DateTime start = date;
            var end = start.AddDays(1);
            List<Record> result = new List<Record>();
            string sql = $"select * from Record where startDateTime > {Utils.ConvertDateTimeToLong(start)} AND startDateTime < {Utils.ConvertDateTimeToLong(end)}";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                result.Add(new Record(Utils.ConvertLongToDateTime(long.Parse(reader["startDateTime"].ToString())), long.Parse(reader["duration"].ToString()),
                    int.Parse(reader["count"].ToString()), reader["summury"].ToString(), int.Parse(reader["type"].ToString())));
            return result;
        }
        #endregion

    }
}
