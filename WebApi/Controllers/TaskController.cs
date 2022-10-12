using Business;
using Entity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly TaskBusiness objTask = new TaskBusiness();

        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        #region Task

        [HttpPost]
        public IActionResult CrudTask(GeneralEntity genEnt)
        {

            //Lista de Datos
            if (genEnt.nOpcion == 1 )
            {
                try
                {
                    var vRes = objTask.BusinessTask(genEnt);

                    return Ok(vRes);
                }
                catch (Exception e)
                {

                    logger.Error(e);
                    throw;

                }
            }

            //Crear/Actualizar/Eliminar
            else if (genEnt.nOpcion == 2 || genEnt.nOpcion == 3 || genEnt.nOpcion == 4 )
            {
                try
                {
                    string[] listaRes;

                    string sResultado = Convert.ToString(objTask.BusinessTask(genEnt));
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
