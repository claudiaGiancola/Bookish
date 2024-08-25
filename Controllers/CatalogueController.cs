using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Controllers;

public class CatalogueController : Controller
{

    private readonly BookishDbContext _context;

    public CatalogueController(BookishDbContext context)
    {
        _context = context;
    }

    // GET: /Catalogue/
    //same as GET: /Catalogue/BookList/
    public async Task<IActionResult> BookList()
    {
        var books = await _context.Books
            .Include(x=>x.Author)
            .ToListAsync();

        return View(books);
    }

    // GET: /Catalogue/BookDetails/{id}?book=title/ 
    public async Task<IActionResult> BookDetails(int? id = 1)
    {

        var book = _context.Books
            .Include(x=>x.Author)
            .FirstOrDefault(b => b.BookId == id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

}