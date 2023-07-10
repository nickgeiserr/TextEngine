using System;
using System.Collections.Generic;

namespace TextEngine {
    internal class TextEngine {
        public static void Main(string[] args) {
            if (args == null || args.Length == 0 || string.IsNullOrEmpty(args[0])) {
                Console.WriteLine("Please provide a valid file path.");
                return;
            }

            var file = AdventureFile.CreateAdventureFile(args[0]);
            var currentPrompt = file.GetPromptById("start");

            bool shouldClose = false;

            while (!shouldClose) {
                // Check if the user wants to quit
                if (currentPrompt?.SelectedChoice?.Redirect == "__exit__") {
                    shouldClose = true;
                    continue;
                }

                // Basic Checks
                Console.Clear();
                if (currentPrompt?.SelectedChoice == null) {
                    currentPrompt?.PresentChoices();
                    continue;
                }

                currentPrompt = file.GetPromptById(currentPrompt.SelectedChoice.Redirect);
                Console.WriteLine(currentPrompt?.SelectedChoice?.RandomEventPool);

                currentPrompt?.PresentChoices();

                if (!string.IsNullOrEmpty(currentPrompt?.SelectedChoice?.RandomEventPool)) {
                    var randomEventPool = file.GetRandomEventPoolById(currentPrompt.SelectedChoice.RandomEventPool);
                    var needPolled = randomEventPool?.PollEvents();

                    foreach(Event e in needPolled ?? new List < Event > ()) {
                        var eventPrompt = file.GetPromptById(e.PromptId);
                        eventPrompt?.PresentChoices();

                        var eventOver = false;
                        while (!eventOver) {
                            if (eventPrompt?.SelectedChoice?.Redirect == "__finish__flag__") {
                                eventOver = true;
                                continue;
                            }

                            // Basic Checks
                            Console.Clear();
                            if (eventPrompt?.SelectedChoice == null) {
                                Console.WriteLine("Invalid choice. Please try again.");
                                eventPrompt?.PresentChoices();
                                continue;
                            }

                            eventPrompt = file.GetPromptById(eventPrompt.SelectedChoice.Redirect);
                            eventPrompt?.PresentChoices();
                        }
                    }
                }
            }
        }
    }
}