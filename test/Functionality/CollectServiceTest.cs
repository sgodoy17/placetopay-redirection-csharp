﻿using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace PlacetoPay.RedirectionTests.Functionality
{
    [TestFixture, Ignore("collect")]
    public class CollectServiceTest : BaseTestCase
    {
        private const string DATA = "{  \n" +
            "   \"payer\":{  \n" +
            "      \"name\":\"John\",\n" +
            "      \"surname\":\"Doe\",\n" +
            "      \"email\":\"johndoe@example.com\",\n" +
            "      \"document\":\"1040035000\",\n" +
            "      \"documentType\":\"CC\"\n" +
            "   },\n" +
            "   \"payment\":{  \n" +
            "      \"reference\":\"TESTING123456\",\n" +
            "      \"amount\":{  \n" +
            "         \"currency\":\"COP\",\n" +
            "         \"total\":\"10000\"\n" +
            "      }\n" +
            "   },\n" +
            "   \"instrument\":{  \n" +
            "      \"token\":{  \n" +
            "         \"token\":\"961da9f371a8edc212a525f5e8d69934bec8484f546c720d3c5bf75350602ba0\"\n" +
            "      }\n" +
            "   }\n" +
            "}";

        [Test]
        public void Should_Make_Collect_Request()
        {
            var gateway = GetGateway(new JObject
            {
                { "additional", new JObject { { "timeout", 45000 }, { "connect_timeout", 30000 } } },
            });

            var response = gateway.Collect(DATA);

            Assert.True(response.IsSuccessful());
        }

        [Test]
        public void Should_Make_Soap_Collect_Request()
        {
            var gateway = GetGateway(new JObject
            {
                { "type", "soap" },
            });

            var response = gateway.Collect(DATA);

            Assert.True(response.IsSuccessful());
        }
    }
}
