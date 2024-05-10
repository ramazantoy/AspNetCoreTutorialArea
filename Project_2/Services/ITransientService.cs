namespace Project_2.Services
{
    public interface IServiceBase
    {
        public string GuidId { get; }
    }
    public interface ITransientService : IServiceBase
    {
     
    }
    public interface IScopedService : IServiceBase
    {
       
    }
    public interface ISingletonService : IServiceBase
    {
    
    }
}