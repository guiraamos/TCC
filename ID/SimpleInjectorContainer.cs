using SimpleInjector;

namespace ID
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            container.Register<IProductService, MicroServiceNet.Classes.ProductService>();

            container.Verify();
            return container;
        }
    }
}