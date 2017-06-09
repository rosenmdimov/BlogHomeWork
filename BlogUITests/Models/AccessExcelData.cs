using BlogBuild.Tests.Models;
using Dapper;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;


namespace BlogBuild.Tests.Models
{
    public class AccessExcelData
    {
        public static string TestDataFileConnection()
        {

            //var path = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var path = DataDrivenFile =>Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..//..//DataDrivenTests/");
            var filename = "UserData.xlsx";
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties=Excel 12.0;", path + "..//..//DataDrivenTests/" + filename);
            return con;
        }

        public static User GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key = '{0}'", keyName);
                var value = connection.Query<User>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}

