using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
.AddUserSecrets<Program>()
.Build();

var connectionString = config.GetConnectionString("FlashCards")
?? throw new InvalidOperationException("Connection string 'Flashcards' missing");

var options = new DbContextOptionsBuilder<AppDbContext>()
.UseSqlServer(connectionString)
.Options;

using var context = new AppDbContext(options);

Console.Clear();
Console.WriteLine(context.Database.CanConnect()
? "it works"
: "it doesn't work");