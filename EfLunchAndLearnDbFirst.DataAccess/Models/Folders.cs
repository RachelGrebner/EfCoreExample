using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLunchAndLearnDbFirst.DataAccess
{
    public partial class Folders
    {
        public Folders()
        {
            Documents = new HashSet<Documents>();
        }

        [Key]
        public int FolderId { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int DrawerId { get; set; }
        public string FolderName { get; set; }
        public int ImportNameTypeId { get; set; }
        public string InsName { get; set; }
        public string Lob { get; set; }

        public Drawers Drawer { get; set; }
        public ImportNameType ImportNameType { get; set; }
        public ICollection<Documents> Documents { get; set; }
    }
}
