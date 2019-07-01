using System;
using System.Threading.Tasks;
using Nethereum.ENS;
using Nethereum.ENS.ENSRegistry.ContractDefinition;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;
using RNS.Resolver.Interfaces;

namespace RNS.Resolver.Services
{
    public class RnsResolver : IRnsResolver
    {
        public static string RskMainnetPublicNode { get; } = "https://public-node.rsk.co";
        public static string RskTestnetPublicNode { get; } = "https://public-node.testnet.rsk.co";

        private string RnsRegistry { get; } = "0xcb868aeabd31e2b66f74e9a55cf064abb31a4ad5";
        private Web3 Web3Client { get; }

        public RnsResolver() : this(RskMainnetPublicNode) { }

        public RnsResolver(string rskNode) : this(new Web3(rskNode)) { }

        public RnsResolver(Web3 web3Client)
        {
            Web3Client = web3Client;
        }

        public async Task<string> GetAddress(string accountDomain)
        {
            if (!IsValidDomain(accountDomain)) throw new ArgumentException("Invalid name.", nameof(accountDomain));

            try
            {
                var ensRegistryService = new ENSRegistryService(Web3Client, RnsRegistry);
                var fullNameNode = new EnsUtil().GetNameHash(accountDomain);

                var resolverAddress = await ensRegistryService.ResolverQueryAsync(
                    new ResolverFunction()
                    {
                        Node = fullNameNode.HexToByteArray()
                    }).ConfigureAwait(false);

                var resolverService = new PublicResolverService(Web3Client, resolverAddress);
                var theAddress = await resolverService
                    .AddrQueryAsync(fullNameNode.HexToByteArray())
                    .ConfigureAwait(false);

                return theAddress;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static bool IsValidDomain(string accountDomain)
        {
            //TODO: implement. will fix the failing test.
            return true;
        }
    }
}