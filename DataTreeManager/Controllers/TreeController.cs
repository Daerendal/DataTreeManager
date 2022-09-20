using DataTreeManager.Models;
using DataTreeManager.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataTreeManager.Controllers
{
    public class TreeController : Controller
    {
        private readonly ILogger<TreeController> _logger;
        private readonly bqclkdz7sje0guv8qeipContext _db;

        public TreeController(ILogger<TreeController> logger, bqclkdz7sje0guv8qeipContext db)
        {
            _logger = logger;
            _db = db;
        }  
        public IActionResult Index()
        {
            var treeBranches = _db.TreeOrder.ToList();


            return View(treeBranches);
        }
        public IActionResult Edit()
        {
            var treeBranches = _db.TreeOrder.ToList();

            BranchVM viewModel = new BranchVM();
            viewModel.allBranches = treeBranches;

            return View(viewModel);
        }

        public IActionResult CreateBranch(BranchVM branch)
        {
            TreeOrder newBranch = new TreeOrder();
            newBranch.Name = branch.Name;
            newBranch.IdParent = branch.IdParent;
            newBranch.Level = _db.TreeOrder.Where(x => x.IdTreeOrder.Equals(newBranch.IdParent)).Select(x => x.Level).Single() +1;
            newBranch.Lineage = "";
            _db.TreeOrder.Add(newBranch);
            _db.SaveChanges();

            return Redirect("Edit");
        }
        public IActionResult DeleteBranch(int branchId)
        {
            var branch = _db.TreeOrder.Where(x => x.IdTreeOrder.Equals(branchId)).Single();

            _db.Remove(branch);

            _db.SaveChanges();

            return Redirect("Edit");
        }
        async public Task<IActionResult> EditBranch(BranchVM branch,int branchId)
        {
            TreeOrder updateBranch = new TreeOrder();
            updateBranch.IdTreeOrder = branchId;
            updateBranch.Name = branch.Name;
            updateBranch.IdParent = _db.TreeOrder.Where(x => x.IdTreeOrder.Equals(branchId)).Select(x => x.IdParent).Single();
            updateBranch.Level = _db.TreeOrder.Where(x => x.IdTreeOrder.Equals(branchId)).Select(x => x.Level).Single();
            updateBranch.Lineage = "";
            _db.TreeOrder.Update(updateBranch);

            _db.SaveChanges();
            return Redirect("Edit");
        }
    }
}
