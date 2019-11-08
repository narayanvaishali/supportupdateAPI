using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using supportupdateAPI.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using supportupdateAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace supportupdateAPI.DataProvider
{
    public class EmployeeLoginDataProvider : IEmployeeLoginProvider
    {
        Config config = new Config();
        //string connStr = Config.ConnectionString;

         private readonly string connectionString;

        public EmployeeLoginDataProvider()
        {
            this.connectionString = Config.ConnectionString;
        }

        public IEnumerable<EmployeeLoginType> GetEmployeeLoginDetails([FromUri]string email, [FromUri]string pwd)
        {
            IEnumerable<EmployeeLoginType> employee = null;

            using (var connection = new SqlConnection(connectionString))
            {
                employee = connection.Query<EmployeeLoginType>(@"GetEmployeeLogin", new
                {
                        EmployeeID = 0,
                        EmployeeName = "",
                        Password = pwd,
                        Email = email
                }, commandType: CommandType.StoredProcedure);
            }
            return employee;
        }


        public dynamic AddEditEmployeeLogin(EmployeeLoginType emploeeloginDetails)
        {
            string employee = "";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@"EmployeeLoginDetails", new
                    {
                        EmployeeID = (int)emploeeloginDetails.ID,
                        EmployeeName = (string)emploeeloginDetails.EmployeeName,
                        Password = (string)emploeeloginDetails.Password,
                        Email = (string)emploeeloginDetails.Email
                    }, commandType: CommandType.StoredProcedure); 
                }

                employee = "Success";
                return employee;
            }

            catch (Exception ex)
            {
                employee = "Internal server error";
                return employee;
            }         
        }

     
    }

}
