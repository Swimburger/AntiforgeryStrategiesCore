using System;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace AntiForgeryStrategiesCore
{
    public class DummyAntiforgeryAdditionalDataProvider : IAntiforgeryAdditionalDataProvider
    {
        public string GetAdditionalData(HttpContext context)
        {
            return "Some dummy additional data";
        }

        public bool ValidateAdditionalData(HttpContext context, string additionalData)
        {
            return additionalData == "Some dummy additional data";
        }
    }
}