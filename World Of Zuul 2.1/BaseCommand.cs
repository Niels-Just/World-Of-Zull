namespace World_Of_Zuul;
/* Baseclass for commands
 */

class BaseCommand {
<<<<<<< HEAD
  //string indicating that subclasses should provide their own description 
  protected string description = "Undocumented";
=======
  //string indicating that subclasses should provide their own descrption 
  protected string description = "Skriv hvad din kommando gør her";
>>>>>>> 2e6f970b42fcb4d7e2b5e65c30fa2759b1ff44f2
  
  //parameters is an array of strings that represents the commandline arguments provided by the users
  //bound this is an integer that specifies the expected number of parameters 
  /*GuardEq method is to check if the number parameters provided is not equal to bound,
   if true means there is a mismatch command cant be executed*/
  protected bool GuardEq (string[] parameters, int bound) {
    return parameters.Length!=bound;
  }
  public String GetDescription () {
    return description;
  }
}



