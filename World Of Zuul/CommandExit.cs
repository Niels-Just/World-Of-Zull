namespace World_Of_Zuul;
/* Command for exiting program
 */

//Inherits from 'BaseComamand' and 'ICommand' can utilize propeties and methods defined i both. 
class CommandExit : BaseCommand, ICommand {
    //context.MakeDone() method sets the 'done' in 'context' to 'true'. Game should terminate.
  public void Execute (Context context, string command, string[] parameters) {
    context.MakeDone();
  }
}
