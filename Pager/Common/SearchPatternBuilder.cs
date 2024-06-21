using Pager.Common.Enums;

namespace Pager.Common
{
    public static class SearchPatternBuilder
    {
        public static string GetSearchPatternFormat(ExpressionMatchTypeEnum matchType)
        {
            return matchType switch
            {
                ExpressionMatchTypeEnum.StartsWith => "{0}%",
                ExpressionMatchTypeEnum.EndsWith => "%{0}",
                ExpressionMatchTypeEnum.Contains => "%{0}%",
                ExpressionMatchTypeEnum.Equals => "{0}",
                _ => throw new Exception($"Unknown match type {matchType}"),
            };
        }

        public static string BuildSearchPattern(this string term, ExpressionMatchTypeEnum matchType)
        {
            return string.Format(GetSearchPatternFormat(matchType), term);
        }

        public static string BuildSearchPattern(this string term, string patternFormat)
        {
            return string.Format(patternFormat, term);
        }
    }
}
