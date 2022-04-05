using Employee.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Employee.Web.Services
{
    public interface ILocationService
    {
        List<City> GetAllCities();
        List<State> GetAllStates();
        List<SelectListItem> GetAllStates(int? stateId = null);
        List<SelectListItem> GetCitiesByState(int? stateId = null, int? cityId = null);
    }
}