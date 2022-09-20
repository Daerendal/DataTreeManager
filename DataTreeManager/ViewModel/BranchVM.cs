using DataTreeManager.Models;

namespace DataTreeManager.ViewModel
{
    public class BranchVM
    {
        public string Name { get; set; }
        public string Lineage { get; set; }
        public int IdParent { get; set; }

        public List<TreeOrder> allBranches { get; set; } = new List<TreeOrder>();
    }
}
