namespace World_of_Zuul___3._0
{
    //NPCalien arver fra NPC så også NPCalien kan bruge add metoden
    public class NPCalien : NPC
    {
        public string Information;

        public NPCalien(string name, string description, string information)
            : base(name, description, new List<Question>())
        {
            Information = information;
        }

        public void TalkFnorkel(Room currentRoom)
        {
            Console.Clear();
            TekstEffektKlassen.TekstEffectNPC($"{Name}: {Description}\n", 40);
            
            TekstEffektKlassen.TekstEffectNPC($"{Information}\n", 40);
            currentRoom.EnterRoomMsg();
        }
    }
}
    