using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticDemo.BusinessLayer
{
    [ElasticsearchType(Name = "books")]
    public class BookDTO
    {
        [Text(Name = "ean")]
        public string Ean { get; set; }

        [Text(Name = "title")]
        public string Title { get; set; }

        [Text(Name = "abstract")]
        public string Abstract { get; set; }

        [Text(Name = "printed")]
        public int Printed { get; set; }

        [Text(Name = "publish_date")]
        public DateTime PublishDate { get; set; }
    }
}
