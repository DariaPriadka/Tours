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
    public partial class tours : System.Web.UI.Page
    {
        bool filter1 = false, filter2 = false, filter3 = false, filter4 = false, filter5 = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            show_tours();
        }
        void show_tours()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["fly_to_dubaiConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "SELECT Tour.id_tour, Hotel.name_hotel, Hotel.stars, District.name_district, Tour.People, Feeding.feeding_type, Tour.departure, Tour.arrival, Airport.name_airport, ";
            sql = sql + "Tour.cost, Tour.how_much_left FROM Tour INNER JOIN Hotel ON Tour.hotel=Hotel.id_hotel ";
            sql = sql + "INNER JOIN Feeding on Tour.Feeding = Feeding.id_feeding INNER JOIN Airport ON Tour.airport=id_airport INNER JOIN District ON Hotel.district=District.id_district ";

            if (filter1 == true)
            {
                sql = sql + "WHERE (Hotel.district = '" + DropDownList1.SelectedValue.ToString() + "' )";

            }
            if (filter2 == true)
            {
                sql = sql + "WHERE (Hotel.stars = '" + DropDownList2.SelectedValue.ToString() + "' )";
            }
            if (filter3 == true)
            {
                sql = sql + "WHERE (Tour.Feeding = '" + DropDownList3.SelectedValue.ToString() + "' )";
            }
            if (filter4 == true)
            {
                sql = sql + "WHERE (Tour.airport = '" + DropDownList4.SelectedValue.ToString() + "' )";
            }
            if (filter5 == true)
            {
                sql = sql + "WHERE (Tour.cost BETWEEN '" + Convert.ToInt32(TextBox1.Text) + "' AND '" + Convert.ToInt32(TextBox2.Text) + "' )";
            }
            //sql = sql + "ORDER BY Tour.departure";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader drTour = cmd.ExecuteReader();
            GridView1.DataSource = drTour;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            filter1 = true;
            show_tours();
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            filter2 = true;
            show_tours();
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            filter3 = true;
            show_tours();
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            filter4 = true;
            show_tours();
        }

        protected void Button8_Click1(object sender, EventArgs e)
        {
            filter5 = true;
            show_tours();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filter1 = true;
            Session["id_tour"] = Convert.ToInt32(GridView1.SelectedRow.Cells[0]);
            //show_tours();
            Response.Redirect("booking.aspx");
        }

    }
}