using models;
using System.Text.Json;

namespace queries
{
    public class LinqQueries {
        private List<Book> booksCollection = new List<Book>();
        public LinqQueries()
        {
            using(StreamReader reader = new StreamReader("books.json")) {
                string json = reader.ReadToEnd();
                this.booksCollection = 
                    JsonSerializer.Deserialize<List<Book>>(json)!;
            }
        }

        public IEnumerable<Book> GetAllCollection() => this.booksCollection;
    }    
}
