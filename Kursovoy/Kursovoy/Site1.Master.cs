using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Kursovoy
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Registration();
        }
        protected void Registration()
        {
            string st = (string)Session["status"];
            switch (st)
            {
                case "1":
                    cabinet_LB.Visible = true;
                    cabinet_LB2.Visible = false;
                    status_label.Text = "СТАТУС: зарегистрирован";
                    Button1.Visible = false;
                    Button2.Visible = false;
                    Button3.Visible = true;
                    break;
                case "2":
                   cabinet_LB.Visible = false;
                    cabinet_LB2.Visible = true;
                    status_label.Text = "СТАТУС: админ";
                    Button1.Visible = false;
                    Button2.Visible = false;
                    Button3.Visible = true;
                    break;
                case "":
                    cabinet_LB.Visible = false;
                    cabinet_LB2.Visible = false;
                    status_label.Text = "СТАТУС: не зарегистрирован";
                    Button3.Visible = false;
                    break;
                case null:
                   cabinet_LB.Visible = false;
                    cabinet_LB2.Visible = false;
                    status_label.Text = "СТАТУС: не зарегистрирован";
                    Button3.Visible = false;
                    break;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("registration.aspx");
        }

        protected void cabinet_LB_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_cabinet.aspx");
        }
        protected void cabinet_LB2_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_cabinet.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("tours.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["fly_to_dubaiConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "SELECT id_client, login, password, surname, name, status FROM Client WHERE (login = N'";
            sql = sql + loginTB.Text.Trim() + "') AND (password = N'";
            sql = sql + loginTB2.Text.Trim() + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader drWebUser = cmd.ExecuteReader();
            if (drWebUser.HasRows)
            {
                drWebUser.Read();
                Session["id_client"] = drWebUser["id_client"].ToString();
                Session["login"] = drWebUser["login"].ToString();
                Session["password"] = drWebUser["password"].ToString();
                Session["surname"] = drWebUser["surname"].ToString();
                Session["name"] = drWebUser["name"].ToString().Trim();
                Session["status"] = drWebUser["status"].ToString();
                status_label.Text = "";
                drWebUser.Close();
                con.Close();
                Registration();
            }
            else
            {
                drWebUser.Close();
                con.Close();
                status_label.Text = "Неверный логин или пароль";
            }
        }

    }
}