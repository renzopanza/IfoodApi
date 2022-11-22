using Microsoft.AspNetCore.Mvc;

namespace Ifood.Controllers
{
    public class ImagesController : Controller
    {

        private string caminhoDiretorio;

        public ImagesController(IWebHostEnvironment sistema)
        {
            caminhoDiretorio = sistema.WebRootPath;
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile imagem)
        {
            string caminhoParaSalvarImagem = caminhoDiretorio + "\\images_restaurantes\\";
            string novoNomeParaImagem = Guid.NewGuid().ToString() + "_" + imagem.FileName;

            if (!Directory.Exists(caminhoParaSalvarImagem))
            {
                Directory.CreateDirectory(caminhoParaSalvarImagem);
            }

            using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + novoNomeParaImagem))
            {
                imagem.CopyToAsync(stream);
            }

            return RedirectToAction("Upload");
        }
    }
}
