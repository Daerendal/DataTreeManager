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
        public IActionResult Index(string usedSort)
        {
            var treeBranches = _db.TreeOrder.ToList();
            

            switch (usedSort)
            {
                case "name_desc":
                    treeBranches = treeBranches.OrderByDescending(s => s.Name).ToList();
                    break;
                case "name":
                    treeBranches = treeBranches.OrderBy(s => s.Name).ToList();
                    break;
                case "id":
                    treeBranches = treeBranches.OrderBy(s => s.IdTreeOrder).ToList();

                    break;
                case "id_desc":
                    treeBranches = treeBranches.OrderByDescending(s => s.IdTreeOrder).ToList();

                    break;
                default:
                    treeBranches = treeBranches.OrderBy(s => s.Name).ToList();
                    break;
            }


            return View(treeBranches);
        }
        public IActionResult Edit()
        {
            var treeBranches = _db.TreeOrder.ToList();

            BranchVM viewModel = new BranchVM();
            viewModel.allBranches = treeBranches;

            return View(viewModel);
        }

        public IActionResult CreateBranch(BranchVM branch, int branchId)
        {
            if (branch.Name != null)
            {
                TreeOrder newBranch = new TreeOrder();
                newBranch.Name = branch.Name;
                newBranch.IdParent = branchId;
                newBranch.Level = _db.TreeOrder.Where(x => x.IdTreeOrder.Equals(newBranch.IdParent)).Select(x => x.Level).Single() + 1;
                newBranch.Lineage = "";
                _db.TreeOrder.Add(newBranch);
                _db.SaveChanges();
            }
            return Redirect("Edit");
        }
        public IActionResult DeleteLeaf(int branchId)
        {
            var branch = _db.TreeOrder.Where(x => x.IdTreeOrder.Equals(branchId)).Single();

            _db.Remove(branch);

            _db.SaveChanges();

            return Redirect("Edit");
        }
        public IActionResult DeleteBranch(int branchId)
        {
            DeleteChild(branchId);

            _db.SaveChanges();

            return Redirect("Edit");
        }
        private void DeleteChild(int parentId)
        {
            var branch = _db.TreeOrder.Where(x => x.IdTreeOrder.Equals(parentId)).Single();
            var children = _db.TreeOrder.Where(x => x.IdParent.Equals(parentId)).ToList();

            
            foreach (var child in children)
            {
                DeleteChild(child.IdTreeOrder);
            }
            _db.Remove(branch);
        }

        public IActionResult EditBranch(BranchVM branch,int branchId)
        {
            if (branch.Name != null)
            {
                TreeOrder updateBranch = new TreeOrder();
                updateBranch.IdTreeOrder = branchId;
                updateBranch.Name = branch.Name;
                updateBranch.IdParent = _db.TreeOrder.Where(x => x.IdTreeOrder.Equals(branchId)).Select(x => x.IdParent).Single();
                updateBranch.Level = _db.TreeOrder.Where(x => x.IdTreeOrder.Equals(branchId)).Select(x => x.Level).Single();
                updateBranch.Lineage = "";
                _db.TreeOrder.Update(updateBranch);

                _db.SaveChanges();
            }
            return Redirect("Edit");
        }
        public IActionResult ChangeParent(BranchVM branch, int branchId, int IdParent)
        {
            if (_db.TreeOrder.Where(x=>x.IdTreeOrder.Equals(IdParent)).Any())
            {
                TreeOrder updateBranch = new TreeOrder();
                updateBranch.IdTreeOrder = branchId;
                updateBranch.Name = _db.TreeOrder.Where(x => x.IdTreeOrder.Equals(branchId)).Select(x => x.Name).Single();
                updateBranch.IdParent = IdParent;
                updateBranch.Level = _db.TreeOrder.Where(x => x.IdTreeOrder.Equals(IdParent)).Select(x => x.Level).Single() + 1;
                updateBranch.Lineage = "";
                _db.TreeOrder.Update(updateBranch);

                _db.SaveChanges();
            }
            return Redirect("Edit");
        }
    }
}
