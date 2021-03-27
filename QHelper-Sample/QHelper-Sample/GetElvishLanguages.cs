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
public static string GetElvishLanguages(Random random, Action<string, ushort> registerAnswer, bool isProof) {
var q = new TruthQuestion(random, isProof);
q.Id = "GetElvishLanguages";
q.Marks = 1;
q.Stem = @"
      Which of these following statements about Elvish languages is false?
   ";
q.AddCorrects(
   @"Quenya's dialects include the languages oF Doriathrin and Noldorin Sindarin.",
   @"Sindarin is the language oF those living in Tol Eressëa and Alqualondë.",
   @"Exilic Quenya is the colloquial speech oF the Nandor.",
   @"Necro Ossiron is the colloquial speech oF the Ossiriand.",
   @"Early Elves adapted Vassarin, the tongue oF the gods or Vassar.",
   @"Myranya is the language spoken in the Myras oF Besëalondë."
);
q.AddIncorrects(
   @"Avarin is the language of various Elves of The Second and Third Clans.",
   @"Quenya is the language of the Elves in Eldamar beyond The Sea.",
   @"Nandorin is the language of The Nandor.",
   @"Falathrin is the language spoken in The Falas of Beleriand.",
   @"Common Eldarin is the language of The three clans of the Eldar, but it later developed into Quenya and Common Telerin.",
   @"Noldorin Sindarin is the language spoken by The Exiled Noldor."
);
string rval = q.GetQuestion(registerAnswer);
return rval;
} // GetElvishLanguages
} // class
} // namespace