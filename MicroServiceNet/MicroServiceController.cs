using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Mvc;

namespace MicroServiceNet
{
    public class MicroServiceController<T> : Controller
    {
        private CompositionContainer _container;

        public MicroServiceController()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(T).Assembly));
            _container = new CompositionContainer(catalog);

            try
            {
                _container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}