using ExtraClasses.Application.ExtraClasses.Queries.GetExtraClass;
using System.Collections.Generic;

namespace ExtraClasses.Application.ExtraClasses.Queries.GetExtraClassList
{
    public class ExtraClassListViewModel
    {
        public IEnumerable<ExtraClassDto> ExtraClasses { get; set; }
    }
}