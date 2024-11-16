using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace fINALPROJECTCORE.Plant_Model
{
    public class PlantModel
    {
        public int PLANTCODE { get; set; }
        public string PLANTNAME { get; set; }
        public string ISWAREHOUSE { get; set; }
        public string COUNTRY { get; set; }
        public int ISTRANSPORT { get; set; }
        public long PHONENUMBER { get; set; }
        public string PLANTIMAGE { get; set; }
        public string TRANSPORTNAME { get; set; }
        public string STATES { get; set; }
        public string CITY { get; set; }

        public IFormFile imageFile { get; set; }
    }
}
