using var context = new AppDbContext();

Console.Clear();
Console.WriteLine(context.Database.CanConnect()
? "it works"
: "it doesn't work");