using fINALPROJECTCORE.Plant_Model;


namespace fINALPROJECTCORE.Plant_Interface
{
    public interface IPlantRepository
    {
        List<PlantModel> GetAll();
        void RegistrationInsertRecord(PlantModel model);
        
        //void RegistrationUpdatePassword();

        void DeleteRecord(int plantcode);
    }
}
