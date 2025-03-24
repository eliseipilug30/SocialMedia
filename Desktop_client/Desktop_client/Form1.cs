namespace Desktop_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            string keyword = textbox1.Text;  

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Please enter a keyword!");
                return;
            }

            Postservice postService = new Postservice();
            postService.createConnection();

            try
            {
                List<Post> posts = postService.GetPostsByKeyword(keyword);
                List<Comment> comments = postService.GetCommentsByKeyword(keyword);

                Posts.Items.Clear(); 
                foreach (var post in posts)
                {
                    Posts.Items.Add($"{post.title}: {post.content}");
                }

                Comments.Items.Clear();
                foreach (var comment in comments)
                {
                    Comments.Items.Add(comment.content);
                }

                if (posts.Count == 0 && comments.Count == 0)
                {
                    MessageBox.Show("No results found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Comments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
