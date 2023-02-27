using models;
using queries;
using System.Linq;

LinqQueries queries = new LinqQueries();

var allBookCollection = queries.GetAllCollection();
PrintCollection(allBookCollection);

void PrintCollection(IEnumerable<Book> booksCollection) {
    Console.WriteLine("\n");
    Console.WriteLine("{0, -60} {1, 9} {2, 11}", "Tile", "T. Pages", "Published Date");
    Console.WriteLine("\n");

    foreach(var book in booksCollection) {        
        Console.WriteLine("{0, -60} {1, 9} {2, 11}", book.title, book.pageCount, book.publishedDate.ToShortDateString());
    }
}
