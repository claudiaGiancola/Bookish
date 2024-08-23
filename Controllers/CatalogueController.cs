using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using System.Text.Encodings.Web;

namespace Bookish.Controllers;

public class CatalogueController : Controller
{
    
    // GET: /Catalogue/
    //same as GET: /Catalogue/BookList/
    public IActionResult BookList()
    {
        return View();
    }
    // 
    // GET: /Catalogue/BookDetails/{id}?book=title/ 
    public IActionResult BookDetails(int id = 1, string book = "True and Me")
    {
        // return HtmlEncoder.Default.Encode($"Show the details for the book {book} of id {id}");

        return View();
    }

}