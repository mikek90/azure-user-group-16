using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nest;
using ElasticDemo.Models;
using ElasticDemo.BusinessLayer;
using ElasticDemo.Common;

namespace ElasticDemo.Controllers
{
    public class ElasticController : Controller
    {
        Uri node;
        ConnectionSettings settings;
        ElasticClient client;

        public ElasticController()
        {
            node = new Uri(address);
            settings = new ConnectionSettings(node);
            settings.DefaultIndex("bookstore");
            client = new ElasticClient(settings);
        }

        public IActionResult Index()
        {
            var books = client.Search<BookDTO>();
            var results = new List<BookViewModel>();

            for (int i = 0; i < books.Documents.Count; i++)
            {
                var document = books.Documents.ElementAt(i);
                var hit = books.Hits.ElementAt(i);

                results.Add(Mapper.MapBook(document, hit));
            }

            return View(results);
        }

        public IActionResult Details(string ean)
        {
            var books = client.Search<BookDTO>(s => s.Query(q => q.Term(t => t.Ean, ean)));
            var result = Mapper.MapBook(books.Documents.Single(), books.Hits.Single());

            return View(result);
        }

        public IActionResult Search(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return View();
            }

            List<BookSearchViewModel> results = new List<BookSearchViewModel>();

            var books = client.Search<BookDTO>(s => s
            .Query(q => q.Match(m => m.Field(f => f.Abstract).Query(text)))
            .Highlight(h => h.PreTags("<mark>").PostTags("</mark>").Fields(fs => fs.Field(a => a.Abstract))));

            for (int i = 0; i < books.Documents.Count; i++)
            {
                var document = books.Documents.ElementAt(i);
                var hit = books.Hits.ElementAt(i);

                results.Add(Mapper.MapBookSearch(document, hit));
            }

            return View(results);
        }

        #region Connection settings
        private string address = @"http://localhost:9200";
        #endregion
    }
}