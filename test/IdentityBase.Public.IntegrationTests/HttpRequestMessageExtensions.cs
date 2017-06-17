﻿using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace IdentityBase.Public.IntegrationTests
{
    public static class HttpRequestMessageExtensions
    {
        public static HttpRequestMessage AddCookies(
            this HttpRequestMessage request, IDictionary<string, string> cookies)
        {
            cookies.Keys.ToList().ForEach(key =>
            {
                request.Headers.Add("Cookie", new CookieHeaderValue(key, cookies[key]).ToString());
            });

            return request;
        }

        public static HttpRequestMessage AddCookiesFromResponse(
            this HttpRequestMessage request, HttpResponseMessage response)
        {
            return request.AddCookies(response.ExtractCookies());
        }
    }
}