using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
    [Authorize(Policy = "ADM")]
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _database;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PropertiesController(ApplicationDbContext database, IWebHostEnvironment webHostEnvironment) {
            _database = database;
            _webHostEnvironment = webHostEnvironment;
        }

        private string[] UploadFile(List<IFormFile> Images) {
            List<string> fileNames = new List<string>();
            if (Images.Count() != 0) {
                foreach (var image in Images) {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "PropImages");
                    string file = Guid.NewGuid().ToString() + "-" + image.FileName;
                    fileNames.Add(file);
                    string filePath = Path.Combine(uploadDir, file);
                    using (var fileStream = new FileStream(filePath, FileMode.Create)) {
                        image.CopyTo(fileStream);
                    }
                }
            }
            return fileNames.ToArray();
        }

        [HttpPost]
        public IActionResult Save(PropertyDTO tempProperty) {
            if (ModelState.IsValid) {
                string[] stringFileNames = UploadFile(tempProperty.Images);

                Property property = new Property();
                property.Category = _database.Categories.First(cat => cat.Id == tempProperty.CategoryId);
                property.Business = _database.Businesses.First(bus => bus.Id == tempProperty.BusinessId);
                property.District = _database.Districts.First(dist => dist.Id == tempProperty.DistrictId);
                property.Address = tempProperty.Address;
                property.Rooms = (int) tempProperty.Rooms;
                property.Images = stringFileNames;
                _database.Properties.Add(property);
                _database.SaveChanges();
                return RedirectToAction("Properties", "Admin");
            } else {
                ViewBag.Categories = _database.Categories.ToList();
                ViewBag.Businesses = _database.Businesses.ToList();
                ViewBag.States = _database.States.ToList();
                return View("../Admin/NewProperty");
            }
        }

        [HttpPost]
        public IActionResult Edit(PropertyEditDTO tempProperty) {
            if (ModelState.IsValid) {
                string[] stringFileNames = null;

                if (tempProperty.Images != null) {
                    stringFileNames = UploadFile(tempProperty.Images);
                }

                var property = _database.Properties.First(prop => prop.Id == tempProperty.Id);
                property.Category = _database.Categories.First(cat => cat.Id == tempProperty.CategoryId);
                property.Business = _database.Businesses.First(bus => bus.Id == tempProperty.BusinessId);
                property.District = _database.Districts.First(dist => dist.Id == tempProperty.DistrictId);
                property.Address = tempProperty.Address;
                property.Rooms = (int) tempProperty.Rooms;
                if (stringFileNames != null) {
                    property.Images = stringFileNames;
                }
                _database.SaveChanges();
                return RedirectToAction("Properties", "Admin");
            } else {
                ViewBag.Categories = _database.Categories.ToList();
                ViewBag.Businesses = _database.Businesses.ToList();
                ViewBag.States = _database.States.ToList();
                ViewBag.CitiesByState = _database.Cities.Where(city => city.State.Id == tempProperty.StateId).ToList();
                ViewBag.DistrictsByCity = _database.Districts.Where(dist => dist.City.Id == tempProperty.CityId).ToList();
                return View("../Admin/EditProperty");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            if (id > 0) {
                try {
                    var property = _database.Properties.First(prop => prop.Id == id);
                    _database.Remove(property);
                    _database.SaveChanges();
                } catch (Exception) {
                    TempData["Error"] = true;
                }
            }
            return RedirectToAction("Properties", "Admin");
        }
    }
}