using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cristyan_resende_DR4_TP2.Pages;

public class SaveNoteModel : PageModel
{
    public string Message { get; set; }
    public string FilePath { get; set; }
    public string FileContent { get; set; }
    public List<string> Files { get; set; } = new();

    public class InputModel
    {
        [BindProperty]
        public string Content { get; set; }
    }

    [BindProperty]
    public InputModel Note { get; set; }

    public void OnGet()
    {
        LoadFiles();
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
                LoadFiles();
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

    public void OnGetView(string fileName)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", fileName);

        if (System.IO.File.Exists(filePath))
        {
            FileContent = System.IO.File.ReadAllText(filePath);
            Message = $"Conteúdo do arquivo: {fileName}";
        }
        else
        {
            Message = "Arquivo não encontrado.";
        }

        LoadFiles();
    }

    private void LoadFiles()
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");
        if (Directory.Exists(folderPath))
        {
            Files = Directory.GetFiles(folderPath, "*.txt")
                             .Select(Path.GetFileName)
                             .ToList();
        }
    }
}