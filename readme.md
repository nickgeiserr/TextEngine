# Adventure File Format

The format for the Adventure File is simple but powerful. It's designed to put
full creative control into your hands. The format is a simple JSON file with
simple attributes and lists that make TextEngine game creation easy.

The format is as follows.

## Top-Level Headers

The top level headers are not nested. They sit at the top level
of every .adventure file. They are as follows:

```json
"name":"Test Game",
"Author":"TextEngine Devs",
"version":"1.0.0",
"MultiplayerEnabled":false,
"MaxPlayers":2,
"ShouldShowChoicesDialoguePhrase": true,
"ShouldShowNumberOfChoices": true,
"StartingPOI":"TestPOI"
```

### Name
The name attribute is the name of the game. It is a string. It will be used 
everywhere that the engine requires the games name. It is required.

### Author
The author attribute is the name of the author of the game. It is a string. It
will be used everywhere that the engine requires the games author. It is
required.

### Version
The version attribute is the version of the game. It is a string. It will be
used everywhere that the engine requires the games version. It is required.

### MultiplayerEnabled
The MultiplayerEnabled attribute is a boolean that determines whether or not
the engine is going to enable certain multiplayer features. Multiplayer in TextEngine
is very simple and will be discussed later. It will **NOT** work if MultiplayerEnabled
is not set to true. It is required.

### MaxPlayers
The MaxPlayers attribute is the maximum number of players that can play the game in a 
single server instance. It is an integer. It is required.

### EnterChoicesDialoguePhrase
This is a optional string that will be displayed when the player is prompted to enter a
option.

### ShouldShowChoicesDialoguePhrase
This determines whether or not the engine will display the EnterChoicesDialoguePhrase
when the player is prompted to enter a option. It is a boolean. It is required.

### ShouldShowNumberOfChoices
This determines whether or not the engine will display the number of choices that the
player has when the player is prompted to enter a option. It is a boolean. It is required.

### StartingPOI
The StartingPOI attribute is the name of the POI that the player will start at
when the game is loaded. It is a string. It is required.

## Section 2 Prompts

The second section of the .adventure file is the prompts section. It is a list of 
prompts

### Prompt Object
```json
"id":"TestPrompt",
"text":"This is a test prompt",
"choices":[
    {
        "text":"Test Choice 1",
        "redirect":"TestPrompt2",
        "RandomEventPool":"TestEventPool"
    },
    {
        "text":"Test Choice 2",
        "redirect":"TestPrompt3",
        "RandomEventPool":"TestEventPool"
    }
]
```

#### Prompt ID
The Prompt ID is the unique identifier for the prompt. It is a string. It is required.

#### Prompt Text
The Prompt Text is the text that will be displayed to the player when the prompt is
displayed. It is a string. It is required.

#### Prompt Choices
The Prompt Choices is a list of choices that the player can make. It is a list of
choice objects. It is required.

##### Choice Object

###### Choice Text
The Choice Text is the text that will be displayed to the player when the choice is
displayed. It is a string. It is required.

###### Choice Redirect
The Choice Redirect is the ID of the prompt that the choice will redirect to when the
player selects the choice. It is a string. It is required.

###### Choice RandomEventPool
The Choice RandomEventPool is the ID of the RandomEventPool that will be used when the
player selects the choice. It is a string. It is required.

## Section 3 RandomEventPools

The third section of the .adventure file is the RandomEventPools section. It is a list of
RandomEventPools

### RandomEventPool Object
```json
"event_pool_id":"TestEventPool",
"events":[
    {
        "id":"TestEvent",
        "prompt_id":"testPrompt",
        "chance":20    
    }
]
```

#### RandomEventPool ID
The RandomEventPool ID is the unique identifier for the RandomEventPool. It is a string. It is required.

#### RandomEventPool Events
The RandomEventPool Events is a list of events that the RandomEventPool can trigger. It is a list of
event objects. It is required.

##### Event Object

###### Event ID
The Event ID is the unique identifier for the event. It is a string. It is required.

###### Event Prompt ID
The Event Prompt ID is the ID of the prompt that will be displayed when the event is triggered. It is a string. It is required.

###### Event Chance
The Event Chance is the chance that the event will be triggered. It is an integer. It is required.

