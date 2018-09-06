using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLunchAndLearnDbFirst.DataAccess
{
    public partial class ImportType
    {
        public ImportType()
        {
            ImportNamesTypes = new HashSet<ImportNameType>();
        }

        [Key]
        public int ImportTypeId { get; set; }
        public string ImportTypeDesc { get; set; }

        public ICollection<ImportNameType> ImportNamesTypes { get; set; }
    }
}
