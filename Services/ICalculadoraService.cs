﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Transportes_MVC_gen_12.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICalculadoraService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICalculadoraService
    {
        [OperationContract]
        double sumar(double a, double b);

        [OperationContract]
        double restar(double a, double b);

        [OperationContract]
        double multipicar(double a, double b);

        [OperationContract]
        double dividir(double a, double b);
    }
}
