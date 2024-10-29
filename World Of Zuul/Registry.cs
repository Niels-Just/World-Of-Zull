namespace World_Of_Zuul;
/* Command registry
 */

class Registry {
  //holds the current location context of the game
  Context context;
  //executed if the player inputs an unrecognized 
  ICommand fallback;
  //maps command names as strings to their coresponding implementation as 'ICommand' objects.
  Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
  
  //initalizes the 'Registry' with a fallback command
  public Registry (Context context, ICommand fallback) {
    this.context = context;
    this.fallback = fallback;
  }
  
  //adds new command to the registry, the command can then be invoked by its name.
  public void Register (string name, ICommand command) {
    commands.Add(name, command);
  }
  
  /*processes a command input, splits the input line into command and parameters
   check if the command exists in the registry, executes the command if the command exists
   if not invokes the fallback command
   */
  public void Dispatch (string line) {
    string[] elements = line.Split(" ");
    string command = elements[0];
    string[] parameters = GetParameters(elements);
    (commands.ContainsKey(command) ? GetCommand(command) : fallback).Execute(context, command, parameters);
  }
  
  
  //retrives a command from the registry based on its name
  public ICommand GetCommand (string commandName) {
    return commands[commandName];
  }
  
  //returns an array of all command names  currently registered in the registry
  public string[] GetCommandNames () {
    return commands.Keys.ToArray();
  }
  
  // helpers
  /* extracts parameters from the input command string, ignores the first element and returns the remaning
    elements as parameters
   */
  private string[] GetParameters (string[] input) {
    string[] output = new string[input.Length-1];
    for (int i=0 ; i<output.Length ; i++) {
      output[i] = input[i+1];
    }
    return output;
  }
}

