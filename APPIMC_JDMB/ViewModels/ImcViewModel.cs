using APPIMC_JDMB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APPIMC_JDMB.ViewModels
{
    internal class ImcViewModel : INotifyPropertyChanged
    {
        public string PesoT { get; set; } = "";
        public string EstaturaT { get; set; } = "";

        private string resultado = "Ingresa tus datos";

        public string Resultado
        {
            get { return resultado; }
            set
            {
                resultado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(resultado)));
            }
        }

        private string clasificacion = "";
        public string Clasificacion
        {
            get { return clasificacion; }
            set
            {
                clasificacion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(clasificacion)));
            }
        }
        public ICommand CalcularCommand { get; }
        public ImcViewModel() 
        {
            CalcularCommand = new Command(Calcular);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void Calcular()
        {
            double peso;
            bool pesoValido = double.TryParse(PesoT, out peso);
            if(pesoValido == false || !double.IsFinite(peso) || peso <= 0)
            {
                Resultado = "Peso Invalido";
                clasificacion = "";
                return;
            }

            double estatura;
            bool estaturaValido = double.TryParse(EstaturaT, out estatura);
            if(estaturaValido == false || !double.IsFinite(estatura) || estatura <= 0)
            {
                Resultado = "Estatura Invalida";
                Clasificacion = "";
                return;
            }

            Persona persona = new Persona();
            persona.Peso = peso;
            persona.Estatura = estatura;

            double imc = persona.CalcularIMC();

            if (!double.IsFinite(imc))
            {
                Resultado = "Revisa el peso y estatura";
                clasificacion = "";
            }

            resultado = "Tu IMC es: " + imc.ToString("F2");

            clasificacion = persona.clasificacion(imc);


        }
    }
}
