using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cristyan_resende_DR4_TP2.Pages;

public class CreateCountryModel : PageModel
{
    public string Message { get; set; }

    public class InputModel
    {
        [BindProperty]
        [Required(ErrorMessage = "O nome do país é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome do país deve ter no mínimo 3 caracteres.")]
        public string CountryName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "O código do país é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código do país deve ter exatamente 2 caracteres.")]
        public string CountryCode { get; set; }
    }

    [BindProperty]
    public InputModel Country { get; set; }

    public void OnGet()
    {
        Message = "Cadastre um país:";
    }

    public void OnPost()
    {
        if (!string.IsNullOrEmpty(Country.CountryName) && !string.IsNullOrEmpty(Country.CountryCode))
        {
            if (char.ToUpper(Country.CountryName[0]) != char.ToUpper(Country.CountryCode[0]))
            {
                ModelState.AddModelError("Country.CountryCode", "O código do país deve começar com a mesma letra que o nome.");
            }
        }

        if (ModelState.IsValid)
        {
            Message = $"País cadastrado: {Country.CountryName} ({Country.CountryCode})";
        }
        else
        {
            Message = "Erro no cadastro. Verifique os campos.";
        }
    }
}
