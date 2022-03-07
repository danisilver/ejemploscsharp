using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEmpleadosCore.Models;
using ApiEmpleadosCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ApiEmpleadosCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        RepositoryEmpleados repo;
        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<List<Empleado>> Get()
        {
            return this.repo.GetEmpleados();
        }
        [HttpGet("{id}")]
        public ActionResult<Empleado> Get(int id)
        {
            return this.repo.BuscarEmpleado(id);
        }
        [HttpGet("{oficio}/{departamento}")]
        public ActionResult<List<Empleado>> GetEmpleados(String oficio, int departamento)
        {
            return this.repo.GetEmpleados(oficio, departamento);
        }

        [Route("[action]/{salario}")]
        [HttpGet]
        public ActionResult<List<Empleado>> GetEmpleadosSalario(int salario)
        {
            return this.repo.GetEmpleadosSalario(salario);
        }
    }
}