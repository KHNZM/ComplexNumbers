using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Complex : TrigonometFunc
    {
        protected static void Setup()
        {
            CreatePI();
            AskCount();
            AskValOfComplex();
        }
        private static void AskCount()
        {
            string Val = "";
            int check = 0;
            Console.WriteLine("複素数をいくつ用意しましょうか。");
            while (true)
            {
                Val = "";
                check = 0;
                Val = Console.ReadLine();
                if (!(int.TryParse(Val, out check)))
                {
                    Console.WriteLine("ちゃんと数値を入力してください。");
                    continue;
                }
                else if (check == 0)
                {
                    Console.WriteLine("いくつ欲しいのか、正の数を入力してください。");
                    continue;
                }
                else
                {
                    ComplexCount = check;
                    break;
                }
            }
        }
        private static void SetMemoryOfComplex()
        {
            ComplexNumber = new double[ComplexCount, 2];
            RealPrt = new double[ComplexCount];
            ImaginPrt = new double[ComplexCount];
        }
        private static void AskValOfComplex()
        {
            SetMemoryOfComplex();
            string Val = "";
            double check = 0;
            for (int ic = 0; ic < ComplexCount; ic++)
            {
                Console.WriteLine("{0}個目の複素数の実部と虚部を指定してください。", ic + 1);
                while (true)
                {
                    Val = "";
                    check = 0;
                    Console.WriteLine("実部：");
                    Val = Console.ReadLine();
                    if (!(double.TryParse(Val, out check)))
                    {
                        Console.WriteLine("ちゃんと数値を入力してください。");
                        continue;
                    }
                    RealPrt[ic] = check;
                    break;
                }
                while (true)
                {
                    Val = "";
                    check = 0;
                    Console.WriteLine("虚部：");
                    Val = Console.ReadLine();
                    if (!(double.TryParse(Val, out check)))
                    {
                        Console.WriteLine("ちゃんと数値を入力してください。");
                        continue;
                    }
                    ImaginPrt[ic] = check;
                    break;
                }
                ComplexNumber[ic, 0] = RealPrt[ic];
                ComplexNumber[ic, 1] = ImaginPrt[ic];
            }
            TellAbsandArg();
            Console.WriteLine();
            for (int ic = 0; ic < ComplexCount; ic++)
            {
                Console.WriteLine("{0}.  実部：{1}、虚部：{2}、絶対値：{3}、偏角：{4}π"
                                    ,ic + 1, RealPrt[ic], ImaginPrt[ic], AbsandArg[ic, 0], AbsandArg[ic, 1] / PI);
            }
        }
        //private int ImaginUnit(int index)
        //{
        //    int Img = 1;
        //    if (index % 2 == 0 && index % 4 != 0) return (-1) * Img;
        //    if (index % 4 == 0) return Img;
        //    return Img;
        //}
        //private void CreateComplex()
        //{
        //    //例) ComplexNumber[0, 0]:一つ目の複素数の実部、ComplexNumber[0, 1]:一つ目の複素数の虚部
        //    for (int ic = 0; ic < ComplexCount; ic++)
        //    {
        //        ComplexNumber[ic, 0] = RealPrt[ic];
        //        ComplexNumber[ic, 1] = ImaginPrt[ic];
        //    }
        //}
        /// <summary>
        /// 累乗する複素数を選択
        /// </summary>
        private static void Select1Complex()
        {
            SelectedComplexes = new double[1, 2];
            string Val = "";
            int check = 0;
            int selection = 0;
            while (true)
            {
                Val = "";
                check = 0;
                Console.WriteLine("複素数を選択してください。1～{0}", ComplexCount);
                Val = Console.ReadLine();
                if (!(int.TryParse(Val, out check)))
                {
                    Console.WriteLine("ちゃんと数値を入力してください。");
                    continue;
                }
                if (check > ComplexCount || check < 0)
                {
                    Console.WriteLine("1～{0}の数値を入力してください。", ComplexCount);
                    continue;
                }
                selection = check;
                break;
            }
            selection -= 1;
            SelectedComplexes[0, 0] = ComplexNumber[selection, 0];
            SelectedComplexes[0, 1] = ComplexNumber[selection, 1];
        }
        /// <summary>
        /// 掛け算をする二つの複素数を選ぶ。
        /// </summary>
        private static void Select2Complexes()
        {
            SelectedComplexes = new double[2, 2];
            string Val = "";
            int check = 0;
            int[] selection = new int[2] { -1, -1 };
            Console.WriteLine("積を求める二つの複素数を選択してください。");
            for (int ic = 0; ic < 2; ic++)
            {
                while (true)
                {
                    Val = "";
                    check = 0;
                    Console.WriteLine("{0}個目の複素数を選択してください。1～{1}", ic + 1, ComplexCount);
                    Val = Console.ReadLine();
                    if (!(int.TryParse(Val, out check)))
                    {
                        Console.WriteLine("ちゃんと数値を入力してください。");
                        continue;
                    }
                    if (check > ComplexCount || check < 0)
                    {
                        Console.WriteLine("1～{0}の数値を入力してください。", ComplexCount);
                    }
                    selection[ic] = check - 1;
                    break;
                }
            }
            if (selection[0] >= 0 && selection[1] >= 0)
            {
                SelectedComplexes[0, 0] = ComplexNumber[selection[0], 0];
                SelectedComplexes[0, 1] = ComplexNumber[selection[0], 1];
                SelectedComplexes[1, 0] = ComplexNumber[selection[1], 0];
                SelectedComplexes[1, 1] = ComplexNumber[selection[1], 1];
            }
        }
        /// <summary>
        /// 回転する複数の複素数を選択
        /// </summary>
        private static void SelectRollComplexes()
        {
            string Val = "";
            int check = 0;
            int ic = 0;
            int[] selection = new int[ComplexCount];
            Console.WriteLine("回転する複素数を選択してください。(複数選択可)");
            while (true)
            {
                while (true)
                {
                    Val = "";
                    check = 0;
                    Console.WriteLine("{0}個目、どれを回転させたいですか？", ic + 1);
                    Val = Console.ReadLine();
                    if (!(int.TryParse(Val, out check)))
                    {
                        Console.WriteLine("ちゃんと数値を入力してください。");
                        continue;
                    }
                    if (check > ComplexCount || check < 0)
                    {
                        Console.WriteLine("1～{0}の数値を入力してください。", ComplexCount);
                    }
                    selection[ic] = check - 1;
                    break;
                }
                while (true)
                {
                    Val = "";
                    Console.WriteLine("まだ選択しますか？");
                    Console.WriteLine("y:はい、n:いいえ");
                    Val = Console.ReadLine();
                    if (Val == "y" || Val == "n") break;
                }
                if (Val == "y")
                {
                    ic += 1;
                    if (ic == ComplexCount)
                    {
                        Console.WriteLine("もう全部選んだでしょ。");
                        break;
                    }
                    else continue;
                }
                if (Val == "n") break;
            }
            SelectedComplexes = new double[ic, 2];
            SelectedAbsandArg = new double[ic, 2];
            for (int jc = 0; jc < ic; jc++)
            {
                SelectedComplexes[jc, 0] = ComplexNumber[selection[jc], 0];
                SelectedComplexes[jc, 1] = ComplexNumber[selection[jc], 0];
                SelectedAbsandArg[jc, 0] = AbsandArg[selection[jc], 0];
                SelectedAbsandArg[jc, 1] = AbsandArg[selection[jc], 1];
            }
        }
        /// <summary>
        /// 純粋に積を求めるメソッド
        /// </summary>
        private static void MultiplyComplex()
        {
            MultipliedComplex = new double[2];
            MultipliedComplex[0] = SelectedComplexes[0, 0] * SelectedComplexes[1, 0] - SelectedComplexes[0, 1] * SelectedComplexes[1, 1];
            MultipliedComplex[1] = SelectedComplexes[0, 0] * SelectedComplexes[1, 1] + SelectedComplexes[0, 1] * SelectedComplexes[1, 0];
        }
        /// <summary>
        /// 累乗のための積のオーバーロードメソッド
        /// </summary>
        /// <param name="Complex1">複素数1</param>
        /// <param name="Complex2">複素数2</param>
        /// <returns></returns>
        private static double[] MultiplyComplex(double[] Complex1, double[] Complex2)
        {
            double[] Complex = new double[2];
            Complex[0] = Complex1[0] * Complex2[0] - Complex1[1] * Complex2[1];
            Complex[1] = Complex1[0] * Complex2[1] + Complex1[1] * Complex2[0];

            return Complex;
        }
        private static void AskIndex()
        {
            string Val = "";
            int check = 0;
            Console.WriteLine("何乗しましょうか？");
            while (true)
            {
                Val = "";
                check = 0;
                Val = Console.ReadLine();
                if (!(int.TryParse(Val, out check)))
                {
                    Console.WriteLine("ちゃんと値を入力してください。");
                    continue;
                }
                else if (check < 0)
                {
                    Console.WriteLine("今のところ負の指数には対応しておりません。");
                    continue;
                }
                Index = check;
                break;
            }
        }
        private static void ExponentiateComplex(double[,] Complex)
        {
            AskIndex();
            ExpoComplex = new double[2];
            double[] buf = new double[2] { Complex[0, 0], Complex[0, 1] };
            double[] CopyComplex = new double[2] { Complex[0, 0], Complex[0, 1] };
            MultipliedComplex = new double[2];
            for (int ic = 2; ic <= Index; ic++)
            {
                buf = MultiplyComplex(buf, CopyComplex);
            }
            Array.Copy(buf, ExpoComplex, buf.Length);
        }
        /// <summary>
        /// 選択された複素数の回転メソッド
        /// 指定方法は、例えば1と打つとπラジアンだけ回転
        /// </summary>
        private static void RollComplexes()
        {
            string Val = "";
            double check = 0;
            double[] RollList = new double[SelectedComplexes.Length / 2];
            Cosine = new double[SelectedComplexes.Length / 2];
            Sine = new double[SelectedComplexes.Length / 2];

            while (true)
            {
                Console.WriteLine("a：全て同じラジアンでの回転, b：回転ラジアンをそれぞれ指定");
                Val = Console.ReadLine();
                if (Val == "a" || Val == "b") break;
            }
            if (Val == "a")
            {
                while (true)
                {
                    Val = "";
                    check = 0;
                    Console.WriteLine("何πラジアン回転しましょうか？(πを記入する必要はありません。)");
                    Val = Console.ReadLine();
                    if (double.TryParse(Val, out check))
                    {
                        RollList[0] = check * PI;
                        break;
                    }
                }
                //回転の処理
                for (int cnt = 0; cnt < SelectedComplexes.Length / 2; cnt++)
                {
                    Cosine[cnt] = RadCosine(SelectedAbsandArg[cnt, 1] + RollList[0]);
                    Sine[cnt] = RadSine(SelectedAbsandArg[cnt, 1] + RollList[0]);
                    SelectedAbsandArg[cnt, 1] = SelectedAbsandArg[cnt, 1] + RollList[0];
                }
            }
            else
            {
                Console.WriteLine("それぞれ何πラジアン回転しましょうか？(πを記入する必要はありません。)");
                int ic = 0;

                while (true)
                {
                    Val = "";
                    Console.WriteLine("{0}.の回転ラジアン", ic + 1);
                    Val = Console.ReadLine();
                    if (double.TryParse(Val, out check))
                    {
                        RollList[ic] = check * PI;
                        ic += 1;
                    }
                    else continue;
                    if (ic == SelectedComplexes.Length / 2) break;
                }
                //回転の処理
                for (int cnt = 0; cnt < SelectedComplexes.Length / 2; cnt++)
                {
                    Cosine[cnt] = RadCosine(SelectedAbsandArg[cnt, 1] + RollList[cnt]);
                    Sine[cnt] = RadSine(SelectedAbsandArg[cnt, 1] + RollList[cnt]);
                    SelectedAbsandArg[cnt, 1] = SelectedAbsandArg[cnt, 1] + RollList[cnt];
                }
            }
        }
        protected static void ShowMultipliedComplex()
        {
            Select2Complexes();
            MultiplyComplex();
            Console.WriteLine(Environment.NewLine + "積は、");
            Console.WriteLine("実部：{0}、虚部：{1}", MultipliedComplex[0], MultipliedComplex[1] + Environment.NewLine);
        }
        protected static void ShowExpoComplex()
        {
            Select1Complex();
            ExponentiateComplex(SelectedComplexes);
            Console.WriteLine("この複素数の{0}乗は、", Index);
            Console.WriteLine("実部：{0}、虚部：{1}", ExpoComplex[0], ExpoComplex[1]);
        }
        protected static void ShowRolledComplex()
        {
            SelectRollComplexes();
            RollComplexes();
            for (int ic = 0; ic < SelectedComplexes.Length / 2; ic++)
            {
                while (true)
                {
                    if (SelectedAbsandArg[ic, 1] >= 2 * PI) SelectedAbsandArg[ic, 1] -= 2 * PI;
                    if (SelectedAbsandArg[ic, 1] < 2 * PI) break;
                }
                Console.WriteLine("実部：{0}、虚部：{1}、絶対値：{2}、偏角：{3}π"
                                    , SelectedAbsandArg[ic, 0] * Cosine[ic]
                                    , SelectedAbsandArg[ic, 0] * Sine[ic]
                                    , SelectedAbsandArg[ic, 0]
                                    , SelectedAbsandArg[ic, 1] / PI);
            }
        }
    }
}
