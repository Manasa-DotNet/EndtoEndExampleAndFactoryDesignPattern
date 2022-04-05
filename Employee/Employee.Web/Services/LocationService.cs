using Employee.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Web.Services
{
    public class LocationService : ILocationService
    {
        private static readonly List<State> _states = new List<State>();
        private static readonly List<City> _cities = new List<City>();
        static LocationService()
        {
            var statesJson = File.ReadAllText("Services/state.json");
            _states = JsonConvert.DeserializeObject<List<Employee.Model.State>>(statesJson);

            var citiesJson = File.ReadAllText("Services/city.json");
            _cities = JsonConvert.DeserializeObject<List<Employee.Model.City>>(citiesJson);


        }
        public List<SelectListItem> GetAllStates(int? stateId = null)
        {

            var states = _states.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name, Selected = stateId != null && stateId == x.Id }).ToList();
            return states;
        }

        public List<City> GetAllCities()
        {
            return _cities;
        }
        public List<State> GetAllStates()
        {
            return _states;
        }

        public List<SelectListItem> GetCitiesByState(int? stateId = null, int? cityId = null)
        {
            var cities = _cities.Where(x => x.StateId == stateId).Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name, Selected = cityId != null && cityId == x.Id }).ToList();
            return cities;
        }
    }
}
