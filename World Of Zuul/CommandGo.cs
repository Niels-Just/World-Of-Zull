namespace World_Of_Zuul;
/* Command for transitioning between spaces
 */

//Inherits from 'BaseComamand' and 'ICommand' can utilize propeties and methods defined i both. 
class CommandGo : BaseCommand, ICommand {
  public CommandGo () {
    //informs the player what the command does.
    description = "Follow an exit";
  }
  //implements the 'ICommand' interface, so 'Execute' method can be used. 
  
  //'context' players current location.
  //'command' the command string that was entered fx. the go command
  //'parameters' the direction the player wants to go
  public void Execute (Context context, string command, string[] parameters) {
    //'GuardEq' checks if the 'parameter' is not equal to 1, if the command is not valid print message.
    if (GuardEq(parameters, 1)) {
      Console.WriteLine("I don't seem to know where that is 🤔");
      return;
    }
    // if the 'parameters' is valid move on to next location.
    // 'context.Transtion(parameters[0])' methos is ressonspible for changing  the players current location.
    //[0] index 1 in an array. 
    context.Transition(parameters[0]);
  }
}
