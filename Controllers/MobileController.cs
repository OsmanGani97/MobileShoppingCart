using DMobileSite.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMobileSite.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class MobileController : Controller
    {
        private readonly IMobileRepository _mobileRepo;
        private readonly IBrandRepository _brandRepo;
        private readonly IFileService _fileService;

        public MobileController(IMobileRepository mobileRepo,IBrandRepository brandRepo, IFileService fileService)
        {
           _mobileRepo = mobileRepo;
            _brandRepo = brandRepo;
            _fileService = fileService;
        }



        public async Task<IActionResult> Index()
        {
            var mobiles = await _mobileRepo.GetMobiles();
            return View(mobiles);
        }
        public async Task<IActionResult> AddMobile()
        {
            var brandSelectList = (await _brandRepo.GetBrands()).Select(brand => new SelectListItem
            {
                Text = brand.BrandName,
                Value = brand.Id.ToString(),
            });
            MobileDTO mobileToAdd = new() { BrandList = brandSelectList };
            return View(mobileToAdd);
        }

        [HttpPost]
        public async Task<IActionResult> AddMobile(MobileDTO mobileToAdd)
        {
            var brandSelectList = (await _brandRepo.GetBrands()).Select(brand => new SelectListItem
            {
                Text = brand.BrandName,
                Value = brand.Id.ToString(),
            });
            mobileToAdd.BrandList = brandSelectList;

            if (!ModelState.IsValid)
                return View(mobileToAdd);

            try
            {
                if (mobileToAdd.ImageFile != null)
                {
                    if (mobileToAdd.ImageFile.Length > 1 * 1024 * 1024)
                    {
                        throw new InvalidOperationException("Image file can not exceed 1 MB");
                    }
                    string[] allowedExtensions = [".jpeg", ".jpg", ".png"];
                    string imageName = await _fileService.SaveFile(mobileToAdd.ImageFile, allowedExtensions);
                    mobileToAdd.Image = imageName;
                }
                
                Mobile mobile = new()
                {
                    Id = mobileToAdd.Id,
                    MobileName = mobileToAdd.MobileName,
                   
                    Image = mobileToAdd.Image,
                    Price=mobileToAdd.Price,
                    Stroage=mobileToAdd.Stroage,
                    Ram=mobileToAdd.Ram,
                    MainCamera=mobileToAdd.MainCamera,
                    ForntCamera=mobileToAdd.ForntCamera,
                    Display=mobileToAdd.Display,
                    Battery=mobileToAdd.Battery,
                    OperatingSystem=mobileToAdd.OperatingSystem,
                    BrandId=mobileToAdd.BrandId
                   
                };
                await _mobileRepo.AddMobile(mobile);
                TempData["successMessage"] = "Mobile is added successfully";
                return RedirectToAction(nameof(AddMobile));
            }
            catch (InvalidOperationException ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View(mobileToAdd);
            }
            catch (FileNotFoundException ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View(mobileToAdd);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error on saving data";
                return View(mobileToAdd);
            }
        }



        public async Task<IActionResult> UpdateMobile(int id)
        {
            var mobile = await _mobileRepo.GetMobileById(id);
            if (mobile == null)
            {
                TempData["errorMessage"] = $"Mobile with the id: {id} does not found";
                return RedirectToAction(nameof(Index));
            }
            var brandSelectList = (await _brandRepo.GetBrands()).Select(brand => new SelectListItem
            {
                Text = brand.BrandName,
                Value = brand.Id.ToString(),
                Selected = brand.Id == mobile.BrandId
            });
            MobileDTO mobileToUpdate = new()
            {
                BrandList = brandSelectList,
                MobileName = mobile.MobileName,

                Image = mobile.Image,
                Price = mobile.Price,
                Stroage = mobile.Stroage,
                Ram = mobile.Ram,
                MainCamera = mobile.MainCamera,
                ForntCamera = mobile.ForntCamera,
                Display = mobile.Display,
                Battery = mobile.Battery,
                OperatingSystem = mobile.OperatingSystem,
                BrandId = mobile.BrandId
            };
            return View(mobileToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMobile(MobileDTO mobileToUpdate)
        {
            var brandSelectList = (await _brandRepo.GetBrands()).Select(brand => new SelectListItem
            {
                Text = brand.BrandName,
                Value = brand.Id.ToString(),
                Selected = brand.Id == mobileToUpdate.BrandId
            });
            mobileToUpdate.BrandList = brandSelectList;

            if (!ModelState.IsValid)
                return View(mobileToUpdate);

            try
            {
                string oldImage = "";
                if (mobileToUpdate.ImageFile != null)
                {
                    if (mobileToUpdate.ImageFile.Length > 1 * 1024 * 1024)
                    {
                        throw new InvalidOperationException("Image file can not exceed 1 MB");
                    }
                    string[] allowedExtensions = [".jpeg", ".jpg", ".png"];
                    string imageName = await _fileService.SaveFile(mobileToUpdate.ImageFile, allowedExtensions);
                    // hold the old image name. Because we will delete this image after updating the new
                    oldImage = mobileToUpdate.Image;
                    mobileToUpdate.Image = imageName;
                }
                // manual mapping of BookDTO -> Book
                Mobile mobile = new()
                {
                    Id = mobileToUpdate.Id,
                    MobileName = mobileToUpdate.MobileName,

                    Image = mobileToUpdate.Image,
                    Price = mobileToUpdate.Price,
                    Stroage = mobileToUpdate.Stroage,
                    Ram = mobileToUpdate.Ram,
                    MainCamera = mobileToUpdate.MainCamera,
                    ForntCamera = mobileToUpdate.ForntCamera,
                    Display = mobileToUpdate.Display,
                    Battery = mobileToUpdate.Battery,
                    OperatingSystem = mobileToUpdate.OperatingSystem,
                    BrandId = mobileToUpdate.BrandId

                };
                await _mobileRepo.UpdateMobile(mobile);
                // if image is updated, then delete it from the folder too
                if (!string.IsNullOrWhiteSpace(oldImage))
                {
                    _fileService.DeleteFile(oldImage);
                }
                TempData["successMessage"] = "Book is updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View(mobileToUpdate);
            }
            catch (FileNotFoundException ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View(mobileToUpdate);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error on saving data";
                return View(mobileToUpdate);
            }
        }

        public async Task<IActionResult> DeleteMobile(int id)
        {
            try
            {
                var mobile = await _mobileRepo.GetMobileById(id);
                if (mobile == null)
                {
                    TempData["errorMessage"] = $"Mobile with the id: {id} does not found";
                }
                else
                {
                    await _mobileRepo.DeleteMobile(mobile);
                    if (!string.IsNullOrWhiteSpace(mobile.Image))
                    {
                        _fileService.DeleteFile(mobile.Image);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                TempData["errorMessage"] = ex.Message;
            }
            catch (FileNotFoundException ex)
            {
                TempData["errorMessage"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error on deleting the data";
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
