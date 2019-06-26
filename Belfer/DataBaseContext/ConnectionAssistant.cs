using Autofac;
using DataBaseService;
using Enigma;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace Belfer.DataBaseContext
{
    public class ConnectionAssistant
    {
        bool IsDirty;
        IConnectionParameters connParams;

        public ConnectionAssistant()
        {
            //SetConnectParams();
        }


        public bool TryConnect()
        {
            try
            {
                if (AppSession.ConnStatus == ConnectionState.Dostępne)
                {
                    return true;
                }
                else
                {
                    //if (LoadConnectParams())
                    {
                        //SetConnectParams();
                        if (TryConnect()) return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
