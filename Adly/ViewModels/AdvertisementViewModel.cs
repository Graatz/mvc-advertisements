using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Adly.Models;

namespace Adly.ViewModels
{
    public class AdvertisementViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Advertisement Advertisement { get; set; }

        public AdvertisementViewModel(IEnumerable<Category> categories, Advertisement advertisement)
        {
            Categories = categories;
            Advertisement = advertisement;
        }
    }
}