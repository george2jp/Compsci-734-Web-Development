using System;
namespace Utilities.Courses
{
   public partial class QHelper
   {
      public static string QIdCS1(Random random, Action<string, ushort> registerAnswer)
      {
         var q = new XyzQuestion(random);
         q.Id = "QIdCS1";
         q.Marks = 2;
         q.Stem = @"?";
         q.AddCorrects(
            @"",
            @"",
            @"",
            @"",
            @"",
            @""
         );
         q.AddIncorrects(
            @"",
            @"",
            @"",
            @"",
            @"",
            @""
         );
         string rval = q.GetQuestion(registerAnswer);
         return rval;
      } // QIdCS1
   } // class
} // namespace
