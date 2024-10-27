using Library.API.DB;
using Library.API.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryDB>(Options=>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("mainDB"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapPost("/books/add",(LibraryDB db,Book book)=>
{
    db.Books.Add(book);
    db.SaveChanges();
});
app.MapGet("/books/list",(LibraryDB db)=>
{
    return db.Books.ToList();
});
app.MapPost("/books/update",(LibraryDB db,Book book)=>
{
    db.Books.Add(book);
    db.SaveChanges();
});
app.MapPost("/books/remove/{id}",(LibraryDB db,int id)=>
{
    var book=db.Books.Find(id);
    if (book!=null)
    {
        db.Books.Remove(book);
        db.SaveChanges();
    }
});
app.MapPost("/members/add",(LibraryDB db,Member member)=>
{
    db.Members.Add(member);
    db.SaveChanges();
});
app.MapGet("/members/list",(LibraryDB db)=>
{
    return db.Members.ToList();
});
app.MapPost("/members/update",(LibraryDB db,Member member)=>
{
    db.Members.Update(member);
    db.SaveChanges();
});
app.MapPost("/members/remove/{id}",(LibraryDB db,int id)=>
{
    var member=db.Members.Find(id);
    if (member!=null)
    {
        db.Members.Remove(member);
        db.SaveChanges();
    }
});
app.MapPost("/rents/add",(LibraryDB db,Rent rent)=>
{
    db.Rents.Add(rent);
    db.SaveChanges();
});
app.MapGet("/rents/list",(LibraryDB db)=>
{
    return db.Rents.ToList();
});
app.MapPost("/rents/update",(LibraryDB db,Rent rent)=>
{
    db.Rents.Update(rent);
    db.SaveChanges();
});
app.MapPost("/rents/remove/{id}",(LibraryDB db,int id)=>
{
    var rent=db.Rents.Find(id);
    if (rent!=null)
    {
        db.Rents.Remove(rent);
        db.SaveChanges();
    }
});
app.Run();
