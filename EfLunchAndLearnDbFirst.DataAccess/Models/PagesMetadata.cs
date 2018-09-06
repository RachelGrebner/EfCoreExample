using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLunchAndLearnDbFirst.DataAccess
{
    public partial class PagesMetadata
    {
        [Key]
        public long PageMetaDataId { get; set; }
        public int PageId { get; set; }
        public string DataKey { get; set; }
        public string DataValue { get; set; }

        public Pages Page { get; set; }
    }
}
