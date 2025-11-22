using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FarmApi.Services
{
    public class FarmService
    {
        private readonly string _connectionString;

        public FarmService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }

        // -----------------------
        // GET FARM ANIMALS
        // -----------------------
        public List<object> GetFarmAnimals()
        {
            var list = new List<object>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = @"
                SELECT
                    Farmers.Name AS FarmerName,
                    Farmers.Location,
                    Animals.Name AS AnimalName,
                    Animals.Type
                FROM Farmers
                LEFT JOIN Animals ON Farmers.Id = Animals.FarmerId";

            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new
                {
                    FarmerName = reader["FarmerName"].ToString(),
                    Location = reader["Location"].ToString(),
                    AnimalName = reader["AnimalName"].ToString(),
                    Type = reader["Type"].ToString()
                });
            }

            return list;
        }

        // -----------------------
        // GET FOODS
        // -----------------------
        public List<object> GetFoods()
        {
            var list = new List<object>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = @"
                SELECT Foods.FoodName, Foods.QuantityPerDay,
                       Animals.Name AS AnimalName,
                       Farmers.Name AS FarmerName
                FROM Foods
                INNER JOIN Animals ON Foods.AnimalId = Animals.Id
                INNER JOIN Farmers ON Animals.FarmerId = Farmers.Id
            ";

            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new
                {
                    FoodName = reader["FoodName"].ToString(),
                    QuantityPerDay = reader["QuantityPerDay"].ToString(),
                    AnimalName = reader["AnimalName"].ToString(),
                    FarmerName = reader["FarmerName"].ToString()
                });
            }

            return list;
        }
    }
}
