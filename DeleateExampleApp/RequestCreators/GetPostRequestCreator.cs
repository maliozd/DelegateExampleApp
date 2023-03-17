using DeleateExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeleateExampleApp.RequestCreators
{
    public class GetPostRequestCreator : BaseRequestCreator
    {
        public event EventHandler<int> OnRequestFinished;
        public GetPostRequestCreator()
        {
            base.SetBaseAddress(() => "https://jsonplaceholder.typicode.com");
            SetHttpMethod(HttpMethod.Get);
            SetRequestCount(2);
        }
        public async Task<List<PostModel>> GetPostsAsync()
        {

            var responseContent = await base.MakeRequestAsync();
            OnRequestFinished?.Invoke(this, responseContent.Length);
            return JsonSerializer.Deserialize<List<PostModel>>(responseContent);
        }


        protected override string GetUrlPath()
        {
            return "posts";
        }
    }
}
