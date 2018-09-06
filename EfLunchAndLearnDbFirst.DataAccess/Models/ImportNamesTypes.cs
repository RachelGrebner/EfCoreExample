using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLunchAndLearnDbFirst.DataAccess
{
    [Table("ImportNamesTypes")]
    public partial class ImportNameType
    {
        public ImportNameType()
        {
            Folders = new HashSet<Folders>();
        }

        [Key]
        public int ImportNameTypeId { get; set; }
        public int ImportNameId { get; set; }
        public int ImportTypeId { get; set; }
        public bool IsHistorical { get; set; }
        public int ImportStatusId { get; set; }

        public ImportName ImportName { get; set; }
        public ImportStatus ImportStatus { get; set; }
        public ImportType ImportType { get; set; }
        public ICollection<Folders> Folders { get; set; }
    }
}
