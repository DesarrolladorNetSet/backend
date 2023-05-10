using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLibrosCRUD.Data
{
    public class MySqlConfiguration
    {
        public MySqlConfiguration(string connectionString) => ConnetionString = connectionString;

        public string ConnetionString { get; set; }
    }
}
