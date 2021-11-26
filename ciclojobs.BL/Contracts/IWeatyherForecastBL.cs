using ciclosjobs.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Contracts
{
    public interface IWeatherForecastBL
    {

        public IEnumerable<WeatherForecast> GetPrevisionesTiempos();

    }
}
