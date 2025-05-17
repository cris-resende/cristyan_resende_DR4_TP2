using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cristyan_resende_DR4_TP2.Pages.CityManager
{
    public class CreateCountryModel : PageModel
    {
        public string Message { get; set; }
        public class Country()
        {
            public string CountryName { get; set; }
            public string CountryCode { get; set; }
        }
        public class InputModel
        {
            [BindProperty]
            [Required(ErrorMessage = "O nome do pa�s � obrigat�rio.")]
            public string CountryName { get; set; }

            [BindProperty]
            [Required(ErrorMessage = "O c�digo do pa�s � obrigat�rio.")]
            [StringLength(3, ErrorMessage = "O c�digo do pa�s deve ter no m�ximo 3 caracteres.")]
            public string CountryCode { get; set; }
        }

        [BindProperty]
        public InputModel CountryInput { get; set; }

        public void OnGet()
        {
            Message = "Cadastre um pa�s:";
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // Criando uma inst�ncia de Country com os dados do InputModel
                var country = new Country
                {
                    CountryName = CountryInput.CountryName,
                    CountryCode = CountryInput.CountryCode
                };

                Message = $"Pa�s cadastrado: {country.CountryName} ({country.CountryCode})";
            }
            else
            {
                Message = "Erro no cadastro. Verifique os campos.";
            }
        }
    }

}
