using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace registration
{
    public partial class registrationform : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-M07BDFTM;initial catalog=registration ;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
                showquli();
                showcountry();
                ddlstate.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        public void clear()
        {
            txtname.Text = "";
            rblbg.ClearSelection();
            ddlqli.SelectedValue = "0";
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
        }
        public void show()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from form join tblquli on qulification = qid join tblcountry on country = cid join tblstate on state=sid ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grid.DataSource = dt;
            grid.DataBind();

        }

        public void showquli()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblquli", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlqli.DataValueField = "qid";
            ddlqli.DataTextField = "qname";
            ddlqli.DataSource = dt;
            ddlqli.DataBind();
            ddlqli.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        public void showcountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblcountry", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.Enabled = false;
            ddlcountry.DataValueField = "cid";
            ddlcountry.DataTextField = "cname";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        public void showstate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblstate where cid='"+ddlcountry.SelectedValue+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "sid";
            ddlstate.DataTextField = "sname";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));

        }


        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert form values('" + txtname.Text + "','" + rblbg.SelectedValue + "','" + ddlqli.SelectedValue + "','"+ddlcountry.SelectedValue+"','"+ddlstate.SelectedValue+"')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                show();
            }
            else if(btnsave.Text=="Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update form set name='"+txtname.Text+"', bloodgroup='"+rblbg.SelectedValue+ "', qulification='"+ddlqli.SelectedValue+"', country='"+ddlcountry.SelectedValue+"',state='"+ddlstate.SelectedValue+"' where id='"+ViewState["kk"]+"'  ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                show();
                btnsave.Text = "Save";
            }
            clear();
        }

        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete form where id='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                show();
            }
            else if(e.CommandName=="B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from form where id='"+e.CommandArgument+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                rblbg.SelectedValue = dt.Rows[0]["bloodgroup"].ToString();
                ddlqli.SelectedValue = dt.Rows[0]["qulification"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["country"].ToString();
                showstate();
                ddlstate.SelectedValue = dt.Rows[0]["state"].ToString();
                btnsave.Text = "Update";
                ViewState["kk"] = e.CommandArgument;
            }
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlcountry.SelectedValue=="0")
            {
                ddlstate.Enabled = false;
            }
            else
            {

            showstate();
            ddlstate.Enabled = true;

            }
        }
    }
}