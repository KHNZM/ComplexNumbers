using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class CUI : Complex
    {
        protected static void ShowCUI()
        {
            string Val = "";
            int check = 0;
            int select = 0;
            int exitnum = 5;
            try
            {
                Setup();

                while (true)
                {
                    if (select == exitnum - 1) Setup();
                    Console.WriteLine();
                    Console.WriteLine("上記複素数で何しましょうか？" + Environment.NewLine);
                    Console.WriteLine("1:指定された二つの複素数の積");
                    Console.WriteLine("2:指定された複素数の累乗");
                    Console.WriteLine("3:指定された複素数の回転");
                    Console.WriteLine("4:複素数の入力しなおし");
                    Console.WriteLine("5:終了");
                    Val = Console.ReadLine();
                    if (!(int.TryParse(Val, out check)))
                    {
                        Console.WriteLine("ちゃんと1～{0}の値を選択してください。", exitnum);
                        continue;
                    }
                    else if (check < 1 || check > exitnum)
                    {
                        Console.WriteLine("選択肢は1～{0}ですよ。Try again!!!", exitnum);
                        Console.WriteLine();
                        continue;
                    }
                    int.TryParse(Val, out select);
                    switch (select)
                    {
                        case 1:
                            ShowMultipliedComplex();
                            break;
                        case 2:
                            ShowExpoComplex();
                            break;
                        case 3:
                            ShowRolledComplex();
                            break;
                        case 4:
                            break;
                        default:
                            break;
                    }
                    if (select == exitnum) break;
                    while (true)
                    {
                        Val = "";
                        Console.WriteLine("まだ続けますか？");
                        Console.WriteLine("y:続ける、n:やめる");
                        Val = Console.ReadLine();
                        if (Val == "y" || Val == "n") break;
                    }
                    if (Val == "y") continue;
                    if (Val == "n") break;
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
        }
    }
}
