namespace Service
{
    using System.Collections.Generic;
    using System.Composition;
    using MicroServiceNet;
    using RestSharp;

    [MicroServiceHost("String.Format(http://localhost:26709/api/Customer/")]
    public interface IMsCustumerControllerService
    {
        [MicroService("AddCustomer")]
        IRestResponse AddCustomer(List<KeyValuePair<object, object>> parameters = null);
        [MicroService("GetAllClientes")]
        IRestResponse GetAllClientes(List<KeyValuePair<object, object>> parameters = null);
        [MicroService("GetClientePorCpf?cpf={0},420.618.058-09)")]
        IRestResponse GetClientePorCpf(List<KeyValuePair<object, object>> parameters = null);
        [MicroService("Delete?cpf={0}, 420.618.058-09)")]
        IRestResponse Delete(List<KeyValuePair<object, object>> parameters = null);
    }
}