namespace World_Of_Zuul;
/* Context class to hold all context relevant to a session.
 */

class Context {
    //keeps track of the players current location
    Space current;
    //checks if game is finished
    bool done = false;
  
    //represents the players location in the game
    public Context (Space node) {
        current = node;
    }
    //returns the current location, allowing other parts of the game to know where the player are at a given time
    public Space GetCurrent() {
        return current;
    }
    //handles the players movement between rooms
    public void Transition (string direction) {
        //determines the next room based on provided direction
        Space next = current.FollowEdge(direction);
        if (next==null) {
            Console.WriteLine("You are confused, and walk in a circle looking for '"+direction+"'. In the end you give up 😩");
        } else {
            //calls Goodbye on the prior room, handles exit messages.
            current.Goodbye();
            //updates room to next room.
            current = next;
            //calls Welcome on the new room, provides entry message. 
            current.Welcome();
        }
    }
    
  
    //sets the done to true, game should end.
    public void MakeDone () {
        done = true;
    }
  
    //allows other parts of the game to check if the game is done.
    public bool IsDone () {
        return done;
    }
}