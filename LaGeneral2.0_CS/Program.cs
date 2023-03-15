using System.ComponentModel;

namespace LaGeneral
{
    class LaGeneral
    {
        // arreglos unidimensionales y bidimensionales
        private static int[,] partidasJugadas = new int[3, 1];
        private static int[] dados = new int[5];
        private static int[] jugadores = new int[3];
        private static int modoJuego = 0;
        public void Dado()
        {
            // hago uso de la clase random para poder escoger numeros de manera "aleatoria"
            Random rnd = new Random();

            // aqui se inicializan y obtienen un valor dado por la clase random y el metodo next
            dados[0] = rnd.Next(1, 6);
            dados[1] = rnd.Next(1, 6);
            dados[2] = rnd.Next(1, 6);
            dados[3] = rnd.Next(1, 6);
            dados[4] = rnd.Next(1, 6);
        }

        public void Modo1()
        {
            Console.WriteLine($"// Jugador 1, teclea para tirar los dados");
            Console.ReadKey();
            Dado();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"// Jugador 1 tira primeron y saca <{jugadores[0] += dados[0] + dados[1] + dados[2] + dados[3] + dados[4]}>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[1]: Dado uno: {dados[0]}");
            Console.WriteLine($"[2]: Dado dos: {dados[1]}");
            Console.WriteLine($"[3]: Dado tres: {dados[2]}");
            Console.WriteLine($"[4]: Dado cuatro: {dados[3]}");
            Console.WriteLine($"[5]: Dado cinco: {dados[4]}\n");

            Console.WriteLine($"// Consola esta tirando");
            Dado();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"// Consola tira despues y saca <{jugadores[2] += dados[0] + dados[1] + dados[2] + dados[3] + dados[4]}>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[1]: Dado uno: {dados[0]}");
            Console.WriteLine($"[2]: Dado dos: {dados[1]}");
            Console.WriteLine($"[3]: Dado tres: {dados[2]}");
            Console.WriteLine($"[4]: Dado cuatro: {dados[3]}");
            Console.WriteLine($"[5]: Dado cinco: {dados[4]}\n");

            if (jugadores[0] > jugadores[2])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("// Jugador 1 es el ganador!");
                Console.ForegroundColor = ConsoleColor.White;
                partidasJugadas[0, 0] += 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("// Consola es el ganador!");
                Console.ForegroundColor = ConsoleColor.White;
                partidasJugadas[2, 0] += 1;
            }
            jugadores[0] = 0;
            jugadores[2] = 0;
        }
        public void Modo2()
        {
            Console.WriteLine($"// Jugador 1, teclea para tirar los dados");
            Console.ReadKey();
            Dado();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"// Jugador 1 tira primeron y saca <{jugadores[0] += dados[0] + dados[1] + dados[2] + dados[3] + dados[4]}>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[1]: Dado uno: {dados[0]}");
            Console.WriteLine($"[2]: Dado dos: {dados[1]}");
            Console.WriteLine($"[3]: Dado tres: {dados[2]}");
            Console.WriteLine($"[4]: Dado cuatro: {dados[3]}");
            Console.WriteLine($"[5]: Dado cinco: {dados[4]}\n");

            Console.WriteLine($"// Jugador 2, teclea para tirar los dados");
            Console.ReadKey();
            Dado();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"// Jugador 2 tira despues y saca <{jugadores[1] += dados[0] + dados[1] + dados[2] + dados[3] + dados[4]}>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[1]: Dado uno: {dados[0]}");
            Console.WriteLine($"[2]: Dado dos: {dados[1]}");
            Console.WriteLine($"[3]: Dado tres: {dados[2]}");
            Console.WriteLine($"[4]: Dado cuatro: {dados[3]}");
            Console.WriteLine($"[5]: Dado cinco: {dados[4]}\n");

            if (jugadores[0] > jugadores[1])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("// Jugador 1 es el ganador!");
                Console.ForegroundColor = ConsoleColor.White;
                partidasJugadas[0, 0] += 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("// Jugador 2 es el ganador!");
                Console.ForegroundColor = ConsoleColor.White;
                partidasJugadas[1, 0] += 1;
            }
            jugadores[0] = 0;
            jugadores[1] = 0;
        }
        public void JuegoDados()
        {
            int result = 0;

            while (modoJuego == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Juego de dados <La General>!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("El juego de dados consiste en sacar la mayor cantidad de puntos posibles para ganar\n");
                Console.WriteLine("// Escoge tu modo de juego");
                Console.WriteLine("[1]: Consola");
                Console.WriteLine("[2]: Dos jugadores");
                Console.WriteLine("[3]: ranking de veces ganadas");
                Console.WriteLine("[4]: Salir");
                try
                {
                    modoJuego = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("// Eso no es una respuesta valida!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            Console.Clear();
            switch (modoJuego)
            {
                case 1:
                    Modo1();
                    break;
                case 2:
                    Modo2();
                    break;
                case 3:
                    Console.WriteLine("// Partidas ganadas del jugador 1: " + partidasJugadas[0, 0]);
                    Console.WriteLine("// Partidas ganadas del jugador 2: " + partidasJugadas[1, 0]);
                    Console.WriteLine("// Partidas ganadas del jugador 3: " + partidasJugadas[2, 0]);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("// Saliendo del juego");
                    break;
            }
            modoJuego = 0;
        }
        static void Main(string[] args)
        {
            while (modoJuego < 3)
            {
                LaGeneral lgn = new LaGeneral();
                lgn.JuegoDados();
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}