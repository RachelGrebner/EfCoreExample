using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLunchAndLearnDbFirst.DataAccess
{
    public partial class Pages
    {
        public Pages()
        {
            PagesMetadata = new HashSet<PagesMetadata>();
        }

        [Key]
        public int PageId { get; set; }
        public DateTime DateRecd { get; set; }
        public int DocumentId { get; set; }
        public Guid? EcmPageGuid { get; set; }
        public string FileName { get; set; }
        public string FullFilePath { get; set; }
        public bool? HasAnnotations { get; set; }
        public bool? ImportStatus { get; set; }
        public int? LibraryIndex { get; set; }
        public int? MergedPageCount { get; set; }
        public string PageDescription { get; set; }
        public int PageNumber { get; set; }
        public string WinFileType { get; set; }

        public Documents Document { get; set; }
        public ICollection<PagesMetadata> PagesMetadata { get; set; }
    }
}
