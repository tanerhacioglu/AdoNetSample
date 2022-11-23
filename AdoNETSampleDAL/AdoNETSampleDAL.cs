using AdoNETSampleDAL.DataSet;
using Npgsql;
using NpgsqlTypes;
using PgSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdoNETSampleDAL
{
    public class AdoNETSampleDAL
    {
        private string GetConnectionString()
        {
            return "User ID=postgrem;Password=mybunsar;Host=10.100.0.185;Port=5432;Database=erp;";
        }

        #region SampleCategory
        public Int64 InsertSampleCategory(Nullable<Int64> ID, String Name)
        {
            NpgsqlConnection cn = new NpgsqlConnection(GetConnectionString());

            NpgsqlCommand cmd = new NpgsqlCommand("\"ERP\".\"SampleCategory_Insert\"(:ID,:Name)", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("ID", NpgsqlDbType.Bigint);
            if (ID != null) cmd.Parameters["ID"].Value = ID;
            cmd.Parameters.Add("Name", NpgsqlDbType.Varchar);
            cmd.Parameters["Name"].Value = Name;


            System.Data.ConnectionState PreviousState = cn.State;
            if (PreviousState != System.Data.ConnectionState.Open) cn.Open();
            String ErrMsg = "";
            Int64 ReturnValue = 0;
            try
            {
                ReturnValue = (Int64)cmd.ExecuteScalar(); //Ayrıca Postgres fonksiyonda returning konusu ve incelenebilir. Affected rowcount incelenebilir. GET DIAGNOSTICS a_count = ROW_COUNT;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            finally
            {
                if (PreviousState != System.Data.ConnectionState.Open) cn.Close();
                cmd.Dispose();
                if (ErrMsg.Trim().Length > 0) { throw new Exception(ErrMsg); }
            }
            return ReturnValue;
        }

        public Int64 InsertSampleCategory(String Name)
        {
            long retVal = 0;
            NpgsqlConnection cn = new NpgsqlConnection(GetConnectionString());

            NpgsqlCommand cmd = new NpgsqlCommand("\"ERP\".\"SampleCategory\" Values (:Name)", cn);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("Name", NpgsqlDbType.Varchar);
            cmd.Parameters["Name"].Value = Name;


            System.Data.ConnectionState PreviousState = cn.State;
            if (PreviousState != System.Data.ConnectionState.Open) cn.Open();
            String ErrMsg = "";
            try
            {
                cmd.ExecuteNonQuery(); //Fonksiyon olmadığı için bize id dönmez. 
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            finally
            {
                if (PreviousState != System.Data.ConnectionState.Open) cn.Close();
                cmd.Dispose();
                if (ErrMsg.Trim().Length > 0) { throw new Exception(ErrMsg); }
            }
            if (string.IsNullOrEmpty(ErrMsg))
            {
                retVal = 1;
            }
            return retVal;
        }

        public void SelectSampleCategory(dsSampleCategory ds, PgSqlFilter Filter, PgSqlOrder Order)
        {
            NpgsqlConnection cn = new NpgsqlConnection(GetConnectionString());

            if (ds == null) ds = new dsSampleCategory();
            NpgsqlCommand cmd = new NpgsqlCommand("Select * From \"ERP\".\"SampleCategory\"", cn);

            if (Filter != null) cmd.CommandText += " Where " + Filter.ToString();
            if (Order != null) cmd.CommandText += " Order By " + Order.ToString();
            System.Data.ConnectionState PreviousState = cn.State;
            if (PreviousState != System.Data.ConnectionState.Open) cn.Open();
            cmd.CommandTimeout = 36000; //10 saat
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            String ErrMsg = "";
            try
            {
                ds.EnforceConstraints = false;
                da.Fill(ds.SampleCategory);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            finally
            {
                if (PreviousState != System.Data.ConnectionState.Open) cn.Close();
                da.Dispose();
                if (ErrMsg.Trim().Length > 0) { throw new Exception(ErrMsg); }
            }
        }

        public dsSampleCategory SelectSampleCategory(PgSqlFilter Filter, PgSqlOrder Order)
        {
            dsSampleCategory ds = new dsSampleCategory();
            SelectSampleCategory(ds, Filter, Order);
            return ds;
        }


        public void UpdateSampleCategory(Int64 ID, String Name)
        {
            NpgsqlConnection cn = new NpgsqlConnection(GetConnectionString());
            NpgsqlCommand cmd = new NpgsqlCommand("\"ERP\".\"SampleCategory_Update\"(:ID,:Name)", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.Add("ID", NpgsqlDbType.Bigint);
            cmd.Parameters["ID"].Value = ID;

            cmd.Parameters.Add("Name", NpgsqlDbType.Varchar);
            cmd.Parameters["Name"].Value = Name;


            System.Data.ConnectionState PreviousState = cn.State;
            if (PreviousState != System.Data.ConnectionState.Open) cn.Open();
            String ErrMsq = "";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrMsq = ex.Message;
            }
            finally
            {
                if (PreviousState != System.Data.ConnectionState.Open) cn.Close();
                cmd.Dispose();
                if (ErrMsq.Trim().Length > 0) { throw new Exception(ErrMsq); };
            }
        }


        public void DeleteSampleCategory(Int64 ID)
        {
            NpgsqlConnection cn = new NpgsqlConnection(GetConnectionString());
            NpgsqlCommand cmd = new NpgsqlCommand("\"ERP\".\"SampleCategory_Delete\"(:ID)", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("ID", NpgsqlDbType.Bigint);
            cmd.Parameters["ID"].Value = ID;
            System.Data.ConnectionState PreviousState = cn.State;
            if (PreviousState != System.Data.ConnectionState.Open) cn.Open();

            String ErrMsg = "";

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            finally
            {
                if (PreviousState != System.Data.ConnectionState.Open) cn.Close();
                cmd.Dispose();
                if (ErrMsg.Trim().Length > 0) { throw new Exception(ErrMsg); }
            }
        }
        #endregion

    }
}
