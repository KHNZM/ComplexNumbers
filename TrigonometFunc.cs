using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class TrigonometFunc : Properties
    {
        /// <summary>
        /// ニュートン法により、正の平方根を求める。虚数単位に対応。
        /// </summary>
        /// <param name="a">正の平方根を求めたい実数</param>
        /// <returns></returns>
        public static double[] Sqrt(double a)
        {
            double[] sqrt = new double[2];
            double[] buf = new double[2] { 1, 1 };
            double temp = 0;

            if (a > 0)
            {
                while (temp != buf[0])
                {
                    temp = buf[0];
                    buf[0] = (BinomialTheorem.RealExpo(buf[0], 2) + a) / (2 * buf[0]);
                }
                sqrt[0] = buf[0];
            }
            else if (a == 0)
            {
                return sqrt;
            }
            else
            {
                a = (-1) * a;
                while (temp != buf[1])
                {
                    temp = buf[1];
                    buf[1] = (BinomialTheorem.RealExpo(buf[1], 2) + a) / (2 * buf[1]);
                }
                sqrt[1] = buf[1];
            }

            return sqrt;
        }
        private double[] CreateTangent()
        {
            Tangent = new double[ComplexCount];

            for (int ic = 0; ic < ComplexCount; ic++) Tangent[ic] = ImaginPrt[ic] / RealPrt[ic];

            return Tangent;
        }
        private double[] CreateCosine()
        {
            Cosine = new double[ComplexCount];
            for (int ic = 0; ic < ComplexCount; ic++)
            {
                Cosine[ic] = ImaginPrt[ic] / Math.Sqrt(BinomialTheorem.RealExpo(RealPrt[ic], 2) + BinomialTheorem.RealExpo(ImaginPrt[ic], 2));
            }
            return Cosine;
        }
        private double[] CreateSine()
        {
            Sine = new double[ComplexCount];
            for (int ic = 0; ic < ComplexCount; ic++)
            {
                Sine[ic] = RealPrt[ic] / Math.Sqrt(BinomialTheorem.RealExpo(RealPrt[ic], 2) + BinomialTheorem.RealExpo(ImaginPrt[ic], 2));
            }
            return Sine;
        }
        /// <summary>
        /// ラジアンを入力すると余弦の値を返す。0 <= rad < 2PI
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        public static double RadCosine(double rad)
        {
            double Cos = 0;
            double buf = 0;
            if (rad == PI / 2) return 0;
            if (rad == PI / 3) return 0.5;
            if (rad == 0)      return 1;
            for (int ic = 0; ic < 100; ic++)
            {
                buf += BinomialTheorem.RealExpo(-1, ic) * BinomialTheorem.RealExpo(rad, 2 * ic) / BinomialTheorem.DoubleFactorial(2 * ic);
            }
            Cos = buf;
            return Cos;
        }
        /// <summary>
        /// ラジアンを入力すると正弦の値を返す。0 <= rad < 2PI
        /// </summary>
        /// <param name="rad">ラジアン</param>
        /// <returns></returns>
        public static double RadSine(double rad)
        {
            double Sine = 0;
            double buf = 0;
            if (rad == PI / 2) return 1;
            if (rad == PI / 6) return 0.5;
            if (rad == 0)      return 0;
            if (Math.Floor(rad % PI) == rad % PI) return 0;
            for (int ic = 0; ic < 100; ic ++)
            {
                buf += BinomialTheorem.RealExpo(-1, ic) * BinomialTheorem.RealExpo(rad, 2 * ic + 1) / BinomialTheorem.DoubleFactorial(2 * ic + 1);
            }
            Sine = buf;
            return Sine;
        }
        /// <summary>
        /// 逆正接 連分数展開により求める。
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double Arctan(double val)
        {
            double arctan;
            double buf = val;
            double random = double.MaxValue;
            for (int ic = 10000; ic >= 1; ic--)
            {
                buf = 2 * ic - 1 + (BinomialTheorem.RealExpo(ic, 2) * BinomialTheorem.RealExpo(val, 2)) / random;
                random = buf;
            }
            arctan = val / buf;
            return arctan;
        }
        /// <summary>
        /// 余弦の引数倍角の値を計算する。引数が2だったら2倍角、3だったら3倍角。
        /// チェビシェフの公式を使用
        /// </summary>
        /// <param name="Num"></param>
        private void NtimesAngleCosine(int Num)
        {
            for (int select = 0; select < SelectedComplexes.Length; select++)
            {
                for (int ic = 0; ic <= Math.Floor((double)Num / 2); ic++)
                {
                    NtimesAngledCosine[select] += BinomialTheorem.RealExpo(-1, ic) * Num * BinomialTheorem.Combination(Num - ic, ic) * BinomialTheorem.RealExpo(2 * Cosine[select - 1], Num - 2 * ic) / (2 * (Num - ic));
                }
            }
        }
        /// <summary>
        /// 正弦の引数倍角の値を計算する。引数が2だったら2倍角、3だったら3倍角。
        /// チェビシェフの公式を使用
        /// </summary>
        /// <param name="Num"></param>
        private void NtimesAngleSine(int Num)
        {
            for (int select = 0; select < SelectedComplexes.Length; select++)
            {
                for (int ic = 0; ic <= Math.Floor((double)(Num - 1) / 2); ic++)
                {
                    NtimesAngledSine[select] += BinomialTheorem.RealExpo(-1, ic) * BinomialTheorem.Combination(Num - ic - 1, ic) * BinomialTheorem.RealExpo(2 * Cosine[select - 1], Num - 2 * ic - 1);
                }
            }
        }
        /// <summary>
        /// 円周率を求める。
        /// ラマヌジャンの公式を使用
        /// </summary>
        protected static void CreatePI()
        {
            double buf1 = 0;
            double buf2 = 1;
            int ic = 0;

            while (buf1 != buf2)
            {
                buf2 = buf1;

                buf1 += (BinomialTheorem.RealExpo(-1, ic) * BinomialTheorem.DoubleFactorial(4 * ic) * (1123 + 21460 * ic))
                    / (BinomialTheorem.RealExpo(882, 2 * ic + 1) * BinomialTheorem.RealExpo(BinomialTheorem.RealExpo(4, ic) * BinomialTheorem.DoubleFactorial(ic), 4));

                ic += 1;
            }
            PI = 4 / buf1;
        }
        /// <summary>
        /// 自然対数の底の指数関数。マクローリン展開の収束半径が∞であることを利用。
        /// </summary>
        /// <param name="val">指数</param>
        /// <returns></returns>
        public double CreateNapierFunc(double val)
        {
            double Val = 0;
            double buf = 0;

            for (int ic = 0; ic < 1000; ic++) buf += BinomialTheorem.RealExpo(val, ic) / BinomialTheorem.DoubleFactorial(ic);
            Val = buf;

            return Val;
        }
        protected static void TellAbsandArg()
        {
            AbsandArg = new double[ComplexCount, 2];
            for (int ic = 0; ic < ComplexCount; ic++)
            {
                double[] sqrtbuf = Sqrt(BinomialTheorem.RealExpo(ComplexNumber[ic, 0], 2) + BinomialTheorem.RealExpo(ComplexNumber[ic, 1], 2));
                AbsandArg[ic, 0] = sqrtbuf[0];
                if (ComplexNumber[ic, 0] > 0 && ComplexNumber[ic, 1] > 0)
                {
                    AbsandArg[ic, 1] = Arctan(ComplexNumber[ic, 1] / ComplexNumber[ic, 0]);
                }
                else if (ComplexNumber[ic, 0] < 0 && ComplexNumber[ic, 1] > 0)
                {
                    AbsandArg[ic, 1] = PI - Arctan((-1) * ComplexNumber[ic, 1] / ComplexNumber[ic, 0]);
                }
                else if (ComplexNumber[ic, 0] < 0 && ComplexNumber[ic, 1] < 0)
                {
                    AbsandArg[ic, 1] = PI + Arctan(ComplexNumber[ic, 1] / ComplexNumber[ic, 0]);
                }
                else if (ComplexNumber[ic, 0] > 0 && ComplexNumber[ic, 1] < 0)
                {
                    AbsandArg[ic, 1] = 2 * PI - Arctan((-1) * ComplexNumber[ic, 1] / ComplexNumber[ic, 0]);
                }
                else if (ComplexNumber[ic, 0] > 0 && ComplexNumber[ic, 1] == 0)
                {
                    AbsandArg[ic, 1] = 0;
                }
                else if (ComplexNumber[ic, 0] < 0 && ComplexNumber[ic, 1] == 0)
                {
                    AbsandArg[ic, 1] = PI;
                }
                else if (ComplexNumber[ic, 0] == 0 && ComplexNumber[ic, 1] > 0)
                {
                    AbsandArg[ic, 1] = PI / 2;
                }
                else if (ComplexNumber[ic, 0] == 0 && ComplexNumber[ic, 1] < 0)
                {
                    AbsandArg[ic, 1] = 3 * PI / 2;
                }
                else if (ComplexNumber[ic, 0] == 0 && ComplexNumber[ic, 1] == 0)
                {
                    AbsandArg[ic, 1] = 0;
                }
                sqrtbuf = null;
            }
        }
    }
}
