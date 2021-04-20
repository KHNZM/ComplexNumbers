using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class BinomialTheorem : Properties
    {
        /// <summary>
        /// 実数の累乗
        /// </summary>
        /// <param name="realnum">底</param>
        /// <param name="index">指数</param>
        /// <returns></returns>
        public static double RealExpo(double realbase, int index)
        {
            int minusflg = 0;
            double powered = 1;
            double buf = 1;
            if (index == 0) return powered;
            if (index < 0)
            {
                index = (-1) * index;
                minusflg = 1;
            }
            for (int ic = 1; ic <= index; ic++) buf *= realbase;

            if (minusflg == 1) powered = 1 / buf;
            else powered = buf;

            return powered;
        }
        /// <summary>
        /// 実数の累乗 指数も実数ver.
        /// </summary>
        /// <param name="realnum">底</param>
        /// <param name="index">指数</param>
        /// <returns></returns>
        public static double RealExpo(double realbase, double index)
        {
            double powered = 0;
            double buf = 0;
            for (int ic = 0; ic < 500; ic++)
            {
                buf += RealExpo(Log(realbase), ic) * RealExpo(index, ic) / DoubleFactorial(ic);
            }
            powered = buf;
            return powered;
        }
        /// <summary>
        /// 自然対数
        /// </summary>
        /// <param name="x">真数</param>
        /// <returns></returns>
        private static double Log(double x)
        {
            double Val = 0;
            double y = (x - 1) / (x + 1);
            double buf = 0;

            for (int ic = 1; ic < 1000; ic += 2)
            {
                buf += RealExpo(y, ic) / ic;
            }
            Val = 2 * buf;
            return Val;
        }
        /// <summary>
        /// 対数
        /// </summary>
        /// <param name="LogBase">底</param>
        /// <param name="AntiLog">真数</param>
        /// <returns></returns>
        private static double Log(double LogBase, double AntiLog)
        {
            double Val = Log(AntiLog) / Log(LogBase);
            return Val;
        }
        /// <summary>
        /// 複素対数関数の主値
        /// </summary>
        /// <param name="Real"></param>
        /// <param name="Img"></param>
        /// <param name="LogReal"></param>
        /// <param name="LogImg"></param>
        private void LogPrincipal(double Real, double Img, ref double LogReal, ref double LogImg)
        {
            TrigonometFunc tri = new TrigonometFunc();
            double[] absbuf = new double[2];
            absbuf = TrigonometFunc.Sqrt(RealExpo(Real, 2) + RealExpo(Img, 2));
            LogReal = absbuf[0];
            
            if (Real > 0 && Img > 0)
            {
                LogImg = TrigonometFunc.Arctan(Img / Real);
            }
            if (Real < 0 && Img > 0)
            {
                LogImg = PI - TrigonometFunc.Arctan((-1) * Img / Real);
            }
            if (Real < 0 && Img < 0)
            {
                LogImg = PI + TrigonometFunc.Arctan(Img / Real);
            }
            if (Real > 0 && Img < 0)
            {
                LogImg = 2 * PI - TrigonometFunc.Arctan((-1) * Img / Real);
            }
            if (Real > 0 && Img == 0)
            {
                LogImg = 0;
            }
            if (Real < 0 && Img == 0)
            {
                LogImg = PI;
            }
            if (Real == 0 && Img > 0)
            {
                LogImg = PI / 2;
            }
            if (Real == 0 && Img < 0)
            {
                LogImg = 3 * PI / 2;
            }
            if (Real == 0 && Img == 0)
            {
                LogImg = 0;
            }
        }
        private double[] ComplexExpo(double realbase, double indexreal, double indeximg)
        {
            TrigonometFunc tri = new TrigonometFunc();
            double[] powered = new double[2];
            if (realbase == 0) return powered;

            double Napier = tri.CreateNapierFunc(1);

            powered[0] = RealExpo(Napier, Log(realbase)) * TrigonometFunc.RadCosine(indeximg * Log(realbase));
            powered[1] = RealExpo(Napier, Log(realbase)) * TrigonometFunc.RadSine(indeximg * Log(realbase));

            return powered;
        }
        /// <summary>
        /// 実数の階乗
        /// </summary>
        /// <param name="RealNum">階乗したい実数</param>
        /// <returns></returns>
        public static double DoubleFactorial(double RealNum)
        {
            double Val = 1;
            double buf = 1;
            double ic = RealNum;
            if (Math.Floor(RealNum) == 0) return Val;
            while (true)
            {
                buf *= ic;
                if (Math.Floor(ic) == 1) break;
                ic -= 1;
            }
            Val = buf;
            return Val;
        }
        /// <summary>
        /// 階乗
        /// </summary>
        /// <param name="Num">自然数</param>
        /// <returns></returns>
        private static int Factorial(int Num)
        {
            int Val = 1;
            int buf = 1;

            if (Num == 0) return Val;
            for (int ic = Num; ic >= 1; ic--) buf *= ic;

            Val = buf;
            return Val;
        }
        /// <summary>
        /// 偶数の階乗
        /// </summary>
        /// <param name="Num">自然数の偶数</param>
        /// <returns></returns>
        public int FactorialEven(int Num)
        {
            int Val = 1;
            int buf = 1;
            if (Num == 0) return Val;
            if (Num % 2 != 0)
            {
                Console.WriteLine("FactorialEven Error!!!");
                Console.WriteLine("上記関数には偶数値を入力すべし!!!");
                return 99999;
            }
            for (int ic = Num; ic >= 2; ic -= 2) buf *= ic;

            Val = buf;
            return Val;
        }
        /// <summary>
        /// 奇数の階乗
        /// </summary>
        /// <param name="Num">自然数の奇数</param>
        /// <returns></returns>
        public int FactorialOdd(int Num)
        {
            int Val = 1;
            int buf = 1;
            if (Num % 2 == 0)
            {
                Console.WriteLine("FactorialOdd Error!!!");
                Console.WriteLine("上記関数には奇数値を入力すべし!!!");
            }
            for (int ic = Num; ic >= 1; ic -= 2) buf *= ic;
            Val = buf;
            return Val;
        }
        /// <summary>
        /// 組み合わせ記号 nCr
        /// </summary>
        /// <param name="n">総数</param>
        /// <param name="r">取得する数</param>
        /// <returns></returns>
        public static int Combination(int n, int r)
        {
            int Combine = 1;
            if (n < r)
            {
                Console.WriteLine("くみあわせの条件がおかしいですよ。");
                return 99999;
            }

            Combine = Factorial(n) / (Factorial(r) * Factorial(n - r));

            return Combine;
        }
        /// <summary>
        /// 二項係数の一般化
        /// </summary>
        /// <param name="realnum">実数</param>
        /// <param name="cnt">取得する数(自然数)</param>
        /// <returns></returns>
        public double RealCombination(double realnum, int cnt)
        {
            double Val = 1;
            double buf = 1;
            int cntbuf = 0;
            if (realnum == 0 || cnt == 0) return Val;
            while (true)
            {
                buf = buf * (realnum - cntbuf);
                if (cntbuf == cnt - 1) break;
                cntbuf += 1;
            }
            Val = buf / DoubleFactorial(cnt);
            return Val;
        }
        /// <summary>
        /// 二項定理
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private double BinomialThmVal(double val1, double val2, int index)
        {
            double Val = 0;
            double buf = 0;

            for (int ic = 0; ic <= index; ic++)
            {
                buf += Combination(index, ic) * RealExpo(val1, index - ic) * RealExpo(val2, ic);
            }
            Val = buf;
            return Val;
        }
    }
}
