using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_client
{
    internal class Comment
    {
        public int id { get; set; }
        public int postId { get; set; }
        public string content { get; set; }
        public User user { get; set; }
        public DateTime createdOn { get; set; }
    }
}
