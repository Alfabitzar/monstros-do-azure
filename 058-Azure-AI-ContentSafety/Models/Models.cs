namespace AiTextAnalysis;

public class AnalysisResult
{
    public List<CategoryAnalysis> CategoriesAnalysis { get; set; }
}

public class CategoryAnalysis
{
    public string Category { get; set; }
    public int Severity { get; set; }
}