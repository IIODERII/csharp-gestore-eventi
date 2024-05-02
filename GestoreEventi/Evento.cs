using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Evento
    {
        private string titolo;
        public string Titolo
        {
            get
            {
                return titolo;
            }
            set
            {
                if(value != "")
                {
                    titolo = value;
                }
                else
                {
                    throw new Exception("Attenzione! Il titolo non può essere vuoto.");
                }
            }
        }
        private DateTime data;
        public DateTime Data {
            get
            {
                return data;
            }
            set
            {
                if(value < DateTime.Now)
                {
                    throw new Exception("Attenzione! La data non può essere già passata.");
                }
                else
                {
                    data = value;
                }
            }
        }
        private int capienza;
        public int Capienza
        {
            get
            {
                return capienza;
            }
            protected set
            {
                if(value < 0)
                {
                    throw new Exception("Attenzione! La capienza massima dell'evento deve essere positiva.");
                }
                else
                {
                    capienza = value;
                }
            }
        }
        public int PostiPrenotati { get; protected set; }

        public Evento(string titolo, DateTime data, int capienza)
        {
            Titolo = titolo;
            Data = data;
            Capienza = capienza;
            PostiPrenotati = 0;
        }

        public void PrenotaPosti(int posti) { 
            if(posti < 0)
                throw new Exception("Attenzione! Non puoi prenotare un numero negativo di posti.");

            else if(Data <  DateTime.Now)
                throw new Exception("Attenzione! L'evento è già passato.");

            else if(PostiPrenotati + posti > Capienza)
                throw new Exception($"Attenzione! Non ci sono {posti} posti disponibili.");

            else
                PostiPrenotati += posti; 
        }

        public void DisdiciPosti(int posti)
        {
            if(Data < DateTime.Now)
                throw new Exception("Attenzione! L'evento è già passato.");

            else if(PostiPrenotati - posti < 0)
                throw new Exception("Attenzione! Il numero di posti prenotati è minore di quelli che si desidera disdire.");
            
            else
                PostiPrenotati -= posti;
        }

        public override string ToString() => $"{Data.ToString("dd/MM/yyyy")} - {Titolo}";
        
        public int PostiDisponibili() => Capienza - PostiPrenotati;
    }
}
