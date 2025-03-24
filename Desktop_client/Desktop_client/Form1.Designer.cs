namespace Desktop_client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label1;
            search = new Button();
            Posts = new ListBox();
            Comments = new ListBox();
            button1 = new Button();
            textbox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(313, 24);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 0;
            label1.Tag = "search keyword";
            label1.Text = "search keyword";
            // 
            // search
            // 
            search.Location = new Point(313, 93);
            search.Name = "search";
            search.Size = new Size(94, 29);
            search.TabIndex = 1;
            search.Text = "search";
            search.UseVisualStyleBackColor = true;
            search.Click += search_Click;
            // 
            // Posts
            // 
            Posts.FormattingEnabled = true;
            Posts.Location = new Point(12, 246);
            Posts.Name = "Posts";
            Posts.Size = new Size(175, 164);
            Posts.TabIndex = 2;
            Posts.Tag = "Posts";
            // 
            // Comments
            // 
            Comments.FormattingEnabled = true;
            Comments.Location = new Point(578, 246);
            Comments.Name = "Comments";
            Comments.Size = new Size(186, 164);
            Comments.TabIndex = 3;
            Comments.Tag = "Comments";
            Comments.SelectedIndexChanged += Comments_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(297, 283);
            button1.Name = "button1";
            button1.Size = new Size(140, 33);
            button1.TabIndex = 4;
            button1.Text = "Manage Emails ";
            button1.UseVisualStyleBackColor = true;
            // 
            // textbox1
            // 
            textbox1.Location = new Point(299, 60);
            textbox1.Name = "textbox1";
            textbox1.Size = new Size(125, 27);
            textbox1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textbox1);
            Controls.Add(button1);
            Controls.Add(Comments);
            Controls.Add(Posts);
            Controls.Add(search);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button search;
        private ListBox Posts;
        private ListBox Comments;
        private Button button1;
        private TextBox textbox1;
    }
}
