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
    public class MenuBusiness
    {
        private readonly MenuData MenuData = new MenuData();
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public object BusinessMenu(GeneralEntity entity)
        {
            try
            {

                return MenuData.DataMenu(entity);

            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;

            }
        }
    }
}
