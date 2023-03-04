using eventando.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace eventando.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public FileResult Arquivo()
        {
            return File("~/pdf/documento.pdf", "application/pdf");
        }

        public IActionResult Resultado()
        {
            ViewData["valor1"] = "Primeiro Resultado";
            ViewBag.Mensagem = "Mensagem gerada em " + DateTime.Now;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Calculadora(double? n1, double? n2)
        {
            ViewBag.n1 = n1;
            ViewBag.n2 = n2;
            return View();
        }

        public IActionResult Calculadora(IFormCollection form)
        {
            double v1 = double.Parse(form["valor1"]);
            double v2 = double.Parse(form["valor2"]);
            double resultado = v1 + v2;
            ViewBag.Resultado = "Resultado da soma: " + (v1 + v2);
            return View();
        }

        [HttpGet]
        public IActionResult IncluirProduto01()
        {
            return View();
        }


        [HttpPost]
        public IActionResult IncluirProduto01(Produto produto)
        {
            StreamWriter writer = new StreamWriter("wwwroot/pdf/documento.txt", false, Encoding.UTF8);

            writer.WriteLine("Código: " + produto.Codigo);
            writer.WriteLine("Descrição: " + produto.Descricao);
            writer.WriteLine("Preço: " + produto.Preco.ToString("c"));
            writer.WriteLine("Data Fabricação: " + produto.DataFabricacao);
            writer.Close();

            return File("~/pdf/documento.txt", "text/plain");
        }

        public IActionResult ExibirProduto()
        {
            Produto produto = new Produto()
            {
                Codigo = 25,
                Descricao = "Bicicleta",
                Preco = 500,
                DataFabricacao = Convert.ToDateTime("13/06/2022")
            };
            return View(produto);
        }
    }
}