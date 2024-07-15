using Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonsAPIDoublePartners.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly Iperson _person;

        public PersonController(Iperson person)
        {
            _person = person;
        }


        // GET: api/<PersonController>
        /// <summary>
        /// Obtener personas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ObtenerPersona()
        {
            try
            {
                List<Entities.person> lsPerson = new List<Entities.person>();
                Bussnies.Person person = new Bussnies.Person();
                DataTable tblResult = person.ObtenerPersona();
                lsPerson = _person.RetornarResultado(tblResult);
                return Ok(lsPerson);
            }
            catch(Exception ex) 
            {
                return BadRequest(StatusCode(400) + " " + ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
