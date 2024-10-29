namespace World_Of_Zuul;
/* Command interface
 */

interface ICommand {
  void Execute (Context context, string command, string[] parameters);
  string GetDescription ();
}

