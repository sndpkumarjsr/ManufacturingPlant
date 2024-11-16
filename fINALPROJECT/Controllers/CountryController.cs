using fINALPROJECTCORE.Countries;
using fINALPROJECTCORE.Country_Interface;
using Microsoft.AspNetCore.Mvc;

namespace fINALPROJECT.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountriyRepository repository;
        private readonly IStatesRepository statesRepository;
        private readonly ICityRepository cityRepository;

        public CountryController(ICountriyRepository repository,IStatesRepository statesRepository,ICityRepository cityRepository)
        {
            this.repository = repository;
            this.statesRepository = statesRepository;
            this.cityRepository = cityRepository;
        }

        [Route("coutries/getalldetails")]
        [HttpGet]
        public List<Country> GetCountries()
        {
            var result = repository.getAllCountries();
            return result;
        }

        [Route("states/getalldetails")]
        [HttpGet]
        public List<States> GetStates()
        {
            var result = statesRepository.getAllStates();
            return result;
        }

        [Route("city/getalldetails")]
        [HttpGet]
        public List<City> GetCities()
        {
            var result = cityRepository.GetAllCities();
            return result;
        }

    }
}
