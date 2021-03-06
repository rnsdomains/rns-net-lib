using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RNS.Resolver.Interfaces;
using RNS.Resolver.Services;

namespace RNS.Tests
{
    [TestClass]
    public class RnsResolverTests
    {
        private IRnsResolver _rns;

        [TestInitialize]
        public void Init()
        {
            _rns = new RnsResolver();
        }

        [TestMethod]
        public void WhenResolvingKnownDomainThenResolves()
        {
            const string addressToMatch = "0x2c4a4a346ddc3122c2628dbe9dbbca1bbd59551c";
            const string domain = "consensus.rsk";
            var address = _rns.GetAddress(domain).Result;

            Console.WriteLine(address);

            Assert.AreEqual(address, addressToMatch);
        }

        [TestMethod]
        public void WhenResolvingNonExistingDomainThenDontResolves()
        {
            const string addressToMatch = null;
            const string domain = "2c4a4a346ddc3122c2628dbe9dbbca1bbd59551c.rsk";
            var address = _rns.GetAddress(domain).Result;

            Console.WriteLine(address);

            Assert.AreEqual(address, addressToMatch);
        }


        [TestMethod]
        public void WhenResolvingInvalidDomainThenThrows()
        {
            const string domain = "rsk";

            Assert.ThrowsException<ArgumentException>(() =>
            {
                var address = _rns.GetAddress(domain).Result;

                Console.WriteLine(address);
            });
        }
    }
}
