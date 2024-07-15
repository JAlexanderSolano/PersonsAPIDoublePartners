using Entities;
using Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PersonsAPIDoublePartners.EntryModels;
using System.Data;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonsAPIDoublePartners.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrarmeController : ControllerBase
    {
        private readonly Iresultado _resultado;

        public RegistrarmeController(Iresultado resultado)
        {
            _resultado = resultado;
        }

        // POST api/<RegistrarmeController>
        /// <summary>
        /// Meotodo para registrar una persona
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Registrarme([FromBody] Registrarme reg)
        {
            try
            {
                List<Entities.resultado> lsResult = new List<resultado>();
                Bussnies.Registrarme _registrarme = new Bussnies.Registrarme();

                DataTable tblResult = _registrarme.Registrar(reg.names, reg.lastnames, reg.identification, reg.email, reg.typeid, reg.username, reg.password);
                lsResult = _resultado.RetornarResultado(tblResult);
                return Ok(lsResult);
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCode(500) + " " + ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
