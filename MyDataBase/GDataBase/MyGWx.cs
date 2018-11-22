using System.Collections.Generic;

namespace GDataBase
{
    interface MyGWx
    {       
       string GetNonce_str();
       string WXMD5Util(string r);
       string CreateSign(Dictionary<string, string> dic);
    }
}
