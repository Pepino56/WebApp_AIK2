using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace WebApp_AIK2_Pluhar.Pages
{
    public class DataModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DataModel> _logger;

        public DataModel(IConfiguration configuration, ILogger<DataModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public List<DataItem> DataList { get; set; }

        public void OnGet()
        {
            GetDataFromDatabase();
        }

        private void GetDataFromDatabase()
        {
            DataList = new List<DataItem>();

            // Zde vytvoøte pøipojení k databázi a získání dat
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Credits", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataList.Add(new DataItem
                            {
                                Id = reader.GetInt32(0),
                                Created = reader.GetDateTime(1),
                                Value = reader.GetInt32(2),
                                Success = reader.GetBoolean(3)
                            });
                        }
                    }
                }
            }
        }
    }

    public class DataItem
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int Value { get; set; }
        public bool Success { get; set; }
    }
}
