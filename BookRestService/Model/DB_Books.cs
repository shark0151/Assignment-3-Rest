using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibraryAssignemnt;

namespace BookRestService.Model
{
    public class DB_Books
    {
        public static List<Book> BookList = new List<Book>()
        {
            new Book("Bad Romance", "Beyonce", 223, "123456789123a"),
            new Book("The Super Man - An autobiography", "Alex", 999, "123456789123b"),
            new Book("How to meet girls", "Marcell", 12, "123456789123c"),
            new Book("Why MVVM is bad", "Bill Gates", 102, "123456789123d"),
            new Book("Lorem Ipsum", "Jim", 102, "123456789123f")

        };

        public static Book GetBook(string isbn13)
        {
            Book book = BookList.FirstOrDefault(b => b.Isbn == isbn13);
            return book;
        }




    }
}
