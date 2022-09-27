using Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TaskData
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        #region Conexion
        private readonly Conexion oCon;
        public TaskData()
        {
            oCon = new Conexion(1);
        }
        #endregion
        #region Task
        public object DataTask(GeneralEntity genEnt)
        {

            string msj = string.Empty;

            switch (genEnt.nOpcion)
            {
                #region 1. Lista de Tasks
                case 1:
                    try
                    {
                        List<TaskEntity> listaTasks = new List<TaskEntity>();
                        using (IDataReader dr = oCon.ejecutarDataReader("USP_MNT_Task", genEnt.nOpcion, genEnt.pParametro))
                        {
                            while (dr.Read())
                            {
                                TaskEntity usrEnt = new TaskEntity();


                                usrEnt.nIdTask = Int32.Parse(Convert.ToString(dr["nIdTask"]));
                                usrEnt.sNameTask = Convert.ToString(dr["sNameTask"]);                               
                                usrEnt.isDone = Boolean.Parse(Convert.ToString(dr["isDone"]));
                                usrEnt.isActive = Boolean.Parse(Convert.ToString(dr["isActive"]));

                                listaTasks.Add(usrEnt);

                            }

                            return listaTasks;
                        }
                    }
                    catch (Exception e)
                    {
                        logger.Error(e);
                        throw;
                    }
                #endregion

                #region 3. Insertar | 4. Actualizar | 5. Eliminar(Logica) -- Tasks
                case 2:
                case 3:
                case 4:                
                    try
                    {
                        string sResultado = Convert.ToString(oCon.EjecutarEscalar("USP_MNT_Task", genEnt.nOpcion, genEnt.pParametro));

                        msj = sResultado;
                    }
                    catch (Exception ex)
                    {
                        msj = ex.Message;
                    }
                    return msj;
                #endregion

                default:
                    return null;

            }


        }
        #endregion

    }
}
