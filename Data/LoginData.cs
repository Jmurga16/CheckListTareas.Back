using Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LoginData
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        #region Conexion
        private readonly Conexion oCon;
        public LoginData()
        {
            oCon = new Conexion(1);
        }
        #endregion

        #region Login
        public object DataLogin(GeneralEntity genEnt)
        {

            string msj = string.Empty;

            switch (genEnt.nOpcion)
            {

                #region 3. Acceso
                case 1:

                    try
                    {
                        string sResultado = Convert.ToString(oCon.EjecutarEscalar("USP_MNT_Login", genEnt.nOpcion, genEnt.pParametro));

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
