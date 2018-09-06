using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLunchAndLearnDbFirst.DataAccess
{
    public partial class Drawers
    {
        public Drawers()
        {
            Folders = new HashSet<Folders>();
        }

        [Key]
        public int DrawerId { get; set; }
        public string DrawerDescription { get; set; }
        public string DrawerName { get; set; }

        public ICollection<Folders> Folders { get; set; }
    }
}
