using System;
using System.Collections;

namespace Shop.Application
{
    public class IoCContainer
    {
        private readonly Hashtable _registrations;

        public IoCContainer()
        {
            _registrations = new Hashtable();
        }

        public void RegisterTransient<TInterface, TImplementation>()
        {
            _registrations.Add(typeof(TInterface), typeof(TImplementation));
        }

        public TInterface Create<TInterface>()
        {
            var typeOfImpl = (Type)_registrations[typeof(TInterface)];
            if (typeOfImpl == null)
            {
                throw new ApplicationException($"Failed to resolve {typeof(TInterface).Name}");
            }
            return (TInterface)Activator.CreateInstance(typeOfImpl);
        }
    }
}
