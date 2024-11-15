using Microsoft.AspNetCore.Mvc;
using FPT_JOBPORTAL.Models;
using Microsoft.AspNetCore.Authorization;
using FPT_JOBPORTAL.Repository.IRepository;

namespace FPT_JOBPORTAL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class JobSeekerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobSeekerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: JobSeeker
        public IActionResult Index()
        {
            var jobSeekerList = _unitOfWork.ApplicationUserRepository.GetAll(u => u.Role == "Job Seeker").ToList();
            return View(jobSeekerList);
        }

        // GET: JobSeeker/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Job Seeker ID is required.");
            }

            var jobSeeker = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            return View(jobSeeker);
        }

        // POST: JobSeeker/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationUser jobSeeker)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ApplicationUserRepository.Update(jobSeeker);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(jobSeeker);
        }

        // GET: JobSeeker/Delete/{id}
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Job Seeker ID is required.");
            }

            var jobSeeker = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            return View(jobSeeker);
        }

        // POST: JobSeeker/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string id)
        {
            var jobSeeker = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            _unitOfWork.ApplicationUserRepository.Delete(jobSeeker);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
