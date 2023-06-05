using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensions.Msal;
using StorageAPI.Models;
using StorageAPI.Services;

namespace StorageAPI.Controllers
{
    [Route("StorageAPI/[controller]")]
    [ApiController]
    public class StoragesController : Controller
    {
        private readonly IStorageService _storageService;
        public StoragesController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetStorages()
        {
            var storages = await _storageService.GetStoragesAsync();

            return Ok(storages);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStorage(uint id)
        {
            var storage = await _storageService.GetStorageAsync(id);
            if (storage == null)
            {
                return NotFound();
            }
            return Ok(storage);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateStorage(Models.Storage storageToCreate)
        {
            var storage = await _storageService.CreateStorageAsync(storageToCreate);
            if (storage == null)
            {
                return BadRequest();
            }
            return Ok(storage);
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> EditStorage(uint id, Models.Storage newStorageData)
        {
            var storage = await _storageService.EditStorageAsync(id, newStorageData);
            if (storage == null)
            {
                return BadRequest();
            }
            return Ok(storage);
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteStorage(uint id)
        {
            var storage = await _storageService.DeleteStorageAsync(id);
            if (storage == null)
            {
                return NotFound();
            }
            return Ok(storage);
        }
    }
}
