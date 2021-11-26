using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ciclosjobs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
      

        private readonly ILogger<WeatherForecastController> _logger;
        private IWeatherForecastBL weatherForecastBL;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastBL weatherForecastBL)
        {
            this.weatherForecastBL = weatherForecastBL;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return this.weatherForecastBL.GetPrevisionesTiempos();
        }
    }
}
