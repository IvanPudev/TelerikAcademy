using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Data
{
    public class Bookstore
    {
        //Task 3. Simple add of books
        public static void AddBook(string authorName, string title, string isbn, string price, string webSite)
        {
            BookstoreEntities context = new BookstoreEntities();

            Book book = new Book();
            if (authorName == null)
            {
                throw new ArgumentNullException();
            }
            book.Authors.Add(CreateOrUpdate(context, authorName));

            if (title == null)
            {
                throw new ArgumentNullException();
            }
            book.Title = title;

            book.ISBN = isbn;
            if (price != null)
            {
                book.Price = decimal.Parse(price);
            }
            else
            {
                book.Price = 0;
            }
            book.WebSite = webSite;
            context.Books.Add(book);
            context.SaveChanges();
        }

        public static Author CreateOrUpdate(BookstoreEntities context, string author)
        {
            Author authorCheck = (from a in context.Authors
                                  where a.Name == author
                                  select a).FirstOrDefault();

            if (authorCheck != null)
            {
                return authorCheck;
            }

            Author newAuthor = new Author();
            newAuthor.Name = author;

            context.Authors.Add(newAuthor);
            return newAuthor;
        }

        //Task 4. Complex adding of books
        public static void ReadComplexEntry(string authorName, string title, 
            string isbn, string price, string webSite, string review)
        {
            
        }

        //Task 5. Simple search by author, name or ISBN
        public static IList<Book> FindBooksByAuthorNameOrIsbn(
            string authorName, string name, string isbn)
        {
            BookstoreEntities context = new BookstoreEntities();
            var bookQuery =
                from b in context.Books
                select b;
            if (authorName != null)
            {
                bookQuery =
                    from b in context.Books
                    where b.Authors.Equals(authorName)
                    select b;
            }
            if (name != null)
            {
                bookQuery = bookQuery.Where(
                    b => b.Title.Any(t => t.Equals(name)));
            }
            if (isbn != null)
            {
                bookQuery = bookQuery.Where(
                    x => x.ISBN.Equals(isbn));
            }
            bookQuery = bookQuery.OrderBy(b => b.Title);

            return bookQuery.ToList();
        }
    }
}
