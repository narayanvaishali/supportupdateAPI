﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using supportupdateAPI.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Dynamic;
using supportupdateAPI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace supportupdateAPI.DataProvider
{
    public class SupportUpdateDataProvider : ISupportUpdateProvider
    {
        Config config = new Config();
        //string connStr = Config.ConnectionString;

        private readonly string connectionString;

        public SupportUpdateDataProvider()
        {
            this.connectionString = Config.ConnectionString;
        }

        public dynamic GetSupportUpdateSummary(int staffid, string dateworked)
        {
            dynamic oResult = new ExpandoObject();
            using (var connection = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@StaffID", staffid);
                parameters.Add("@DateWorked", dateworked == "null" ? null :  dateworked);
                var data = connection.QueryMultiple(@"GetSupportUpdateSummary", parameters, commandType: CommandType.StoredProcedure);

                oResult.supportupdatesummary = data.Read<dynamic>().ToArray();
            }
            return oResult;
        }

        //  public IEnumerable<SupportUpdateType> GetSupportUpdateDetails(int supportupdateid)
        public dynamic GetSupportUpdateDetails(int supportupdateid)
        {
            //IEnumerable<SupportUpdateType> support = null;
            dynamic oResult = new ExpandoObject();
            using (var connection = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SupportUpdateID", supportupdateid);
                var data = connection.QueryMultiple(@"GetSupportUpdateDetails", parameters, commandType: CommandType.StoredProcedure);

                oResult.supportupdate = data.Read<dynamic>().ToArray();
                oResult.supportstatus = data.Read<dynamic>().ToArray();
                oResult.supportpriority = data.Read<dynamic>().ToArray();
                oResult.supportstaff = data.Read<dynamic>().ToArray();
                oResult.supportclients = data.Read<dynamic>().ToArray();
            }
            return oResult;
        }


        public dynamic AddEditSupportUpdate(SupportUpdateType supportDetails)
        {
            string Status = "";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@"SupportUpdateDetails", new
                    {
                        SupportUpdateID = (int)supportDetails.SupportUpdateID,
                        //supportDetails.SupportUpdateID == null ? null : (int)supportDetails.SupportUpdateID,
                        ZD_ID = (int)supportDetails.ZD_ID,
                        ZD_Descr = (string)supportDetails.ZD_Descr,
                        PriorityID = (int)supportDetails.PriorityID,
                        CurrentStatusID = (int)supportDetails.CurrentStatusID,
                        TimeSpent = (int)supportDetails.TimeSpent,
                        DateWorked = (DateTime?)supportDetails.DateWorked, /*.ToString("yyyy-MM-dd"),*/
                        ClientID = (int)supportDetails.ClientID,
                        StaffID = (int)supportDetails.StaffID
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

        public dynamic DeleteSupportUpdate(int supportupdateID)
        {
            string Status = "";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@"Deletesupportupdate", new
                    {
                        SupportUpdateID = supportupdateID
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


        public dynamic SendSummaryEmail(SupportSummaryType summary)
        {
            string Status = "";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(@"SendSummaryEmail", new
                    {
                        DateWorked = summary.DateWorked == ""? null : (string)summary.DateWorked, /*.ToString("yyyy-MM-dd"),*/
                        StaffID = (int)summary.StaffID
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
    }

}
