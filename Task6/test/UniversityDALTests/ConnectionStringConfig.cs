using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDALIntegrationTests
{
    class ConnectionStringConfig
    {
        public static string GetConnectionString()
        {
            return "Server=localhost\\sqlexpress;Database=university_TestDB;Integrated Security=True";
        }
    }
}
