using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSS.Logger;

namespace PTSS.Application.SMSCore.DataAccess
{
    class SMSCoreDataAccess
    {
        string sClassName = "PTSS.Application.SMSCore.DataAccess.SMSCoreDataAccess";
        //Declaration of the Variables.
        Logger.Logger oLog = new Logger.Logger();
        SecurityModel oSecurity = new SecurityModel();
        string sConnectionString;

        SqlConnection oCon = new SqlConnection();
        DataSet oDS = new DataSet();
        DataTable oDT = new DataTable();
        //On Creation of the Object, a SQL Connection will be established automatically.
        public SMSCoreDataAccess()
        {
            string sFunctionName = "SMSCoreDataAccess()";
            try
            {
                setSqlConnection();
            }
            catch (Exception ex)
            {
                //errHandler();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging

            }
        }
        //Creates SQL Connection to Database.
        public void setSqlConnection()
        {
            string sFunctionName = "setSqlConnection()";
            try
            {
                oCon.ConnectionString = getConnectionString();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    "Connection string set to DB connection.");
                #endregion Text Logging
            }
            catch (Exception ex)
            {
                //errHandler();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging

            }
        }
        //Gets Database connection details from the configuration file and creates connection string.
        public string getConnectionString()
        {
            string sFunctionName = "getConnectionString()";
            try
            {
                //this.sConnectionString = oSecurity.sDecrypt(ConfigurationManager.ConnectionStrings[DataAccessConstants.WebConstants.SMSCoreDBConName].ToString());
                this.sConnectionString = ConfigurationManager.ConnectionStrings[DataAccessConstants.WebConstants.SMSCoreDBConName].ToString();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    "Connection string successfully fetched.");
                #endregion Text Logging
            }
            catch (Exception ex)
            {
                //errHandler();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging

            }
            return this.sConnectionString;
        }
        //Returns a DataView for the query.
        public DataView getDataView(string query)
        {
            string sFunctionName = "getDataView()";
            DataView oDV = new DataView();
            try
            {
                //setSqlConnection();
                oDS = new DataSet();
                oDT = new DataTable();
                SqlDataAdapter oDA = new SqlDataAdapter(query, oCon);
                oDA.Fill(oDS);
                oDT = oDS.Tables[0];
                oDV.Table = oDT;
                //return oDV;
            }
            catch (Exception ex)
            {
                //errHandler();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging

            }
            return oDV;
        }
        //Returns a DataView based on the Stored Procedure.
        public DataView getDataViewProc(string sProcName)
        {
            string sFunctionName = "getDataViewProc()";
            DataView oDV = new DataView();
            try
            {
                //setSqlConnection();
                SqlCommand oCMD = new SqlCommand();
                oDS = new DataSet();
                oDT = new DataTable();
                oCMD.CommandType = CommandType.StoredProcedure;
                oCMD.CommandText = sProcName;
                oCMD.Connection = oCon;
                SqlDataAdapter oDA = new SqlDataAdapter(oCMD);
                oDA.Fill(oDS);
                oDT = oDS.Tables[0];
                oDV.Table = oDT;
                //return oDV;
            }
            catch (Exception ex)
            {
                //errHandler();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging

            }
            return oDV;
        }
        //Returns a DataView based on the Stored Procedure with Parameters.
        public DataView getDataViewProc(string sProcName, SqlParameter[] paramArray)
        {
            string sFunctionName = "getDataViewProc(,)";
            DataView oDV = new DataView();
            try
            {
                //setSqlConnection();
                SqlCommand oCMD = new SqlCommand();
                oDS = new DataSet();
                oDT = new DataTable();
                oCMD.CommandType = CommandType.StoredProcedure;
                oCMD.Parameters.AddRange(paramArray);
                oCMD.CommandText = sProcName;
                oCMD.Connection = oCon;
                SqlDataAdapter oDA = new SqlDataAdapter(oCMD);
                oDA.Fill(oDS);
                oDT = oDS.Tables[0];
                oDV.Table = oDT;
                oCMD.Parameters.Clear();
                //return oDV;
            }
            catch (Exception ex)
            {
                //errHandler();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging

            }
            return oDV;
        }
        //Add or Updates record based on the query.
        public void InsertRecord(string query)
        {
            string sFunctionName = "InsertRecord()";
            try
            {
                SqlDataAdapter oDA = new SqlDataAdapter(query, oCon);
                oDA.Fill(oDS);
            }
            catch (Exception ex)
            {
                //errHandler();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging

            }
        }
        //Add or Updates record based on the Stored Procedure.
        public void InsertRecordProc(string sProcName)
        {
            string sFunctionName = "InsertrecordProc()";
            try
            {
                SqlCommand oCMD = new SqlCommand();
                oCMD.CommandType = CommandType.StoredProcedure;
                oCMD.CommandText = sProcName;
                oCMD.Connection = oCon;
                SqlDataAdapter oDA = new SqlDataAdapter(oCMD);
                oDA.Fill(oDS);
            }
            catch (Exception ex)
            {
                //errHandler();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging

            }
        }
        //Add or Updates record based on the Stored Procedure with Parameters.
        public void InsertRecordProc(string sProcName, SqlParameter[] paramArray)
        {
            string sFunctionName = "InsertRecordProc(,)";
            try
            {
                SqlCommand oCMD = new SqlCommand();
                oCMD.CommandType = CommandType.StoredProcedure;
                oCMD.Parameters.AddRange(paramArray);
                oCMD.CommandText = sProcName;
                oCMD.Connection = oCon;
                SqlDataAdapter oDA = new SqlDataAdapter(oCMD);
                oDA.Fill(oDS);
                oCMD.Parameters.Clear();
            }
            catch (Exception ex)
            {
                //errHandler();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging

            }
        }
        //Return DataTable based on the query.
        public DataTable getDataTable(string query)
        {
            string sFunctionName = "getDataTable()";
            try
            {
                SqlDataAdapter oDA = new SqlDataAdapter(query, oCon);
                oDA.Fill(oDS);
                oDT = oDS.Tables[0];
                //return oDT;
            }
            catch (Exception ex)
            {
                //errHandler();
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging

            }
            return oDT;
        }
    }
}
