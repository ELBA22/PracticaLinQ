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


}