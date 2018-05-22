using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_MVVM_Step_6.DataAccessLayer
{
    public class BookRepository
    {
        readonly Random random = new Random();
        readonly string[] titles = { "Harry Potter - Stein der Weisen", "Tom Turbo - Die Mumie", "Die drei ???", "Der Kleine Vampir", "C# für Dummys" };
        readonly string[] authors = { "Thomas Brezina", "Author Joggel", "Author Schnägg", "Tolkien", "Jolanda isch scholang da" };
        readonly double[] prices = { 123.45, 777.89, 1.1, 543.21, 9999.9 };

        public string GetRandomTitle()
        {
            return titles[random.Next(titles.Length)];
        }

        public string GetRandomAuthor()
        {
            return authors[random.Next(authors.Length)];
        }

        public double GetRandomPrice()
        {
            return prices[random.Next(prices.Length)];
        }
    }
}
