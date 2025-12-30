using Calculadora_Web.Models;
using System.Globalization;

namespace Calculadora_Web.Services
{
    public class CalculadoraService
    {
        

        public string Suma(CalculadoraViewModel model)
        {
            decimal resultado;

                                                      //Esto se ocupa para que obligatorimente se use el punto (.) como decimal y no la coma (,)
            decimal num1 = decimal.Parse(model.PrimerValor, System.Globalization.CultureInfo.InvariantCulture);
            decimal num2 = decimal.Parse(model.ValorActual, System.Globalization.CultureInfo.InvariantCulture);

            resultado = num1 + num2;
            
                                    //Igualmente, lo devolvemos con el punto decimal
            return resultado.ToString(CultureInfo.InvariantCulture);
        }

        public string Resta(CalculadoraViewModel model)
        {
            decimal resultado;

            //                                            Esto se ocupa para que obligatorimente se use el punto (.) como decimal y no la coma (,)
            decimal num1 = decimal.Parse(model.PrimerValor, System.Globalization.CultureInfo.InvariantCulture);
            decimal num2 = decimal.Parse(model.ValorActual, System.Globalization.CultureInfo.InvariantCulture);

            resultado = num1 - num2;

                                    //Igualmente, lo devolvemos con el punto decimal
            return resultado.ToString(CultureInfo.InvariantCulture);
        }

        public string Multiplicacion(CalculadoraViewModel model)
        {
            decimal resultado;

            //                                            Esto se ocupa para que obligatorimente se use el punto (.) como decimal y no la coma (,)
            decimal num1 = decimal.Parse(model.PrimerValor, System.Globalization.CultureInfo.InvariantCulture);
            decimal num2 = decimal.Parse(model.ValorActual, System.Globalization.CultureInfo.InvariantCulture);

            resultado = num1 * num2;

                            //Igualmente, lo devolvemos con el punto decimal
            return resultado.ToString(CultureInfo.InvariantCulture);
        }

        public string Division(CalculadoraViewModel model)
        {
            decimal resultado;
            String mensaje;

            //                                            Esto se ocupa para que obligatorimente se use el punto (.) como decimal y no la coma (,)
            decimal num1 = decimal.Parse(model.PrimerValor, System.Globalization.CultureInfo.InvariantCulture);
            decimal num2 = decimal.Parse(model.ValorActual, System.Globalization.CultureInfo.InvariantCulture);

            if (num2 == 0)
            {
                return mensaje = "No se puede divir por cero";
            }
            else
            {
                resultado = num1 / num2;
            }
                                //Igualmente, lo devolvemos con el punto decimal
            return resultado.ToString(CultureInfo.InvariantCulture);
        }

    }

}


