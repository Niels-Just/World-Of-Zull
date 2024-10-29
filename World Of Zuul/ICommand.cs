namespace World_Of_Zuul;
/* Command interface
 */

//'context' players current location.
//'command' the command string that was entered fx. the go command
//'parameters' the direction the player wants to go

interface ICommand {
  void Execute (Context context, string command, string[] parameters);
  //provides a description of the command.
  string GetDescription ();
}

    