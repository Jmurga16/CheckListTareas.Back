using Business;
using Entity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly MenuBusiness objMenu = new MenuBusiness();

        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        #region Menu

        [HttpPost]
        public IActionResult CrudMenu(GeneralEntity genEnt)
        {

            if (genEnt.nOpcion == 1)
            {
                try
                {
                    var vRes = objMenu.BusinessMenu(genEnt);

                    return Ok(vRes);
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
