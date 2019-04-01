using System;

namespace PV239_05_Storage.Core.Api
{
    public partial class ApiClient
    {
        public ApiClient()
            : this(new Uri("http://10.0.2.2:5000"))
        {
        }
    }
}