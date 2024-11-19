namespace World_of_Zuul___3._0
{
    //NPCalien arver fra NPC så også NPCalien kan bruge add metoden
    public class NPCalien : NPC
    {
        public string Information;

        public NPCalien(string name, string description, string information, bool hasPart, Item part)
            : base(name, description, new List<Question>(), hasPart, part)
        {
            Information = information;
        }

        public void TalkFnorkel(Room currentRoom)
        {
            Console.Clear();
            TextEffect.TxtEffectNpc($"{Name}: {Description}\n", 40);
            
            TextEffect.TxtEffectNpc($"{Information}\n", 40);
            currentRoom.EnterRoomMsg();
        }
    }
}
    