using AxosBlobLearning.Models;
using AxosBlobLearning.Services;
using Microsoft.AspNetCore.Mvc;

namespace AxosBlobLearning.Controllers
{
    public class ContainerController : Controller
    {
        private readonly IContainerService _containerService;

        public ContainerController(IContainerService containerService)
        {
            _containerService = containerService;
        }

        public async Task<IActionResult> Index()
        {
            var allContainer = await _containerService.GetAllContainers();
            return View(allContainer);
        }

        public async Task<IActionResult> Delete(string containerName)
        {
            await _containerService.DeleteContainer(containerName);
            TempData["success"] = "Container successfully deleted!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View(new Container());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Container container)
        {
            await _containerService.CreateContainer(container.Name);
            TempData["success"] = "Container successfully added!";
            return RedirectToAction(nameof(Index));
        }
    }
}
