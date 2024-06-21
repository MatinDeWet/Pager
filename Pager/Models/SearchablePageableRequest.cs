using Pager.Common;
using System.ComponentModel.DataAnnotations;

namespace Pager.Models
{
    public abstract class SearchablePageableRequest : PageableRequest
    {
        [StringLength(120)]
        public virtual string SearchTerms { get; set; }

        public IEnumerable<string> GetSearchTerms(bool toLower = false)
        {
            return Tools.GetSearchTerms(SearchTerms, toLower);
        }
    }
}
