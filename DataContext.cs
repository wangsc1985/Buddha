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
        private SQLiteConnection dbConnection;


        //创建一个连接到指定数据库
        public void Connect()
        {
            if (!File.Exists(database))
            {
                SQLiteConnection.CreateFile(database);
            }
            dbConnection = new SQLiteConnection($"Data Source={database};Version=3;");
            dbConnection.Open();

            CreateTable();
        }

        public void DisConnect()
        {
            dbConnection.Close();
        }

        #region 住户操作
        public void CreateTable()
        {
            string sql = "create table if not exists Record (startDateTime LONG, duration LONG,count INT ,summury CHAR, type INT,dateStr CHAR)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void AddRecord(Record model)
        {
            string sql = $"insert into Record (startDateTime, duration,count, summury,type,dateStr) " +
                $"values ('{Utils.ConvertDateTimeToLong(model.startDateTime)}','{model.duration}','{model.count}','{model.summury}','{model.type}','{model.dateStr}')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void AddRecords(List<Record> models)
        {
            foreach (var model in models)
            {
                string sql = $"insert into Record (startDateTime, duration,count, summury,type,dateStr) " +
                    $"values ('{Utils.ConvertDateTimeToLong(model.startDateTime)}','{model.duration}','{model.count}','{model.summury}','{model.type}','{model.dateStr}')";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();
            }
        }

        public void EditRecord(Record model)
        {
            string sql = $"update Record set " +
                $"duration= '{model.duration}'," +
                $"count = '{model.count}'," +
                $"summury = '{model.summury}'," +
                $"type = '{model.type}'," +
                $"dateStr = '{model.dateStr}' " +
                $"where startDateTime='{Utils.ConvertDateTimeToLong(model.startDateTime)}'";
            
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public List<Record> GetRecords(DateTime date)
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

        public List<Record> GetAllRecords()
        {
            List<Record> result = new List<Record>();
            string sql = $"select * from Record";
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
