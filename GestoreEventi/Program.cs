namespace GestoreEventi
{
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
        }
    }
}
