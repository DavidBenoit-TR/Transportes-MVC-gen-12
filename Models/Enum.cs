using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transportes_MVC_gen_12.Models
{
    public class Enum
    {
        //es un tipo de datos que permite definir un conjunto de constantes con nombre. Estas constantes representan valores simbólicos significativos y pueden ayudar a hacer que el código sea más legible y mantenible.
        public enum NotificationType
        {
            error,
            success,
            warning,
            info,
            question
        }
    }
}