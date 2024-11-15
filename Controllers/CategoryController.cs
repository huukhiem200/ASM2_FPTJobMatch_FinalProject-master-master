using FPT_JOBPORTAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPT_JOBPORTAL;
using FPT_JOBPORTAL.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FPT_JOBPORTAL.Controllers
{
    [Authorize(Roles = "Admin, Employer")]

    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Only display approved categories
            var approvedCategories = await _context.CategoryModel
                .Where(c => c.Status == CategoryStatus.Active)
                .ToListAsync();

            return View(approvedCategories);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.CategoryModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        public IActionResult Create()
        {
            return View();

        }
        [Authorize(Roles = "Employer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Status")] CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                categoryModel.Status = CategoryStatus.Pending; // Đặt trạng thái là đang chờ phê duyệt
                _context.Add(categoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PendingCategories()
        {
            var pendingCategories = await _context.CategoryModel
                .Where(c => c.Status == CategoryStatus.Pending)
                .ToListAsync();

            return View(pendingCategories);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveCategory(int id)
        {
            var category = await _context.CategoryModel.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.Status = CategoryStatus.Active;
            _context.Update(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(PendingCategories));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectCategory(int id)
        {
            var category = await _context.CategoryModel.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.Status = CategoryStatus.Denied;
            _context.Update(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(PendingCategories));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Status")] CategoryModel categoryModel)
        {
            if (id != categoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryModelExists(categoryModel.Id))
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
            return View(categoryModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.CategoryModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryModel = await _context.CategoryModel.FindAsync(id);
            if (categoryModel != null)
            {
                _context.CategoryModel.Remove(categoryModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryModelExists(int id)
        {
            return _context.CategoryModel.Any(e => e.Id == id);
        }
    }
}
