using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebAPI.Repository.EF
{
    public class MyContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Thư mục hiện tại làm thư mục gốc WebCore.Data
                .AddJsonFile("appsettings.json") // Add file này vào
                .Build();

            var connetionString = configuration.GetConnectionString("DefaultConnectionString");
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connetionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}