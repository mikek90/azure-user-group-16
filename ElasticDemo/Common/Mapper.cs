using ElasticDemo.BusinessLayer;
using ElasticDemo.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticDemo.Common
{
    public static class Mapper
    {
        public static BookViewModel MapBook(BookDTO bookDTO, IHit<BookDTO> hit = null)
        {
            var bookViewModel = new BookViewModel()
            {
                Ean = bookDTO.Ean,
                Title = bookDTO.Title,
                Abstract = bookDTO.Abstract,
                Printed = bookDTO.Printed,
                PublishDate = bookDTO.PublishDate
            };

            if (hit != null)
            {
                bookViewModel.Id = hit.Id;
            }

            return bookViewModel;
        }

        public static BookSearchViewModel MapBookSearch(BookDTO bookDTO, IHit<BookDTO> hit)
        {
            var bookSearchViewModel = new BookSearchViewModel()
            {
                Id = hit.Id,
                Ean = bookDTO.Ean,
                Title = bookDTO.Title,
                Highlights = string.Empty,
                Score = hit.Score.Value
            };


            int i = 0;
            var highlights = hit.Highlights["abstract"].Highlights;
            foreach (var highlight in highlights)
            {
                bookSearchViewModel.Highlights += $"{++i}. '{highlight.TrimStart(',').Trim()}'<br/>";
            }

            return bookSearchViewModel;
        }
    }
}
