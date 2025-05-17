using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cristyan_resende_DR4_TP2.Pages.CityManager;

public class CreateCityModel : PageModel
{
    public string Message;
    public void OnGet()
    {
        Message = "Cadastre uma cidade turística: ";
    }
    public void OnPost(string CityName)
    {
        if (!string.IsNullOrEmpty(CityName))
        {
            Message = $"A cidade cadastrada é: {CityName}.";
        }
        else
        {
            Message = "Insira o nome de uma cidade:";

        }
    }
}
