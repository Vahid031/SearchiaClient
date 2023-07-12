namespace Searchia.Models;

public class SuggestRequest
{
    public string IndexName { get; set; }
    public string Query { get; set; }
    public string AnalyticsTag { get; set; }
    public bool InContent { get; set; }
    public bool SpellCheckEnabled { get; set; }
    public string ObjectCategoryIdFieldName { get; set; }
    public string Filter { get; set; }
    public bool IncludeDocCount { get; set; }
}