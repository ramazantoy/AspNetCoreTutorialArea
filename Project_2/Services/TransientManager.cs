using System;

namespace Project_2.Services
{
    public class TransientManager : ITransientService
    {
        private string _guidId;
        public string GuidId => _guidId;

        public TransientManager()
        {
            _guidId=Guid.NewGuid().ToString();
        }
        
    }

    public class ScopedManager : IScopedService
    {
        private string _guidId;
        public string GuidId => _guidId;

        public  ScopedManager()
        {
            _guidId=Guid.NewGuid().ToString();
        }
    }

    public class SingletonManager : ISingletonService
    {
        private string _guidId;
        public string GuidId => _guidId;

        public  SingletonManager()
        {
            _guidId=Guid.NewGuid().ToString();
        }
    }
}