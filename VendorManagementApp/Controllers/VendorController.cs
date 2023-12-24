using Microsoft.AspNetCore.Mvc;
using VendorManagementApp.DAL.Interface;
using VendorManagementApp.Models;

namespace VendorManagementApp.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorInterface _vendorRepository;

        public VendorController(IVendorInterface vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        // GET: /Vendor/Index
        public IActionResult Index()
        {
            var vendors = _vendorRepository.GetAllVendors();
            return View(vendors);
        }

        // GET: /Vendor/Details/{id}
        public IActionResult Details(int id)
        {
            var vendor = _vendorRepository.GetVendorById(id);

            if (vendor == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(vendor);
        }

        // GET: /Vendor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Vendor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _vendorRepository.AddVendor(vendor);
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: /Vendor/Edit/{id}
        public IActionResult Edit(int id)
        {
            var vendor = _vendorRepository.GetVendorById(id);

            if (vendor == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(vendor);
        }

        // POST: /Vendor/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendor updatedVendor)
        {
            if (id != updatedVendor.VendorId)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _vendorRepository.UpdateVendor(updatedVendor);
                }
                catch (ArgumentException)
                {
                    return NotFound(); // 404 Not Found
                }

                return RedirectToAction("Index");
            }

            return View(updatedVendor);
        }

        // GET: /Vendor/Delete/{id}
        public IActionResult Delete(int id)
        {
            var vendor = _vendorRepository.GetVendorById(id);

            if (vendor == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(vendor);
        }

        // POST: /Vendor/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deletedVendor = _vendorRepository.DeleteVendor(id);

            if (deletedVendor == null)
            {
                return NotFound(); // 404 Not Found
            }

            return RedirectToAction("Index");
        }
    }
}
