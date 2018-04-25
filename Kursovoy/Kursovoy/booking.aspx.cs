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
    public partial class booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["fly_to_dubaiConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "SELECT Hotel.name_hotel, Hotel.stars, Hotel.image1, District.name_district, Tour.people, Feeding.feeding_type, Tour.departure, Tour.arrival, Airport.name_airport, Tour.info, ";
            sql = sql + "Tour.cost, Tour.how_much_left FROM Tour INNER JOIN Hotel ON Tour.hotel=Hotel.id_hotel ";
            sql = sql + "INNER JOIN Feeding on Tour.Feeding = Feeding.id_feeding INNER JOIN Airport ON Tour.airport=id_airport INNER JOIN District ON Hotel.district=District.id_district ";
            sql = sql + "WHERE (Tour.id_tour = '" + Session["id_tour"] + "' )";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader drTour = cmd.ExecuteReader();
            DetailsView1.DataSource = drTour;             //А вот и привязка
            DetailsView1.DataBind();
            con.Close();
        }
    }
}