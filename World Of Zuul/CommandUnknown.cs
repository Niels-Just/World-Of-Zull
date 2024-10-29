namespace World_Of_Zuul;
/* Fallback for when a command is not implemented
 */

//implementaion of the Execute method inherited from 'ICommand'

//'context' players current location.
//'command' the command string that was entered fx. the go command
//'parameters' the direction the player wants to go

class CommandUnknown : BaseCommand, ICommand {
  public void Execute (Context context, string command, string[] parameters) {
    Console.WriteLine("Woopsie, I don't understand '"+command+"' 😕");
  }
}
