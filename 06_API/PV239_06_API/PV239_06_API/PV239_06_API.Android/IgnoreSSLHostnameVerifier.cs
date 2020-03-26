using Java.Lang;
using Javax.Net.Ssl;

namespace PV239_06_API.Droid
{
    public class IgnoreSSLHostnameVerifier : Object, IHostnameVerifier
    {
        public bool Verify(string hostname, ISSLSession session)
        {
            return true;
        }
    }
}