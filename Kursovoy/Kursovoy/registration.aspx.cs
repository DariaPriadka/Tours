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
    public partial class registration : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /*protected void fReg()
        {
            string st = (string)Session["status"];
            switch (st)
            {
                case "1":
                    cabinet_LB.Visible = true;
                    cabinet_LB2.Visible = false;
                    status_label.Text = "СТАТУС: зарегистрирован";
                    break;
                case "2":
                   cabinet_LB.Visible = false;
                    cabinet_LB2.Visible = true;
                    status_label.Text = "СТАТУС: админ";
                    break;
                case "":
                    cabinet_LB.Visible = false;
                    cabinet_LB2.Visible = false;
                    status_label.Text = "СТАТУС: не арегистрирован";
                    break;
                case null:
                   cabinet_LB.Visible = false;
                    cabinet_LB2.Visible = false;
                    status_label.Text = "СТАТУС: не зарегистрирован";
                    break;
            }
        }
        */
        
        public void LoginDB(ref int login)
        {
            login = 0;
            string connectionString = WebConfigurationManager.ConnectionStrings["fly_to_dubaiConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "SELECT login FROM Client WHERE (login = N'" + login_TB.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader drWebUser = cmd.ExecuteReader();
            if (drWebUser.HasRows)
            {
                login = 1;
                iscorrect_label.Text = "Логин занят";
            }
            else
            {
                login = 0;
                iscorrect_label.Text = "Логин свободен";
            }
            drWebUser.Close();
        }
        protected void Button3_Click1(object sender, EventArgs e)
        {
            int login = 1;
            LoginDB(ref login);
            if (login == 1) { Response.Redirect("Registration.aspx"); }
            string connectionString = WebConfigurationManager.ConnectionStrings["fly_to_dubaiConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "INSERT INTO Client (name, surname, birthday, city, phone, email, login, password, status) ";
            sql = sql + "VALUES (@name,@surname,@birthday,@city,@phone,@email,@login,@password,@status)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            cmd.Parameters["@name"].Value = name_TB.Text.Trim();
            cmd.Parameters.Add("@surname", SqlDbType.NVarChar, 50);
            cmd.Parameters["@surname"].Value = surname_TB.Text.Trim();
            string sdt = (string)day_DD.SelectedItem.Value + "." + (string)month_DD.SelectedItem.Value + "." +
            (string)year_DD.SelectedItem.Value;
            DateTime dt = Convert.ToDateTime(sdt);
            cmd.Parameters.Add("@birthday", SqlDbType.DateTime);
            cmd.Parameters["@birthday"].Value = dt;
            cmd.Parameters.Add("@city", SqlDbType.NVarChar, 50);
            cmd.Parameters["@city"].Value = city_TB.Text.Trim();
            cmd.Parameters.Add("@phone", SqlDbType.Int);
            cmd.Parameters["@phone"].Value = phone_TB.Text.Trim();
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50);
            cmd.Parameters["@email"].Value = mail_TB.Text.Trim();
            cmd.Parameters.Add("@login", SqlDbType.NVarChar, 50);
            cmd.Parameters["@login"].Value = login_TB.Text.Trim();
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50);
            cmd.Parameters["@password"].Value = password_TB.Text.Trim();
            cmd.Parameters.Add("@status", SqlDbType.Int);
            cmd.Parameters["@status"].Value = 1.ToString();
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Session["login"] = login_TB.Text.Trim();
                Session["password"] = password_TB.Text.Trim();
                Session["surname"] = surname_TB.Text.Trim();
                Session["name"] = name_TB.Text.Trim();
                Session["status"] = 1.ToString();
            }
            finally
            {
                //SELECT id_student FROM Student
                //WHERE  (login = N'__') AND (password = N'__')
                sql = "";
                sql = "SELECT id_client FROM Client WHERE (login = N'";
                sql = sql + Session["login"].ToString() + "') AND (password = N'" + Session["password"].ToString() + "')";
                cmd = new SqlCommand(sql, con);
                SqlDataReader drWebUser = cmd.ExecuteReader();
                drWebUser.Read();
                Session["id_client"] = drWebUser["id_client"].ToString().Trim();
                drWebUser.Close();
                con.Close();
                Response.Redirect("main.aspx");
            }
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            int login = 1;
            LoginDB(ref login);
        }
    }
}