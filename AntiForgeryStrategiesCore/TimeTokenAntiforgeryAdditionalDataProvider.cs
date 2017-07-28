using System;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace AntiForgeryStrategiesCore
{
    public class TimeTokenAntiforgeryAdditionalDataProvider : IAntiforgeryAdditionalDataProvider
    {
        private static readonly TimeSpan ExpirationTime = TimeSpan.FromSeconds(10);

        public string GetAdditionalData(HttpContext context)
        {
            return DateTime.Now.ToString();
        }

        public bool ValidateAdditionalData(HttpContext context, string additionalData)
        {
            var timeWhenGenerated = DateTime.Parse(additionalData);
            return DateTime.Now - timeWhenGenerated < ExpirationTime;
        }
    }
}