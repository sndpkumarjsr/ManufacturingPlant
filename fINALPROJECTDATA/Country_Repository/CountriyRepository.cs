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
    public class CountriyRepository : ICountriyRepository
    {
        IDbConnection connection = new SqlConnection(AppSettings.ConnnectionString.DevOps);
        public List<Country> getAllCountries()
        {
            return connection.Query<Country>("GETDETAILSOFCOUNTRIES", commandType : CommandType.StoredProcedure).ToList();
        }
    }
}
