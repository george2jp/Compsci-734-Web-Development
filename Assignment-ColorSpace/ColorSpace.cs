// Assignment ColorSpace Template. S Manoharan.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Utilities.Courses
{
   public class ColorSpace : TemplatedCoursework
   {
        public override void Initialize()
      {
         base.Initialize();
         
      } // Initialize

      public override string Answers(bool withAnswers, uint uid)
      {
         InitInputs(uid);
         StringBuilder sb = new StringBuilder();
         sb.AppendFormat("AUID: {0}", uid);
         sb.AppendLine();
         WriteAnswers(sb, GetRGB(uid), "1", withAnswers);
         WriteAnswers(sb, GetCIE(uid), "2", withAnswers);
         WriteAnswers(sb, GetRGBSpace(uid), "3", withAnswers);
         WriteAnswers(sb, GetHSVSpace(uid), "4", withAnswers);
         WriteAnswers(sb, GetHSVcood(uid), "5", withAnswers);
         WriteAnswers(sb, GetRGBvalue(uid), "6", withAnswers);

            return sb.ToString();
      } // Answers

      private void WriteAnswers(StringBuilder sb, string answer, string partId, bool withAnswers)
      {
            withAnswers = true;
            sb.AppendFormat("{0}: {1}", partId, withAnswers ? answer : "");
         sb.AppendLine();
            
        } // WriteAnswers

      public override string MarkingResult(bool withAnswers, uint uid, string submission, out double mark)
      {
         InitInputs(uid);
         mark = 0.0;
         StringBuilder sb = new StringBuilder();
         withAnswers = true;
         Dictionary<string, string> kvp = ProcessAnswerFile(submission);
         string a1_aS = SubmittedAnswer(kvp, "1");
         string a2_aS = SubmittedAnswer(kvp, "2");
         string a3_aS = SubmittedAnswer(kvp, "3");
         string a4_aS = SubmittedAnswer(kvp, "4");
         string a5_aS = SubmittedAnswer(kvp, "5");
         string a6_aS = SubmittedAnswer(kvp, "6");

            if (withAnswers)
         {
            sb.AppendFormat("1: correct answer: [{0}]; your answer: [{1}]\n",
               GetRGB(uid), a1_aS);
            sb.AppendFormat("2: correct answer: [{0}]; your answer: [{1}]\n",
               GetCIE(uid), a2_aS);
            sb.AppendFormat("3: correct answer: [{0}]; your answer: [{1}]\n",
               GetRGBSpace(uid), a3_aS);
            sb.AppendFormat("4: correct answer: [{0}]; your answer: [{1}]\n",
               GetHSVSpace(uid), a4_aS);
            sb.AppendFormat("5: correct answer: [{0}]; your answer: [{1}]\n",
               GetHSVcood(uid), a5_aS);
            sb.AppendFormat("6: correct answer: [{0}]; your answer: [{1}]\n",
               GetRGBvalue(uid), a6_aS);

            }

         //-----------------------------------------------------------implement
         if (a1_aS == GetRGB(uid)) mark += 1;
         if (a2_aS == GetCIE(uid)) mark += 1;
         if (a3_aS == GetRGBSpace(uid)) mark += 1;
         if (a4_aS == GetHSVSpace(uid)) mark += 1;
         if (a5_aS == GetHSVcood(uid)) mark += 1;
         if (a6_aS == GetRGBvalue(uid)) mark += 1;

            sb.AppendLine();
         sb.AppendFormat("Your total marks: {0}/6\n", mark);
         return sb.ToString();
      } // MarkingResult

      private static string SubmittedAnswer(Dictionary<string, string> kvp, string qId)
      {
         string a = kvp.ContainsKey(qId) ? Regex.Replace(kvp[qId], @"\s+", "") : "";
         return a;
      } // SubmittedAnswer

      private void InitInputs(uint uid)
      {
         Random random = GetRandom(uid);
         numRGB.Clear();
         for (int i = 0; i < 3; ++i)
         {
            numRGB.Add((double)random.Next(11)/10);
         }

         numCIE.Clear();
         for (int i = 0; i < 3; ++i)
            {
                numCIE.Add((double)random.Next(30)*10);
            }

         numRGBSpace1.Clear();
         for (int i = 0; i < 3; ++i)
            {
                numRGBSpace1.Add((double)random.Next(256));
            }

         numRGBSpace2.Clear();
         for (int i = 0; i < 3; ++i)
            {
                numRGBSpace2.Add((double)random.Next(256));
            }

         numHSVSpace1.Clear();
         numHSVSpace1.Add((double)random.Next(361));
         numHSVSpace1.Add((double)random.Next(11)/10);
         numHSVSpace1.Add((double)random.Next(11)/10);


         numHSVSpace2.Clear();
         numHSVSpace2.Add((double)random.Next(361));
         numHSVSpace2.Add((double)random.Next(101)/100);
         numHSVSpace2.Add((double)random.Next(101)/100);


        numR2H.Clear();
        for (int i = 0; i < 3; ++i)
        {
                numR2H.Add((double)random.Next(256));
        }
            numH2R.Clear();
            numH2R.Add(random.Next(361));
            numH2R.Add((double)random.Next(101)/100);
            numH2R.Add((double)random.Next(101)/100);

        } // InitInputs

        //---------------------------------------------------------------------------------------------------------------------------------------
        public string GetSum(uint uid)
        {
            InitInputs(uid);
            int sum = 0;
            for (int i = 0; i < numbers.Count; ++i)
            {
                sum += numbers[i];
            }
            return sum.ToString();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------
        public string GetRGBNumbers(uint uid)
      {
         InitInputs(uid);
         StringBuilder sb = new StringBuilder();
         sb.AppendFormat("{0:0.0}", numRGB[0]);
         for (int i = 1; i < numRGB.Count; ++i)
         {
            sb.AppendFormat(", {0:0.0}", numRGB[i]);
         }
         return sb.ToString();
      } // GetRGBNumbers

      public string GetRGB(uint uid)
      {
         InitInputs(uid);
         StringBuilder sb = new StringBuilder();
         for (int i = 0; i < numRGB.Count; ++i)
         {
             double numb1 = 1;
             double result = numb1 - numRGB[i];
             sb.AppendFormat("{0:0.0},", result);
         }
            string insa = sb.ToString();
            int leng = sb.Length - 1;
            return "(" + insa.Substring(0, leng) + ")";
      } // GetRGB
        //---------------------------------------------------------------------------------------------------------------------------------------
        public string GetCIENumbers(uint uid)
        {
            InitInputs(uid);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}", numCIE[0]);
            for (int i = 1; i < numCIE.Count; ++i)
            {
                sb.AppendFormat(", {0}", numCIE[i]);
            }
            return sb.ToString();
        } // GetCIENumbers


        public string GetCIE(uint uid)
        {
         InitInputs(uid);
         StringBuilder sb = new StringBuilder();
         double sumCIE = 0;
         for (int i = 0; i < numCIE.Count; ++i)
            {
                sumCIE += numCIE[i];
            }
            double x = numCIE[0] / sumCIE;
            double y = numCIE[1] / sumCIE;

         sb.AppendFormat("({0:0.00},{1:0.00})", Math.Round(x, 2), Math.Round(y, 2));
         return sb.ToString();
        } // GetCIE
 //----------------------------------------------------------------------------------------------------------
        public string GetRGBSpace_n1(uint uid)
        {
            InitInputs(uid);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}", numRGBSpace1[0]);
            for (int i = 1; i < numRGBSpace1.Count; ++i)
            {
                sb.AppendFormat(", {0}", numRGBSpace1[i]);
            }
            return sb.ToString();
        } // GetRGBSpace_n1

        public string GetRGBSpace_n2(uint uid)
        {
            InitInputs(uid);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}", numRGBSpace2[0]);
            for (int i = 1; i < numRGBSpace2.Count; ++i)
            {
                sb.AppendFormat(", {0}", numRGBSpace2[i]);
            }
            return sb.ToString();
        } // GetRGBSpace_n2


        public string GetRGBSpace(uint uid)
        {
            InitInputs(uid);
            StringBuilder sb = new StringBuilder();
            double smlnum = 0; 
            for (int i = 0; i < numRGBSpace1.Count; ++i)
            {
                double diff = Math.Pow((numRGBSpace1[i] - numRGBSpace2[i]), 2);
                smlnum += diff;
            }
            double spacediff = Math.Sqrt(smlnum);

            sb.AppendFormat("{0}", Math.Round(spacediff,1));
            return sb.ToString();
        } // GetRGBSpace


        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        public string GetHSVSpace_n1(uint uid)
        {
            InitInputs(uid);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}", numHSVSpace1[0]);
            for (int i = 1; i < numHSVSpace1.Count; ++i)
            {
                sb.AppendFormat(", {0}", numHSVSpace1[i]);
            }
            return sb.ToString();
        } // GetHSVSpace_n1

        public string GetHSVSpace_n2(uint uid)
        {
            InitInputs(uid);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}", numHSVSpace2[0]);
            for (int i = 1; i < numRGBSpace2.Count; ++i)
            {
                sb.AppendFormat(", {0}", numHSVSpace2[i]);
            }
            return sb.ToString();
        } // GetHSVSpace_n2


        public string GetHSVSpace(uint uid)
        {
            InitInputs(uid);
            StringBuilder sb = new StringBuilder();
            double R = 100;
            double angle = 30;
            double h = R * Math.Cos(angle / 180 * Math.PI);
            double r = R * Math.Sin(angle / 180 * Math.PI);
            double H_1 = numHSVSpace1[0];
            double S_1 = numHSVSpace1[1];
            double V_1 = numHSVSpace1[2];
            double H_2 = numHSVSpace2[0];
            double S_2 = numHSVSpace2[1];
            double V_2 = numHSVSpace2[2];
            double x1 = r * V_1 * S_1 * Math.Cos(H_1 / 180 * Math.PI);
            double y1 = r * V_1 * S_1 * Math.Sin(H_1 / 180 * Math.PI);
            double z1 = h * (1 - V_1);
            double x2 = r * V_2 * S_2 * Math.Cos(H_2 / 180 * Math.PI);
            double y2 = r * V_2 * S_2 * Math.Sin(H_2 / 180 * Math.PI);
            double z2 = h * (1 - V_2);
            double dx = x1 - x2;
            double dy = y1 - y2;
            double dz = z1 - z2;
            sb.AppendFormat("{0}",Math.Round(Math.Sqrt(dx * dx + dy * dy + dz * dz),1));
            return sb.ToString();
        } // GetHSVSpace
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public string GetRGBcood(uint uid)
        {
            InitInputs(uid);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}", numR2H[0]);
            for (int i = 1; i < numR2H.Count; ++i)
            {
                sb.AppendFormat(", {0}", numR2H[i]);
            }
            return sb.ToString();
        } // GetRGBcood


        public string GetHSVcood(uint uid)
        {
            InitInputs(uid);
            StringBuilder sb = new StringBuilder();
            double R_new = numR2H[0];
            double G_new = numR2H[1];
            double B_new = numR2H[2];
            double C_max = Math.Max(R_new, Math.Max(G_new, B_new));
            double C_min = Math.Min(R_new, Math.Min(G_new, B_new));
            var diff = C_max - C_min;
            double H, S, V;
            V = C_max;
            if (C_max == 0)
            {
                S = 0;
            }
            else
            {
                S = diff / C_max;
            }


            if (diff == 0)
            {
                H = 0.0;
            }else
            {
                if (R_new == C_max)
                {
                     H = 60 * (G_new - B_new) / diff;
                }else if(G_new == C_max){
                     H = 60 * (B_new - R_new) / diff + 120;
                }
                else
                {
                     H = 60 * (R_new - G_new) / diff + 240;
                }

                if (H < 0)
                {
                    H += 360;
                }
            }

            
            

            sb.AppendFormat("({0:0.0},{1:0.0},{2:0.0})", Math.Round(H, 1), Math.Round(S, 1), Math.Round(V/255, 1));
            return sb.ToString();
        } // GetHSVcood
        //-------------------------------------------------------------------------------------------------------------------------------------------------
        public string GetH2Rvalue(uint uid)
        {
            InitInputs(uid);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}", numH2R[0]);
            for (int i = 1; i < numH2R.Count; ++i)
            {
                sb.AppendFormat(", {0}", numH2R[i]);
            }
            return sb.ToString();
        } // GetH2Rvalue


        public string GetRGBvalue(uint uid)
        {
            InitInputs(uid);
            StringBuilder sb = new StringBuilder();
            double r, g, b;
            var H = numH2R[0];
            var S = numH2R[1];
            var V = numH2R[2];
            if (S == 0)
            {
                r = V;
                g = V;
                b = V;
            }
            else
            {
                int i;
                double f, p, q, t;

                if (H == 360)
                    H = 0;
                else
                    H = H / 60;

                i = (int)Math.Truncate(H);
                f = H - i;

                p = V * (1.0 - S);
                q = V * (1.0 - (S * f));
                t = V * (1.0 - (S * (1.0 - f)));

                switch (i)
                {
                    case 0:
                        r = V;
                        g = t;
                        b = p;
                        break;

                    case 1:
                        r = q;
                        g = V;
                        b = p;
                        break;

                    case 2:
                        r = p;
                        g = V;
                        b = t;
                        break;

                    case 3:
                        r = p;
                        g = q;
                        b = V;
                        break;

                    case 4:
                        r = t;
                        g = p;
                        b = V;
                        break;

                    default:
                        r = V;
                        g = p;
                        b = q;
                        break;
                }

            }
            sb.AppendFormat("({0},{1},{2})", (byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
            return sb.ToString();
        } // GetRGBvalue



        //-----------------------------------------------------------------------------------------------------------
        List<int> numbers = new List<int>();
        List<double> numRGB = new List<double>();
        List<double> numCIE = new List<double>();
        List<double> numRGBSpace1 = new List<double>();
        List<double> numRGBSpace2 = new List<double>();
        List<double> numHSVSpace1 = new List<double>();
        List<double> numHSVSpace2 = new List<double>();
        List<double> numR2H = new List<double>();
        List<double> numH2R = new List<double>();

    } // class
} // namespace
