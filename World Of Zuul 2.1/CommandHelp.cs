namespace World_Of_Zuul;
/* Help command
 */

class CommandHelp : BaseCommand, ICommand {
    //class which is managing the availabe commands 
    Registry registry;
    
    //Contructor takes a 'Registry' object as a parameter and initalizes the instance 'registry'.
    //sets the 'description' field inherited from 'BaseCommand' to "Display a help message"
    public CommandHelp (Registry registry) {
        this.registry = registry;
        this.description = "Viser alle mulige handlinger";
    }
    
    public void Execute (Context context, string command, string[] parameters) {
        //Retrives the name of all registerede commands using 'registry.GetCommandNames();'
        string[] commandNames = registry.GetCommandNames();
        //The command names are sorted alphabetically 
        Array.Sort(commandNames);
      
        // find max length of command name
        // ensures that the command names are aligned when printed
        int max = 0;
        foreach (String commandName in commandNames) {
            int length = commandName.Length;
            if (length>max) max = length;
        }
      
        // present list of commands
        //The output is formatted to align the command names based on the maximum length found earlier.
        Console.WriteLine("Commands:");
        foreach (String commandName in commandNames) {
            string description = registry.GetCommand(commandName).GetDescription();
            Console.WriteLine(" - {0,-"+max+"} "+description, commandName);
        }
    }
}