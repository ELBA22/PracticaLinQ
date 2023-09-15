using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using PracticaLinQ.Entiies;
public class LinqQueries{
    List<Book> lstBooks = new List<Book>();

    public LinqQueries(){
        using(StreamReader reader = new StreamReader("books.json")){
            string json = reader.ReadToEnd();
            this.lstBooks = System.Text.Json.JsonSerializer
            .Deserialize<List<Book>>(json,new System.Text.Json.JsonSerializerOptions()
            {PropertyNameCaseInsensitive = true}) ?? new List<Book>();
            
        }
    }
public IEnumerable<Book> AllCollection(){
    return lstBooks;
}

public IEnumerable<Book> LibrosDespues2000(){
    //Extension method
    //return lstBooks.Where(book => book.PublishedDate.Year > 200);
    return from book in lstBooks where book.PublishedDate.Year >200 
    select book;
}


public IEnumerable<Book> LibrosDelYear(int year){
    //Extension method
    //return lstBooks.Where(book => book.PublishedDate.Year > 200);
    return from book in lstBooks where book.PublishedDate.Year == year 
    select book;
}

public IEnumerable<Book> LibrosAndroid(){
    return from book in lstBooks where book.Title.Contains("Android") 
    select book; 
}

public IEnumerable<Book> LibrosAndroid2005(){
    return from book in lstBooks where book.PublishedDate.Year >2005 && book.Title.Contains("Android") 
    select book;
}

public IEnumerable<Book> Libros250Pag(){
    return from book in lstBooks where book.PageCount  > 250 && book.Title.Contains("Action") 
    select book;
}


//Con el operador All
public bool verificarStatus(){
    return lstBooks.All(book => book.Status != String.Empty);
}


//Con el Operador Any
public bool ValidarFechaPub(){
    return lstBooks.Any(book => book.PublishedDate.Year == 2005);
}

// Operador Contains
public IEnumerable<Book> ConseguirLibros(){
    return lstBooks.Where(
        book => (book.Categories ?? Array.Empty<String>()).Contains("Python"));
}

//Operador OrderBy
public IEnumerable<Book> OrdenarLibros(){
    return lstBooks.Where(
        book => (book.Categories ?? Array.Empty<string>()).Contains("Java"))
    .OrderBy(book => book.Title);
}
//Operador OrderByDescending
public IEnumerable<Book> Libros450pag(){
    return lstBooks.Where(
        book => book.PageCount>450)
        .OrderByDescending(book => book.PageCount);
}

//Operador Take
public IEnumerable<Book> ObtenerLibrosTke(){
    return lstBooks
    .Where (book => (book.Categories ?? Array.Empty<String>()).Contains("Java"))
    .OrderByDescending(book => book.PublishedDate).Take(3);
}

//Muestre los ultimos tres libros.

public IEnumerable<Book> ObtenerLibrosTakeLast(){
    return lstBooks
    .Where (book => (book.Categories ?? Array.Empty<String>()).Contains("Java"))
    .OrderBy(book => book.PublishedDate).TakeLast(3);
}

}