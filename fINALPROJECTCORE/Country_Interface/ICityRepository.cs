using fINALPROJECTCORE.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fINALPROJECTCORE.Country_Interface
{
    public interface ICityRepository
    {
        List<City> GetAllCities();
    }
}
