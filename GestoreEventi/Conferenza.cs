using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestoreEventi
{
    public class Conferenza : Evento
    {
        string Relatore {  get; set; }
        double Prezzo { get; set; }

        public Conferenza(string titolo, DateTime data, int capienza, string relatore, double prezzo) : base(titolo, data, capienza)
        {
            Relatore = relatore;
            Prezzo = prezzo;
        }

        public string DataFormattata() => Data.ToString("dd/MM/yyyy");

        public string PrezzoFormattato() => Prezzo.ToString("0.00");

        public override string ToString() => $"{DataFormattata()} - {Titolo} - {Relatore} - {PrezzoFormattato()}";

    }
}
