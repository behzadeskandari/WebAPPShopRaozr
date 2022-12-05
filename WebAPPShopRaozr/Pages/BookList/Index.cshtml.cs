using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPPShopRaozr.Data;
using WebAPPShopRaozr.Data.Model;

namespace WebAPPShopRaozr.Pages.BookList
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        
        [TempData]
        public string Message { get; set; }

        public IEnumerable<Book> Books { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        //public string SomeData { get; set; }

        public async Task OnGet()
        {
            //SomeData = "this is first Property";

            Books = await _db.Books.ToListAsync();

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Books.FindAsync(id);
            
            _db.Books.Remove(book);
        
            await _db.SaveChangesAsync();

            Message = "Book deleted successfully";

            return RedirectToPage("Index");
        }
    }
}
