using Projet_EBook.Models;
using Microsoft.EntityFrameworkCore;
namespace Projet_EBook.Data
{
    public class EbookDBContext:DbContext
    {
        public EbookDBContext(DbContextOptions<EbookDBContext> options) : base(options)
        {

        }
        public DbSet<EBook> Ebooks { get; set; }
    }
}
