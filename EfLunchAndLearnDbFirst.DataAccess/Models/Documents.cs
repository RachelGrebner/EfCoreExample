using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLunchAndLearnDbFirst.DataAccess
{
    public partial class Documents
    {
        public Documents()
        {
            Pages = new HashSet<Pages>();
        }

        [Key]
        public int DocumentId { get; set; }
        public string FileLocation { get; set; }
        public int FileTypeMappingId { get; set; }
        public int FolderId { get; set; }
        public int OriginalDocumentId { get; set; }

        public Folders Folder { get; set; }
        public ICollection<Pages> Pages { get; set; }
    }
}
