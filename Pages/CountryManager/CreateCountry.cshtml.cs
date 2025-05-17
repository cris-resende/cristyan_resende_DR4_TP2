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
        [Required(ErrorMessage = "O nome do pa�s � obrigat�rio.")]
        [MinLength(3, ErrorMessage = "O nome do pa�s deve ter no m�nimo 3 caracteres.")]
        public string CountryName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "O c�digo do pa�s � obrigat�rio.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O c�digo do pa�s deve ter exatamente 2 caracteres.")]
        public string CountryCode { get; set; }
    }

    [BindProperty]
    public InputModel Country { get; set; }

    public void OnGet()
    {
        Message = "Cadastre um pa�s:";
    }

    public void OnPost()
    {
        if (!string.IsNullOrEmpty(Country.CountryName) && !string.IsNullOrEmpty(Country.CountryCode))
        {
            if (char.ToUpper(Country.CountryName[0]) != char.ToUpper(Country.CountryCode[0]))
            {
                ModelState.AddModelError("Country.CountryCode", "O c�digo do pa�s deve come�ar com a mesma letra que o nome.");
            }
        }

        if (ModelState.IsValid)
        {
            Message = $"Pa�s cadastrado: {Country.CountryName} ({Country.CountryCode})";
        }
        else
        {
            Message = "Erro no cadastro. Verifique os campos.";
        }
    }
}
