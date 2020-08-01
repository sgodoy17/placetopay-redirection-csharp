﻿using NUnit.Framework;
using PlacetoPay.Redirection.Entities;
using PlacetoPay.Redirection.Message;

namespace PlacetoPay.RedirectionTests.Messages
{
    [TestFixture]
    public class RedirectInformationTest
    {
        [Test]
        public void Should_Parse_A_Rest_Updated_Response()
        {
            string result = 
            "{ " +
            "   \"requestId\":371," +
            "   \"status\":" +
            "   {" +
            "       \"status\":\"PENDING\"," +
            "       \"reason\":\"PT\"," +
            "       \"message\":\"La petición se encuentra pendiente\"," +
            "       \"date\":\"2017-05-17T15:57:44-05:00\"" +
            "   }," +
            "   \"request\":" +
            "   {" +
            "       \"locale\":\"es_CO\"," +
            "       \"payer\":" +
            "       {" +
            "           \"document\":\"1040035000\"," +
            "           \"documentType\":\"CC\"," +
            "           \"name\":\"Simon\"," +
            "           \"surname\":\"Godoy\"," +
            "           \"email\":\"test@gmail.com\"," +
            "           \"mobile\":\"3006108399\"," +
            "           \"address\":" +
            "           {" +
            "               \"street\":\"123 Main Street\"," +
            "               \"city\":\"Chesterfield\"," +
            "               \"postalCode\":\"63017\"," +
            "               \"country\":\"US\"" +
            "           }" +
            "       }," +
            "       \"buyer\":" +
            "       {" +
            "           \"document\":\"1040035000\"," +
            "           \"documentType\":\"CC\"," +
            "           \"name\":\"Sugeis\"," +
            "           \"surname\":\"Meza\"," +
            "           \"email\":\"test@msn.com\"," +
            "           \"mobile\":\"3002566565\"" +
            "       }," +
            "       \"payment\":" +
            "       {" +
            "           \"reference\":\"TEST_20200517_205552\"," +
            "           \"description\":\"Payment test.\"," +
            "           \"amount\":" +
            "           {" +
            "               \"currency\":\"USD\"," +
            "               \"total\":\"178\"" +
            "           }," +
            "           \"allowPartial\":false" +
            "       }," +
            "       \"subscription\":null," +
            "       \"fields\":null," +
            "       \"returnUrl\":\"http:\\/\\/redirect.p2p.dev\\/client\"," +
            "       \"paymentMethod\":null," +
            "       \"cancelUrl\":null," +
            "       \"ipAddress\":\"127.0.0.1\"," +
            "       \"userAgent\":\"Mozilla\\/5.0 (X11; Linux x86_64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/57.0.2987.98 Safari\\/537.36\"," +
            "       \"expiration\":\"2017-05-18T20:55:52+00:00\"," +
            "       \"captureAddress\":false," +
            "       \"skipResult\":false," +
            "       \"noBuyerFill\":false" +
            "   }," +
            "   \"payment\":" +
            "   [" +
            "       {" +
            "           \"status\":" +
            "           {" +
            "               \"status\":\"REJECTED\"," +
            "               \"reason\":\"01\"," +
            "               \"message\":\"Negada, Transacción declinada\"," +
            "               \"date\":\"2017-05-17T15:56:37-05:00\"" +
            "           }," +
            "           \"internalReference\":1447498827," +
            "           \"paymentMethod\":\"masterpass\"," +
            "           \"paymentMethodName\":\"MasterCard\"," +
            "           \"amount\":" +
            "           {" +
            "               \"from\":" +
            "               {" +
            "                   \"currency\":\"USD\"," +
            "                   \"total\":178" +
            "               }," +
            "               \"to\":" +
            "               {" +
            "                   \"currency\":\"COP\"," +
            "                   \"total\":511433.16" +
            "               }," +
            "               \"factor\":2873.22" +
            "           }," +
            "           \"authorization\":\"000000\"," +
            "           \"reference\":\"TEST_20200517_205552\"," +
            "           \"receipt\":\"1495054597\"," +
            "           \"franchise\":\"RM_MC\"," +
            "           \"refunded\":false," +
            "           \"processorFields\":" +
            "           [" +
            "               {" +
            "                   \"keyword\":\"lastDigits\"," +
            "                   \"value\":\"****0206\"," +
            "                   \"displayOn\":\"none\"" +
            "               }," +
            "               {" +
            "                   \"keyword\":\"id\"," +
            "                   \"value\":\"e6bc23b9f16980bc3e5422dbb6218f59\"," +
            "                   \"displayOn\":\"none\"" +
            "               }" +
            "           ]" +
            "       }" +
            "   ]," +
            "   \"subscription\":null" +
            "}";

            var information = new RedirectInformation(result);

            Assert.AreEqual(371, information.RequestId);
            Assert.AreEqual(Status.ST_PENDING, information.Status.StatusText);

            Assert.True(information.IsSuccessful());
            Assert.False(information.IsApproved());

            Assert.AreEqual("TEST_20200517_205552", information.Request.Payment.Reference);
            Assert.AreEqual("1040035000", information.Request.Buyer.Document);

            Assert.Null(information.LastApprovedTransaction());
            Assert.AreEqual(1495054597, information.LastTransaction().Receipt);
            Assert.Null(information.LastAuthorization());
        }

        [Test]
        public void Should_Parse_A_Rest_Created_Response()
        {
            string result = 
            "{" +
            "   \"requestId\":368," +
            "   \"status\":" +
            "   {" +
            "       \"status\":\"PENDING\"," +
            "       \"reason\":\"PC\"," +
            "       \"message\":\"La petici\\u00f3n se encuentra activa\"," +
            "       \"date\":\"2017-05-17T14:44:05-05:00\"" +
            "   }," +
            "   \"request\":" +
            "   {" +
            "       \"locale\":\"es_CO\"," +
            "       \"payer\":null," +
            "       \"buyer\":" +
            "       {" +
            "           \"document\":\"1040035000\"," +
            "           \"documentType\":\"CC\"," +
            "           \"name\":\"Jakob\"," +
            "           \"surname\":\"Macejkovic\"," +
            "           \"email\":\"dcallem88@msn.com\"," +
            "           \"mobile\":\"3006108300\"" +
            "       }," +
            "       \"payment\":" +
            "       {" +
            "           \"reference\":\"TEST_20200517_144129\"," +
            "           \"description\":\"Quisquam architecto optio rem in non expedita.\"," +
            "           \"amount\":" +
            "           {" +
            "               \"taxes\":" +
            "               [" +
            "                   {" +
            "                       \"kind\":\"valueAddedTax\"," +
            "                       \"amount\":20," +
            "                       \"base\":140" +
            "                   }" +
            "               ]," +
            "               \"currency\":\"USD\"," +
            "               \"total\":\"199.8\"" +
            "           }," +
            "           \"allowPartial\":false" +
            "       }," +
            "       \"subscription\":null," +
            "       \"fields\":null," +
            "       \"returnUrl\":\"http:\\/\\/local.dev\\/redirect\\/client\"," +
            "       \"paymentMethod\":null," +
            "       \"cancelUrl\":null," +
            "       \"ipAddress\":\"192.168.33.20\"," +
            "       \"userAgent\":\"Mozilla\\/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/58.0.3029.96 Safari\\/537.36\"," +
            "       \"expiration\":\"2017-05-18T14:41:29+00:00\"," +
            "       \"captureAddress\":false," +
            "       \"skipResult\":false," +
            "       \"noBuyerFill\":false" +
            "   }," +
            "   \"payment\":null," +
            "   \"subscription\":null" +
            "}";

            var information = new RedirectInformation(result);

            Assert.AreEqual(368, information.RequestId);
            Assert.AreEqual(Status.ST_PENDING, information.Status.StatusText);

            Assert.True(information.IsSuccessful());
            Assert.False(information.IsApproved());

            Assert.AreEqual("TEST_20200517_144129", information.Request.Payment.Reference);
            Assert.AreEqual("1040035000", information.Request.Buyer.Document);

            Assert.Null(information.LastApprovedTransaction());
            Assert.Null(information.LastAuthorization());
            Assert.Null(information.LastTransaction());

            Assert.That(information.ToJsonObject().ContainsKey("requestId"));
        }

        public void Should_Parse_A_Rest_Finished_Response()
        {
            string result = 
            "{" +
            "   \"requestId\":360," +
            "   \"status\":" +
            "   {" +
            "       \"status\":\"APPROVED\"," +
            "       \"reason\":\"00\"," +
            "       \"message\":\"La petici\\u00f3n ha sido aprobada exitosamente\"," +
            "       \"date\":\"2017-05-17T14:53:54-05:00\"" +
            "   }," +
            "   \"request\":" +
            "   {" +
            "       \"locale\":\"es_CO\"," +
            "       \"payer\":" +
            "       {" +
            "           \"document\":\"1040035000\"," +
            "           \"documentType\":\"CC\"," +
            "           \"name\":\"Leilani\"," +
            "           \"surname\":\"Zulauf\"," +
            "           \"email\":\"dcallem88@msn.com\"," +
            "           \"mobile\":\"3006108300\"" +
            "       }," +
            "       \"buyer\":" +
            "       {" +
            "           \"document\":\"1040035000\"," +
            "           \"documentType\":\"CC\"," +
            "           \"name\":\"Leilani\"," +
            "           \"surname\":\"Zulauf\"," +
            "           \"email\":\"dcallem88@msn.com\"," +
            "           \"mobile\":\"3006108300\"" +
            "       }," +
            "       \"payment\":" +
            "       {" +
            "           \"reference\":\"TEST_20200516_154231\"," +
            "           \"description\":\"Et et dolorem tenetur et cum.\"," +
            "           \"amount\":" +
            "           {" +
            "               \"currency\":\"USD\"," +
            "               \"total\":\"0.3\"" +
            "           }," +
            "           \"allowPartial\":false" +
            "       }," +
            "       \"subscription\":null," +
            "       \"fields\":null," +
            "       \"returnUrl\":\"http:\\/\\/redirect.p2p.dev\\/client\"," +
            "       \"paymentMethod\":null," +
            "       \"cancelUrl\":null," +
            "       \"ipAddress\":\"127.0.0.1\"," +
            "       \"userAgent\":\"Mozilla\\/5.0 (X11; Linux x86_64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/57.0.2987.98 Safari\\/537.36\"," +
            "       \"expiration\":\"2017-05-17T15:42:31+00:00\"," +
            "       \"captureAddress\":false," +
            "       \"skipResult\":false," +
            "       \"noBuyerFill\":false" +
            "   }," +
            "   \"payment\":" +
            "   [" +
            "       {" +
            "           \"status\":" +
            "           {" +
            "               \"status\":\"APPROVED\"," +
            "               \"reason\":\"00\"," +
            "               \"message\":\"Aprobada\"," +
            "               \"date\":\"2017-05-16T10:43:39-05:00\"" +
            "           }," +
            "           \"internalReference\":1447466623," +
            "           \"paymentMethod\":\"paypal\"," +
            "           \"paymentMethodName\":\"PayPal\"," +
            "           \"amount\":" +
            "           {" +
            "               \"from\":" +
            "               {" +
            "                   \"currency\":\"USD\"," +
            "                   \"total\":0.3" +
            "               }," +
            "               \"to\":" +
            "               {" +
            "                   \"currency\":\"USD\"," +
            "                   \"total\":0.3" +
            "               }," +
            "               \"factor\":1" +
            "           }," +
            "           \"authorization\":\"2DG26929XX8381738\"," +
            "           \"reference\":\"TEST_20200516_154231\"," +
            "           \"receipt\":\"1447466623\"," +
            "           \"franchise\":\"PYPAL\"," +
            "           \"refunded\":false," +
            "           \"processorFields\":" +
            "           [" +
            "               {" +
            "                   \"keyword\":\"trazabilyCode\"," +
            "                   \"value\":\"PAY-9BU08130ME378305MLENR4CI\"," +
            "                   \"displayOn\":\"none\"" +
            "               }" +
            "           ]" +
            "       }" +
            "   ]," +
            "   \"subscription\":null" +
            "}";

            var information = new RedirectInformation(result);

            Assert.AreEqual(368, information.RequestId);
            Assert.AreEqual(Status.ST_PENDING, information.Status.StatusText);

            Assert.True(information.IsSuccessful());
            Assert.False(information.IsApproved());

            Assert.AreEqual("TEST_20200517_144129", information.Request.Payment.Reference);
            Assert.AreEqual("1040035000", information.Request.Buyer.Document);

            Assert.Null(information.LastApprovedTransaction());
            Assert.Null(information.LastAuthorization());
            Assert.Null(information.LastTransaction());

            Assert.That(information.ToJsonObject().ContainsKey("requestId"));
        }
    }
}
