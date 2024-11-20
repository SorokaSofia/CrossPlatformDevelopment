using Microsoft.AspNetCore.Mvc;
using Library;

namespace lab6.Controllers
{
    public class LabController : Controller
    {
        private readonly Lab1Runner _lab1Runner;
        private readonly Lab2Runner _lab2Runner;
        private readonly Lab3Runner _lab3Runner;

        public LabController()
        {
            _lab1Runner = new Lab1Runner();
            _lab2Runner = new Lab2Runner();
            _lab3Runner = new Lab3Runner();
        }

        public IActionResult Lab1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab1(string inputFile, string outputFile)
        {
            try
            {
                _lab1Runner.Run(inputFile, outputFile);
                ViewBag.Message = "Lab1 виконана успішно!";
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Помилка: {ex.Message}";
            }
            return View();
        }

        public IActionResult Lab2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab2(string inputFile, string outputFile)
        {
            try
            {
                _lab2Runner.Run(inputFile, outputFile);
                ViewBag.Message = "Lab2 виконана успішно!";
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Помилка: {ex.Message}";
            }
            return View();
        }

        public IActionResult Lab3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab3(string inputFile, string outputFile)
        {
            try
            {
                _lab3Runner.Run(inputFile, outputFile);
                ViewBag.Message = "Lab3 виконана успішно!";
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Помилка: {ex.Message}";
            }
            return View();
        }
    }
}