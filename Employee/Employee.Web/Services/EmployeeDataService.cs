using Employee.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Web.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private static readonly List<Employee.Model.Employee> _employees;
        static EmployeeDataService()
        {
            var employeeJson = File.ReadAllText("Services/Employee.json");
            _employees = JsonConvert.DeserializeObject<List<Employee.Model.Employee>>(employeeJson);
        }
        public List<Employee.Model.Employee> GetAll()
        {
            return _employees.OrderBy(x => x.Id).ToList();
        }
        public Employee.Model.Employee Add(Employee.Model.Employee employee)
        {
            employee.Id = _employees.Count == 0 ? 1 : _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            this.UpdateEmployeeJson();
            return employee;
        }

        public Employee.Model.Employee Update(Employee.Model.Employee employee)
        {
            _employees.Remove(_employees.First(x => x.Id == employee.Id));
            _employees.Add(employee);
            this.UpdateEmployeeJson();
            return employee;
        }

        public void Remove(int employeeId)
        {
            _employees.Remove(_employees.First(x => x.Id == employeeId));
            this.UpdateEmployeeJson();
        }
        private void UpdateEmployeeJson()
        {
            var employeeJson = JsonConvert.SerializeObject(_employees);
            File.WriteAllText("Services/Employee.json", employeeJson);
        }
    }
}
