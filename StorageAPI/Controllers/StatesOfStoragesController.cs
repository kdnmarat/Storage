using Microsoft.AspNetCore.Mvc;
using StorageAPI.Models;
using StorageAPI.Services;

namespace StorageAPI.Controllers
{
    [Route("StorageAPI/[controller]")]
    [ApiController]
    public class StatesOfStoragesController : Controller
    {
        private readonly IStorageService _storageService;
        public StatesOfStoragesController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetStatesOfStorage()
        {
            var statesOfStorages = await _storageService.GetStatesOfStoragesAsync();

            return Ok(statesOfStorages);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStateOfStorage(uint id)
        {
            var stateOfStorage = await _storageService.GetStateOfStorageAsync(id);
            if (stateOfStorage == null)
            {
                return NotFound();
            }
            return Ok(stateOfStorage);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateStateOfStorage(StateOfStorage stateOfStorageToCreate)
        {
            var stateOfStorage = await _storageService.CreateStateOfStorageAsync(stateOfStorageToCreate);
            if (stateOfStorage == null)
            {
                return BadRequest();
            }
            return Ok(stateOfStorage);
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> EditStateOfStorage(uint id, StateOfStorage newStateOfStorageData)
        {
            var stateOfStorage = await _storageService.EditStateOfStorageAsync(id, newStateOfStorageData);
            if (stateOfStorage == null)
            {
                return BadRequest();
            }
            return Ok(stateOfStorage);
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteStateOfStorage(uint id)
        {
            var stateOfStorage = await _storageService.DeleteStateOfStorageAsync(id);
            if (stateOfStorage == null)
            {
                return NotFound();
            }
            return Ok(stateOfStorage);
        }
    }
}
