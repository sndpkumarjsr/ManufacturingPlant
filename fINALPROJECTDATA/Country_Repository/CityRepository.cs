using Dapper;
using fINALPROJECTCORE.AppSettings;
using fINALPROJECTCORE.Countries;
using fINALPROJECTCORE.Country_Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fINALPROJECTDATA.Country_Repository
{
    public class CityRepository : ICityRepository
    {
        IDbConnection connection = new SqlConnection(AppSettings.ConnnectionString.DevOps);
        public List<City> GetAllCities()
        {
            return connection.Query<City>("GETDETAILSOFCITIES", commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
