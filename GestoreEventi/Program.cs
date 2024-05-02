namespace GestoreEventi
{
    public class DataPassataException : Exception
    {
        public override string Message => "Attenzione! Non puoi creare un evento in data passata.";
    }
    public class TitoloVuotoException : Exception {
        public override string Message => "Attenzione! Il titolo non può essere vuoto.";
    }
    public class PostiNegativiException : Exception
    {
        public override string Message => "Attenzione! Il numero di posti non può essere negativo.";
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto al gestore di eventi!");

            Console.Write("\nInserisci il nome dell'evento: ");
            string titoloEvento = Console.ReadLine();

            Console.Write("Inserisci la data dell'evento (gg/mm/aaaa): ");
            DateTime dataEvento = DateTime.Parse(Console.ReadLine());

            Console.Write("Inserisci il numero di posti totali: ");
            int capienzaEvento = int.Parse(Console.ReadLine());

            Evento evento = new Evento(titoloEvento, dataEvento, capienzaEvento);

            Console.Write("Quanti posti desideri prenotare (inserire 0 se non si vuole prenotare nessun posto)? ");
            evento.PrenotaPosti(int.Parse(Console.ReadLine()));

            Console.WriteLine($"\nNumero di posti prenotati: {evento.PostiPrenotati}");
            Console.WriteLine($"Numero di posti disponibili: {evento.PostiDisponibili()}");

            string input = "";

            while(input != "no")
            {
                Console.Write("\nVuoi disdire dei posti (si/no)? ");
                input = Console.ReadLine();

                if(input == "si")
                {
                    Console.Write("\nIndica il numero di posti da disdire: ");
                    evento.DisdiciPosti(int.Parse(Console.ReadLine()));

                    Console.WriteLine($"\nNumero di posti prenotati: {evento.PostiPrenotati}");
                    Console.WriteLine($"Numero di posti disponibili: {evento.PostiDisponibili()}");
                }
                else if(input == "no")
                {
                    Console.WriteLine("Ok va bene!");

                    Console.WriteLine($"\nNumero di posti prenotati: {evento.PostiPrenotati}");
                    Console.WriteLine($"Numero di posti disponibili: {evento.PostiDisponibili()}");
                }
                else
                {
                    Console.WriteLine("Attenzione! Input non valido");
                }
            }

            Console.Write("\nInserisci il nome del tuo programma eventi: ");
            string nomeProgramma = Console.ReadLine();
            Console.Write("Indica il numero di eventi da inserire: ");
            int numeroEventi = int.Parse(Console.ReadLine());

            ProgrammaEventi programma = new ProgrammaEventi(nomeProgramma);

            for(int i = 0; i< numeroEventi; i++)
            {
                try
                {
                    Console.Write($"\nInserisci il nome del {i + 1}° evento: ");
                    string nomeEventoLista = Console.ReadLine();
                    Console.Write($"Inserisci la data del {i + 1}° evento (gg/mm/aaaa): ");
                    DateTime dataEventoLista = DateTime.Parse(Console.ReadLine());
                    Console.Write($"Inserisci il numero di posti totali del {i + 1}° evento: ");
                    int postiEventoLista = int.Parse(Console.ReadLine());

                    if (dataEventoLista.Date < DateTime.Now)
                        throw new DataPassataException();
                    if (nomeEventoLista == "")
                        throw new TitoloVuotoException();
                    if (postiEventoLista < 0)
                        throw new PostiNegativiException();

                    programma.AggiungiEvento(new Evento(nomeEventoLista, dataEventoLista, postiEventoLista));
                }
                catch (DataPassataException e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
                catch (TitoloVuotoException e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
                catch (PostiNegativiException e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            Console.WriteLine($"\nIl numero degli eventi nel programma è: {programma.NumeroEventi()}");
            Console.WriteLine($"Ecco il tuo programma eventi:\n{programma.ListaInStringa()}");

            Console.Write("\nInserisci una data per sapere che eventi ci saranno quel giorno (gg/mm/aaaa): ");
            List<Evento> eventiInData = programma.EventiInData(DateTime.Parse(Console.ReadLine()));

            Console.WriteLine($"\nEcco gli eventi questa data:");
            Console.WriteLine(ProgrammaEventi.ListaInStringa(eventiInData));

            //programma.SvuotaEventi();

            //BONUS

            Console.WriteLine("\n---- BONUS ----");
            Console.WriteLine("\nAggiungiamo anche una conferenza!");
            var going = true;
            while(going)
            {
                Console.Write("\nInserisci il nome della conferenza: ");
                string titoloConf = Console.ReadLine();
                Console.Write("Inserisci la data della conferenza (gg/mm/aaaa): ");
                DateTime dataConf = DateTime.Parse(Console.ReadLine());
                Console.Write("Inserisci il numero dei posti per la conferenza: ");
                int postiConf = int.Parse(Console.ReadLine());
                Console.Write("Inserisci il relatore della conferenza: ");
                string relatoreConf = Console.ReadLine();
                Console.Write("Inserisci il prezzo del biglietto della conferenza: ");
                double prezzoConf = double.Parse(Console.ReadLine());

                try
                {
                     if (dataConf.Date < DateTime.Now)
                            throw new DataPassataException();
                     if (titoloConf == "")
                            throw new TitoloVuotoException();
                     if (postiConf < 0)
                            throw new PostiNegativiException();

                     going = false;
                     programma.AggiungiEvento(new Conferenza(titoloConf, dataConf, postiConf, relatoreConf, prezzoConf));
                    }
                    catch (DataPassataException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (TitoloVuotoException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (PostiNegativiException e)
                    {
                        Console.WriteLine(e.Message);
                    }
            }

            Console.WriteLine($"\nEcco il tuo programma eventi con anche la conferenza:\n{programma.ListaInStringa()}");
        }
    }
}
