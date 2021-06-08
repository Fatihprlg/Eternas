using System;
using System.Collections;
using System.Collections.Generic;
namespace Eternas
{
    class Program
    {
        /*
         * Oyunda 8 tahta çubuk ve 32 boncuk (16 beyaz, 16 yeşil) bulunmaktadır.
           Oyun, 2 oyuncu (beyaz ve yeşil) tarafından oynanmaktadır.
           Oyuna ilk başlayan oyuncu her zaman beyaz oyuncudur.
           Her oyuncunun boncuğunu yerleştireceği çubuk random olarak belirlenir. (Kullanıcıdan input alınmayacaktır.)
           Bir çubuğa 4 tane kendi renginden boncuk yerleştiren ilk oyuncu oyunu kazanır.
           Oyun boyunca (32 boncuğun tamamının yerleştirilmesi sonucunda) kazanan bir oyuncu olmaması durumunda oyun berabere biter.
        */
        static void Main(string[] args)
        {
            List<Stack> sticks = new List<Stack>();
            Random random = new Random();
            bool scoreless = true;
            int nextStick;
            for (int i = 0; i < 8; i++)
            {
                Stack stick = new Stack();
                sticks.Add(stick);
            }

            for (int i = 0; i < 32; i++)
            {
                
                nextStick = random.Next(0, 8);
                while (sticks[nextStick].Count >=4)
                {
                    nextStick = random.Next(0, 8);
                }
                if (i%2 == 0)
                {
                    PrintGame(sticks);
                    sticks[nextStick].Push('W');
                }
                else
                {
                    sticks[nextStick].Push('G');
                }
                char winner = WinControl(sticks);
                if (winner != 'N')
                {
                    PrintGame(sticks);
                    Console.WriteLine("\n\nWinner : {0}", winner);
                    scoreless = false;
                    break;
                }
            }
            if (scoreless == true)
            {
                PrintGame(sticks);
                Console.WriteLine("\n\nScoreless");
            }

        }

        static char WinControl(List<Stack> stacks)
        {
            char winner = 'N'; //N = Null, W = White, G = Green
            foreach (Stack s in stacks)
            {
                if (s.Count == 4)
                {

                    string str = StackConvert(s);
                    switch (str)
                    {
                        case "WWWW":
                            winner = 'W';
                            break;
                        case "GGGG":
                            winner = 'G';
                            break;
                        default:
                            break;
                    }
                }
            }
            return winner;
        }

        static string StackConvert(Stack stack)
        {
            string str = "";
            foreach (object s in stack)
            {
                str += s.ToString();
            }
            return str;
        }
        static void PrintGame(List<Stack> stacks)
        {
            Console.Write("\n");
            for (int i = 0; i < stacks.Count; i++)
            {
                Console.Write("\n" +(i + 1) + ". ");
                foreach (char bead in stacks[i])
                {
                    Console.Write(bead);
                }
            }
        }
    }
}
