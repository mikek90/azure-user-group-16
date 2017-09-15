using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticDemo.Models
{
    public class BookSearchViewModel
    {
        public string Id { get; set; }
        public string Ean { get; set; }
        public string Title { get; set; }

        public string Highlights { get; set; }
        public double Score { get; set; }
    }
}
