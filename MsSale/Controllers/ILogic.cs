using Microsoft.AspNetCore.Http;

namespace MsSale.Controllers
{
    interface ILogic
    {
        string Executa(HttpRequest req, HttpResponse res);
    }
}
