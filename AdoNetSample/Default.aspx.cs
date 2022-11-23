using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoNetSample
{
    public partial class Default : System.Web.UI.Page
    {
        AdoNETSampleBL.AdoNETSampleBL sampleBL = new AdoNETSampleBL.AdoNETSampleBL();
        protected void Page_Load(object sender, EventArgs e)
        {

            var x = sampleBL.SelectSampleCategory(null, null);
            GridView1.DataSource = x.SampleCategory;
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtCatName.Text = "";
            txtID.Text = GridView1.SelectedRow.Cells[1].Text.ToString();
            txtCatName.Text = GridView1.SelectedRow.Cells[2].Text.ToString();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            sampleBL.InsertSampleCategory(Convert.ToInt32(txtID.Text), txtCatName.Text);
            GridView1.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            sampleBL.UpdateSampleCategory(Convert.ToInt32(txtID.Text), txtCatName.Text);
            GridView1.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            sampleBL.DeleteSampleCategory(Convert.ToInt32(txtID.Text));
            GridView1.DataBind();
        }
    }
}