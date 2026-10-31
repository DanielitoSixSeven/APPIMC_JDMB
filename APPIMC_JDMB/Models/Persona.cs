using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPIMC_JDMB.Models
{
    public class Persona
    {
        public double Peso {  get; set; }
        public double Estatura {  get; set; }
        
        public double CalcularIMC()
        {
            return Peso / (Estatura *  Estatura);
        }

        public string clasificacion(double imc)
        {
            if (imc < 18.5)
            {
                return "Bajo peso";
            }
            else if(imc < 25)
            {
                return "peso normal";
            }

            else if(imc < 30)
            {
                return "sorepeso";
            }
            else
            {
                return "Obesidad";
            }
            
        }

    }
}
