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
                Car car = new Car();
                car.IdCar = Convert.ToInt32(dt.Rows[0]["idCar"].ToString());
                car.Name = dt.Rows[0]["name"].ToString();
                //...

                listCars.Add(car);

            }
            return listCars;
        }

    }
}
