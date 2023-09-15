using Newtonsoft;
using PracticaLinQ.Entiies;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        int?[] args2 = new int?[5];
        Console.WriteLine(args2[0]);
        LinqQueries queries = new LinqQueries();
       /*  imprimirValores(queries.AllCollection()); */
        /* imprimirValores(queries.LibrosAndroid()); */
        /* imprimirValores(queries.LibrosAndroid2005()); */
       /*  imprimirValores(queries.Libros250Pag()); */
        /* Console.WriteLine(queries.verificarStatus() ? "Todos los libros contienen un status" : "Al menos uno de los libros no contiene un status"); */
       /*  Console.WriteLine(queries.ValidarFechaPub());
        if (queries.ValidarFechaPub())
        {
            imprimirValores(queries.LibrosDelYear(2005));
        } else
        {
            Console.WriteLine("No hay libros con ese año");
        } */
       /*  imprimirValores(queries.ConseguirLibros()); */
       /* imprimirValores(queries.OrdenarLibros()); 
       /* imprimirValores(queries.Libros450pag()); */
        /* imprimirValores(queries.ObtenerLibrosTke()); */
    }
    
    
    private static void imprimirValores(IEnumerable<Book> books)
    {
        int registros = 0;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("{0,-70}{1,7}{2,20}", "Titulo", "N. Paginas", "fecha publicacion");
        foreach (Book book in books)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            registros += 1;
            Console.WriteLine("{0,-70}{1,7}{2,20}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
}