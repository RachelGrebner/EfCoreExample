using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLunchAndLearnDbFirst.DataAccess
{
    public partial class ImportName
    {
        public ImportName()
        {
            ImportNamesTypes = new HashSet<ImportNameType>();
        }

        [Key]
        public int ImportNameId { get; set; }

        //it doens't like having a column named after the name of the table
        //EF automatically handled mapping this to the database, specifying it's actual name in the table in the context
        public string ImportName1 { get; set; }

        public ICollection<ImportNameType> ImportNamesTypes { get; set; }
    }
}
