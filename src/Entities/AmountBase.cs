﻿using Newtonsoft.Json.Linq;
using PlacetoPay.Redirection.Contracts;
using System;

namespace PlacetoPay.Redirection.Entities
{
    /// <summary>
    /// Class <c>AmountBase</c>
    /// </summary>
    public class AmountBase : Entity
    {
        protected string currency = "COP";
        protected double total;

        /// <summary>
        /// AmountBase construnctor.
        /// </summary>
        /// <param name="data">JObject</param>
        public AmountBase(JObject data)
        {
            Load(data, new JArray { "currency", "total" });
        }

        /// <summary>
        /// AmountBase construnctor.
        /// </summary>
        /// <param name="data">string</param>
        public AmountBase(string data)
        {
            JObject json = JObject.Parse(data);

            Load(json, new JArray { "currency", "total" });
        }

        /// <summary>
        /// AmountBase construnctor.
        /// </summary>
        /// <param name="currency">string</param>
        /// <param name="total">double</param>
        public AmountBase(string currency, double total)
        {
            this.currency = currency;
            this.total = total;
        }

        /// <summary>
        /// Currency property.
        /// </summary>
        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        /// <summary>
        /// Total property.
        /// </summary>
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        /// <summary>
        /// Json Object sent back from API.
        /// </summary>
        /// <returns>JsonObject</returns>
        public override JObject ToJsonObject()
        {
            throw new NotImplementedException();
        }
    }
}