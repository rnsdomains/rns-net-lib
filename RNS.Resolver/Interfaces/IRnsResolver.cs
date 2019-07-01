using System.Threading.Tasks;

namespace RNS.Resolver.Interfaces
{
    public interface IRnsResolver
    {
        Task<string> GetAddress(string accountDomain);
    }
}
