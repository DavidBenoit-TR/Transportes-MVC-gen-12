using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Transportes_MVC_gen_12.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "CalculadoraService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione CalculadoraService.svc o CalculadoraService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class CalculadoraService : ICalculadoraService
    {
        public double sumar(double a, double b)
        {
            return a + b;
        }

        public double restar(double a, double b)
        {
            return a - b;
        }

        public double multipicar(double a, double b)
        {
            return a * b;
        }

        public double dividir(double a, double b)
        {
            return a / b;
        }
    }
}
