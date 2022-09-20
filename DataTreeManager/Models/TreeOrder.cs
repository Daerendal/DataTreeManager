using System;
using System.Collections.Generic;

namespace DataTreeManager.Models
{
    public partial class TreeOrder
    {
        public int IdTreeOrder { get; set; }
        public string Name { get; set; } = null!;
        public string Lineage { get; set; } = null!;
        public int Level { get; set; }
        public int IdParent { get; set; }
    }
}
