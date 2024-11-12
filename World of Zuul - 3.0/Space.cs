namespace World_of_Zuul___3._0;

/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node
{
}

  public void Welcome () {
    Console.WriteLine("Du er nu ved "+name);
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Dine mulige udgange er:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }
  }
  

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
    foreach (var item in roomItem)
    {
      if (item.ItemName == itemName)
      {
        roomItem.Remove(item);
        // Console.WriteLine($"You picked up {item}");
        return item;
      }
    }
    // Console.WriteLine($"{itemName} is not in this room");
    return null!;
  }
  
  // Method to print all items in the room to console
  public void ListRoomItems()
  {
    if (roomItem.Count == 0)
    {
      Console.WriteLine("Der er ingen genstande her.");
    }
    else
    {
      Console.WriteLine("Der er følgende genstande her:");
      foreach (var item in roomItem)
      {
        Console.WriteLine(item.ToString());
      }
    }
  }
  
  public void AddNPC(NPC npc) // Method to add an NPC to the room
  {
    npcs.Add(npc);
  }

  public void RemoveNpc(string npcName)
  {
    foreach (var npc in npcs)
    {
      if (npc.NpcName == npcName)
      {
        npcs.Remove(npc);
        return; // Return Exits the method when the item is removed
      }
    }
  }

  public void PrintNPCs() // Method to print all NPCs in the room
  {
    if (npcs.Count == 0)
    {
      Console.WriteLine("Der er ingen personer her.");
    }
    else
    {
      Console.WriteLine("Personer i rummet:");
      foreach (var npc in npcs)
      {
        Console.WriteLine(npc.ToString());
      }
    }
  }
  
  public NPC GetNpcByName(string npcName)
  {
            
    foreach (NPC npc in npcs)
    {
      if (npc.getNpcName() == npcName)
      {
        return npc; 
      }
    }
    return null; 
  }
}


