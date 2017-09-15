using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticDemo.Models
{
    public class BookViewModel
    {
        public string Id { get; set; }

        public string Ean { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public int Printed { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
