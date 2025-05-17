using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cristyan_resende_DR4_TP2.Pages.CityManager
{
    public class CityDetailsModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                Message = $"Você está vendo detalhes de: {cityName}";
            }
            else
            {
                Message = "Nenhuma cidade foi especificada.";
            }
        }
    }
}
