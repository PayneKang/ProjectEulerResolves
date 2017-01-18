using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kang.Algorithm.BaseLib.Formulas
{
    public class QuadResultModel
    {
        public bool HaveSolution { get; set; }
        public int SolutionType { get; set; }
        public long Xi { get; set; }
        public long Xl { get; set; }
        public long Yi { get; set; }
        public long Yl { get; set; }
    }
    /// <summary>
    /// 对公式: a * x^2 + b * x * y + c * y^2 + d*x + e*y + f = 0求解
    /// </summary>
    public class QuadFormula
    {
        public const string ANY_INTEGER = "Any Integer";
        public const string NO_SOLUTION = "No solution";
        private QuadFormula() { }
        public long A { get; private set; }
        public long B { get; private set; }
        public long C { get; private set; }
        public long D { get; private set; }
        public long E { get; private set; }
        public long F { get; private set; }

        private long Mi;
        private long Bi;
        private long[] NUM = new long[6];
        private long[] DEN = new long[6];
        private long DET;
        private long SQD;
        private long DosALa32;
        private long DosALa31;
        private double dDosALa32;
        private double dDosALa64;
        private double dDosALa96;
        private double dDosALa128;
        private double dDosALa160;
        private long DosALa32_1;
        private long A1;
        private long A2;
        private long B1;
        private long B2;
        private long CY1, CY0;
        private int NbrSols, NbrCo, NbrEqs, EqNbr;
        public QuadFormula(int a, int b, int c, int d, int e, int f)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            this.D = d;
            this.E = e;
            this.F = f;
            DosALa32 = (long)1 << 32;
            DosALa31 = (long)1 << 31;
            dDosALa32 = (double)DosALa32;
            dDosALa64 = dDosALa32 * dDosALa32;
            dDosALa96 = dDosALa64 * dDosALa32;
            dDosALa128 = dDosALa96 * dDosALa32;
            dDosALa160 = dDosALa128 * dDosALa32;
            DosALa32_1 = DosALa32 - 1;
            Mi = 1000000000;
            Bi = Mi * Mi;
        }
        public override string ToString()
        {
            return string.Format("{0} * x^2 + {1} * x * y + {2} * y^2 + {3} * x + {4} * y + {5} = 0", this.A, this.B, this.C, this.D, this.E, this.F);
        }
        public QuadResultModel CalculateLinearSolution(long d, long e, long f)
        {
            Console.WriteLine("This is a linear equation {0} * x + {1} * y = {2}", d, e, f);
            if (d == 0)
            {
                if (e == 0)
                {
                    if (f != 0)
                        return new QuadResultModel() { HaveSolution = false };
                    return new QuadResultModel() { HaveSolution = true, SolutionType = 2 };
                }
                if (f % e != 0)
                    return new QuadResultModel() { HaveSolution = false };
                return new QuadResultModel() { HaveSolution = true, SolutionType = 0, Xi = 0, Xl = 1, Yl = 0, Yi = -f / e };
            }
            if (e == 0)
            {
                if (f % d != 0)
                    return new QuadResultModel() { HaveSolution = false };
                return new QuadResultModel() { HaveSolution = true, SolutionType = 0, Xi = -f / d, Xl = 0, Yi = 0, Yl = 1 };
            }

            long Q = NumberUtils.GCD(this.D, this.E);
            if (Q != 1 && Q != -1)
            {
                if (f % Q != 0)
                    return new QuadResultModel() { HaveSolution = false };
                while (d % Q == 0 && e % Q == 0 && f % Q == 0)
                {
                    d = d / Q;
                    e = e / Q;
                    f = f / Q;
                }
            }
            long u1 = 1; long u2 = 0; long u3 = d;
            long v1 = 0; long v2 = 1; long v3 = e;
            long t = 1;
            while (v3 != 0)
            {
                long q = floorDiv(u3, v3);
                long t1 = u1 - q * v1;
                long t2 = u2 - q * v2;
                long t3 = u3 - q * v3;
                u1 = v1; u2 = v2; u3 = v3;
                v1 = t1; v2 = t2; v3 = t3;
                t++;
            }
            QuadResultModel result = new QuadResultModel() { Xi = -u1 * f / u3, Xl = e, Yi = -u2 * f / u3, Yl = -d };
            v1 = d * d + e * e;
            long tx = floorDiv((d * result.Yi - e * result.Xi) + v1 / 2, v1);
            result.Xi += e * tx; result.Yi += -d * tx;
            if (result.Xl < 0 && result.Yl < 0)
            {
                result.Xl = -result.Xl;
                result.Yl = -result.Yl;
            }
            result.HaveSolution = true;
            result.SolutionType = 0;
            return result;
        }
        public QuadResultModel CalculateSolution()
        {
            if (this.A == this.B && this.A == this.C && this.A == 0)
            {
                return CalculateLinearSolution(this.D, this.E, this.F);
            }

            /*
            long G, H, K, T;
            long S;
            long t;
            long[] biA = new long[6];
            long[] biB = new long[6];
            long[] biC = new long[6];

            t = gcd(this.A, gcd(this.B, gcd(this.C, gcd(this.D, this.E))));

            if (t != 0)
            {
                if (this.F % t != 0)
                    return new QuadResultModel() { HaveSolution = false };
                this.A /= t;
                this.B /= t;
                this.C /= t;
                this.D /= t;
                this.E /= t;
                this.F /= t;
            }
            if (this.D == 0 && this.A != 0 && this.C != 0)
            {
                if (CheckMod(this.A, this.B, this.C, this.E, this.F))
                    return new QuadResultModel() { HaveSolution = false };
            }
            if (this.E == 0 && this.A != 0 && this.C != 0)
            {
                if (CheckMod(this.B, this.C, this.A, this.D, this.F))
                    return new QuadResultModel() { HaveSolution = false };
            }

            S = this.B * this.B - 4 * this.A * this.C;

            if (S > 0 && sqrt(S) * sqrt(S) != S && this.D == 0 && this.E == 0 && this.F != 0)
            {
                LongToDoublePrecLong(this.A, out biA);
                LongToDoublePrecLong(this.B, out biB);
                LongToDoublePrecLong(this.C, out biC);
                GetRoot(biA, biB, biC);
                G = H = F; K = 1; T = 3;
                while (G % 4 == 0)
                {
                    G /= 4;
                    K *= 2;
                }
                while (abs(G) >= T * T)
                {
                    while (G % (T * T) == 0)
                    {
                        G /= T * T;
                        K *= T;
                    }
                    T += 2;
                }
                for (T = 1; T * T <= K; T++)
                {
                    if (K % T == 0)
                    {
                        SolContFrac(H, T, A, B, C, "");
                    }
                }        
        
            }
            */
            return null;
        }
        private long floorDiv(long num, long den)
        {
            if ((num < 0 && den > 0 || num > 0 && den < 0) && num % den != 0)
            {
                return num / den - 1;
            }
            return num / den;
        }
        private long gcd(long M, long N)
        {
            long P = M;
            long Q = N;
            while (P != 0)
            {
                long R = Q % P;
                Q = P;
                P = R;
            }
            return abs(Q);
        }
        private long abs(long num)
        {
            return (num < 0) ? -num : num;
        }

        private long[] H1;
        private long[] H2;
        private long[] K1;
        private long[] K2;
        private long[] L1;
        private long[] L2;
        private bool CheckMod(long R, long S, long X2, long X1, long X0)
        {
            long Y2 = gcd(R, S);
            long Y1 = 2;
            int indH = 1;
            long D1 = abs(Y2);
            while (D1 >= Y1 * Y1)
            {
                int T = 0;
                while (D1 % Y1 == 0)
                {
                    T++;
                    if (T == 1)
                    {
                        H1[indH++] = Y1;
                    }
                    D1 /= Y1;
                }
                Y1++;
                if (Y1 > 3)
                {
                    Y1++;
                }
            }
            if (D1 > 1)
            {
                H1[indH++] = D1;
            }
            for (int T = 1; T < indH; T++)
            {
                if (H1[T] > 1)
                {
                    long Z = ((X1 * X1 - 4 * X0 * X2) % H1[T]) + H1[T];
                    long N = (H1[T] - 1) / 2;
                    long Y = 1;
                    while (N != 0)
                    {
                        if (N % 2 != 0)
                        {
                            Y = (Y * Z) % H1[T];
                        }
                        N /= 2;
                        Z = (Z * Z) % H1[T];
                    }
                    if (Y > 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private long sqrt(long num)
        {
            long num1 = 0;
            long num2 = (long)65536 * (long)32768;  /* 2^31 */
            while (num2 != 0)
            {
                if ((num1 + num2) * (num1 + num2) <= num)
                {
                    num1 += num2;
                }
                num2 /= 2;
            }
            return num1;
        }

        private void LongToDoublePrecLong(long Nbr, out long[] Out)
        {
            long[] result = new long[6];
            result[0] = Nbr & DosALa32_1;
            result[1] = Nbr >> 32;
            result[2] = result[3] = result[4] = result[5] = (Nbr < 0 ? DosALa32_1 : 0);
            Out = result;
        }
        private void AddDoublePrecLong(long[] Nbr1, long[] Nbr2, long[] Sum)
        {
            long Cy = 0;
            for (int i = 0; i < 6; i++)
            {
                Cy += Nbr1[i] + Nbr2[i];
                Sum[i] = Cy & DosALa32_1;
                Cy >>= 32;
            }
        }
        private void ChSignDoublePrecLong(long[] Nbr)
        {
            long Cy = 0;
            for (int i = 0; i < 6; i++)
            {
                Cy -= Nbr[i];
                Nbr[i] = (Cy >= 0 ? Cy : Cy + DosALa32);
                Cy = (Cy >= 0 ? 0 : -1);
            }
        }

        private void MultDoublePrecLong(long[] Nbr1, long[] Nbr2, long[] Prod)
        {
            long Cy, Pr;
            int i, j;
            Cy = Pr = 0;
            for (i = 0; i < 6; i++)
            {
                Pr = Cy & DosALa32_1;
                Cy >>= 32;
                for (j = 0; j <= i; j++)
                {
                    Pr += Nbr1[j] * Nbr2[i - j];
                    Cy += (Pr >> 32);
                    Pr &= DosALa32_1;
                }
                Prod[i] = Pr;
            }
        }

        private void DivDoublePrecLongByLong(long[] Dividend, long Divisor, long[] Quotient)
        {
            int i;
            bool ChSignDivisor = false;
            long Divid, Rem = 0;

            if (Divisor < 0)
            {
                ChSignDivisor = true;
                Divisor = -Divisor;
            }
            if (Dividend[5] >= DosALa31)
            {
                Rem = Divisor - 1;
            }
            for (i = 5; i >= 0; i--)
            {
                Divid = Dividend[i] + (Rem << 32);
                Rem = Divid % Divisor;
                Quotient[i] = Divid / Divisor;
            }
            if (ChSignDivisor)
            {
                ChSignDoublePrecLong(Quotient);
            }
        }
        private void SubtDoublePrecLong(long[] Nbr1, long[] Nbr2, long[] Diff)
        {
            long Cy = 0;
            for (int i = 0; i < 6; i++)
            {
                Cy += Nbr1[i] - Nbr2[i];
                Diff[i] = Cy & DosALa32_1;
                Cy = (Cy >= 0 ? 0 : -1);
            }
        }
        private void GcdDoublePrecLong(long[] Nbr1, long[] Nbr2, long[] Gcd)
        {
            long[] u = new long[6];
            long[] v = new long[6];
            long[] t = new long[6];
            int k;

            Array.Copy(Nbr1, 0, u, 0, 6);
            Array.Copy(Nbr2, 0, v, 0, 6);
            if (u[0] == 0 && u[1] == 0 && u[2] == 0 && u[3] == 0 && u[4] == 0 && u[5] == 0)
            {
                Array.Copy(v, 0, Gcd, 0, 6);
                return;
            }
            if (v[0] == 0 && v[1] == 0 && v[2] == 0 && v[3] == 0 && v[4] == 0 && v[5] == 0)
            {
                Array.Copy(u, 0, Gcd, 0, 6);
                return;
            }
            if (u[5] >= DosALa31)
            {
                ChSignDoublePrecLong(u);
            }
            if (v[5] >= DosALa31)
            {
                ChSignDoublePrecLong(v);
            }
            k = 0;
            while ((u[0] & 1) == 0 && (v[0] & 1) == 0)
            {   // Step 1
                k++;
                DivDoublePrecLongByLong(u, 2, u);
                DivDoublePrecLongByLong(v, 2, v);
            }
            if ((u[0] & 1) == 1)
            {                       // Step 2
                Array.Copy(v, 0, t, 0, 6);
                ChSignDoublePrecLong(t);
            }
            else
            {
                Array.Copy(u, 0, t, 0, 6);
            }
            do
            {
                while ((t[0] & 1) == 0)
                {                  // Step 4
                    DivDoublePrecLongByLong(t, 2, t);        // Step 3
                }
                if (t[5] < DosALa31)
                {                   // Step 5
                    Array.Copy(t, 0, u, 0, 6);
                }
                else
                {
                    Array.Copy(t, 0, v, 0, 6);
                    ChSignDoublePrecLong(v);
                }
                SubtDoublePrecLong(u, v, t);               // Step 6

            } while (t[0] != 0 || t[1] != 0 || t[2] != 0 || t[3] != 0 || t[4] != 0 || t[5] != 0);
            Array.Copy(u, 0, Gcd, 0, 6);             // Step 7
            while (k > 0)
            {
                AddDoublePrecLong(Gcd, Gcd, Gcd);
                k--;
            }
        }
        private void GetRoot(long[] biA, long[] biB, long[] biC)
        {
            long G, K, L, M, P, S, T, Z;
            long[] biP = new long[6];
            long[] biM = new long[6];
            long[] biZ = new long[6];
            long[] biG = new long[6];
            long[] biK = new long[6];
            bool DENis1;
            bool NUMis0;

            G = biA[1] * DosALa32 + biA[0];
            K = biB[1] * DosALa32 + biB[0];
            L = biC[1] * DosALa32 + biC[0];
            DET = K * K - 4 * G * L;
            Array.Copy(biB, 0, NUM, 0, 6);
            ChSignDoublePrecLong(NUM);
            NUMis0 = (NUM[0] == 0 && NUM[1] == 0 && NUM[2] == 0 && NUM[3] == 0 && NUM[4] == 0 && NUM[5] == 0);
            AddDoublePrecLong(biA, biA, DEN);

            GcdDoublePrecLong(NUM, DEN, biG);
            MultDoublePrecLong(biG, biG, biZ);
            LongToDoublePrecLong(DET, out biG);
            GcdDoublePrecLong(biZ, biG, biG);
            G = biG[0] | biG[1] << 32;
            K = 1; T = 3;
            while (G % 4 == 0)
            {
                G /= 4; K *= 2;
            }
            while (G >= T * T)
            {
                while (G % (T * T) == 0)
                {
                    G /= T * T; K *= T;
                }
                T += 2;
            }
            DET /= K * K;
            DivDoublePrecLongByLong(NUM, K, NUM);
            DivDoublePrecLongByLong(DEN, K, DEN);
            DENis1 = (DEN[0] == 1 && DEN[1] == 0 && DEN[2] == 0 && DEN[3] == 0 && DEN[4] == 0 && DEN[5] == 0);
            DET *= K * K;
            Array.Copy(biB, 0, NUM, 0, 6);
            ChSignDoublePrecLong(NUM);
            AddDoublePrecLong(biA, biA, DEN);
            SQD = sqrt(DET);
        }
        private void SolContFrac(long H, long T, long A, long B, long C, String S)
        {
            long[] factor = new long[64];
            long[] P = new long[64];
            long[] Q = new long[64];
            long[] Dif = new long[64];   /* Holds difference */
            long[] mod = new long[64];
            long[] pos = new long[64];
            long Tmp, q, r, s, t, u, v, Pp, dif, Sol1, Sol2, Modulo;
            long Tmp1 = SQD;
            long[] Tmp2 = new long[6];
            long[] Tmp3 = new long[6];
            long Tmp4 = DET;
            long ValA, ValB, ValC, ValF, ValAM, ValBM, ValCM;
            long VarD, VarK, VarQ, VarR, VarT, VarV, VarW, VarX, VarY, VarY1;
            long[] biA = new long[6];
            long[] biB = new long[6];
            long[] biC = new long[6];
            long[] biR = new long[6];
            long[] biS = new long[6];
            long[] biT = new long[6];
            ArrayLongs LongArrayX, LongArrayY;
            int index, index2, cont;
            int NbrFactors;
            long gcdAF, MagnifY;
            int cuenta = 0;
            long OrigA, OrigC;
            bool ShowHR = false;

            Array.Copy(NUM, 0, Tmp2, 0, 6);
            Array.Copy(DEN, 0, Tmp3, 0, 6);
            F = H / T / T;
            gcdAF = gcd(A, F);
            OrigA = A;
            OrigC = C;
            for (MagnifY = 1; MagnifY * MagnifY <= gcdAF; MagnifY++)
            {
                do
                {
                    if (gcdAF / MagnifY * MagnifY != gcdAF) { continue; }
                    MagnifY = gcdAF / MagnifY;
                    F = H / T / T / MagnifY;
                    ValF = abs(F);
                    A = OrigA / MagnifY;
                    C = OrigC * MagnifY;
                    ValA = (A + ValF) % ValF;
                    ValB = (B + ValF) % ValF;
                    ValC = (C + ValF) % ValF;
                    /* Find factors of F */
                    NbrFactors = 0;
                    Tmp = ValF;
                    if (Tmp == 1)
                    {
                        factor[NbrFactors++] = 1;
                    }
                    else
                    {
                        while ((Tmp % 2) == 0)
                        {
                            factor[NbrFactors++] = 2;
                            Tmp /= 2;
                        }
                        while ((Tmp % 3) == 0)
                        {
                            factor[NbrFactors++] = 3;
                            Tmp /= 3;
                        }
                        s = 5;        /* Sequence of divisors 5, 7, 11, 13, 17, 19,... */
                        do
                        {
                            while ((Tmp % s) == 0)
                            {
                                factor[NbrFactors++] = s;
                                Tmp /= s;
                            }
                            s += 2;
                            while ((Tmp % s) == 0)
                            {
                                factor[NbrFactors++] = s;
                                Tmp /= s;
                            }
                            s += 4;
                        } while (s * s <= Tmp);
                        if (Tmp != 1)
                        {
                            factor[NbrFactors++] = Tmp;
                        }
                    }
                    mod[NbrFactors] = Tmp = 1;
                    Pp = (2 * ValA) % ValF;
                    for (index = NbrFactors - 1; index >= 0; index--)
                    {
                        P[index] = Pp;
                        Tmp *= factor[index];
                        mod[index] = Tmp;
                        Pp = MultMod(MultMod(Pp, factor[index], ValF), factor[index], ValF);
                    }
                    Modulo = factor[NbrFactors - 1];
                    ValAM = (ValA + Modulo) % Modulo;
                    ValBM = (ValB + Modulo) % Modulo;
                    ValCM = (ValC + Modulo) % Modulo;
                    if (ValAM == 0)
                    {  /* Linear equation: sol=-C/B */
                        Sol1 = Sol2 = MultMod(Modulo - ValCM, ModInv(ValBM, Modulo), Modulo);
                    }
                    else
                    {    /* Quadratic equation Ax^2+Bx+C=0 (mod F) */
                        if (Modulo > 2)
                        {
                            Sol1 = MultMod(ValBM, ValBM, Modulo) - MultMod(4 * ValAM, ValCM, Modulo);
                            if (Sol1 < 0) { Sol1 += Modulo; }
                            /* Find square root of Sol1 mod Modulo */
                            if (Sol1 == 0)
                            {                 /* if double root: sol = -b/2a */
                                Sol1 = Sol2 = MultMod(ModInv((2 * ValAM + Modulo) % Modulo, Modulo), ((-ValBM) + Modulo) % Modulo, Modulo);
                            }
                            else
                            {
                                if (ModPow(Sol1, (Modulo - 1) / 2, Modulo) == 1)
                                { /* if sols exist */
                                    if (Modulo % 8 == 5)
                                    {
                                        s = ModPow(2 * Sol1, (Modulo - 5) / 8, Modulo);
                                        Sol1 = MultMod(MultMod(MultMod(MultMod(2 * Sol1, s, Modulo), s, Modulo) - 1, Sol1, Modulo), s, Modulo);
                                    }
                                    else
                                    {
                                        if (Modulo % 8 != 1)
                                        {
                                            Sol1 = ModPow(Sol1, (Modulo + 1) / 4, Modulo);
                                        }
                                        else
                                        {
                                            VarR = 1;
                                            VarQ = Modulo - 1;
                                            while (VarQ % 2 == 0)
                                            {
                                                VarQ /= 2;
                                                VarR *= 2;
                                            }
                                            VarX = 2;
                                            while (true)
                                            {
                                                VarY = ModPow(VarX, VarQ, Modulo);
                                                if (ModPow(VarY, VarR / 2, Modulo) != 1) { break; }
                                                VarX++;
                                            }
                                            VarX = ModPow(Sol1, (VarQ - 1) / 2, Modulo);
                                            VarV = MultMod(Sol1, VarX, Modulo);
                                            VarW = MultMod(VarV, VarX, Modulo);
                                            while (VarW != 1)
                                            {
                                                VarK = 1; VarD = VarW;
                                                while (VarD != 1)
                                                {
                                                    VarD = MultMod(VarD, VarD, Modulo);
                                                    VarK *= 2;
                                                }
                                                VarD = ModPow(VarY, VarR / VarK / 2, Modulo);
                                                VarY1 = MultMod(VarD, VarD, Modulo);
                                                VarR = VarK;
                                                VarV = MultMod(VarV, VarD, Modulo);
                                                VarW = MultMod(VarW, VarY1, Modulo);
                                                VarY = VarY1;
                                            }   /* end while */
                                            Sol1 = VarV;
                                        }     /* end modulo 8 = 1 */
                                    }
                                    s = ModInv((2 * ValAM) % Modulo, Modulo);
                                    Sol2 = MultMod((Modulo + Sol1 - ValBM) % Modulo, s, Modulo);
                                    Sol1 = MultMod((2 * Modulo - Sol1 - ValBM) % Modulo, s, Modulo);
                                }
                                else
                                {   /* No solution exists */
                                    Sol1 = Sol2 = -1;
                                }
                            }
                        }
                        else
                        {         /* Modulo <= 2 */
                            if (Modulo == 2)
                            {
                                switch ((int)ValBM * 2 + (int)ValCM)
                                {
                                    case 0:           /* A = 1, B = 0, C = 0 */
                                        Sol1 = Sol2 = 0;    /* Solution only for s=0 */
                                        break;
                                    case 1:           /* A = 1, B = 0, C = 1 */
                                        Sol1 = Sol2 = 1;    /* Solution only for s=1 */
                                        break;
                                    case 2:           /* A = 1, B = 1, C = 0 */
                                        Sol1 = 0;         /* Solution for s=0 and s=1 */
                                        Sol2 = 1;
                                        break;
                                    default:          /* A = 1, B = 1, C = 1 */
                                        Sol1 = Sol2 = -1;   /* No solutions */
                                        break;
                                }
                            }                   /* End Modulo = 2 */
                            else
                            {                /* Modulo = 1 */
                                Sol1 = Sol2 = 0;
                            }
                        }
                    }               /* End Quadratic Equation */
                    ValAM = (ValA + ValF) % ValF;
                    ValBM = (ValB + ValF) % ValF;
                    ValCM = (ValC + ValF) % ValF;
                    NbrEqs = EqNbr = 0;
                    byte sol = 0;
                    t = Sol1;
                    for (cont = (Sol1 < 0 ? 2 : 0); cont < 2; cont++)
                    {
                        index = NbrFactors - 1; v = mod[index];
                        dif = 0;
                        q = (MultMod((MultMod(ValAM, t, ValF) + ValBM) % ValF, t, ValF) + ValCM) % ValF;  /* q%v = 0 */
                        while (true)
                        {
                            if (q % v == 0)
                            {
                                if (index == 0)
                                {          /* Solution found */
                                    NbrEqs++;
                                }
                                else
                                {
                                    pos[index] = t;
                                    t = 0;
                                    for (index2 = index; index2 < NbrFactors; index2++)
                                    {
                                        t += pos[index2] * mod[index2 + 1];
                                    }
                                    t = t % ValF;
                                    Dif[index] = dif;
                                    Q[index] = q;
                                    dif = MultMod((MultMod((2 * t + v) % ValF, ValAM, ValF) + ValBM) % ValF, v, ValF);
                                    Pp = P[--index];
                                    t = 0; v = mod[index];
                                    continue;
                                }
                            }
                            if (index != NbrFactors - 1 && ++t < factor[index])
                            {
                                q = (q + dif) % ValF;
                                dif = (dif + Pp) % ValF;
                                continue;
                            }
                            else
                            {
                                while (++index < NbrFactors)
                                {
                                    t = pos[index]; v = mod[index];   /* Restore previous values */
                                    if (index < NbrFactors - 1 && ++t < factor[index])
                                    {
                                        Pp = P[index];
                                        dif = Dif[index];
                                        q = (Q[index] + dif) % ValF;
                                        dif = (dif + Pp) % ValF;
                                        break;
                                    }
                                }
                                if (index >= NbrFactors) { break; }
                            }
                        }
                        if (Sol1 == Sol2) { break; }  /* Do not process double root */
                        t = Sol2;
                    }
                    t = Sol1;
                    for (cont = (Sol1 < 0 ? 2 : 0); cont < 2; cont++)
                    {
                        index = NbrFactors - 1; v = mod[index];
                        dif = 0;
                        q = (MultMod((MultMod(ValAM, t, ValF) + ValBM) % ValF, t, ValF) + ValCM) % ValF;  /* q%v = 0 */
                        while (true)
                        {
                            if (q % v == 0)
                            {
                                if (index == 0)
                                {          /* Solution found */
                                    EqNbr++;
                                    s = t * mod[1];
                                    for (index2 = 1; index2 < NbrFactors; index2++)
                                    {
                                        s += pos[index2] * mod[index2 + 1];
                                    }
                                    s = s % ValF;
                                    //  Calculate biA = -((As+B)s+C)/F
                                    //            biB = 2As+B
                                    //            biC = -AF
                                    //            biR = gcd(biA, biB, biC)
                                    LongToDoublePrecLong(A, out biR);         // biR = A
                                    LongToDoublePrecLong(s, out biS);         // biS = s
                                    LongToDoublePrecLong(B, out biB);         // biB = B
                                    MultDoublePrecLong(biR, biS, biC);     // biC = As
                                    AddDoublePrecLong(biC, biB, biT);      // biT = As+B
                                    MultDoublePrecLong(biT, biS, biA);     // biA = (As+B)s
                                    LongToDoublePrecLong(C, out biR);         // biR = C
                                    AddDoublePrecLong(biA, biR, biT);      // biT = (As+B)s+C
                                    LongToDoublePrecLong(-F, out biR);        // biR = -F
                                    DivideDoublePrecLong(biT, biR, biA);   // biA = -((As+B)s+C)/F
                                    AddDoublePrecLong(biC, biC, biC);      // biC = 2As
                                    AddDoublePrecLong(biC, biB, biB);      // biB = 2As+B
                                    LongToDoublePrecLong(A, out biT);         // biT = A
                                    MultDoublePrecLong(biR, biT, biC);     // biC = -AF
                                    GcdDoublePrecLong(biA, biB, biT);      // biT = gcd(biA, biB)
                                    GcdDoublePrecLong(biT, biC, biR);      // biR = gcd(biA, biB, biC)
                                    if (biR[0] > 1 || biR[1] > 0 || biR[2] > 0 || biR[3] > 0 || biR[4] > 0 ||
                                            biR[5] > 0 && biR[5] < DosALa31)
                                    {  // if biR > 1 ...
                                    }
                                    else
                                    {
                                        LongArrayX = LongArrayY = null;
                                        GetRoot(biA, biB, biC);
                                        if (S.Equals(""))
                                        {
                                            if (ContFrac(biA, (byte)3, (byte)1, s, T, MagnifY, A))
                                            {
                                                if (L2[0] < 0)
                                                {
                                                    ChangeSign(L1, (byte)1);
                                                    ChangeSign(L2, (byte)1);
                                                }
                                                LongArrayX = new ArrayLongs((int)(abs(L1[0]) + 1));
                                                Array.Copy(L1,
                                                        0,
                                                        LongArrayX.element,
                                                        0,
                                                        (int)(abs(L1[0]) + 1));
                                                LongArrayY = new ArrayLongs((int)(abs(L2[0]) + 1));
                                                Array.Copy(L2,
                                                        0,
                                                        LongArrayY.element,
                                                        0,
                                                        (int)(abs(L2[0]) + 1));
                                            }

                                            if (ContFrac(biA, (byte)3, (byte)0xF, s, T, MagnifY, A))
                                            {
                                                if (L2[0] < 0)
                                                {
                                                    ChangeSign(L1, (byte)1);
                                                    ChangeSign(L2, (byte)1);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            ContFrac(biA, (byte)4, (byte)1, s, T, MagnifY, A);
                                            ContFrac(biA, (byte)4, (byte)0xF, s, T, MagnifY, A);
                                        }
                                    }
                                }
                                else
                                {
                                    pos[index] = t;
                                    t = 0;
                                    for (index2 = index; index2 < NbrFactors; index2++)
                                    {
                                        t += pos[index2] * mod[index2 + 1];
                                    }
                                    t = t % ValF;
                                    Dif[index] = dif;
                                    Q[index] = q;
                                    dif = MultMod((MultMod((2 * t + v) % ValF, ValAM, ValF) + ValBM) % ValF, v, ValF);
                                    Pp = P[--index];
                                    t = 0; v = mod[index];
                                    continue;
                                }
                            }
                            if (index < NbrFactors - 1 && ++t < factor[index])
                            {
                                q = (q + dif) % ValF;
                                dif = (dif + Pp) % ValF;
                                continue;
                            }
                            else
                            {
                                while (++index < NbrFactors)
                                {
                                    t = pos[index]; v = mod[index];   /* Restore previous values */
                                    if (index < NbrFactors - 1 && ++t < factor[index])
                                    {
                                        Pp = P[index];
                                        dif = Dif[index];
                                        q = (Q[index] + dif) % ValF;
                                        dif = (dif + Pp) % ValF;
                                        break;
                                    }
                                }
                                if (index >= NbrFactors) { break; }
                            }
                        }
                        if (Sol1 == Sol2) { break; }  /* Do not process double root */
                        t = Sol2;
                    }
                    SQD = Tmp1;
                    Array.Copy(Tmp2, 0, NUM, 0, 6);
                    Array.Copy(Tmp3, 0, DEN, 0, 6);
                    DET = Tmp4;
                } while (MagnifY * MagnifY > gcdAF);
            }
        }
        private void ChangeSign(long[] Nbr, byte type)
        {
            long Cy = Bi;
            if (LargeNumberIsZero(Nbr)) { return; }
            for (int s = 1; s <= abs(Nbr[0]); s++)
            {
                Nbr[s] = Cy - Nbr[s];
                if (Nbr[s] == Bi)
                {
                    Nbr[s] = 0;
                }
                else
                {
                    Cy = Bi - 1;
                }
            }
            if (type == 1) { Nbr[0] = -Nbr[0]; }
        }
        private int Compare(long[] longarray, long[] K1)
        {
            int length, i, retcode;
            bool signlongarray = false, signK1 = false;

            if (longarray[0] < 0)
            {
                signlongarray = true;
                ChangeSign(longarray, (byte)1);
            }
            if (K1[0] < 0)
            {
                signK1 = true;
                ChangeSign(K1, (byte)1);
            }

            length = (int)longarray[0];
            if (length < (int)K1[0])
            {
                retcode = -1;
            }
            else
            {
                if (length > (int)K1[0])
                {
                    retcode = 1;
                }
                else
                {
                    for (i = length; i > 0; i--)
                    {
                        if (longarray[i] != K1[i])
                        {
                            break;
                        }
                    }
                    if (i == 0)
                    {    /* Absolute values are equal */
                        if (signlongarray == signK1)
                        {
                            retcode = 0;
                        }
                        else
                        {
                            if (signlongarray == false)
                            {
                                retcode = 1;
                            }
                            else
                            {
                                retcode = -1;
                            }
                        }
                    }
                    else
                    {           /* Different absolute values */
                        if (longarray[i] < K1[i])
                        {
                            retcode = -1;
                        }
                        else
                        {
                            retcode = 1;
                        }
                    }
                }
            }
            if (signlongarray == true)
            {
                ChangeSign(longarray, (byte)1);
            }
            if (signK1 == true)
            {
                ChangeSign(K1, (byte)1);
            }
            return retcode;
        }
        private bool ContFrac(long[] biA, byte type, byte SqrtSign, long s, long T, long MagnifY, long A)
        {
            long P, Z, M, P1, M1, Tmp, K, L, Mu;
            long[] biP = new long[6];
            long[] biM = new long[6];
            long[] biZ = new long[6];
            long[] biG = new long[6];
            long[] biMu = new long[6];
            long[] biK = new long[6];
            long[] biL = new long[6];
            long[] biM1 = new long[6];
            long[] biP1 = new long[6];
            long H1ModCY1 = 1, H2ModCY1 = 0, K1ModCY1 = 0, K2ModCY1 = 1;
            bool Sols, secondDo = true;
            int i;
            int Conv;
            int Co = -1;
            String U = (type == 4 ? "'" : "");
            String X1 = "X";
            String Y1 = (MagnifY == 1 ? "Y" : "Y'");
            Sols = true;
            if (biA[0] == 1 && biA[1] == 0 && biA[2] == 0 && biA[3] == 0 && biA[4] == 0 && biA[5] == 0)
            {
                H1[0] = SqrtSign; K1[0] = 1; H1[1] = (SqrtSign + Bi) % Bi; K1[1] = 0;
                if (type == 1)
                {
                    return true;            /* Indicate there are solutions */
                }
                if ((type == 3 || type == 4) && (DET != 5 || A * F < 0))
                {
                    if (ShowHomoSols(type, H1, K1, s, T, MagnifY, "", ""))
                    {
                        return true;          /* Indicate there are solutions */
                    }
                }
            }
            /* Paso = 1: Quick scan for solutions */
            /* Paso = 2: Show actual solutions */
            for (int Paso = (type == 2 || DET == 5 && A * F > 0 && (type == 3 || type == 4) ? 2 : 1);
                 Sols && Paso <= 2; Paso++)
            {
                Conv = 0;
                Sols = false;
                Array.Copy(DEN, 0, biP, 0, 6);
                if (SqrtSign < 0)
                {
                    ChSignDoublePrecLong(biP);
                }
                LongToDoublePrecLong(SQD + (biP[5] >= DosALa31 ? 1 : 0), out biK);
                if (SqrtSign < 0)
                {
                    SubtDoublePrecLong(biK, NUM, biK);
                }
                else
                {
                    AddDoublePrecLong(biK, NUM, biK);
                }
                Z = DivDoublePrecLong(biK, biP);
                LongToDoublePrecLong(Z, out biM);
                MultDoublePrecLong(biM, DEN, biK);
                SubtDoublePrecLong(biK, NUM, biM);
                if (SqrtSign < 0)
                {
                    ChSignDoublePrecLong(biM);
                }
                if (type == 4)
                {
                    H2ModCY1 = Z % CY1;
                }
                // biM=(NUM+Z*DEN)*SqrtSign;
                if (type == 5)
                {
                    A1 = B2 = 1; A2 = Z % T; B1 = 0;
                }
                else
                {
                    H1[0] = SqrtSign; H2[0] = (Z * SqrtSign < 0) ? -1 : 1; K1[0] = 1; K2[0] = H1[0];
                    H1[1] = (SqrtSign + Bi) % Bi; H2[1] = (Z * SqrtSign + Bi) % Bi; K1[1] = 0; K2[1] = H1[1];
                    A1 = B2 = 1; A2 = B1 = 0;
                }
                Co = -1;
                for (i = 0; i < 6; i++)
                {
                    biK[i] = biL[i] = DosALa32_1;
                }
                switch (type)
                {
                    case 1:
                        LongToDoublePrecLong(-2 * F * SqrtSign, out biMu);
                        break;
                    case 3:
                        LongToDoublePrecLong(-2 * SqrtSign, out biMu);
                        break;
                    case 4:
                        LongToDoublePrecLong(-2 * SqrtSign, out biMu);
                        break;
                    default:
                        Array.Copy(DEN, 0, biMu, 0, 6);
                        if (SqrtSign > 0)
                        {
                            ChSignDoublePrecLong(biMu);
                        }
                        break;
                }
                do
                {
                    LongToDoublePrecLong(DET, out biZ);       // biP1 = (DET-biM*biM)/biP
                    MultDoublePrecLong(biM, biM, biG);
                    SubtDoublePrecLong(biZ, biG, biG);
                    DivideDoublePrecLong(biG, biP, biP1);
                    LongToDoublePrecLong(SQD + (biP1[5] >= DosALa31 ? 1 : 0), out biZ);
                    AddDoublePrecLong(biZ, biM, biK);
                    Z = DivDoublePrecLong(biK, biP1);
                    LongToDoublePrecLong(Z, out biG);         // biM1 = Z * biP1 - biM
                    MultDoublePrecLong(biG, biP1, biZ);
                    SubtDoublePrecLong(biZ, biM, biM1);
                    if (Co < 0 &&
                            biP[0] > 0 && biP[0] <= SQD + biM[0] && biP[1] == 0 && biP[2] == 0 &&
                            biP[3] == 0 && biP[4] == 0 && biP[5] == 0 &&
                            biM[0] > 0 && biM[0] <= SQD && biM[1] == 0 && biM[2] == 0 &&
                            biM[3] == 0 && biM[4] == 0 && biM[5] == 0)
                    {
                        Co = 0;
                        Array.Copy(biP, 0, biK, 0, 6);
                        Array.Copy(biM, 0, biL, 0, 6);
                    }
                    if (type == 1 && biP[0] == biMu[0] && biP[1] == biMu[1] && biP[2] == biMu[2] &&
                            biP[3] == biMu[3] && biP[4] == biMu[4] && biP[5] == biMu[5])
                    { // Solution found
                        if (Co % 2 == 0 ||
                                biK[0] != biP1[0] || biK[1] != biP1[1] || biK[2] != biP1[2] ||
                                biK[3] != biP1[3] || biK[4] != biP1[4] || biK[5] != biP1[5] ||
                                biL[0] != biM1[0] || biL[1] != biM1[1] || biL[2] != biM1[2] ||
                                biL[3] != biM1[3] || biL[4] != biM1[4] || biL[5] != biM1[5])
                        {
                            if (Paso == 2)
                            {
                                if (A2 != 0)
                                {
                                    NextConv(H1, H2); NextConv(K1, K2);
                                    A1 = B2 = 1; A2 = B1 = 0;
                                }
                            }
                            Sols = true;
                        }
                        secondDo = false;
                        break;
                    }
                    if (type == 3 || type == 4)
                    {
                        if (Co == 0 && A * F > 0 && DET == 5)
                        {  /* Solution found */
                            if (Paso == 1)
                            {
                                secondDo = false;
                                Sols = true;
                                break;
                            }
                            else
                            {
                                NextConv(H1, H2); NextConv(K1, K2);
                                A1 = B2 = 1; A2 = B1 = 0;
                                ChangeSign(H2, (byte)1);
                                AddLargeNumbers(H1, H2, H2);
                                ChangeSign(H2, (byte)1);
                                ChangeSign(K2, (byte)1);
                                AddLargeNumbers(K1, K2, K2);
                                ChangeSign(K2, (byte)1);
                                if (ShowHomoSols(type, H2, K2, s, T, MagnifY, "NUM(" + Conv + ") - NUM(" + (Conv - 1) + ") = ", "DEN(" + Conv + ") - DEN(" + (Conv - 1) + ") = "))
                                {
                                    secondDo = false;
                                    Sols = true;
                                    break;
                                }
                                AddLargeNumbers(H1, H2, H2);
                                AddLargeNumbers(K1, K2, K2);
                            }
                        }
                        if (biP1[0] == biMu[0] && biP1[1] == biMu[1] && biP1[2] == biMu[2] &&
                                biP1[3] == biMu[3] && biP1[4] == biMu[4] && biP1[5] == biMu[5])
                        {  // Solution found
                            if (Co % 2 == 0 ||
                                    biK[0] != biP1[0] || biK[1] != biP1[1] || biK[2] != biP1[2] ||
                                    biK[3] != biP1[3] || biK[4] != biP1[4] || biK[5] != biP1[5] ||
                                    biL[0] != biM1[0] || biL[1] != biM1[1] || biL[2] != biM1[2] ||
                                    biL[3] != biM1[3] || biL[4] != biM1[4] || biL[5] != biM1[5])
                            {
                                if (Paso == 2)
                                {
                                    if (A2 != 0)
                                    {
                                        NextConv(H1, H2); NextConv(K1, K2);
                                        A1 = B2 = 1; A2 = B1 = 0;
                                    }
                                    if (ShowHomoSols(type, H2, K2, s, T, MagnifY, "NUM(" + Conv + ") = ", "DEN(" + Conv + ") = "))
                                    {
                                        secondDo = false;
                                        Sols = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (type == 4)
                                    {
                                        Tmp = H2ModCY1 * T;
                                        if ((Tmp - CY0) % CY1 == 0 || (Tmp + CY0) % CY1 == 0)
                                        {
                                            secondDo = false;
                                            Sols = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        secondDo = false;
                                        Sols = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (Paso == 1 && type == 4)
                        {
                            Tmp = (H1ModCY1 + Z * H2ModCY1) % CY1;
                            H1ModCY1 = H2ModCY1;
                            H2ModCY1 = Tmp;
                            Tmp = (K1ModCY1 + Z * K2ModCY1) % CY1;
                            K1ModCY1 = K2ModCY1;
                            K2ModCY1 = Tmp;
                        }
                    }
                    Array.Copy(biM1, 0, biM, 0, 6);
                    Array.Copy(biP1, 0, biP, 0, 6);
                    if (Co == 0) { Co = 1; }
                    if (type == 5)
                    {
                        Tmp = (A1 + Z * A2) % T;
                        A1 = A2; A2 = Tmp;
                        Tmp = (B1 + Z * B2) % T;
                        B1 = B2; B2 = Tmp;
                    }
                    ChSignDoublePrecLong(biMu);
                    if (Paso == 2)
                    {
                        if (A2 != 0 && Z > (Bi / 10 - A1) / A2 || B2 != 0 && Z > (Bi / 10 - B1) / B2)
                        {
                            NextConv(H1, H2); NextConv(K1, K2); A1 = B2 = 1; A2 = B1 = 0;
                        }
                        A1 += Z * A2; B1 += Z * B2;
                        Tmp = A1; A1 = A2; A2 = Tmp; Tmp = B1; B1 = B2; B2 = Tmp;
                    }
                    Conv++;
                } while (Co < 0);

                if (secondDo == false)
                {
                    continue;
                }
                Mu = biMu[0] | biMu[1] << 32;
                L = biL[0] | biL[1] << 32;
                K = biK[0] | biK[1] << 32;
                M = biM[0] | biM[1] << 32;
                P = biP[0] | biP[1] << 32;

                do
                {
                    P1 = (DET - M * M) / P;    /* P & Q should be > 0 (See Knuth Ex 4.5.3-12) */
                    Z = (SQD + M) / P1;
                    M1 = Z * P1 - M;
                    if (type == 1 && P == Mu)
                    {    /* Solution found */
                        if (Co % 2 == 0 || K != P1 || L != M1)
                        {
                            if (Paso == 2)
                            {
                                if (A2 != 0)
                                {
                                    NextConv(H1, H2); NextConv(K1, K2);
                                    A1 = B2 = 1; A2 = B1 = 0;
                                }
                            }
                            Sols = true;
                        }
                        break;
                    }
                    if (type == 3 || type == 4)
                    {
                        if ((Co & 1) == 0 && A * F > 0 && DET == 5)
                        {   /* Solution found */
                            if (Paso == 1)
                            {
                                Sols = true;
                                break;
                            }
                            else
                            {
                                NextConv(H1, H2); NextConv(K1, K2);
                                A1 = B2 = 1; A2 = B1 = 0;
                                ChangeSign(H2, (byte)1);
                                AddLargeNumbers(H1, H2, H2);
                                ChangeSign(H2, (byte)1);
                                ChangeSign(K2, (byte)1);
                                AddLargeNumbers(K1, K2, K2);
                                ChangeSign(K2, (byte)1);
                                if (ShowHomoSols(type, H2, K2, s, T, MagnifY, "NUM(" + Conv + ") - NUM(" + (Conv - 1) + ") = ", "DEN(" + Conv + ") - DEN(" + (Conv - 1) + ") = "))
                                {
                                    Sols = true;
                                    break;
                                }
                                AddLargeNumbers(H1, H2, H2);
                                AddLargeNumbers(K1, K2, K2);
                            }
                        }
                        if (P1 == Mu)
                        {   /* Solution found */
                            if (Co % 2 == 0 || K != P1 || L != M1)
                            {
                                if (Paso == 2)
                                {
                                    if (A2 != 0)
                                    {
                                        NextConv(H1, H2); NextConv(K1, K2);
                                        A1 = B2 = 1; A2 = B1 = 0;
                                    }
                                    if (ShowHomoSols(type, H2, K2, s, T, MagnifY, "NUM(" + Conv + ") = ", "DEN(" + Conv + ") = "))
                                    {
                                        Sols = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (type == 4)
                                    {
                                        Tmp = H2ModCY1 * T;
                                        if ((Tmp - CY0) % CY1 == 0 || (Tmp + CY0) % CY1 == 0)
                                        {
                                            Sols = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Sols = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (Paso == 1 && type == 4)
                        {
                            Tmp = (H1ModCY1 + Z * H2ModCY1) % CY1;
                            H1ModCY1 = H2ModCY1;
                            H2ModCY1 = Tmp;
                            Tmp = (K1ModCY1 + Z * K2ModCY1) % CY1;
                            K1ModCY1 = K2ModCY1;
                            K2ModCY1 = Tmp;
                        }
                    }
                    Co++;
                    M = M1; P = P1;
                    if (type == 2 && P1 == Mu)
                    {
                        NextConv(H1, H2);
                        NextConv(K1, K2);
                        Sols = true;
                        break;
                    }
                    if (type == 5)
                    {
                        if (P1 == Mu)
                        {
                            NbrCo = Co;
                            Sols = true;
                            break;
                        }
                        else
                        {
                            Tmp = (A1 + Z * A2) % T;
                            A1 = A2; A2 = Tmp;
                            Tmp = (B1 + Z * B2) % T;
                            B1 = B2; B2 = Tmp;
                        }
                    }
                    Mu = -Mu;
                    if (Paso == 2)
                    {
                        if (A2 != 0 && Z > (Bi / 10 - A1) / A2 || B2 != 0 && Z > (Bi / 10 - B1) / B2)
                        {
                            NextConv(H1, H2); NextConv(K1, K2); A1 = B2 = 1; A2 = B1 = 0;
                        }
                        A1 += Z * A2; B1 += Z * B2;
                        Tmp = A1; A1 = A2; A2 = Tmp; Tmp = B1; B1 = B2; B2 = Tmp;
                    }
                    Conv++;
                } while (NbrCo > 0 ? Co != NbrCo : Co % 2 != 0 || K != P || L != M);
                if (type == 5) { break; }
            }                            /* end for */
            return Sols;
        }

        private void AddLargeNumbers(long[] Nbr1, long[] Nbr2, long[] Sum)
        {
            int S = (int)abs(Nbr1[0]);
            long T = (Nbr1[0] < 0 ? Bi - 1 : 0);
            long U = (Nbr2[0] < 0 ? Bi - 1 : 0);
            while (abs(Nbr2[0]) > S)
            {
                Nbr1[++S] = T;
            }
            S = (int)abs(Nbr2[0]);
            while (S < abs(Nbr1[0]))
            {
                Nbr2[++S] = U;
            }
            Nbr1[S + 1] = Nbr1[S + 2] = T;
            Nbr2[S + 1] = Nbr2[S + 2] = U;
            Sum[0] = S;
            long Cy = 0;
            for (S = 1; S <= Sum[0] + 2; S++)
            {
                Cy += Nbr1[S] + Nbr2[S]; Sum[S] = Cy % Bi; Cy /= Bi;
            }
            AdjustSign(Sum);
        }
        private void NextConv(long[] Prev, long[] Act)
        {
            long CP1H, CP1L, CP2H, CP2L;
            long CA1H, CA1L, CA2H, CA2L;
            long Cy1H, Cy1L, Cy2H, Cy2L;
            long PH, PL, AH, AL;
            long Tmp, Re1, Re2, Re4;
            int S = (int)abs(Act[0]);
            long T = (Prev[0] < 0 ? Bi - 1 : 0);
            long U = (Act[0] < 0 ? Bi - 1 : 0);
            while (S < abs(Prev[0]))
            {
                Act[++S] = U;
            }
            S = (int)abs(Prev[0]);
            while (S < abs(Act[0]))
            {
                Prev[++S] = T;
            }
            Prev[S + 1] = Prev[S + 2] = T;
            Act[S + 1] = Act[S + 2] = U;
            Act[0] = Prev[0] = S;
            CP1H = A1 / Mi; CP1L = A1 % Mi;
            CP2H = A2 / Mi; CP2L = A2 % Mi;
            CA1H = B1 / Mi; CA1L = B1 % Mi;
            CA2H = B2 / Mi; CA2L = B2 % Mi;
            Cy1L = Cy1H = Cy2L = Cy2H = 0;
            for (S = 1; S <= Prev[0] + 2; S++)
            {
                PL = Prev[S] % Mi; PH = Prev[S] / Mi;
                AL = Act[S] % Mi; AH = Act[S] / Mi;
                Tmp = PL * CP1L + AL * CA1L + Cy1L; Re2 = Tmp / Mi; Re1 = Tmp % Mi;
                Tmp = PH * CP1L + PL * CP1H + AH * CA1L + AL * CA1H + Cy1H + Re2; Re4 = Tmp / Mi; Re1 += (Tmp % Mi) * Mi;
                Tmp = PH * CP1H + AH * CA1H + Re4 - (Re1 < 0 ? 1 : 0); Cy1H = Tmp / Mi; Cy1L = Tmp % Mi;
                Prev[S] = (Re1 + Bi) % Bi;
                Tmp = PL * CP2L + AL * CA2L + Cy2L; Re2 = Tmp / Mi; Re1 = Tmp % Mi;
                Tmp = PH * CP2L + PL * CP2H + AH * CA2L + AL * CA2H + Cy2H + Re2; Re4 = Tmp / Mi; Re1 += (Tmp % Mi) * Mi;
                Tmp = PH * CP2H + AH * CA2H + Re4 - (Re1 < 0 ? 1 : 0); Cy2H = Tmp / Mi; Cy2L = Tmp % Mi;
                Act[S] = (Re1 + Bi) % Bi;
            }
            AdjustSign(Prev);
            AdjustSign(Act);
        }
        private void AdjustSign(long[] Nbr)
        {
            int S = (int)abs(Nbr[0]) + 2;
            if (Nbr[S] * 2 >= Bi)
            {
                while (Nbr[S] == Bi - 1 && --S > abs(Nbr[0]))
                {
                }
                Nbr[0] = -S;
            }
            else
            {
                while (Nbr[S] == 0 && --S > abs(Nbr[0]))
                {
                }
                Nbr[0] = S;
            }
        }
        private long DivDoublePrecLong(long[] Dividend, long[] Divisor)
        {
            bool ChSignDividend = false;
            bool ChSignDivisor = false;
            double dDividend, dDivisor;
            long QuotientH, QuotientL, Cy;
            long D0, D1, D2, D3, D4, D5, E0, E1, E2, E3, E4, E5;

            if (Dividend[5] >= DosALa31)
            {
                ChSignDividend = true;
                ChSignDoublePrecLong(Dividend);
            }
            if (Divisor[5] >= DosALa31)
            {
                ChSignDivisor = true;
                ChSignDoublePrecLong(Divisor);
            }

            dDividend = ((((((double)Dividend[5] * dDosALa32 +
                    (double)Dividend[4]) * dDosALa32 +
                    (double)Dividend[3]) * dDosALa32 +
                    (double)Dividend[2]) * dDosALa32 +
                    (double)Dividend[1]) * dDosALa32 +
                    (double)Dividend[0]);

            dDivisor = ((((((double)Divisor[5] * dDosALa32 +
                    (double)Divisor[4]) * dDosALa32 +
                    (double)Divisor[3]) * dDosALa32 +
                    (double)Divisor[2]) * dDosALa32 +
                    (double)Divisor[1]) * dDosALa32 +
                    (double)Divisor[0]);

            QuotientH = (long)(dDividend / dDivisor / dDosALa32) + 3;
            do
            {
                QuotientH--;
                D1 = Dividend[1] - Divisor[0] * QuotientH;
                if (D1 > Dividend[1] || D1 < 0)
                {
                    Cy = (D1 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                D2 = Dividend[2] - Divisor[1] * QuotientH + Cy;
                if (D2 > Dividend[2] || D2 < 0)
                {
                    Cy = (D2 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                D3 = Dividend[3] - Divisor[2] * QuotientH + Cy;
                if (D3 > Dividend[3] || D3 < 0)
                {
                    Cy = (D3 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                D4 = Dividend[4] - Divisor[3] * QuotientH + Cy;
                if (D4 > Dividend[4] || D4 < 0)
                {
                    Cy = (D4 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                D5 = Dividend[5] - Divisor[4] * QuotientH + Cy;
            } while (D5 < 0);

            D0 = Dividend[0];
            D1 &= DosALa32_1;
            D2 &= DosALa32_1;
            D3 &= DosALa32_1;
            D4 &= DosALa32_1;

            dDividend = ((((((double)D5 * dDosALa32 +
                    (double)D4) * dDosALa32 +
                    (double)D3) * dDosALa32 +
                    (double)D2) * dDosALa32 +
                    (double)D1) * dDosALa32 +
                    (double)D0);

            QuotientL = (long)(dDividend / dDivisor) + 3;
            do
            {
                QuotientL--;
                E0 = D0 - Divisor[0] * QuotientL;
                if (E0 > D0 || E0 < 0)
                {
                    Cy = (E0 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                E1 = D1 - Divisor[1] * QuotientL + Cy;
                if (E1 > D1 || E1 < 0)
                {
                    Cy = (E1 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                E2 = D2 - Divisor[2] * QuotientL + Cy;
                if (E2 > D2 || E2 < 0)
                {
                    Cy = (E2 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                E3 = D3 - Divisor[3] * QuotientL + Cy;
                if (E3 > D3 || E3 < 0)
                {
                    Cy = (E3 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                E4 = D4 - Divisor[4] * QuotientL + Cy;
                if (E4 > D4 || E4 < 0)
                {
                    Cy = (E4 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                E5 = D5 - Divisor[5] * QuotientL + Cy;
            } while (E5 < 0);

            if (ChSignDividend != ChSignDivisor)
            {
                if (((E0 | E1 | E2 | E3 | E4 | E5) & DosALa32_1) != 0)
                {
                    QuotientL++;
                }
            }

            if (ChSignDividend)
            {
                ChSignDoublePrecLong(Dividend);
            }
            if (ChSignDivisor)
            {
                ChSignDoublePrecLong(Divisor);
            }

            if (ChSignDividend == ChSignDivisor)
            {
                return QuotientH << 32 | QuotientL;
            }
            return -(QuotientH << 32 | QuotientL);
        }
        private void DivideDoublePrecLong(long[] Dividend, long[] Divisor, long[] Quotient)
        {
            bool ChSignDividend = false;
            bool ChSignDivisor = false;
            double dDividend, dDivisor, dAux;
            double dDosALa32 = (double)DosALa32;
            long QuotientH, D0, D1, D2, D3, D4, D5, E0, E1, E2, E3, E4, E5, Cy;

            if (Dividend[5] >= DosALa31)
            {
                ChSignDividend = true;
                ChSignDoublePrecLong(Dividend);
            }
            if (Divisor[5] >= DosALa31)
            {
                ChSignDivisor = true;
                ChSignDoublePrecLong(Divisor);
            }

            Quotient[0] = Quotient[1] = Quotient[2] = Quotient[3] = Quotient[4] = Quotient[5] = 0;

            D0 = Dividend[0];
            D1 = Dividend[1];
            D2 = Dividend[2];
            D3 = Dividend[3];
            D4 = Dividend[4];
            D5 = Dividend[5];

            dDividend = ((((((double)D5 * dDosALa32 +
                    (double)D4) * dDosALa32 +
                    (double)D3) * dDosALa32 +
                    (double)D2) * dDosALa32 +
                    (double)D1) * dDosALa32 +
                    (double)D0);

            dDivisor = ((((((double)Divisor[5] * dDosALa32 +
                    (double)Divisor[4]) * dDosALa32 +
                    (double)Divisor[3]) * dDosALa32 +
                    (double)Divisor[2]) * dDosALa32 +
                    (double)Divisor[1]) * dDosALa32 +
                    (double)Divisor[0]);

            if (dDividend >= dDosALa32 * dDivisor)
            {
                if (dDividend >= dDosALa64 * dDivisor)
                {
                    if (dDividend >= dDosALa96 * dDivisor)
                    {
                        if (dDividend >= dDosALa128 * dDivisor)
                        {
                            if (dDividend >= dDosALa160 * dDivisor)
                            {
                                QuotientH = (long)(dDividend / dDivisor / dDosALa160) + 3;
                                do
                                {
                                    QuotientH--;
                                    E5 = D5 - Divisor[0] * QuotientH;
                                } while (E5 < 0);
                                Quotient[5] = QuotientH;
                                D5 = E5;

                                dDividend = ((((((double)D5 * dDosALa32 +
                                        (double)D4) * dDosALa32 +
                                        (double)D3) * dDosALa32 +
                                        (double)D2) * dDosALa32 +
                                        (double)D1) * dDosALa32 +
                                        (double)D0);
                            }
                            QuotientH = (long)(dDividend / dDivisor / dDosALa128) + 3;
                            do
                            {
                                QuotientH--;
                                E4 = D4 - Divisor[0] * QuotientH;
                                if (E4 > D4 || E4 < 0)
                                {
                                    Cy = (E4 >> 32) - DosALa32;
                                }
                                else
                                {
                                    Cy = 0;
                                }
                                E5 = D5 - Divisor[1] * QuotientH + Cy;
                            } while (E5 < 0);
                            Quotient[4] = QuotientH;
                            D4 = E4 & DosALa32_1;
                            D5 = E5;
                            dDividend = ((((((double)D5 * dDosALa32 +
                                    (double)D4) * dDosALa32 +
                                    (double)D3) * dDosALa32 +
                                    (double)D2) * dDosALa32 +
                                    (double)D1) * dDosALa32 +
                                    (double)D0);
                        }
                        QuotientH = (long)(dDividend / dDivisor / dDosALa96) + 3;
                        do
                        {
                            QuotientH--;
                            E3 = D3 - Divisor[0] * QuotientH;
                            if (E3 > D3 || E3 < 0)
                            {
                                Cy = (E3 >> 32) - DosALa32;
                            }
                            else
                            {
                                Cy = 0;
                            }
                            E4 = D4 - Divisor[1] * QuotientH + Cy;
                            if (E4 > D4 || E4 < 0)
                            {
                                Cy = (E4 >> 32) - DosALa32;
                            }
                            else
                            {
                                Cy = 0;
                            }
                            E5 = D5 - Divisor[2] * QuotientH + Cy;
                        } while (E5 < 0);
                        Quotient[3] = QuotientH;
                        D3 = E3 & DosALa32_1;
                        D4 = E4 & DosALa32_1;
                        D5 = E5;
                        dDividend = ((((((double)D5 * dDosALa32 +
                                (double)D4) * dDosALa32 +
                                (double)D3) * dDosALa32 +
                                (double)D2) * dDosALa32 +
                                (double)D1) * dDosALa32 +
                                (double)D0);
                    }
                    QuotientH = (long)(dDividend / dDivisor / dDosALa64) + 3;
                    do
                    {
                        QuotientH--;
                        E2 = D2 - Divisor[0] * QuotientH;
                        if (E2 > D2 || E2 < 0)
                        {
                            Cy = (E2 >> 32) - DosALa32;
                        }
                        else
                        {
                            Cy = 0;
                        }
                        E3 = D3 - Divisor[1] * QuotientH + Cy;
                        if (E3 > D3 || E3 < 0)
                        {
                            Cy = (E3 >> 32) - DosALa32;
                        }
                        else
                        {
                            Cy = 0;
                        }
                        E4 = D4 - Divisor[2] * QuotientH + Cy;
                        if (E4 > D4 || E4 < 0)
                        {
                            Cy = (E4 >> 32) - DosALa32;
                        }
                        else
                        {
                            Cy = 0;
                        }
                        E5 = D5 - Divisor[3] * QuotientH + Cy;
                    } while (E5 < 0);
                    Quotient[2] = QuotientH;
                    D2 = E2 & DosALa32_1;
                    D3 = E3 & DosALa32_1;
                    D4 = E4 & DosALa32_1;
                    D5 = E5;
                    dDividend = ((((((double)D5 * dDosALa32 +
                            (double)D4) * dDosALa32 +
                            (double)D3) * dDosALa32 +
                            (double)D2) * dDosALa32 +
                            (double)D1) * dDosALa32 +
                            (double)D0);
                }
                QuotientH = (long)(dDividend / dDivisor / dDosALa32) + 3;
                do
                {
                    QuotientH--;
                    E1 = D1 - Divisor[0] * QuotientH;
                    if (E1 > D1 || E1 < 0)
                    {
                        Cy = (E1 >> 32) - DosALa32;
                    }
                    else
                    {
                        Cy = 0;
                    }
                    E2 = D2 - Divisor[1] * QuotientH + Cy;
                    if (E2 > D2 || E2 < 0)
                    {
                        Cy = (E2 >> 32) - DosALa32;
                    }
                    else
                    {
                        Cy = 0;
                    }
                    E3 = D3 - Divisor[2] * QuotientH + Cy;
                    if (E3 > D3 || E3 < 0)
                    {
                        Cy = (E3 >> 32) - DosALa32;
                    }
                    else
                    {
                        Cy = 0;
                    }
                    E4 = D4 - Divisor[3] * QuotientH + Cy;
                    if (E4 > D4 || E4 < 0)
                    {
                        Cy = (E4 >> 32) - DosALa32;
                    }
                    else
                    {
                        Cy = 0;
                    }
                    E5 = D5 - Divisor[4] * QuotientH + Cy;
                } while (E5 < 0);
                Quotient[1] = QuotientH;
                D1 = E1 & DosALa32_1;
                D2 = E2 & DosALa32_1;
                D3 = E3 & DosALa32_1;
                D4 = E4 & DosALa32_1;
                D5 = E5;
                dDividend = ((((((double)D5 * dDosALa32 +
                        (double)D4) * dDosALa32 +
                        (double)D3) * dDosALa32 +
                        (double)D2) * dDosALa32 +
                        (double)D1) * dDosALa32 +
                        (double)D0);
            }
            QuotientH = (long)(dDividend / dDivisor) + 3;
            do
            {
                QuotientH--;
                E0 = D0 - Divisor[0] * QuotientH;
                if (E0 > D0 || E0 < 0)
                {
                    Cy = (E0 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                E1 = D1 - Divisor[1] * QuotientH + Cy;
                if (E1 > D1 || E1 < 0)
                {
                    Cy = (E1 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                E2 = D2 - Divisor[2] * QuotientH + Cy;
                if (E2 > D2 || E2 < 0)
                {
                    Cy = (E2 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                E3 = D3 - Divisor[3] * QuotientH + Cy;
                if (E3 > D3 || E3 < 0)
                {
                    Cy = (E3 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                E4 = D4 - Divisor[4] * QuotientH + Cy;
                if (E4 > D4 || E4 < 0)
                {
                    Cy = (E4 >> 32) - DosALa32;
                }
                else
                {
                    Cy = 0;
                }
                E5 = D5 - Divisor[5] * QuotientH + Cy;
            } while (E5 < 0);

            if (ChSignDividend != ChSignDivisor)
            {
                if (((E0 | E1 | E2 | E3 | E4 | E5) & DosALa32_1) != 0)
                {
                    if (++QuotientH == DosALa32)
                    {
                        QuotientH = 0;
                        if (++Quotient[1] == DosALa32)
                        {
                            Quotient[1] = 0;
                            if (++Quotient[2] == DosALa32)
                            {
                                Quotient[2] = 0;
                                if (++Quotient[3] == DosALa32)
                                {
                                    Quotient[3] = 0;
                                    if (++Quotient[4] == DosALa32)
                                    {
                                        Quotient[4] = 0;
                                        if (++Quotient[5] == DosALa32)
                                        {
                                            Quotient[5] = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Quotient[0] = QuotientH;

            if (ChSignDividend)
            {
                ChSignDoublePrecLong(Dividend);
            }
            if (ChSignDivisor)
            {
                ChSignDoublePrecLong(Divisor);
            }
            if (ChSignDividend != ChSignDivisor)
            {
                ChSignDoublePrecLong(Quotient);
            }
        }

        private bool LargeNumberIsZero(long[] Nbr)
        {
            int i;
            if (Nbr[0] > 0)
            {
                for (i = (int)abs(Nbr[0]); i > 0; i--)
                {
                    if (Nbr[i] != 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private long ModPow(long Base, long Exp, long Mod)
        {
            long Pot, Pwr, mask, value;
            if (Exp == 0) { return 1L; }
            mask = 1L;
            Pot = 1L;
            Pwr = Base;
            value = 0;
            while (true)
            {
                if ((Exp & mask) != 0)
                {
                    Pot = MultMod(Pot, Pwr, Mod);
                    value += mask;
                    if (value == Exp) { return Pot; }
                }
                mask *= 2L;
                Pwr = MultMod(Pwr, Pwr, Mod);
            }
        }
        private long ModInv(long Val, long Mod)
        {
            long U1, U3, V1, V3, Aux, Q;
            U1 = 1; U3 = Val; V1 = 0; V3 = Mod;
            while (V3 != 0)
            {
                Q = U3 / V3;
                Aux = U1 - V1 * Q; U1 = V1; V1 = Aux;
                Aux = U3 - V3 * Q; U3 = V3; V3 = Aux;
            }
            return (U1 + Mod) % Mod;
        }
        /* Calculate factor1*factor2 mod Mod */
        private long MultMod(long factor1, long factor2, long Mod)
        {
            long aux;
            aux = factor1 * factor2 - Mod * (long)(((double)factor1 * (double)factor2) / (double)Mod);
            if (aux >= Mod) { return aux - Mod; }
            if (aux < 0) { return aux + Mod; }
            return aux;
        }
        private bool ShowHomoSols(byte type, long[] H1, long[] K1, long s, long T, long MagnifY, String eqX, String eqY)
        {
            int i;
            String U = (type == 4 ? "'" : "");
            String X1 = "X";
            String Y1 = (MagnifY == 1 ? "Y" : "Y'");

            MultAddLargeNumbers(s * T, H1, -F * T, K1, L1);
            MultLargeNumber(T, H1, L2);
            if (type == 4)
            {
                for (i = (LargeNumberIsZero(L1) && LargeNumberIsZero(L2) ? 1 : 0); i < 2; i++)
                {
                    AddLargeLong(L2, -CY0, L2);
                    if (DivLargeNumber(L2, CY1, L2) != 0)
                    {
                    }
                    else
                    {
                        AddLargeLong(L1, -D, L1);
                        MultAddLargeNumbers(1, L1, -B, L2, L1);
                        if (DivLargeNumber(L1, 2 * A, L1) != 0)
                        {
                        }
                        else
                        {
                            MultLargeNumber(MagnifY, L2, L2);
                            return true;
                        }
                    }
                    MultAddLargeNumbers(-s * T, H1, F * T, K1, L1);
                    MultLargeNumber(-T, H1, L2);
                }
            }
            else
            {
                MultLargeNumber(MagnifY, L2, L2);
                return true;
            }
            return false;
        }
        private void AddLargeLong(long[] Src, long Nbr, long[] Dest)
        {
            ExtendSign(Src);
            long Cy = Nbr;
            for (int i = 1; i < abs(Src[0]) + 3; i++)
            {
                Dest[i] = Src[i] + (Cy < 0 ? Cy + Bi : Cy);
                Cy = Dest[i] / Bi - (Cy < 0 ? 1 : 0);
                Dest[i] %= Bi;
            }
            Dest[0] = abs(Src[0]);
            AdjustSign(Dest);
        }
        private long DivLargeNumber(long[] Nbr, long Coef, long[] Dest)
        {
            long Q, R, Rem, C;
            int i;
            if (LargeNumberIsZero(Nbr)) { return 0; };
            C = (Coef < 0 ? -Coef : Coef);
            Rem = (Nbr[0] < 0 ? C - 1 : 0);
            for (i = (int)(Nbr[0] < 0 ? -Nbr[0] : Nbr[0]); i > 0; i--)
            {
                R = Rem * Mi + Nbr[i] / Mi;
                Q = (long)((double)R / (double)C);
                R = R - C * Q;
                if (R >= C && R < C + C) { Q++; R -= C; }
                else
                {
                    if (R >= -C && R < 0) { Q--; R += C; }
                }
                Rem = Q;
                R = R * Mi + Nbr[i] % Mi;
                Q = (long)((double)R / (double)C);
                R = R - C * Q;
                if (R >= C && R < C + C) { Q++; R -= C; }
                else
                {
                    if (R >= -C && R < 0) { Q--; R += C; }
                }
                Dest[i] = Rem * Mi + Q;
                Rem = R;
            }
            Dest[0] = Nbr[0];
            AdjustSign(Dest);
            if (Coef < 0)
            {
                ChangeSign(Dest, (byte)1);
            }
            return Rem;
        }

        private void ExtendSign(long[] Nbr)
        {
            if (Nbr[0] < 0)
            {
                Nbr[1 - (int)Nbr[0]] = Nbr[2 - (int)Nbr[0]] = Bi - 1;
            }
            else
            {
                Nbr[1 + (int)Nbr[0]] = Nbr[2 + (int)Nbr[0]] = 0;
            }
        }
        private void MultAddLargeNumbers(long CPrev, long[] Prev, long CAct, long[] Act, long[] Dest)
        {
            long Tmp, Re1, Re2, Re4, PL, PH, AL, AH;
            int S = (int)abs(Act[0]);
            long T = (Prev[0] < 0 ? Bi - 1 : 0);
            long U = (Act[0] < 0 ? Bi - 1 : 0);
            while (S < abs(Prev[0]))
            {
                Act[++S] = U;
            }
            S = (int)abs(Prev[0]);
            while (S < abs(Act[0]))
            {
                Prev[++S] = T;
            }
            Prev[S + 1] = Prev[S + 2] = T;
            Act[S + 1] = Act[S + 2] = U;
            Dest[0] = S;
            long CPH = CPrev / Mi; long CPL = CPrev % Mi;
            long CAH = CAct / Mi; long CAL = CAct % Mi;
            long CyL = 0; long CyH = 0;
            for (S = 1; S <= Dest[0] + 2; S++)
            {
                PL = Prev[S] % Mi; PH = Prev[S] / Mi;
                AL = Act[S] % Mi; AH = Act[S] / Mi;
                Tmp = PL * CPL + AL * CAL + CyL; Re2 = Tmp / Mi; Re1 = Tmp % Mi;
                Tmp = PH * CPL + PL * CPH + AH * CAL + AL * CAH + CyH + Re2; Re4 = Tmp / Mi; Re1 += (Tmp % Mi) * Mi;
                Tmp = PH * CPH + AH * CAH + Re4 - (Re1 < 0 ? 1 : 0); CyH = Tmp / Mi; CyL = Tmp % Mi;
                Dest[S] = (Re1 + Bi) % Bi;
            }
            AdjustSign(Dest);
        }
        private void MultLargeNumber(long Coef, long[] Nbr, long[] Dest)
        {
            long LSM, MSM, Re2, Re1, Re4, Tmp;
            ExtendSign(Nbr);
            long CfH = Coef / Mi; long CfL = Coef % Mi;
            long CyL = 0; long CyH = 0;
            for (int S = 1; S <= abs(Nbr[0]) + 2; S++)
            {
                LSM = Nbr[S] % Mi; MSM = Nbr[S] / Mi;
                Tmp = CfL * LSM + CyL; Re2 = Tmp / Mi; Re1 = Tmp % Mi;
                Tmp = CfH * LSM + CfL * MSM + CyH + Re2; Re4 = Tmp / Mi; Re1 += (Tmp % Mi) * Mi;
                Tmp = CfH * MSM + Re4 - (Re1 < 0 ? 1 : 0); CyH = Tmp / Mi; CyL = Tmp % Mi;
                Dest[S] = (Re1 + Bi) % Bi;
            }
            Dest[0] = Nbr[0];
            AdjustSign(Dest);
        }
    }
    class ArrayLongs
    {
        public long[] element;

        public ArrayLongs(int NbrElements)
        {
            this.element = new long[NbrElements];
        }
    }
}