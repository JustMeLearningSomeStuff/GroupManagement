using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlayBall.GroupManagement.Web.Models;

namespace PlayBall.GroupManagement.Web.Controllers
{
    [Route("groups")]
    public class GroupsController : Controller {
        private static List<GroupViewModel> groups = new List<GroupViewModel>
        {
            new GroupViewModel
            {
                Id = 1,
                Name = "First Group"
            }
        };
        private static long currentGroupId = 1;

        [HttpGet]
        [Route("")]
        public IActionResult Index() {
            return View(groups);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(long id) {
            var group = groups.SingleOrDefault(x => x.Id == id);

            if (group is null) {
                return NotFound();
            }

            return View(group);
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, GroupViewModel model) {
            var group = groups.SingleOrDefault(x => x.Id == id);

            if (group is null) {
                return NotFound();
            }

            group.Name = model.Name;

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
            model.Id = ++currentGroupId;
            groups.Add(model);

            return RedirectToAction("Index");
        }
    }
}