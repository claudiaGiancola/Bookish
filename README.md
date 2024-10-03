# Bookish

Building a simple library-management system by designing, querying, and interfacing with databases.

### Dependencies

- Install PostgreSQL and pgAdmin

- Install Entity Framework Core:
  - `dotnet add package Microsoft.EntityFrameworkCore`
  * `dotnet add package Microsoft.EntityFrameworkCore.Design`
    - `dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL`
    - `dotnet add package Microsoft.EntityFrameworkCore.Tools` (to use EF Core Migrations API)
    * `dotnet add package Microsoft.EntityFrameworkCore.Relational`
  
- Run `dotnet tool install --global dotnet-ef` to allow you to run dotnet entity framework commands in your terminal


### Development

- Planning out the needed data models, tables and the program logic.
  Keep in mind that the librarian will need to:
  1. browse the catalogue of books > books sorting, search feature
  2. edit the catalogue of books > add a book, update a book's details, add copies of an existing book, delete copies of a book
  3. manage books > total number of copies, copies available, which users borrowed a certain copy
  4. manage members > list of members, borrowed books, add/edit/delete a member, checking books in/out, notification for late returns
 
- Implement first migration
  > `dotnet ef migrations add InitialMigrationName`
  > `dotnet ef database update`

- In pgAdmin, create a role ("Login/Group Roles") with the details in the connection string (username and password set to "bookish" + role has  “can login” and “create databases” privileges)
  
- In the controllers endpoints, use the DbContext to query the database for the needed data.
  Use a ViewModel to hold the data to be displayed.
