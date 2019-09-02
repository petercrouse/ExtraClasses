using System.Collections.Generic;

namespace ExtraClasses.Application.ExtraClasses.Queries.GetExtraClassList
{
    public class ExtraClassListViewModel
    {
        public IEnumerable<ExtraClassLookupModel> ExtraClasses { get; set; }
    }
}