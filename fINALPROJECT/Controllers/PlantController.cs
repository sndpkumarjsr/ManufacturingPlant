
using fINALPROJECTCORE.Plant_Interface;
using fINALPROJECTCORE.Plant_Model;
using Microsoft.AspNetCore.Mvc;


namespace fINALPROJECT.Controllers
{
    public class PlantController : Controller
    {
        private readonly IPlantRepository repository;
        private readonly IWebHostEnvironment environment;

        public PlantController(IPlantRepository repository,IWebHostEnvironment environment)
        {
            this.repository = repository;
            this.environment = environment;
        }

        [Route("plant/getAllDetails")]
        [HttpGet]
        public List<PlantModel> GetAllDetails()
        {
            var list = repository.GetAll();
            foreach (var item in list)
            {
                item.PLANTIMAGE = GetImage(item.PHONENUMBER);
            }
            return list;
        }

        [Route("plant/insertRecords")]
        [HttpPost]
        public ActionResult RegistrationInsertRecord([FromForm] PlantModel model)
        {
            try
            {

                string ImageName = InsertRecords(model.imageFile, model.PHONENUMBER);
                    model.PLANTIMAGE = ImageName;
                repository.RegistrationInsertRecord(model);
                
                return Json(new {Success = true,Message = "Record Inserted"});
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Error = e.Message });
            }
        }
        [Route("plant/delete")]
        [HttpDelete]
        public ActionResult DeleteRecord(int plantcode)
        {
            try
            {
                repository.DeleteRecord(plantcode);
                return Json(new { Success = true, Message = "Record Deleted" });
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Error = e.Message });
            }
        }
        [NonAction]
        public  string InsertRecords(IFormFile image, long PlantPhonenum)
        {
            try
            {
                string FilePath = this.environment.WebRootPath + "\\Image\\plantimage\\" + PlantPhonenum;
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                var ext = Path.GetExtension(image.FileName);
                string imagepath = Path.Combine(FilePath, $"{PlantPhonenum}{ext}");
                if (System.IO.File.Exists(imagepath))
                {
                    System.IO.File.Delete(imagepath);
                }
                using (FileStream stream = System.IO.File.Create(imagepath))
                {
                    image.CopyTo(stream); // Corrected line
                }
                return imagepath;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [NonAction]
        public string GetImage(long PlantPhonenum)
        {
            string Imageurl = string.Empty;
            string hostUrl =$"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string FilePath = this.environment.WebRootPath + "\\Image\\plantimage\\" + PlantPhonenum;
                string ImagePath = FilePath + "\\" + PlantPhonenum + ".png";
                if (System.IO.File.Exists(ImagePath))
                {
                    Imageurl = hostUrl + "/Image//plantimage//" + PlantPhonenum +"//"+ PlantPhonenum + ".png";

                }
                return Imageurl;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        
    }
}
