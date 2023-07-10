using System;
using System.Collections.Generic;

namespace TextEngine
{
    public class Prompt
    {
        private readonly string _id;
        private readonly string _text;
        private readonly List<Choice> _choices;
        public Choice SelectedChoice { get; set; }

        public Prompt(string id, string text, List<Choice> choices)
        {
            _id = id ?? throw new ArgumentNullException(nameof(id));
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _choices = choices ?? throw new ArgumentNullException(nameof(choices));
        }

        public void PresentChoices()
        {
            Console.WriteLine(_text);

            for (int i = 0; i < _choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_choices[i].Text}");
            }

            if (Globals.ShouldShowChoicesDialoguePhrase)
            {
                if (Globals.ShouldShowNumberOfChoices)
                {
                    Console.WriteLine(Globals.EnterChoicesDialoguePhrase + $" (1-{_choices.Count})");
                }
                else
                {
                    Console.WriteLine(Globals.EnterChoicesDialoguePhrase);
                }
            }
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int choiceIndex) && choiceIndex >= 1 && choiceIndex <= _choices.Count)
            {
                SelectedChoice = _choices[choiceIndex - 1];
                
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        // Getters
        public string GetId()
        {
            return _id;
        }

        public string GetText()
        {
            return _text;
        }
        public List<Choice> GetChoices()
        {
            return _choices;
        }
    }
}