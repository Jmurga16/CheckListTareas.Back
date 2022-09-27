using Data;
using Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LoginBusiness
    {
        private readonly LoginData LoginData = new LoginData();
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public object BusinessLogin(GeneralEntity entity)
        {
            try
            {

                return LoginData.DataLogin(entity);

            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;

            }
        }
    }
}
