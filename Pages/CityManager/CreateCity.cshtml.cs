using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cristyan_resende_DR4_TP2.Pages.CityManager;

public class CreateCityModel : PageModel
{
    public string Message { get; set; }

    public class InputModel
    {
        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome da cidade deve ter no mínimo 3 caracteres.")]
        public string CityName { get; set; }
    }

    [BindProperty]
    public InputModel City { get; set; }

    public void OnGet()
    {
        Message = "Cadastre uma cidade turística.";
    }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            Message = $"Cidade cadastrada: {City.CityName}";
        }
    }
}