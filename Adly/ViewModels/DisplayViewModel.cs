using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Adly.Models;

namespace Adly.ViewModels
{
    public class DisplayViewModel
    {
        public Advertisement Advertisement { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public Comment Comment { get; set; }

        public DisplayViewModel(Advertisement advertisement, IEnumerable<Comment> comments, Comment comment)
        {
            Advertisement = advertisement;
            Comments = comments;
            Comment = comment;
        }
    }
}