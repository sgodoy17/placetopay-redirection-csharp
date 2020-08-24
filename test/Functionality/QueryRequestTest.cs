﻿using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace PlacetoPay.RedirectionTests.Functionality
{
    [TestFixture, Ignore("query")]
    public class QueryRequestTest : BaseTestCase
    {
        [Test]
        public void Should_Make_Query_Request()
        {
            var gateway = GetGateway(new JObject
            {
                { "rest", new JObject { { "timeout", 45000 }, { "connect_timeout", 30000 } } },
            });

            var response = gateway.Query("340097");

            Assert.True(response.IsSuccessful());
        }
    }
}