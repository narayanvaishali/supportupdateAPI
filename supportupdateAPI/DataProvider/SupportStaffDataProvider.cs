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

namespace supportupdateAPI.DataProvider
{
    public class SupportStaffDataProvider : ISupportStaffProvider
    {
        Config config = new Config();
        //string connStr = Config.ConnectionString;

         private readonly string connectionString;

        public SupportStaffDataProvider()
        {
            this.connectionString = Config.ConnectionString;
        }

        public IEnumerable<SupportStaffType> GetSupportStaffDetails(int staffid)
        {
            IEnumerable<SupportStaffType> staff = null;

            using (var connection = new SqlConnection(connectionString))
            {
                staff = connection.Query<SupportStaffType>(@"GetSupportStaffDetails", new
                {
                    StaffID = staffid
                }, commandType: CommandType.StoredProcedure);;
            }
            return staff;
        }


        public dynamic AddEditStaff(SupportStaffType staffDetails)
        {
            string staff = "";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@"SupportStaffDetails", new
                    {
                        StaffID = (int)staffDetails.StaffID,
                        StaffName = (string)staffDetails.StaffName,
                        StaffEmail = (string)staffDetails.StaffEmail
                    }, commandType: CommandType.StoredProcedure); 
                }

                staff = "Success";
                return staff;
            }

            catch (Exception ex)
            {
                staff = "Internal server error";
                return staff;
            }         
        }

        public dynamic DeleteStaff(int staffid)
        {
            string staff = "";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@"Deletesupportstaff", new
                    {
                        StaffID = staffid
                    }, commandType: CommandType.StoredProcedure);
                }

                staff = "Delete";
                return staff;
            }
            catch (Exception ex)
            {
                staff = "Internal server error";
                return staff;
            }
        }

    }

}
