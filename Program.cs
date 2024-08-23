using Bookish;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

using (var context = new BookishDbContext())
{

    //creates db if not exists 
    context.Database.EnsureCreated();

    //create entity objects
    if (!context.Books.Any())
    {
        var author1 = new Author() { AuthorName = "Alen Timofeyev" };
        var book1 = new Book() { Title = "True&Me", Copies = 4, Author = author1 };
        var author2 = new Author() { AuthorName = "Homer" };
        var book2 = new Book() { Title = "Odyssey", Copies = 9, Author = author2 };
        var book3 = new Book() { Title = "Iliad", Copies = 7, Author = author2 };
        var author3 = new Author() { AuthorName = "Zerocalcare" };
        var book4 = new Book() { Title = "Dimentica il mio nome", Copies = 3, Author = author3 };

        //add entity to the context
        context.Books.Add(book1);
        context.Books.Add(book2);
        context.Books.Add(book3);
        context.Books.Add(book4);

        //save data to the database tables
        context.SaveChanges();

        //retrieve all the books from the database
        foreach (var b in context.Books)
        {
            Console.WriteLine($"Title: {b.Title}, Author: {b.Author}");
        }
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "catalogue",
    pattern: "{controller=Catalogue}/{action=BookList}/{id?}");

app.Run();
