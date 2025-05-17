using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cristyan_resende_DR4_TP2.Pages;

public class SaveNoteModel : PageModel
{
    public string Message { get; set; }
    public string FilePath { get; set; }

    public class InputModel
    {
        [BindProperty]
        public string Content { get; set; }
    }

    [BindProperty]
    public InputModel Note { get; set; }

    public void OnGet()
    {
        Message = "Digite o conteúdo da nota e salve:";
    }

    public void OnPost()
    {
        if (!string.IsNullOrEmpty(Note.Content))
        {
            try
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = $"note-{DateTime.Now:yyyyMMdd-HHmmss}.txt";
                var fullPath = Path.Combine(folderPath, fileName);

                System.IO.File.WriteAllText(fullPath, Note.Content);

                Message = "Nota salva com sucesso!";
                FilePath = $"/files/{fileName}";
            }
            catch (Exception ex)
            {
                Message = $"Erro ao salvar a nota: {ex.Message}";
            }
        }
        else
        {
            Message = "Por favor, digite algum conteúdo.";
        }
    }
}
