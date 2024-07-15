using Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonsAPIDoublePartners.EntryModels;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonsAPIDoublePartners.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Iresultado _resultado;

        public LoginController(Iresultado resultado)
        {
            _resultado = resultado;
        }

        // POST api/<LoginController>
        /// <summary>
        /// Metodo para iniciar sesion
        /// </summary>
        /// <param name="value"></param>
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] Login log)
        {
            try
            {
                List<Entities.resultado> lsResult = new List<Entities.resultado>();
                Bussnies.Login login = new Bussnies.Login();
                DataTable tblResult = login.LoginSesion(log.username, log.password);
                lsResult = _resultado.RetornarResultado(tblResult);
                return Ok(lsResult);
            }
            catch(Exception ex) 
            {
                return BadRequest(StatusCode(400) + ex.Message + ex.StackTrace);
            }
        }
    }
}
