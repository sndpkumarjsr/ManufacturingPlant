using Dapper;
using fINALPROJECTCORE.AppSettings;

using fINALPROJECTCORE.Plant_Interface;
using fINALPROJECTCORE.Plant_Model;

using System.Data;
using System.Data.SqlClient;


namespace fINALPROJECTDATA.Plant_Repository
{
    public class PlantRepository : IPlantRepository
    {
        IDbConnection dbConnection = new SqlConnection(AppSettings.ConnnectionString.DevOps);

        public void DeleteRecord(int plantcode)
        {
            var parameter = new DynamicParameters();
            parameter.Add("PLANTCODE", plantcode);
            dbConnection.Execute("DELETERECORDSFROMPLANT", parameter, commandType: CommandType.StoredProcedure);
        }

        public List<PlantModel> GetAll()
        {
            var result = dbConnection.Query<PlantModel>("SPGETPLANTALLDETAILS", commandType: CommandType.StoredProcedure).ToList();
            
            return result;
        }

        public void RegistrationInsertRecord(PlantModel model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PLANTNAME", model.PLANTNAME);
            parameters.Add("ISWAREHOUSE", model.ISWAREHOUSE);
            parameters.Add("COUNTRY", model.COUNTRY);
            parameters.Add("ISTRANSPORT", model.ISTRANSPORT);
            parameters.Add("PHONENUMBER", model.PHONENUMBER);
            parameters.Add("PLANTIMAGE", model.PLANTIMAGE); // Assumes PLANTIMAGE is IFormFile
            parameters.Add("TRANSPORTNAME", model.TRANSPORTNAME);
            parameters.Add("STATES", model.STATES);
            parameters.Add("CITY", model.CITY);
            dbConnection.Execute("SPINSERTRECORDINPLANT", parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
