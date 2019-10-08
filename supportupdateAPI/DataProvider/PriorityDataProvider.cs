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
    public class PriorityDataProvider : ISupportPriorityProvider
    {
        Config config = new Config();
        //string connStr = Config.ConnectionString;

         private readonly string connectionString;

        public PriorityDataProvider()
        {
            this.connectionString = Config.ConnectionString;
        }

        public IEnumerable<SupportPriorityType> GetSupportPriorityDetails(int priorityid)
        {
            IEnumerable<SupportPriorityType> priority = null;

            using (var connection = new SqlConnection(connectionString))
            {
                priority = connection.Query<SupportPriorityType>(@"GetSupportPriorityDetails", new
                {
                    PriorityID = priorityid
                }, commandType: CommandType.StoredProcedure);;
            }
            return priority;
        }


        public dynamic AddEditPriority(SupportPriorityType priorityDetails)
        {
            string Status = "";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@"SupportPriorityDetails", new
                    {
                        PriorityID = (int)priorityDetails.PriorityID,
                        Priority = (string)priorityDetails.Priority
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

        public dynamic DeletePriority(int priorityid)
        {
            string Status = "";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@"Deletesupportpriority", new
                    {
                        PriorityID = priorityid
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

    }

}
