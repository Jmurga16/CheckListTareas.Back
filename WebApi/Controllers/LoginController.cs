using Microsoft.AspNetCore.Mvc;
using Business;
using Entity;
using NLog;
using System;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly LoginBusiness objLogin = new LoginBusiness();

        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        #region Login

        [HttpPost]
        public IActionResult CrudLogin(GeneralEntity genEnt)
        {

            if (genEnt.nOpcion == 1)
            {
                try
                {
                    string[] listaRes;

                    string sResultado = Convert.ToString(objLogin.BusinessLogin(genEnt));
                    listaRes = sResultado.Split('|');

                    return Ok(new { cod = listaRes[0], mensaje = listaRes[1] });
                }
                catch (Exception e)
                {

                    logger.Error(e);
                    throw;

                }
            }

            else
            {
                return null;
            }

        }

        #endregion
    }
}
