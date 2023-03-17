using DeleateExampleApp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeleateExampleApp.RequestCreators
{
    public class CreatePostRequestCreator : BaseRequestCreator
    {
        public CreatePostRequestCreator()
        {
            base.SetBaseAddress(() => "https://jsonplaceholder.typicode.com");
            SetHttpMethod(HttpMethod.Post);
            SetRequestCount(10);
        }
        private PostModel postModel;
        public async Task<PostModel> CreatePostAsync(PostModel model)
        {
            postModel = model;
            var responseContent = await base.MakeRequestAsync();
            return JsonSerializer.Deserialize<PostModel>(responseContent);
        }

        protected override string GetUrlPath()
        {
            return "posts";
        }

        protected override object GetBodyObject()
        {
            return postModel;
        }
    }
}
