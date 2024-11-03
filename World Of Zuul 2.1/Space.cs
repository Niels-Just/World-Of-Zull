namespace World_Of_Zuul;
/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {
  
  private List<Item> roomItem = new List<Item>(); // Liste for at opbevarer items i et rum
  public Space (String name) : base(name)
  {
  }
  
  /*called when a player enters a new room
  Prints a message indicating the players current location, using the 'name' property inherited from 'Node'
  Retrieves the keys from the 'edges' dictionary and them into a 'HashSet'
  Displays the avaible exits by iterating over the 'exits' collection and printing each exit.
  */
  public void Welcome () {
    Console.WriteLine("You are now at "+name);
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Current exits are:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }
  }
  
  //farewell message when the player leaves
  public void Goodbye () {
  }
  
  //overrides the 'FollowEdge' method from the 'node' class
  /*calls the base class's 'FollowEdge' method, which returns a 'Node' object.
   The method then casts this object to a 'Space' type before running it.
   This ensures that when a player transitons to a new space, they are working with a 'Space'
   object rather than a more generic 'Node'
   */
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
  }
  
  public void AddRoomItem(Item item)
  {
    roomItem.Add(item);
  }

  // TakeItem method look for the itemName and if jt finds it the item is removed from the room.
  public Item TakeItem(string itemName)
  {
    // OrdinalIgnoreCase ignores case sensitivity
    Item item = roomItem.Find(i => i.getItemName().Equals(itemName, StringComparison.OrdinalIgnoreCase));
    if (item != null)
    {
      roomItem.Remove(item);
    }
    return item;
  }
  
  // Method to print all items in the room to console
  public void ListRoomItems()
  {
    if (roomItem.Count == 0)
    {
      Console.WriteLine("There are no items here.");
    }
    else
    {
      Console.WriteLine("Items in this room:");
      foreach (var item in roomItem)
      {
        Console.WriteLine(item.ToString());
      }
    }
  }
}


