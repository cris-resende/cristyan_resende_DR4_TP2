using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cristyan_resende_DR4_TP2.Pages.CountryManager;

public class CreateCountryModel : PageModel
{
    public string Message { get; set; }

    // Classe para representar um país
    public class Country
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }

    // Classe de entrada para capturar os dados do formulário
    public class InputModel
    {
        [Required(ErrorMessage = "O nome do país é obrigatório.")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "O código do país é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código do país deve ter exatamente 2 caracteres.")]
        public string CountryCode { get; set; }
    }

    // Lista para armazenar múltiplos países
    [BindProperty]
    public List<InputModel> Countries { get; set; } = new List<InputModel>();

    public void OnGet()
    {
        // Inicializa a lista com 5 registros vazios
        for (int i = 0; i < 5; i++)
        {
            Countries.Add(new InputModel());
        }
        Message = "Cadastre até 5 países simultaneamente:";
    }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            // Monta a lista de países cadastrados
            var countryList = Countries
                .Where(c => !string.IsNullOrEmpty(c.CountryName))
                .Select(c => $"{c.CountryName} ({c.CountryCode})");

            Message = "Países cadastrados: " + string.Join(", ", countryList);
        }
        else
        {
            Message = "Erro no cadastro. Verifique os campos.";
        }
    }
}
