using System;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace AntiForgeryStrategiesCore
{
    public class QueueTokensAntiforgeryAdditionalDataProvider : IAntiforgeryAdditionalDataProvider
    {
        private const string TokenKey = "QueueTokensKey";
        private const int AmountOfSessionTokens = 3;
        private const char Separator = ';';

        public string GetAdditionalData(HttpContext context)
        {
            var newToken = TokenGenerator.GetRandomToken();
            if (newToken.Contains(Separator))
            {
                newToken = newToken.Replace(Separator.ToString(), string.Empty); //to prevent collision
            }

            List<string> existingTokens = GetTokens(context);
            if (existingTokens.Count == AmountOfSessionTokens)
            {
                existingTokens.RemoveAt(0);
            }

            existingTokens.Add(newToken);
            SetTokens(context, existingTokens);

            return newToken;
        }

        public bool ValidateAdditionalData(HttpContext context, string additionalData)
        {
            var tokens = GetTokens(context);
            if (tokens.Contains(additionalData))
            {
                tokens.Remove(additionalData);
                SetTokens(context, tokens);
                return true;
            }

            return false;
        }

        private static void SetTokens(HttpContext context, List<string> existingTokens)
        {
            context.Session.SetString(TokenKey, string.Join(";", existingTokens));
        }

        private static List<string> GetTokens(HttpContext context)
        {
            return context.Session.GetString(TokenKey)?.Split(';').ToList() ?? new List<string>();
        }
    }
}