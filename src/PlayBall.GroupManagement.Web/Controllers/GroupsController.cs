using Microsoft.AspNetCore.Mvc;
using PlayBall.GroupManagement.Business.Services;
using PlayBall.GroupManagement.Web.Mappings;
using PlayBall.GroupManagement.Web.Models;

namespace PlayBall.GroupManagement.Web.Controllers
{
    [Route("groups")]
    public class GroupsController : Controller 
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService) => _groupService = groupService;

        [HttpGet]
        [Route("")]
        public IActionResult Index() 
        {
            return View(_groupService.GetAll().ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(long id) 
        {
            var group = _groupService.GetById(id);

            if (group is null) {
                return NotFound();
            }

            return View(group.ToViewModel());
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, GroupViewModel model) 
        {
            var group = _groupService.Update(model.ToServiceModel());

            if (group is null) {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateGroup(GroupViewModel model)
        {
            _groupService.Add(model.ToServiceModel());

            return RedirectToAction("Index");
        }
    }
}