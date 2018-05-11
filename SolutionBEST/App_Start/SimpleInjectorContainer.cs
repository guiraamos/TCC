using SimpleInjector;
using MicroServiceNet;

namespace WebApplication1
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices(Container container)
        {
            container.Verify();

            return container;
        }
    }
}