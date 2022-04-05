using System.Collections.Generic;

namespace Employee.Web.Services
{
    public interface IEmployeeDataService
    {
        Model.Employee Add(Model.Employee employee);
        List<Model.Employee> GetAll();
        void Remove(int employeeId);
        Model.Employee Update(Model.Employee employee);
    }
}