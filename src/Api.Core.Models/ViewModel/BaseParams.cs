namespace Api.Core.Models.ViewModel;
public class BaseParams
{
    public bool? Ativo { get; set; } = true;
    public int Page { get; set; } = 0;
    public int Limit { get; set; } = 0;
    public string OrderBy { get; set; } = "";
    public string OrderByOrder { get; set; } = "ASC";

    public int Skip()
    {
        return (Page - 1) * Limit;
    }
}
