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
    public class TaskBusiness
    {
        private readonly TaskData TaskData = new TaskData();
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public object BusinessTask(GeneralEntity entity)
        {
            try
            {

                return TaskData.DataTask(entity);

            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;

            }
        }
    }
}
