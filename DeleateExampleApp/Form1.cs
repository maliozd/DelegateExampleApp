using DeleateExampleApp.RequestCreators;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DeleateExampleApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnTestPost_Click(object sender, EventArgs e)
        {
            CreatePostRequestCreator req = new CreatePostRequestCreator();
            req.SetRequestStartedMethod(() =>  //event
            {
                MessageBox.Show("Request started");
            });
            var createPost = await req.CreatePostAsync(new Models.PostModel()
            {
                title = "foo",
                body = "bar",
                userId = 1
            });
            MessageBox.Show(createPost.id.ToString());
        }

        private async void btnTestGet_Click(object sender, EventArgs e)
        {
            GetPostRequestCreator req = new GetPostRequestCreator();
            req.OnRequestFinished += Req_OnRequestFinished;
            req.SetRequestStartedMethod(() =>
            {
                MessageBox.Show("Request started");
            });
            var posts = await req.GetPostsAsync();
            MessageBox.Show(posts.FirstOrDefault().title);
        }

        private void Req_OnRequestFinished(object sender, int e)
        {
            MessageBox.Show($"Request finished: {e}");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
