//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and
//     will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace Utilities.Courses {
public partial class QHelper {
public static string GetThorinsCompany(Random random, Action<string, ushort> registerAnswer, bool isProof) {
var q = new XyzQuestion(random, isProof);
q.Id = "GetThorinsCompany";
q.Marks = 1;
q.Stem = @"
      Which of these following were part of Thorin's company?
   ";
q.AddCorrects(
   @"Fili",
   @"Kili",
   @"Balin",
   @"Dwalin",
   @"Oin",
   @"Gloin",
   @"Dori",
   @"Nori",
   @"Ori",
   @"Bifur",
   @"Bofur",
   @"Bombur"
);
q.AddIncorrects(
   @"Gili",
   @"Malin",
   @"Bloin",
   @"Gyori",
   @"Ryori",
   @"Dombur",
   @"Rofur",
   @"Roalin",
   @"Gróin",
   @"Azaghâl"
);
string rval = q.GetQuestion(registerAnswer);
return rval;
} // GetThorinsCompany
} // class
} // namespace
