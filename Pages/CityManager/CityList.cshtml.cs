using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cristyan_resende_DR4_TP2.Pages.CityManager
{
    public class CityListModel : PageModel
    {
        public List<string> Cities { get; set; } = new List<string> { "Rio", "S�o Paulo", "Bras�lia" };

        public void OnGet()
        {
        }
    }
}
