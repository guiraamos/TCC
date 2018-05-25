namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;

    [MicroServiceHost("MSNEWSLETTER")]
    public interface IMsCustumerService : IMicroService
    {
        [MicroService("AddCustomer", TypeRequest.Post)]
        Task<HttpResponseMessage> AddCustomer(List<KeyValuePair<string, string>> parameters = null);
        [MicroService("GetAllClientes", TypeRequest.Get)]
        Task<HttpResponseMessage> GetAllClientes(List<KeyValuePair<string, string>> parameters = null);
        [MicroService("GetClientePorCpf?cpf={0},420.618.058-09)", TypeRequest.Get)]
        Task<HttpResponseMessage> GetClientePorCpf(List<KeyValuePair<string, string>> parameters = null);
        [MicroService("Delete?cpf={0}, 420.618.058-09)", TypeRequest.Get)]
        Task<HttpResponseMessage> Delete(List<KeyValuePair<string, string>> parameters = null);
    }
}