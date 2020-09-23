using HotwheelsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotwheelsAPI.Azure
{
    public class CarAzure
    {
        static readonly string ConnectionString = @"Server=DESKTOP-S6JN4IA\SQLEXPRESS;Database=Hotwheels;Trusted_Connection=True;";

        public static List<Car> listCars;

        //Get All Hotwheels
        public static List<Car> getAllCars()
        {
            var dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "select * from Car";

                //abrir la conexion
                connection.Open();
                //ejecutar query
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dt);

                listCars = new List<Car>();
               

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Car car = new Car();
                    car.IdCar = Convert.ToInt32(dt.Rows[i]["idCar"].ToString());
                    car.Year = int.Parse(dt.Rows[i]["year"].ToString());
                    car.Serie = dt.Rows[i]["serie"].ToString();
                    car.Name = dt.Rows[i]["name"].ToString();
                    car.Model = dt.Rows[i]["model"].ToString();
                    car.Colour = dt.Rows[i]["colour"].ToString();
                    listCars.Add(car);
                }
            }
            return listCars;
        }
    
        //Get One HotWheel
        public static List<Car> getHotwheel(int id)
        {
            var dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = $"select * from Car where idCar = {id}";

                //abrir la conexion
                connection.Open();
                //ejecutar query
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dt);

                listCars = new List<Car>();

                if(dt != null && dt.Rows.Count > 0)
                {
                    Car car = new Car();
                    car.IdCar = Convert.ToInt32(dt.Rows[0]["idCar"].ToString());
                    car.Year = int.Parse(dt.Rows[0]["year"].ToString());
                    car.Serie = dt.Rows[0]["serie"].ToString();
                    car.Name = dt.Rows[0]["name"].ToString();
                    car.Model = dt.Rows[0]["model"].ToString();
                    car.Colour = dt.Rows[0]["colour"].ToString();
                    listCars.Add(car);
                }
               


                return listCars;
            }
        }

    }
}
