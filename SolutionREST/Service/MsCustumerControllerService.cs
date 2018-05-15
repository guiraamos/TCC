namespace Service
{
    using System.Collections.Generic;
    using System.Composition;
    using MicroServiceNet;
    using RestSharp;

    [Export(typeof(IMsCustumerControllerService))]
    [MicroServiceHost("String.Format(http://localhost:26709/api/Customer/")]
    public class MsCustumerController : MicroServiceBase, IMsCustumerControllerService
    {
        [MicroService("AddCustomer")]
        public IRestResponse AddCustomer(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<MsCustumerController>(AddCustomer, Method.POST, parameters);
        }

        [MicroService("GetAllClientes")]
        public IRestResponse GetAllClientes(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<MsCustumerController>(GetAllClientes, Method.GET, parameters);
        }

        [MicroService("GetClientePorCpf?cpf={0},420.618.058-09)")]
        public IRestResponse GetClientePorCpf(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<MsCustumerController>(GetClientePorCpf, Method.GET, parameters);
        }

        [MicroService("Delete?cpf={0}, 420.618.058-09)")]
        public IRestResponse Delete(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<MsCustumerController>(Delete, Method.GET, parameters);
        }
    }
}