using models;
using System.Text.Json;

namespace queries
{
    public class LinqQueries {
        private List<Book> booksCollection = new List<Book>();

        private List<Animal> animals = new List<Animal>();
        public LinqQueries()
        {
            using(StreamReader reader = new StreamReader("books.json")) {
                string json = reader.ReadToEnd();
                this.booksCollection = 
                    JsonSerializer.Deserialize<List<Book>>(json)!;
            }

            animals.Add(new Animal() { Nombre = "Hormiga", Color = "Rojo" });
            animals.Add(new Animal() { Nombre = "Lobo", Color = "Gris" });
            animals.Add(new Animal() { Nombre = "Elefante", Color = "Gris" });
            animals.Add(new Animal() { Nombre = "Pantegra", Color = "Negro" });
            animals.Add(new Animal() { Nombre = "Gato", Color = "Negro" });
            animals.Add(new Animal() { Nombre = "Iguana", Color = "Verde" });
            animals.Add(new Animal() { Nombre = "Sapo", Color = "Verde" });
            animals.Add(new Animal() { Nombre = "Camaleon", Color = "Verde" });
            animals.Add(new Animal() { Nombre = "Gallina", Color = "Blanco" });
        }

        public IEnumerable<Book> GetAllCollection() => this.booksCollection;

        public IEnumerable<Book> GetBooksPublishedAfter2000 () {
            // Extension method
            return this.booksCollection.Where(b => b.publishedDate.Year > 2000);
        }

        public IEnumerable<Book> GetBooksPublishedAfter2000_QueryExpresion () {
            var _books = from books in booksCollection
                        where books.publishedDate.Year > 2000
                        select books;
            return _books;
        }

        public IEnumerable<Book> GetBooksByPagesAndTitle() {
            return this.booksCollection
                    .Where(book => 
                        book.pageCount > 250 && 
                        book.title.ToLower().Contains("in action"));
        }

        public IEnumerable<Animal> GetAnimalsByColorAndName() {
            string[] vowels = { "a", "e", "i", "o", "u" };
            return this.animals
                    .Where(a => 
                        a.Color == "Verde" &&
                        vowels.Contains(a.Nombre.Substring(0,1).ToLower())
                    );
        }

        public bool haveStatusAllBooks() {
            // Si todos los elementos cumplen la condición
            return this.booksCollection.All(a => a.status != string.Empty);
        }

        public bool anyBookPublishedIn2005() {
            // Si algún libro cumple la condición
            return this.booksCollection.Any(a => a.publishedDate.Year == 2005);
        }

        public IEnumerable<Book> GetPythonBooks() {
            return this.booksCollection.Where(book => book.categories.Contains("Python"));
        }

        public IEnumerable<Book> GetThirdAndFourthBooksOver400Pages() {
            return this.booksCollection
                        .Where(b => b.pageCount > 400)
                        .Take(4)
                        .Skip(2);
        }
    }    
}