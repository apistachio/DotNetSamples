using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
//using System.ServiceModel.Web;
using System.Text;
using System.IO;

namespace WCF
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SAM : ISAM
    {

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string GetString(string s)
        {
            return "str:" + s;
        }

    }
}
