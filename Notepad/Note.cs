using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public string Created { get; }
        public string Modified { get; set; }

        public Note(string title, string description, string content)
        {
            Title = title;
            Description = description;
            Content = content;

            Created = DateTime.Now.ToString();
        }

        public Note(string title, string description, string content, string created, string modified)
        {
            Title = title;
            Description = description;
            Content = content;
            Created = created;
            Modified = modified;
        }
    }
}