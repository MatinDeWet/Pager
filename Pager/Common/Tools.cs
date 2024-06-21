using System.Globalization;

namespace Pager.Common
{
    public static class Tools
    {
        public static IEnumerable<string> GetSearchTerms(string searchTerms, bool toLower = false)
        {
            SqlCiStringComparer comparer = new SqlCiStringComparer();
            return ((from o in searchTerms?.Split(' ')
                     select o.Trim('%', '?', '(', ')') into t
                     select (!toLower) ? t : t.ToLower(CultureInfo.CurrentCulture) into t
                     where !string.IsNullOrWhiteSpace(t)
                     select t).Distinct<string>(comparer) ?? Enumerable.Empty<string>()).ToList();
        }
    }
}
