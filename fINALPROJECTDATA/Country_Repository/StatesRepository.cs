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
    public class StatesRepository : IStatesRepository
    {
        IDbConnection connection = new SqlConnection(AppSettings.ConnnectionString.DevOps);
        public List<States> getAllStates()
        {
            return connection.Query<States>("GETDETAILSOFSTATES",commandType : CommandType.StoredProcedure).ToList();   
        }
    }
}
