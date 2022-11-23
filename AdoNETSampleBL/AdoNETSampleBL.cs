using AdoNETSampleDAL.DataSet;
using PgSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdoNETSampleBL
{
    public class AdoNETSampleBL
    {
        AdoNETSampleDAL.AdoNETSampleDAL dAL = new AdoNETSampleDAL.AdoNETSampleDAL();
        public Int64 InsertSampleCategory(Nullable<Int64> ID, String Name)
        {
            long retVal = 0;
            //Buralarda BL ile ilgili kısıtlar konulabilir. Select atılıp kayıt varsa ekleme gibi
            retVal = dAL.InsertSampleCategory(ID, Name);

            //retval > 0 değilse birde override void metodu denemek gibi

            return retVal;
        }

        public dsSampleCategory SelectSampleCategory(PgSqlFilter filter, PgSqlOrder order)
        {
            dsSampleCategory result = new dsSampleCategory();
            result = dAL.SelectSampleCategory(filter, order);

            return result;

        }

        public void UpdateSampleCategory(Int64 ID, String Name)
        {
            try
            {
                dAL.UpdateSampleCategory(ID, Name);
            }
            catch (Exception ex)
            {

                string err = ex.Message;
            }

        }

        public void DeleteSampleCategory(Int64 ID)
        {
            try
            {
                dAL.DeleteSampleCategory(ID);
            }
            catch (Exception ex)
            {

                string err = ex.Message;
            }

        }

    }
}
