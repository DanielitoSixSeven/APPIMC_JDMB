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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resultado)));
            }
        }

        private string clasificacion = "";
        public string Clasificacion
        {
            get { return clasificacion; }
            set
            {
                clasificacion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Clasificacion)));
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
            if (!double.TryParse(PesoT, out double peso) || !double.IsFinite(peso) || peso <= 0)
            {
                Resultado = "Peso inválido";
                Clasificacion = "";
                return;
            }

            if (!double.TryParse(EstaturaT, out double estatura) || !double.IsFinite(estatura) || estatura <= 0)
            {
                Resultado = "Estatura inválida";
                Clasificacion = "";
                return;
            }

            Persona persona = new Persona { Peso = peso, Estatura = estatura };
            double imc = persona.CalcularIMC();

            if (!double.IsFinite(imc))
            {
                Resultado = "Revisa el peso y estatura";
                Clasificacion = "";
                return;
            }

            Resultado = "Tu IMC es: " + imc.ToString("F2");
            Clasificacion = persona.clasificacion(imc);
        }
    }
}
