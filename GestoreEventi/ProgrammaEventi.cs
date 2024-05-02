using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class ProgrammaEventi
    {
        public string Titolo { get; set; }
        public List<Evento> eventi { get; set; }

        public ProgrammaEventi(string titolo) { 
            Titolo = titolo;
            eventi = new List<Evento>();
        }

        public void AggiungiEvento(Evento evento) => eventi.Add(evento);

        public List<Evento> EventiInData(DateTime data)
        {
            List<Evento> lista = new List<Evento>();

            foreach (Evento e in eventi) { 
                if(e.Data.Date  == data.Date)
                {
                    lista.Add(e);
                }
            }
            return lista;
        }

        public static string ListaInStringa(List<Evento> lista)
        {
            string text = "";

            foreach(Evento e in lista)
            {
                text += $"\n\t{e.ToString()}";
            }

            return text;
        }

        public int NumeroEventi() => eventi.Count;

        public void SvuotaEventi() => eventi.Clear();

        public string ListaInStringa() => Titolo + ListaInStringa(eventi);

    }
}
