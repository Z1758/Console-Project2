using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    public static class GamaOver
    {

        public static void OutPutGameOver(bool flag)
        {
            Console.Clear();

     


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            string[] gameover =
{"  ■■■    ■■    ■      ■  ■■■■        ■■    ■      ■  ■■■■  ■■■    \n",
"■        ■    ■  ■■  ■■  ■            ■    ■  ■      ■  ■        ■    ■  \n",
"■  ■■  ■■■■  ■  ■  ■  ■■■        ■    ■  ■      ■  ■■■    ■■■   \n",
"■    ■  ■    ■  ■      ■  ■            ■    ■    ■  ■    ■        ■    ■  \n",
"  ■■■  ■    ■  ■      ■  ■■■■        ■■        ■      ■■■■  ■    ■ \n"};

          
            string[]  clear =
                    
{ " ■■■   ■        ■■■■    ■■    ■■■\n",
"■   ■   ■        ■         ■  ■   ■  ■\n",
"■        ■        ■■■     ■■■   ■■■\n",
"■   ■   ■        ■         ■  ■   ■ ■\n",
" ■■■   ■■■■  ■■■■   ■  ■   ■  ■\n",
};
            string[] output;

            if (flag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                output = clear;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                output = gameover;
            }
         
            int cnt = 0;
            while (cnt < output[3].Length)
            {
                
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(10);

                int z = 0;

                for (int i = 0; i < output.Length; i++)
                {
                 
                    for (int j = 0; j < output[i].Length; j++)
                    {
                        z = output[i].Length - 1;
                        if (j <= cnt)
                        {

                            Console.Write(output[i][j]);


                        }
                        else if (j >= z - cnt)
                        {

                            Console.Write(output[i][j]);

                        }
                        else
                        {
                            if (output[i][j] == '■')
                            {

                                Console.Write("  ");
                            }
                            else
                            {
                                Console.Write(output[i][j]);
                            }
                        }

                    }

                }
                cnt++;
            }


            Console.ResetColor();


            Console.WriteLine("ReStart? Yes == 1 \n");
        } 
    }
}
