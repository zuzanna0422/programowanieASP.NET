using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Movies;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private readonly MoviesContext _context;

        public MovieController(MoviesContext context)
        {
            _context = context;
            
        }
        
        // GET: Movie
        public IActionResult Index(int page = 1, int size = 10)
        {
            var contactsPage =_context.Movies
                    .OrderBy(b => b.Title)
                    .Skip((page - 1) * size)
                    .Take(size)
                .AsNoTracking()
                .ToList();
            
            int totalCount = _context.Movies.Count();
            return View( PagingListAsync<Movie>.Create(
                (p, s) => 
                    _context.Movies
                        .OrderBy(b => b.Title)
                        .Skip((p - 1) * s)
                        .Take(s)
                        .AsAsyncEnumerable(),
                _context.Movies.Count(),
                page,
                size));
        }
        

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Title,Budget,Homepage,Overview,Popularity,ReleaseDate,Revenue,Runtime,MovieStatus,Tagline,VoteAverage,VoteCount")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Title,Budget,Homepage,Overview,Popularity,ReleaseDate,Revenue,Runtime,MovieStatus,Tagline,VoteAverage,VoteCount")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
        public class PagingListAsync<T>
        {
            public IAsyncEnumerable<T> Data { get;  }
            public int TotalItems { get; }
            public int TotalPages { get; }
            public int Page { get; }
            public int Size { get; }
            public bool IsFirst { get; }
            public bool IsLast { get; }
            public bool IsNext { get; }
            public bool IsPrevious { get; }
            private PagingListAsync(Func<int, int, IAsyncEnumerable<T>> dataGenerator, int totalItems, int page, int size)
            {
                TotalItems = totalItems;
                Page = page;
                Size = size;
                TotalPages = CalcTotalPages(Page, TotalItems, Size);
                IsFirst = Page <= 1;
                IsLast = Page >= TotalPages;
                IsNext = !IsLast;
                IsPrevious = !IsFirst;
                Data = dataGenerator(Page, size);
            }
            public static PagingListAsync<T> Create(Func<int, int, IAsyncEnumerable<T>> data, int totalItems, int number, int size)
            {
                return new PagingListAsync<T>( data, totalItems, ClipPage(number, totalItems, size), Math.Abs(size));
            }

            private static int CalcTotalPages(int page, int totalItems, int size)
            {
                return totalItems / size + (totalItems % size > 0 ? 1 : 0);
            }
            private static int ClipPage(int page, int totalItems, int size)
            {
                int totalPages = CalcTotalPages(page, totalItems, size);
                if (page > totalPages)
                {
                    return totalPages;
                }
                if (page < 1)
                {
                    return 1;
                }
                return page;
            } 
        }
    }
}
