using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeleateExampleApp.RequestCreators
{
    public abstract class BaseRequestCreator
    {
        public BaseRequestCreator()
        {
            makeRequestDelegateMethod = MakeGETRequestAsync;
        }
        protected delegate string GetBaseAddressDelegate();
        GetBaseAddressDelegate getBaseAddressDelegateMethod;

        private delegate Task<string> MakeRequestDelegate();
        MakeRequestDelegate makeRequestDelegateMethod;

        public delegate void RequestStartedDelegate();
        RequestStartedDelegate requestStartedMethod;

        Func<int> requestCountFunc;

        private HttpMethod httpMethod { get; set; }

        protected void SetRequestCount(int count)
        {
            requestCountFunc = () => count;
        }

        protected async Task<string> MakeRequestAsync()
        {
            var requestCount = Math.Max(requestCountFunc.Invoke(), 1);
            while ((requestCount--) > 0)
            {
                requestStartedMethod.Invoke();
            }
            return await makeRequestDelegateMethod.Invoke();
        }
        private async Task<string> MakeGETRequestAsync()
        {
            var baseAddress = getBaseAddressDelegateMethod.Invoke();
            HttpClient client = new HttpClient();
            var message = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri($"{baseAddress}/{GetUrlPath()}")
            };
            var httpResponse = await client.SendAsync(message);
            httpResponse.EnsureSuccessStatusCode(); //200 ile başlamayan bir kodsa hata fırlatacak
            var contentResult = await httpResponse.Content.ReadAsStringAsync();
            return contentResult;
        }
        private async Task<string> MakePOSTRequestAsync()
        {
            var baseAddress = getBaseAddressDelegateMethod.Invoke();
            HttpClient client = new HttpClient();
            var message = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri($"{baseAddress}/{GetUrlPath()}")
            };
            var bodyContent = GetBodyObject();
            if (bodyContent != null)
                message.Content = new StringContent(JsonSerializer.Serialize(bodyContent));

            var httpResponse = await client.SendAsync(message);
            httpResponse.EnsureSuccessStatusCode();
            var contentResult = await httpResponse.Content.ReadAsStringAsync();
            return contentResult;
        }

        protected void SetBaseAddress(GetBaseAddressDelegate paramDelegateMethod)
        {
            getBaseAddressDelegateMethod = paramDelegateMethod;
        }
        public void SetRequestStartedMethod(RequestStartedDelegate requestStartedDelegate)
        {
            requestStartedMethod = requestStartedDelegate;
        }


        protected HttpMethod SetHttpMethod(HttpMethod method)
        {
            if (method == HttpMethod.Post)
                makeRequestDelegateMethod = MakePOSTRequestAsync;
            return httpMethod = method;
        }
        protected virtual string GetUrlPath()
        {
            return "";
        }
        protected virtual object GetBodyObject()
        {
            return default;
        }
    }
}
