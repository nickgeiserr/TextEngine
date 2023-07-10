using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TextEngine
{
    public class AdventureFile
    {
        private readonly string _name;
        private readonly string _author;
        private readonly string _version;
        private readonly bool _multiplayerEnabled;
        private readonly int  _maxPlayers;

        private List<Prompt> _prompts;
        private List<RandomEventPool> _randomEventPools;


        public AdventureFile(string name = null, string author = null, string version = null,
            bool multiplayerEnabled = default, int maxPlayers = default, string EnterChoicesDialoguePhrase = null, bool ShouldShowChoicesDialoguePhrase = default, bool ShouldShowNumberOfChoices = default)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _author = author ?? throw new ArgumentNullException(nameof(author));
            _version = version ?? throw new ArgumentNullException(nameof(version));
            _multiplayerEnabled = multiplayerEnabled;
            if (EnterChoicesDialoguePhrase != null)
                Globals.EnterChoicesDialoguePhrase = EnterChoicesDialoguePhrase;
            if (ShouldShowChoicesDialoguePhrase)
                Globals.ShouldShowChoicesDialoguePhrase = ShouldShowChoicesDialoguePhrase;
            if (ShouldShowNumberOfChoices)
            {
                Globals.ShouldShowNumberOfChoices = ShouldShowNumberOfChoices;
            }
        }

        public static AdventureFile CreateAdventureFile(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            var json = File.ReadAllText(filePath);

            string[] sections = json.Split(new string[] { "--SECTION--" }, StringSplitOptions.None);

            AdventureFile file = JsonConvert.DeserializeObject<AdventureFile>(sections[0]);

            var promptList = JsonConvert.DeserializeObject<List<Prompt>>(sections[1]);

            var randomEventPoolList = JsonConvert.DeserializeObject<List<RandomEventPool>>(sections[2]);
            
            file.SetRandomEventPool(randomEventPoolList);
            file.SetPrompts(promptList);

            return file;
        }

        public Prompt GetPromptById(string id)
        {
            foreach (var p in _prompts)
            {
                if (p.GetId() == id)
                {
                    return p;
                }
            }

            return null;
        }
        
        public RandomEventPool GetRandomEventPoolById(string id)
        {
            foreach (var p in _randomEventPools)
            {
                if (p.GetEventPoolId() == id)
                {
                    return p;
                }
            }

            return null;
        }
        
        
        // Getters
        public string GetName()
        {
            return _name;
        }

        public void SetPrompts(List<Prompt> prompts)
        {
            if (_prompts == null)
                _prompts = prompts;
        }

        public void SetRandomEventPool(List<RandomEventPool> pools)
        {
            if (_randomEventPools == null)
                _randomEventPools = pools;
        }

        
        public List<Prompt> GetPrompts()
        {
            return _prompts;
        }
        
        public string GetAuthor()
        {
            return _author;
        }
        public string GetVersion()
        {
            return _version;
        }
        public bool GetMultiplayerEnabled()
        {
            return _multiplayerEnabled;
        }
    }
}