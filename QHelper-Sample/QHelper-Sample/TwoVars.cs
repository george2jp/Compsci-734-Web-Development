using System;
using System.Text;

namespace Utilities.Courses
{
   public partial class QHelper
   {
      public static string GetApplesAndOranges(Random random, Action<string, ushort> registerAnswer, bool isProof)
      {
         int appleCnt1 = random.Next(2, 6);
         int orangeCnt1 = random.Next(6, 10);
         int appleCnt2 = random.Next(10, 15);
         int orangeCnt2 = random.Next(15, 20);
         int applePrice = 2 * random.Next(4, 9);
         int orangePrice = 2 * random.Next(11, 19);
         StringBuilder sb = new StringBuilder();
         sb.AppendFormat("At Prancing Pony, you can buy {0} apples and {1} oranges for {2} Castars; ",
             appleCnt1, orangeCnt1, appleCnt1 * applePrice + orangeCnt1 * orangePrice);
         sb.AppendFormat("you can also buy {0} apples and {1} oranges for {2} Castars. ",
             appleCnt2, orangeCnt2, appleCnt2 * applePrice + orangeCnt2 * orangePrice);
         sb.AppendLine("What is the price of a single apple, expressed in Castars?");

         var q = new TruthQuestion(random, isProof);
         q.AddCorrects(applePrice.ToString());
         q.AddIncorrects(orangePrice.ToString());
         q.AddIncorrects((orangePrice + 1).ToString());
         q.AddIncorrects((orangePrice - 1).ToString());
         q.AddIncorrects((orangePrice + 2).ToString());
         q.AddIncorrects((orangePrice - 2).ToString());
         q.AddIncorrects((applePrice + 1).ToString());
         q.AddIncorrects((applePrice - 1).ToString());
         q.AddIncorrects((applePrice + 2).ToString());
         q.AddIncorrects((applePrice - 2).ToString());
         sb.Append(q.GetQuestion(registerAnswer));
         return sb.ToString();
       } // GetApplesAndOranges

   } // class
} // namespace
