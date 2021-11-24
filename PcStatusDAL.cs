using KLConnect.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLConnect.PC.Status.App
{
    public class PcStatusDAL
    {
        public static PcStatusDAL instance = null;
        private UapiHelper UAPIhelp;
        public static PcStatusDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PcStatusDAL();
                return instance;
            }
        }

        public PcStatusDAL()
        {
            UAPIhelp = new UapiHelper();
            UAPIhelp.InitalizeUser("KCID028", "5GP7K4Z3-D3D9-XGP9-L54A-492FSRBLP2X7", "KTR+Diagnostic");
        }

        public async Task<List<UpdateStatusModel>> sendStatus(string pcname, int status)
        {
            var json = await UAPIhelp.RunAPI("PCStatus", "UpdateRunning", 202111, null, pcname, status);
            var sdl = JsonConvert.DeserializeObject<List<UpdateStatusModel>>(json);
            return sdl;
        }
    }
}
