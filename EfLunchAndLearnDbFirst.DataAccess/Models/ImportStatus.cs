using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLunchAndLearnDbFirst.DataAccess
{
    public partial class ImportStatus
    {
        public ImportStatus()
        {
            ImportNamesTypes = new HashSet<ImportNameType>();
        }

        [Key]
        public int ImportStatusId { get; set; }
        public string ImportStatus1 { get; set; }

        public ICollection<ImportNameType> ImportNamesTypes { get; set; }
    }
}
