using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Properties
    {
        protected static double[] RealPrt { get; set; }
        protected static double[] ImaginPrt { get; set; }
        protected static int ComplexCount { get; set; }
        protected static double[,] ComplexNumber { get; set; }
        protected static double[,] SelectedComplexes { get; set; }
        protected static double[] MultipliedComplex { get; set; }
        protected static int Index { get; set; }
        protected static double[] ExpoComplex { get; set; }
        protected static double[] Tangent { get; set; }
        protected static double[] Cosine { get; set; }
        protected static double[] Sine { get; set; }
        protected static double[] NtimesAngledCosine { get; set; }
        protected static double[] NtimesAngledSine { get; set; }
        protected static double PI { get; set; }
        protected static double[,] AbsandArg { get; set; }
        protected static double[,] SelectedAbsandArg { get; set; }

        public void DeleteMemories()
        {
            if (RealPrt != null) RealPrt = null;
            if (ImaginPrt != null) ImaginPrt = null;
            if (ComplexNumber != null) ComplexNumber = null;
            if (SelectedComplexes != null) SelectedComplexes = null;
            if (MultipliedComplex != null) MultipliedComplex = null;
            if (ExpoComplex != null) ExpoComplex = null;
            if (Tangent != null) Tangent = null;
            if (Cosine != null) Cosine = null;
            if (Sine != null) Sine = null;
            if (NtimesAngledCosine != null) NtimesAngledCosine = null;
            if (NtimesAngledSine != null) NtimesAngledSine = null;
        }
        ~Properties()
        {
            if (RealPrt != null) RealPrt = null;
            if (ImaginPrt != null) ImaginPrt = null;
            if (ComplexNumber != null) ComplexNumber = null;
            if (SelectedComplexes != null) SelectedComplexes = null;
            if (MultipliedComplex != null) MultipliedComplex = null;
            if (ExpoComplex != null) ExpoComplex = null;
            if (Tangent != null) Tangent = null;
            if (Cosine != null) Cosine = null;
            if (Sine != null) Sine = null;
            if (NtimesAngledCosine != null) NtimesAngledCosine = null;
            if (NtimesAngledSine != null) NtimesAngledSine = null;
        }
    }
}
