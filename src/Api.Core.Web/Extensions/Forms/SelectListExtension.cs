using Microsoft.AspNetCore.Mvc.Rendering;

namespace Api.Core.Web.Extensions.Forms;
public static class SelectListExtension
{
    public static SelectList SetDefault(this SelectList selectList, string chave = null)
    {
        var list = selectList.ToList();
        var itemList = list.Prepend(new SelectListItem("Selecione", "null"));
        var select = new SelectList(itemList, "Value", "Text");
        return select;
    }
}
