using AdoNETSampleBL;
using AdoNETSampleDAL.DataSet;
using PgSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {

            AdoNETSampleBL.AdoNETSampleBL bL = new AdoNETSampleBL.AdoNETSampleBL();
            PgSqlFilter filter = null;
            PgSqlOrder order = null;

            dsSampleCategory ds = bL.SelectSampleCategory(filter, order);

            foreach (var row in ds.SampleCategory)
            {
                Console.WriteLine(row.ID.ToString() + " " + row.Name.ToString());

            }
            Console.ReadLine();

        }
    }
}
