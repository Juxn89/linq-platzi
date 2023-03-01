using models;
using queries;
using System.Linq;

LinqQueries queries = new LinqQueries();

var allBookCollection = queries.GetAllCollection();
PrintCollection(allBookCollection);

Console.WriteLine("\n");
Console.WriteLine("**************** Books published after 2000 ****************");
var booksPublishedAfter2000 = queries.GetBooksPublishedAfter2000();
PrintCollection(booksPublishedAfter2000);

Console.WriteLine("\n");
Console.WriteLine("**************** Books published after 2000 (Query Expresion) ****************");
var booksPublishedAfter2000_QueryExpresion = queries.GetBooksPublishedAfter2000_QueryExpresion();
PrintCollection(booksPublishedAfter2000_QueryExpresion);

Console.WriteLine("\n");
Console.WriteLine("**************** Books filtered by pages and title ****************");
var booksFilteredByPagesAndTitle = queries.GetBooksByPagesAndTitle();
PrintCollection(booksFilteredByPagesAndTitle);

Console.WriteLine("\n");
Console.WriteLine("**************** Animals where color is green and name begins with a vowel ****************");
var animalFiltered = queries.GetAnimalsByColorAndName();

Console.WriteLine("\n");
Console.WriteLine("{0, 40} {1, 9}", "Name", "Color");
Console.WriteLine("\n");
foreach (var animal in animalFiltered)
{    
    Console.WriteLine("{0, 40} {1, 9}", animal.Nombre, animal.Color);
}

Console.WriteLine("\n");
Console.WriteLine("**************** All books have status ****************");
var booksStatus = queries.haveStatusAllBooks() ? "Yes" : "No";
Console.Write($"Have all books status? { booksStatus }");

Console.WriteLine("\n");
Console.WriteLine("**************** Book published in 2005 ****************");
var bookPublishedIn2005 = queries.anyBookPublishedIn2005() ? "Yes" : "No";
Console.Write($"Is there any book published in 2005? { bookPublishedIn2005 }");



void PrintCollection(IEnumerable<Book> booksCollection) {
    Console.WriteLine("\n");
    Console.WriteLine("{0, -60} {1, 9} {2, 11}", "Tile", "T. Pages", "Published Date");
    Console.WriteLine("\n");

    foreach(var book in booksCollection) {        
        Console.WriteLine("{0, -60} {1, 9} {2, 11}", book.title, book.pageCount, book.publishedDate.ToShortDateString());
    }
}
