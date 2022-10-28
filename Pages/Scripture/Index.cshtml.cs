using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages_Scripture
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;
        

        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        public SelectList ? Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ? ScriptureBook { get; set; }


        public async Task OnGetAsync()
        {
             // Use LINQ to get list of genres.
            IQueryable<string> booksQuery = from m in _context.Scripture
                                    orderby m.Book
                                    select m.Book;
            var scrip = from s in _context.Scripture
                 select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scrip = scrip.Where(s => s.Notes.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scrip = scrip.Where(x => x.Book == ScriptureBook);
            }
            Books = new SelectList(await booksQuery.Distinct().ToListAsync());
            Scripture = await scrip.ToListAsync();
        }
    }
}
