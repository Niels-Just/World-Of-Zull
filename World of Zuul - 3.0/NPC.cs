using System;
using System.Collections.Generic;

namespace World_of_Zuul___3._0
{
    public class NPC
    {
        public string Name;
        public string Description;
        public bool HasPart;
        public string PartName;

        // Liste over spørgsmål
        public List<Question> Questions;

        public NPC(string name, string description, List<Question> questions, bool hasPart, string partName)
        {
            Name = name;
            Description = description;
            Questions = questions;
            HasPart = hasPart;
            PartName = partName;
        }

        public void Talk()
        {
            Console.Clear();
            TextEffect.TxtEffectNpc($"{Name}: {Description}\n", 40);

            bool allCorrect = true; 

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
                    }
                    else
                    {
                        TextEffect.TxtEffect("Det er det forkerte svar, prøv igen.\n", 30, 200);
                        allCorrect = false; // Hvis spillerens svar er forkert, markeres allCorrect som false
                    }
                }
            }

            if (allCorrect)
            {
                TextEffect.TxtEffect("Du har besvaret alle spørgsmål korrekt!\n" +
                                               $"Her din beløning! Du får {PartName}" , 30, 400);
                //Her tænker jeg man skal have en del af solcellen 
                
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
