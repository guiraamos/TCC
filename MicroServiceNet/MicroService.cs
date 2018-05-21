using System.Net.Http;
using System.Web.Mvc;

namespace MicroServiceNet
{
    public class MicroService
    {
        public string Name { get; set; }
        public HttpVerbs Action { get; set; }
    }
}
