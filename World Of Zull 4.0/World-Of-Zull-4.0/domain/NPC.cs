using World_Of_Zull_4._0.presentation;
namespace World_Of_Zull_4._0.domain
{
    public class Npc
    {
        public string Name;
        public string Description;
        public bool HasPart;
        public Item Part;

        // Liste over spørgsmål
        public List<Question> Questions;

        public Npc(string name, string description, List<Question> questions, bool hasPart, Item part)
        {
            Name = name;
            Description = description;
            Questions = questions;
            HasPart = hasPart;
            Part = part;
        }

        public void Talk(Player player)
        {
            Console.Clear();

            int correctQuestions = 0;

            if (HasPart)
            {
                TextEffect.TxtEffectNpc($"{Description}\n", 20);
                foreach (var question in Questions)
                {
                    bool correctAnswer = false;
                    while (!correctAnswer)
                    {
                        // Print spørgsmålet og svarmulighederne
                        string dialog = $"{question.Text}\n";
                        for (int i = 0; i < question.Answers.Length; i++)
                        {
                            dialog = dialog + $"Svar {i + 1}: {question.Answers[i]}\n";
                        }
            
                        Console.WriteLine(dialog);
                        Console.WriteLine("Skriv dit svar her!:\n");
                        string spillerSvar = Console.ReadLine()?.ToLower();
            
                        // Tjek for korrekt svar
                        if (spillerSvar == $"svar {question.CorrectAnswer}")
                        {
                            TextEffect.TxtEffect("Det er det rigtige svar!\n", 30, 200);
                            correctAnswer = true;
                            correctQuestions++;
                        }
                        else
                        {
                            TextEffect.TxtEffect("Det er det forkerte svar, prøv igen.\n", 30, 200);
                        }
                    }
                }
                
                if (correctQuestions == 2)
                {
                    TextEffect.TxtEffectNpc("Du har besvaret alle spørgsmål korrekt!\n" +
                                            $"Her er din belønning! Du får {Part.ItemName}" , 30);
                    player.AddItem(Part);
                    HasPart = false;
                }
            }
            else
            {
                TextEffect.TxtEffect("Du har allerede fundet alle delene her.\n", 30, 1000);
            }
        }
    }

    public class Question
    {
        public string Text;
        public string[] Answers;
        public int CorrectAnswer; // Indeks for korrekt svar 

        public Question(string text, string[] answers, int correctAnswer)
        {
            Text = text;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
    }
}
