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
    public class StatusDataProvider : ISupportStatusProvider
    {
        Config config = new Config();
        //string connStr = Config.ConnectionString;

         private readonly string connectionString;

        public StatusDataProvider()
        {
            this.connectionString = Config.ConnectionString;
        }

        public IEnumerable<SupportStausType> GetSupportStatusDetails(int statusid)
        {
            IEnumerable<SupportStausType> status = null;

            using (var connection = new SqlConnection(connectionString))
            {
                status = connection.Query<SupportStausType>(@"GetSupportStatusDetails", new
                {
                    StatusID = statusid
                }, commandType: CommandType.StoredProcedure);;
            }
            return status;
        }


        public dynamic AddEditStatus(SupportStausType statusDetails)
        {
            string Status = "";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@"SupportStatusDetails", new
                    {
                        StatusID = (int)statusDetails.StatusID,
                        StatusDescr = (string)statusDetails.StatusDescr
                    }, commandType: CommandType.StoredProcedure); 
                }

                Status = "Success";
                return Status;
            }

            catch (Exception ex)
            {
                 Status = "Internal server error";
                return Status;
            }         
        }

        public dynamic DeleteStatus(int statusid)
        {
            string Status = "";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@"Deletesupportstatus", new
                    {
                        StatusID = statusid
                    }, commandType: CommandType.StoredProcedure);
                }

                Status = "Delete";
                return Status;
            }
            catch (Exception ex)
            {
                Status = "Internal server error";
                return Status;
            }
        }


        /* public dynamic GetSupportUpdateDetails()
         {

             using (var _conn = new SqlConnection(connStr))
             {
                 return _conn.Query(@"GetSupportUpdateDetails", new
                 {
                     SupportUpdateID = (int?)null
                   }, commandType: CommandType.StoredProcedure);
             }
         }

         public dynamic GetSupportUpdate(int ZD_ID)
         {

             using (var _conn = new SqlConnection(connStr))
             {
                 return _conn.Query(@"GetSupportUpdateDetails", new
                 {
                     SupportUpdateID = (int?)null
                 }, commandType: CommandType.StoredProcedure);
             }
         }

         public dynamic AddSupportUpdate (SupportUpdateType support)
         {
              using (var _conn = new SqlConnection(connStr))
             {
                 return _conn.Query(@"GetSupportUpdateDetails", new
                 {
                     SupportUpdateID = (int?)null
                    }, commandType: CommandType.StoredProcedure);
             }
         }

         public dynamic UpdateSupportUpdate(SupportUpdateType support)
         {
             using (var _conn = new SqlConnection(connStr))
             {
                 return _conn.Query(@"GetSupportUpdateDetails", new
                 {
                     SupportUpdateID = (int?)null
                 }, commandType: CommandType.StoredProcedure);
             }
         }

         public dynamic DeleteSupportUpdate(int ZD_ID)
         {
             using (var _conn = new SqlConnection(connStr))
             {
                 return _conn.Query(@"GetSupportUpdateDetails", new
                 {
                     SupportUpdateID = (int?)null
                 }, commandType: CommandType.StoredProcedure);
             }
         }
         */
    }

}
