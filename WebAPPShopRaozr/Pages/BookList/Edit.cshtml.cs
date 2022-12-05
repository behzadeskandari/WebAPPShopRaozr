using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebAPPShopRaozr.Data;
using WebAPPShopRaozr.Data.Model;

namespace WebAPPShopRaozr.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }
        public void OnGet(int id)
        {
            Book = _db.Books.Find(id);
        
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = _db.Books.Find(Book.Id);
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Author = Book.Author;
                BookFromDb.Name = Book.Name;

                await _db.SaveChangesAsync();
                Message = "Book Has Benn Updated Successfully";
                return RedirectToPage("Index");
            }


            return RedirectToPage();
        }

    }
}
