using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPT_JOBPORTAL;
using FPT_JOBPORTAL.Data;
using Microsoft.AspNetCore.Authorization;

namespace FPT_JOBPORTAL.Controllers
{
    [Authorize(Roles = "Job Seeker, Admin, Employer")]

    public class ApplicationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ApplicationController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var application = _context.Application.Include(a => a.Job);
            return View(await application.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .Include(a => a.Job)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        public IActionResult Create()
        {
            ViewData["JobId"] = new SelectList(_context.JobModel, "Id", "NameJob");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,Phone,Education,JobId,Resume,Status")] Application application)
        {
            if (ModelState.IsValid)
            {
                IFormFile Resume = Request.Form.Files["Resume_file"];
                string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string resumePath = Path.Combine(wwwRootPath, @"pdf/Resume");
                if (Resume != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Resume.FileName);
                    using (var fileStream = new FileStream(Path.Combine(resumePath, fileName), FileMode.Create))
                    {
                        Resume.CopyTo(fileStream);
                    }
                    application.Resume = fileName;
                }
                application.Status = Status.Pending;
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobId"] = new SelectList(_context.JobModel, "Id", "NameJob", application.JobId);
            return View(application);
        }
        public async Task<IActionResult> ViewResume(int id)
        {
            var application = await _context.Application.FindAsync(id);
            if (application == null || string.IsNullOrEmpty(application.Resume))
            {
                return NotFound("Resume not found.");
            }

            // Đường dẫn tới file resume
            string resumePath = Path.Combine(_webHostEnvironment.WebRootPath, "pdf/Resume", application.Resume);

            // Kiểm tra xem file có tồn tại không
            if (!System.IO.File.Exists(resumePath))
            {
                return NotFound("Resume file not found.");
            }

            // Trả về view để hiển thị resume
            return View(application);
        }
        public IActionResult GetResume(string fileName)
        {
            // Đường dẫn đến thư mục chứa file PDF
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "pdf/Resume", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var mimeType = "application/pdf";

            return File(fileBytes, mimeType, fileName);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Application.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.JobModel, "Id", "NameJob", application.JobId);
            return View(application);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,Phone,Education,JobId,Resume,Status")] Application application)
        {
            if (id != application.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingApplication = await _context.Application.FindAsync(id);
                    if (existingApplication == null)
                    {
                        return NotFound();
                    }

                    IFormFile Resume_file = Request.Form.Files["resume_file"];
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string resumePath = Path.Combine(wwwRootPath, @"pdf/Resume");
                    if (Resume_file != null)
                    {
                        if (!string.IsNullOrEmpty(application.Resume))
                        {
                            string oldResumePath = Path.Combine(wwwRootPath, "pdf/Resume", application.Resume);
                            // Console.WriteLine("Old resume path: " + oldResumePath);
                            FileInfo fileInfo = new FileInfo(oldResumePath);
                            if (fileInfo.Exists)
                            {
                                fileInfo.Delete();
                            }
                        }

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Resume_file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(resumePath, fileName), FileMode.Create))
                        {
                            Resume_file.CopyTo(fileStream);
                        }
                        application.Resume = fileName;
                    }
                    else
                    {
                        application.Resume = existingApplication.Resume;
                    }

                    // Preserve the existing status if not provided in the form
                    if (application.Status == null)
                    {
                        application.Status = existingApplication.Status;
                    }

                    _context.Entry(existingApplication).CurrentValues.SetValues(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.Id))
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
            ViewData["JobId"] = new SelectList(_context.JobModel, "Id", "NameJob", application.JobId);
            return View(application);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .Include(a => a.Job)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.Application.FindAsync(id);
            if (application != null)
            {
                _context.Application.Remove(application);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(int id)
        {
            return _context.Application.Any(e => e.Id == id);
        }

        public IActionResult ViewResume(string resume)
        {
            if (string.IsNullOrWhiteSpace(resume) || resume.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                return BadRequest("Invalid file name.");
            }

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "pdf/Resume", resume);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            try
            {
                return PhysicalFile(filePath, "application/pdf");
            }
            catch (Exception ex)
            {
                // Log the exception
                // _logger.LogError(ex, "Error while retrieving resume file.");

                return StatusCode(500, "An error occurred while retrieving the file.");
            }
        }

    }
}
