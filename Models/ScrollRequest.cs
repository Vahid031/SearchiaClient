namespace Searchia.Models;

public class ScrollRequest
{
    public string IndexName { get; set; }
    public int ChunkNo { get; set; }
    public string Filters { get; set; }
    public string FieldName { get; set; }
    public string Query { get; set; }
}