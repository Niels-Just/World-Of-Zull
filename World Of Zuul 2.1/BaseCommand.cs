namespace World_Of_Zuul;
/* Baseclass for commands
 */

class BaseCommand {
  //string indicating that subclasses should provide their own descrption 
  protected string description = "Undocumented";
  
  //parameters is an array of strings that represents the commandline arguments provided by the users
  //bound this is an integer that specifies the expected number of parameteres 
  /*GuardEq method is to check if the number parameters provided is not equal to bound,
   if true means there is a mismatch command cant be executed*/
  protected bool GuardEq (string[] parameters, int bound) {
    return parameters.Length!=bound;
  }
  public String GetDescription () {
    return description;
  }
}



