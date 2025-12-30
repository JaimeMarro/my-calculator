using System.Diagnostics;
using Calculadora_Web.Models;
using Calculadora_Web.Services;
using Microsoft.AspNetCore.Mvc;


namespace Calculadora_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Creamos un objeto para enviarle el valor de cero a la vista
            var modelo = new CalculadoraViewModel();

            modelo.ValorActual = "0";
            modelo.OperacionCompleta = "";

            
            //Se lo pasamos a la vista
            return View(modelo);

        }

        //HttpPost se usa para recibir los datos que envia el formulario
        [HttpPost]
        public IActionResult Index(CalculadoraViewModel model, CalculadoraService calcular)
        {
            //
            // -- APARTADO EXCLUSIVAMENTE PARA NUMEROS 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, ., -
            //

            //Según, esta linea de código borra la memoria del envio anterior y obliga usar los nuevos
            ModelState.Clear();

            //Si el Valor es un cero, se ejecutara este if (En donde indica que este es el primer numero a colocar)
            if (model.ValorActual == "0")
            {
                //Aqui nos aseguramos que nada más podemos usar estos botones al iniciar
                if (model.BotonPresionado == "1" || model.BotonPresionado == "2" || model.BotonPresionado == "3"
                || model.BotonPresionado == "4" || model.BotonPresionado == "5" || model.BotonPresionado == "6"
                || model.BotonPresionado == "7" || model.BotonPresionado == "8" || model.BotonPresionado == "9"
                || model.BotonPresionado == "-" || model.BotonPresionado == "0" )
                {   
                    model.ValorActual = model.BotonPresionado;
                }
                //Este es si se pone un punto despues del cero
                else if (model.BotonPresionado == ".")
                {
                    model.ValorActual = "0.";
                }
                //Si no tocamos ninguno de los botones anteriores, entonces seguira apareciendo el "0"
                else
                {
                    model.ValorActual = "0";
                }
            }
            else
            {
                //Esto es para cuando ya hay un numero que no es "0", asi podemos poner más de un numero, ejemplo, 10, 100, 1000, etc
                if (model.BotonPresionado == "1" || model.BotonPresionado == "2" || model.BotonPresionado == "3"
                || model.BotonPresionado == "4" || model.BotonPresionado == "5" || model.BotonPresionado == "6"
                || model.BotonPresionado == "7" || model.BotonPresionado == "8" || model.BotonPresionado == "9"
                || model.BotonPresionado == "0" || model.BotonPresionado == ".")
                {
                    //Usamos el primer numero que teniamos guardado y lo unimos con el siguiente valor que proporcionamos
                    model.ValorActual += model.BotonPresionado;
                }
            }

            //
            // -- APARTADO EXCLUSIVAMENTE PARA OPERADORES +, -, /, *
            //

            if (model.ValorActual != "0")
            {
                if (model.BotonPresionado == "+" || model.BotonPresionado == "÷" || model.BotonPresionado == "x" || model.BotonPresionado == "-")
                {
                    
                    model.PrimerValor = model.ValorActual;
                    model.Operador = model.BotonPresionado;
                    model.OperacionCompleta = $"{model.PrimerValor} {model.Operador} ";
                    model.ValorActual = "0";
                }
            }

            //
            // --APARTADO EXCLUSIVAMENTE PARA IGUAL =
            //

            if (model.PrimerValor != null && model.Operador != null)
            {
                if (model.BotonPresionado == "=")
                {
                    model.OperacionCompleta = $"{model.PrimerValor} {model.Operador} {model.ValorActual}";

                    switch (model.Operador)
                    {
                        case "+": model.ValorActual = $"{calcular.Suma(model)}"; break;
                        case "-": model.ValorActual = $"{calcular.Resta(model)}"; break;
                        case "x": model.ValorActual = $"{calcular.Multiplicacion(model)}"; break;
                        case "÷": model.ValorActual = $"{calcular.Division(model)}"; break;

                        default: model.ValorActual = "0"; break;
                    }
                    if (model.ValorActual == "No se puede divir por cero")
                    {
                        model.BotonPresionado = "C";
                        model.OperacionCompleta = "No se puede divir por cero";
                    }
                    model.PrimerValor = null;
                    model.Operador = null;

                }
            }


            //
            // --APARTADO EXCLUSIVAMENTE PARA AC Y C
            //

            if (model.BotonPresionado == "AC")
            {
                model.PrimerValor = null;
                model.Operador = null;
                model.OperacionCompleta = "";
                model.ValorActual = "0";
            }
            if (model.BotonPresionado == "C")
            {
                model.ValorActual = "0";
            }

            //Devolvemos el modelo actualizado a la vista
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
