using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class bootTooBigScript : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable[] Buttons;
    public SpriteRenderer[] Icons;

    //Logging
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    private string[] AudioOrder = {"Wire Sequence", "Wires", "Who's on First", "Venting Gas", "Simon Says", "Password", "Morse Code", "Memory", "Maze", "Knob", "Keypad", "Complicated Wires", "Capacitor Discharge", "The Button", "Colour Flash", "Piano Keys", "Semaphore", "Math", "Emoji Math", "Lights Out", "Switches", "Two Bits", "Word Scramble", "Anagrams", "Combination Lock", "Filibuster", "Motion Sense", "Round Keypad", "Listening", "Foreign Exchange Rates", "Answering Questions", "Orientation Cube", "Morsematics", "Connection Check", "Letter Keys", "Forget Me Not", "Rotary Phone", "Astrology", "Logic", "Mystic Square", "Crazy Talk", "Adventure Game", "Turn The Key", "Plumbing", "Cruel Piano Keys", "Safety Safe", "Tetris", "Cryptography", "Chess", "Turn The Keys", "Mouse In The Maze", "3D Maze", "Silly Slots", "Simon States", "Number Pad", "Laundry", "Probing", "Alphabet", "Caesar Cipher", "Resistors", "Skewed Slots", "Perspective Pegs", "Microcontroller", "Murder", "The Gamepad", "Tic Tac Toe", "Who's That Monsplode?", "Monsplode, Fight!", "Shape Shift", "Follow the Leader", "Friendship", "The Bulb", "Blind Alley", "Sea Shells", "English Test", "Rock-Paper-Scissors-Lizard-Spock", "Square Button", "Hexamaze", "Bitmaps", "Colored Squares", "Adjacent Letters", "Third Base", "Souvenir", "Word Search", "Broken Buttons", "Simon Screams", "Modules Against Humanity", "Complicated Buttons", "Battleship", "Text Field", "Symbolic Password", "Wire Placement", "Double-Oh", "Cheap Checkout", "Coordinates", "Light Cycle", "HTTP Response", "Rhythms", "Color Math", "Only Connect", "Neutralization", "Web Design", "Chord Qualities", "Creation", "Rubik's Cube", "FizzBuzz", "The Clock", "LED Encryption", "Edgework", "Bitwise Operations", "Fast Math", "Minesweeper", "Zoo", "Binary LEDs", "Boolean Venn Diagram", "Point of Order", "Ice Cream", "Hex To Decimal", "The Screw", "Yahtzee", "X-Ray", "QR Code", "Button Masher", "Random Number Generator", "Color Morse", "Mastermind Simple", "Mastermind Cruel", "Gridlock", "Big Circle", "Morse-A-Maze", "Colored Switches", "Perplexing Wires", "Monsplode Trading Cards", "Game of Life Simple", "Game of Life Cruel", "Nonogram", "S.E.T.", "Refill that Beer!", "Painting", "Color Generator", "Shape Memory", "Symbol Cycle", "Hunting", "Extended Password", "Curriculum", "Braille", "Mafia", "Festive Piano Keys", "Flags", "Timezone", "Polyhedral Maze", "Symbolic Coordinates", "Poker", "Sonic the Hedgehog", "Poetry", "Button Sequence", "Algebra", "Visual Impairment", "The Jukebox", "Identity Parade", "Maintenance", "Blind Maze", "Backgrounds", "Mortal Kombat", "Mashematics", "Faulty Backgrounds", "Radiator", "Modern Cipher", "LED Grid", "Sink", "The iPhone", "The Swan", "Waste Management", "Human Resources", "Skyrim", "Burglar Alarm", "Press X", "European Travel", "Error Codes", "Rapid Buttons", "LEGOs", "Rubik's Clock", "Font Select", "The Stopwatch", "Pie", "The Wire", "The London Underground", "Logic Gates", "Forget Everything", "Grid Matching", "Color Decoding", "The Sun", "Playfair Cipher", "Tangrams", "The Number", "Cooking", "Superlogic", "The Moon", "The Cube", "Dr. Doctor", "Tax Returns", "The Jewel Vault", "Digital Root", "Graffiti Numbers", "Marble Tumble", "X01", "Logical Buttons", "The Code", "Tap Code", "Simon Sings", "Simon Sends", "Synonyms", "Greek Calculus", "Simon Shrieks", "Complex Keypad", "Subways", "Lasers", "Turtle Robot", "Guitar Chords", "Calendar", "USA Maze", "Binary Tree", "The Time Keeper", "Lightspeed", "Black Hole", "Simon's Star", "Morse War", "The Stock Market", "Mineseeker", "Maze Scrambler", "The Number Cipher", "Alphabet Numbers", "British Slang", "Double Color", "Maritime Flags", "Equations", "Determinants", "Pattern Cube", "Know Your Way", "Splitting The Loot", "Simon Samples", "Character Shift", "Uncolored Squares", "Dragon Energy", "Flashing Lights", "3D Tunnels", "Synchronization", "The Switch", "Reverse Morse", "Manometers", "Shikaku", "Wire Spaghetti", "Tennis", "Module Homework", "Benedict Cumberbatch", "Signals", "Horrible Memory", "Boggle", "Command Prompt", "Boolean Maze", "Sonic & Knuckles", "Quintuples", "The Sphere", "Coffeebucks", "Colorful Madness", "Bases", "Lion's Share", "Snooker", "Blackjack", "Party Time", "Accumulation", "The Plunger Button", "The Digit", "The Jack-O'-Lantern", "T-Words", "Divided Squares", "Connection Device", "Instructions", "Valves", "Encrypted Morse", "The Crystal Maze", "Cruel Countdown", "Countdown", "Catchphrase", "Blockbusters", "IKEA", "Retirement", "Periodic Table", "101 Dalmatians", "Schlag den Bomb", "Mahjong", "Kudosudoku", "The Radio", "Modulo", "Number Nimbleness", "Pay Respects", "Challenge & Contact", "The Triangle", "Sueet Wall", "Hot Potato", "Christmas Presents", "Hieroglyphics", "Functions", "Scripting", "Needy Mrs Bob", "Simon Spins", "Ten-Button Color Code", "Cursed Double-Oh", "Crackbox", "Street Fighter", "The Labyrinth", "Spinning Buttons", "Color Match", "The Festive Jukebox", "Skinny Wires", "The Hangover", "Factory Maze", "Binary Puzzle", "Broken Guitar Chords", "Regular Crazy Talk", "Hogwarts", "Dominoes", "Simon Speaks", "Discolored Squares", "Krazy Talk", "Numbers", "Flip The Coin", "Varicolored Squares", "Simon's Stages", "Free Parking", "Cookie Jars", "Alchemy", "Zoni", "Simon Squawks", "Unrelated Anagrams", "Mad Memory", "Bartending", "Question Mark", "Shapes And Bombs", "Flavor Text EX", "Flavor Text", "Decolored Squares", "Homophones", "DetoNATO", "Air Traffic Controller", "SYNC-125 [3]", "Westeros", "Morse Identification", "Pigpen Rotations", "LED Math", "Alphabetical Order", "Simon Sounds", "The Fidget Spinner", "Simon's Sequence", "Simon Scrambles", "Harmony Sequence", "Unfair Cipher", "Melody Sequencer", "Colorful Insanity", "Passport Control", "Left and Right", "Gadgetron Vendor", "Wingdings", "The Hexabutton", "The Plunger", "Genetic Sequence", "Micro-Modules", "Module Maze", "Elder Futhark", "Tasha Squeals", "Forget This", "Digital Cipher", "Subscribe to Pewdiepie", "Grocery Store", "Draw", "Burger Alarm", "Purgatory", "Mega Man 2", "Lombax Cubes", "The Stare", "Graphic Memory", "Quiz Buzz", "Wavetapping", "The Hypercube", "Speak English", "Stack'em", "Seven Wires", "Colored Keys", "The Troll", "Planets", "The Necronomicon", "Four-Card Monte", "aa", "The Giant's Drink", "Digit String", "Alpha", "Snap!", "Hidden Colors", "Colour Code", "Vexillology", "Brush Strokes", "Odd One Out", "The Triangle Button", "Mazematics", "Equations X", "Maze³", "Gryphons", "Arithmelogic", "Roman Art", "Faulty Sink", "Simon Stops", "Morse Buttons", "Terraria Quiz", "Baba Is Who?", "Triangle Buttons", "Simon Stores", "Risky Wires", "Modulus Manipulation", "Daylight Directions", "Cryptic Password", "Stained Glass", "The Block", "Bamboozling Button", "Insane Talk", "Transmitted Morse", "A Mistake", "Red Arrows", "Green Arrows", "Yellow Arrows", "Encrypted Values", "Encrypted Equations", "Forget Them All", "Ordered Keys", "Blue Arrows", "Sticky Notes", "Unordered Keys", "Orange Arrows", "Hyperactive Numbers", "Reordered Keys", "Button Grid", "Find The Date", "Misordered Keys", "The Matrix", "Purple Arrows", "Bordered Keys", "The Dealmaker", "Seven Deadly Sins", "The Ultracube", "Symbolic Colouring", "Recorded Keys", "The Deck of Many Things", "Disordered Keys", "Character Codes", "Raiding Temples", "Bomb Diffusal", "Tallordered Keys", "Pong", "Ten Seconds", "Cruel Ten Seconds", "Double Expert", "Calculus", "Boolean Keypad", "Toon Enough", "Pictionary", "Qwirkle", "Antichamber", "Simon Simons", "Lucky Dice", "Forget Enigma", "Constellations", "Prime Checker", "Cruel Digital Root", "Faulty Digital Root", "The Crafting Table", "Boot Too Big", "Vigenère Cipher", "Langton's Ant", "Old Fogey", "Insanagrams", "Treasure Hunt", "Snakes and Ladders", "Module Movements", "Bamboozled Again", "Safety Square", "Roman Numerals", "Colo(u)r Talk", "Annoying Arrows", "Double Arrows", "Boolean Wires", "Block Stacks", "Vectors", "Partial Derivatives", "Caesar Cycle", "Needy Piano", "Forget Us Not", "Affine Cycle", "Pigpen Cycle", "Flower Patch", "Playfair Cycle", "Jumble Cycle", "Organization", "Forget Perspective", "Alpha-Bits", "Jack Attack", "Ultimate Cycle", "Hill Cycle", "Binary", "Chord Progressions", "Matchematics", "Bob Barks", "Simon's On First", "Weird Al Yankovic", "Forget Me Now", "Simon Selects", "The Witness", "Simon Literally Says", "Cryptic Cycle", "Bone Apple Tea", "Robot Programming", "Masyu", "Hold Ups", "Red Cipher", "Flash Memory", "A-maze-ing Buttons", "Desert Bus", "Orange Cipher", "Common Sense", "The Very Annoying Button", "Unown Cipher", "Needy Flower Mash", "TetraVex", "Meter", "Timing is Everything", "The Modkit", "The Rule", "Fruits", "Bamboozling Button Grid", "Footnotes", "Lousy Chess", "Module Listening", "Garfield Kart", "Yellow Cipher", "Kooky Keypad", "Green Cipher", "RGB Maze", "Blue Cipher", "The Legendre Symbol", "Keypad Lock", "Forget Me Later", "Übermodule", "Heraldry", "Faulty RGB Maze", "Indigo Cipher", "Violet Cipher", "Encryption Bingo", "Color Addition", "Chinese Counting", "Tower of Hanoi", "Keypad Combinations", "UltraStores", "Kanji", "Geometry Dash", "Ternary Converter", "N&Ms", "Eight Pages", "The Colored Maze", "White Cipher", "Gray Cipher", "The Hyperlink", "Black Cipher", "Loopover", "Divisible Numbers", "Corners", "The High Score", "Ingredients", "Jenga", "Intervals", "Cruel Boolean Maze", "Cheep Checkout", "Spelling Bee", "Memorable Buttons", "Thinking Wires", "Seven Choose Four", "Object Shows", "Lunchtime", "Natures", "Neutrinos", "Scavenger Hunt", "Polygons", "Ultimate Cipher", "Codenames", "Odd Mod Out", "Logic Statement", "Blinkstop", "Ultimate Custom Night", "Hinges", "Time Accumulation", "❖", "Forget It Not", "egg", "BuzzFizz", "Answering Can Be Fun", "3x3 Grid", "15 Mystic Lights", "14", "Rainbow Arrows", "Time Signatures", "Multicolored Switches", "Digital Dials", "Passcodes", "Hereditary Base Notation", "Lines of Code", "The cRule", "Prime Encryption", "Encrypted Dice", "Colorful Dials", "Naughty or Nice", "Following Orders", "Binary Grid", "Matrices", "Cruel Keypads", "The Black Page", "64", "Simon Forgets"};
    private string[][] Groups = new string[][] {
        new string[]{"Boolean Keypad", "Complex Keypad", "Keypad", "Kooky Keypad", "Number Pad", "Round Keypad", "The Gamepad"}, 
        new string[]{"Flags", "Maritime Flags"}, 
        new string[]{"Blackjack", "Jack Attack"}, 
        new string[]{"Boolean Venn Diagram", "Nonogram"}, 
        new string[]{"Anagrams", "Insanagrams", "Tangrams", "Unrelated Anagrams"}, 
        new string[]{"Stained Glass", "Venting Gas"}, 
        new string[]{"Colour Flash", "Geometry Dash", "Needy Flower Mash"}, 
        new string[]{"Benedict Cumberbatch", "Color Match", "Flower Patch"}, 
        new string[]{"Color Math", "Emoji Math", "Fast Math", "LED Math", "Math"}, 
        new string[]{"Pie", "Subscribe to Pewdiepie"}, 
        new string[]{"Colorful Dials", "Digital Dials"}, 
        new string[]{"Boolean Wires", "Complicated Wires", "Perplexing Wires", "Risky Wires", "Seven Wires", "Skinny Wires", "Thinking Wires", "Wires"}, 
        new string[]{"Lunchtime", "Party Time"}, 
        new string[]{"Connection Device", "Encrypted Dice", "Lucky Dice", "Naughty or Nice"}, 
        new string[]{"Left and Right", "Monsplode, Fight!", "Ultimate Custom Night"}, 
        new string[]{"15 Mystic Lights", "Flashing Lights"}, 
        new string[]{"Countdown", "Cruel Countdown"}, 
        new string[]{"Backgrounds", "Faulty Backgrounds", "Simon Sounds"}, 
        new string[]{"Cheap Checkout", "Cheep Checkout", "Lights Out", "Odd Mod Out", "Odd One Out"}, 
        new string[]{"Knob", "Needy Mrs Bob"}, 
        new string[]{"Combination Lock", "Gridlock", "Keypad Lock", "Rock-Paper-Scissors-Lizard-Spock", "Rubik's Clock", "The Block", "The Clock"}, 
        new string[]{"Crackbox", "The Festive Jukebox", "The Jukebox"}, 
        new string[]{"The Necronomicon", "The Swan"}, 
        new string[]{"Elder Futhark", "Question Mark"}, 
        new string[]{"Burger Alarm", "Burglar Alarm"}, 
        new string[]{"Garfield Kart", "Roman Art"}, 
        new string[]{"Forget It Not", "Forget Me Not", "Forget Us Not", "Turtle Robot"}, 
        new string[]{"Silly Slots", "Skewed Slots"}, 
        new string[]{"aa", "Know Your Way", "X-Ray"}, 
        new string[]{"Foreign Exchange Rates", "Logic Gates", "Simon States"}, 
        new string[]{"3D Maze", "Blind Maze", "Boolean Maze", "Catchphrase", "Cruel Boolean Maze", "Factory Maze", "Faulty RGB Maze", "Hexamaze", "Maze", "Module Maze", "Morse-A-Maze", "Mouse In The Maze", "Polyhedral Maze", "RGB Maze", "Subways", "The Colored Maze", "The Crystal Maze", "USA Maze"}, 
        new string[]{"Algebra", "Alpha", "Forget Enigma"}, 
        new string[]{"Affine Cycle", "Big Circle", "Binary Puzzle", "Boggle", "Bomb Diffusal", "Caesar Cycle", "Cryptic Cycle", "European Travel", "Game of Life Simple", "Hex To Decimal", "Hill Cycle", "Jumble Cycle", "Light Cycle", "Marble Tumble", "Mastermind Simple", "Periodic Table", "Pigpen Cycle", "Playfair Cycle", "Qwirkle", "Symbol Cycle", "The Crafting Table", "The Legendre Symbol", "The Triangle", "Ultimate Cycle", "Word Scramble"}, 
        new string[]{"3D Tunnels", "Intervals", "Quintuples", "Raiding Temples", "Roman Numerals", "Signals", "Simon Samples", "Simon Scrambles", "Sonic & Knuckles"}, 
        new string[]{"❖", "Bamboozled Again", "Bamboozling Button", "Square Button", "The Button", "The Hexabutton", "The Plunger Button", "The Triangle Button", "The Very Annoying Button"}, 
        new string[]{"Cruel Ten Seconds", "Ten Seconds"}, 
        new string[]{"Button Sequence", "Genetic Sequence", "Harmony Sequence", "Maintenance", "Simon's Sequence", "Wire Sequence"}, 
        new string[]{"Logic Statement", "Retirement", "Visual Impairment", "Waste Management", "Wire Placement"}, 
        new string[]{"Christmas Presents", "Determinants", "Module Movements"}, 
        new string[]{"A-maze-ing Buttons", "Answering Questions", "Broken Buttons", "Complicated Buttons", "Gryphons", "Logical Buttons", "Memorable Buttons", "Morse Buttons", "Rapid Buttons", "Simon Simons", "Spinning Buttons", "Triangle Buttons"}, 
        new string[]{"Air Traffic Controller", "Alphabetical Order", "Antichamber", "Black Cipher", "Blue Cipher", "Button Masher", "Caesar Cipher", "Calendar", "Color Generator", "Digital Cipher", "Double Color", "Dr. Doctor", "Filibuster", "Follow the Leader", "Forget Me Later", "Gadgetron Vendor", "Gray Cipher", "Green Cipher", "Indigo Cipher", "Loopover", "Maze Scrambler", "Melody Sequencer", "Meter", "Microcontroller", "Mineseeker", "Minesweeper", "Modern Cipher", "Murder", "Orange Cipher", "Playfair Cipher", "Point of Order", "Poker", "Prime Checker", "Radiator", "Random Number Generator", "Red Cipher", "Snooker", "Street Fighter", "Ternary Converter", "The Dealmaker", "The Fidget Spinner", "The Hangover", "The Number", "The Number Cipher", "The Plunger", "The Time Keeper", "Ultimate Cipher", "Unfair Cipher", "Unown Cipher", "Vigenère Cipher", "Violet Cipher", "White Cipher", "Yellow Cipher"}, 
        new string[]{"Adjacent Letters", "Alphabet Numbers", "Blockbusters", "Corners", "Divisible Numbers", "Following Orders", "Graffiti Numbers", "Hidden Colors", "Hyperactive Numbers", "Lasers", "Manometers", "Natures", "Numbers", "Resistors", "Snakes and Ladders", "Time Signatures", "Vectors"}, 
        new string[]{"Calculus", "Colorful Madness", "Greek Calculus", "Number Nimbleness", "Tennis", "Tetris", "The Witness"}, 
        new string[]{"The Digit", "The Stock Market"}, 
        new string[]{"Coordinates", "Planets", "Symbolic Coordinates"}, 
        new string[]{"Bases", "Colored Switches", "Eight Pages", "Multicolored Switches", "Simon's Stages", "Switches"}, 
        new string[]{"Equations X", "Flavor Text EX", "Press X", "TetraVex"}, 
        new string[]{"Font Select", "Only Connect"}, 
        new string[]{"Pay Respects", "Simon Selects"}, 
        new string[]{"Common Sense", "Motion Sense"}, 
        new string[]{"Lion's Share", "Mystic Square", "Safety Square", "The Stare"}, 
        new string[]{"Colored Squares", "Decolored Squares", "Discolored Squares", "Divided Squares", "Uncolored Squares", "Varicolored Squares"}, 
        new string[]{"Chess", "Lousy Chess"}, 
        new string[]{"Alphabet", "S.E.T."}, 
        new string[]{"Simon Literally Says", "Simon Says"}, 
        new string[]{"Cryptic Password", "Extended Password", "Password", "Symbolic Password"}, 
        new string[]{"Edgework", "Module Homework"}, 
        new string[]{"Simon's On First", "Who's on First"}, 
        new string[]{"Alchemy", "Astrology", "Binary", "Binary Tree", "Blind Alley", "Bone Apple Tea", "Colorful Insanity", "Cryptography", "Dragon Energy", "Flash Memory", "Four-Card Monte", "Graphic Memory", "Heraldry", "Horrible Memory", "Kanji", "Laundry", "Mad Memory", "Memory", "Modules Against Humanity", "Old Fogey", "Pictionary", "Poetry", "Purgatory", "Shape Memory", "Spelling Bee", "SYNC-125 [3]", "Turn The Key", "Vexillology", "Wire Spaghetti", "Yahtzee", "Zoni"}, 
        new string[]{"IKEA", "Mafia"}, 
        new string[]{"Simon Shrieks", "Simon Speaks"}, 
        new string[]{"Binary LEDs", "Bordered Keys", "Chord Qualities", "Colored Keys", "Cruel Piano Keys", "Disordered Keys", "Festive Piano Keys", "Letter Keys", "Misordered Keys", "Ordered Keys", "Piano Keys", "Recorded Keys", "Reordered Keys", "Tallordered Keys", "Turn The Keys", "Unordered Keys"}, 
        new string[]{"3x3 Grid", "Bamboozling Button Grid", "Binary Grid", "Button Grid", "LED Grid"}, 
        new string[]{"Character Shift", "Shape Shift"}, 
        new string[]{"Arithmelogic", "Logic", "Superlogic", "Weird Al Yankovic"}, 
        new string[]{"Hieroglyphics", "Mashematics", "Matchematics", "Mazematics", "Morsematics", "The Matrix"}, 
        new string[]{"Seven Deadly Sins", "Simon Spins"}, 
        new string[]{"Bartending", "Chinese Counting", "Color Decoding", "Cooking", "Digit String", "Forget Everything", "Free Parking", "Grid Matching", "Hunting", "Listening", "Module Listening", "Painting", "Plumbing", "Probing", "Robot Programming", "Scripting", "Symbolic Colouring", "Timing is Everything", "Wavetapping"}, 
        new string[]{"Faulty Sink", "Sink", "The Giant's Drink", "The Hyperlink"}, 
        new string[]{"Simon Sings", "The Deck of Many Things", "Wingdings"}, 
        new string[]{"Battleship", "Friendship"}, 
        new string[]{"Refill that Beer!", "Souvenir", "The Sphere"}, 
        new string[]{"Alpha-Bits", "Two Bits"}, 
        new string[]{"BuzzFizz", "Hinges", "Human Resources", "Matrices", "Terraria Quiz"}, 
        new string[]{"Cursed Double-Oh", "DetoNATO", "Double-Oh", "Encryption Bingo", "Hot Potato", "Modulo", "Needy Piano", "The Radio", "Tic Tac Toe"}, 
        new string[]{"Colour Code", "Lines of Code", "Morse Code", "QR Code", "Tap Code", "Ten-Button Color Code", "The Code", "Who's That Monsplode?"}, 
        new string[]{"Character Codes", "Error Codes", "Passcodes"}, 
        new string[]{"Black Hole", "Passport Control", "The Troll"}, 
        new string[]{"Rotary Phone", "The iPhone", "Timezone"}, 
        new string[]{"Footnotes", "Sticky Notes"}, 
        new string[]{"Annoying Arrows", "Blue Arrows", "Dominoes", "Double Arrows", "Green Arrows", "LEGOs", "Neutrinos", "Object Shows", "Orange Arrows", "Purple Arrows", "Rainbow Arrows", "Red Arrows", "Yellow Arrows"}, 
        new string[]{"Colo(u)r Talk", "Crazy Talk", "Insane Talk", "Krazy Talk", "Regular Crazy Talk"}, 
        new string[]{"Forget Them All", "Sueet Wall"}, 
        new string[]{"Mahjong", "Pong"}, 
        new string[]{"64", "Grocery Store", "Morse War", "Semaphore", "Seven Choose Four", "The High Score"}, 
        new string[]{"Broken Guitar Chords", "Guitar Chords"}, 
        new string[]{"Color Morse", "Encrypted Morse", "Reverse Morse", "Transmitted Morse"}, 
        new string[]{"Simon Stores", "UltraStores"}, 
        new string[]{"Accumulation", "Color Addition", "Creation", "Hereditary Base Notation", "LED Encryption", "Modulus Manipulation", "Morse Identification", "Neutralization", "Organization", "Prime Encryption", "Synchronization", "Time Accumulation"}, 
        new string[]{"101 Dalmatians", "Bitwise Operations", "Chord Progressions", "Constellations", "Daylight Directions", "Functions", "Instructions", "Keypad Combinations", "Pigpen Rotations"}, 
        new string[]{"Baba Is Who?", "Kudosudoku", "Masyu", "Mega Man 2", "Shikaku", "The Screw", "Zoo"}, 
        new string[]{"Orientation Cube", "Pattern Cube", "Rubik's Cube", "The Cube", "The Hypercube", "The Ultracube"}, 
        new string[]{"Game of Life Cruel", "Mastermind Cruel", "The cRule", "The Rule", "Übermodule"}, 
        new string[]{"Cruel Digital Root", "Digital Root", "Faulty Digital Root", "Splitting The Loot"}, 
        new string[]{"Answering Can Be Fun", "The Sun", "X01"}, 
        new string[]{"Scavenger Hunt", "Treasure Hunt"}, 
        new string[]{"FizzBuzz", "Quiz Buzz"}, 
        new string[]{"Encrypted Equations", "Equations"}, 
        new string[]{"14", "A Mistake", "Adventure Game", "Bitmaps", "Blinkstop", "Block Stacks", "Bob Barks", "Boot Too Big", "Braille", "British Slang", "Brush Strokes", "Capacitor Discharge", "Challenge & Contact", "Codenames", "Coffeebucks", "Command Prompt", "Connection Check", "Cookie Jars", "Cruel Keypads", "Curriculum", "Desert Bus", "Double Expert", "Draw", "egg", "Encrypted Values", "English Test", "Find The Date", "Flavor Text", "Flip The Coin", "Forget Me Now", "Forget Perspective", "Forget This", "Fruits", "Hogwarts", "Hold Ups", "Homophones", "HTTP Response", "Ice Cream", "Identity Parade", "Ingredients", "Jenga", "Langton's Ant", "Lightspeed", "Lombax Cubes", "Maze³", "Micro-Modules", "Monsplode Trading Cards", "Mortal Kombat", "N&Ms", "Partial Derivatives", "Perspective Pegs", "Polygons", "Rhythms", "Safety Safe", "Schlag den Bomb", "Sea Shells", "Shapes And Bombs", "Simon Forgets", "Simon Screams", "Simon Sends", "Simon Squawks", "Simon Stops", "Simon's Star", "Skyrim", "Snap!", "Sonic the Hedgehog", "Speak English", "Stack'em", "Synonyms", "T-Words", "Tasha Squeals", "Tax Returns", "Text Field", "The Black Page", "The Bulb", "The Jack-O'-Lantern", "The Jewel Vault", "The Labyrinth", "The London Underground", "The Modkit", "The Moon", "The Stopwatch", "The Switch", "The Wire", "Third Base", "Toon Enough", "Tower of Hanoi", "Valves", "Web Design", "Westeros", "Word Search"}
    };
    int chosenGroup = -1;
    private List<string> chosenModules = new List<string> { };
    string secondModule = "";
    private List<int> groupsUsed = new List<int> { };
    int randomGroup = -1;
    private List<string> answers = new List<string> { };
    int presses = 0;
    string previous = "";

    void Awake () {
        moduleId = moduleIdCounter++;
        foreach (KMSelectable button in Buttons) {
            button.OnInteract += delegate () { ButtonPress(button); return false; };
        }
    }

    // Use this for initialization
    void Start () {
        chosenGroup = UnityEngine.Random.Range(0, Groups.Count()-1); //Don't do non-rhyme group at the bottom
        chosenModules.Add(Groups[chosenGroup][UnityEngine.Random.Range(0,Groups[chosenGroup].Count())]);
        TryADifferentOne:
        secondModule = Groups[chosenGroup][UnityEngine.Random.Range(0,Groups[chosenGroup].Count())];
        if (secondModule == chosenModules[0]) {
            goto TryADifferentOne;
        }
        chosenModules.Add(secondModule);
        groupsUsed.Add(chosenGroup);

        for (int i = 0; i < 6; i++) {
        TryADifferentGroup:
            randomGroup = UnityEngine.Random.Range(0, Groups.Count()); //non-rhymes are okay here
            for (int j = 0; j < groupsUsed.Count(); j++) {
                if (randomGroup == groupsUsed[j]) {
                    goto TryADifferentGroup;
                }
            }
            groupsUsed.Add(randomGroup);
            chosenModules.Add(Groups[randomGroup][UnityEngine.Random.Range(0,Groups[randomGroup].Count())]);
        }

        Debug.LogFormat("[Boot Too Big #{0}] Match: \"{1}\" and \"{2}\"", moduleId, chosenModules[0], chosenModules[1]);
        answers.Add(chosenModules[0]);
        answers.Add(chosenModules[1]);

        chosenModules.Shuffle();

        for (int k = 0; k < 8; k++) {
            Debug.LogFormat("[Boot Too Big #{0}] Icon #{1}: {2}", moduleId, k+1, chosenModules[k]);
        }

        StartCoroutine(ShowTheDamnIcons());
    }

    IEnumerator ShowTheDamnIcons() {
        if (!Application.isEditor)
            yield return new WaitUntil(() => BTBLoader.sprites != null);
        for (int i = 0; i < 8; i++) {
            if (!Application.isEditor)
                Icons[i].sprite = BTBLoader.sprites[Array.FindIndex(BTBLoader.sprites, s => s.name == WaitASec(chosenModules[i]))];
            else
                Icons[i].sprite = Resources.Load<Sprite>("Icons/" + WaitASec(chosenModules[i]));
        }
    }

    string WaitASec (string s) {
        switch (s) {
            case "Baba Is Who?": return "Baba Is Who";
            case "Who's That Monsplode?": return "Who's That Monsplode";
            default: return s;
        }
    }

    void ButtonPress(KMSelectable button) {
        for (int l = 0; l < 8; l++) {
            if (button == Buttons[l]) {
                Buttons[l].AddInteractionPunch(0.5f);
                Audio.PlaySoundAtTransform(SoundNum(chosenModules[l]), transform);
                if (!moduleSolved) {
                    Debug.LogFormat("[Boot Too Big #{0}] Pressed \"{1}\"", moduleId, chosenModules[l]);
                    if (presses % 2 == 0) {
                        previous = chosenModules[l];
                    } else {
                        if (previous == chosenModules[l]) {
                            GetComponent<KMBombModule>().HandleStrike();
                            Debug.LogFormat("[Boot Too Big #{0}] That is incorrect, strike!", moduleId);
                        } else {
                            if ((previous == answers[0] || previous == answers[1]) && (chosenModules[l] == answers[0] || chosenModules[l] == answers[1])) {
                                GetComponent<KMBombModule>().HandlePass();
                                moduleSolved = true;
                                Debug.LogFormat("[Boot Too Big #{0}] That is correct, module solved.", moduleId);
                                /*
                                //////////////////////
                                chosenGroup = -1;
                                chosenModules = new List<string> { };
                                secondModule = "";
                                groupsUsed = new List<int> { };
                                randomGroup = -1;
                                answers = new List<string> { };

                                Start();
                                */
                            } else {
                                GetComponent<KMBombModule>().HandleStrike();
                            }
                        }
                        previous = "";
                    }
                }
            }
        }
        presses += 1;
    }

    string SoundNum (string m) {
        for (int p = 0; p < AudioOrder.Count(); p++) {
            if (AudioOrder[p] == m) {
                if (p < 10) {
                    return "boot-0" + p.ToString();
                } else {
                    return "boot-" + p.ToString();
                }
            }
        }
        Debug.Log("Sound clip failed: " + m);
        return "";
    }

    //twitch plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} <pos1> <pos2> [Presses the buttons in the specified two positions] | Valid button positions are TL, TM, ML, MM, MR, BL, BM, and BR";
    #pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command)
    {
        if (!Application.isEditor)
            yield return new WaitUntil(() => BTBLoader.audioClips != null);
        string[] parameters = command.Split(' ');
        if (parameters.Length == 2)
        {
            string[] btnPos = { "TL", "TM", "ML", "MM", "MR", "BL", "BM", "BR" };
            for (int i = 0; i < 2; i++)
            {
                if (!btnPos.Contains(parameters[i].ToUpper()))
                {
                    yield return "sendtochaterror!f The specified position '" + parameters[i] + "' is invalid!";
                    yield break;
                }
            }
            yield return null;
            int index = Array.IndexOf(btnPos, parameters[0].ToUpper());
            Buttons[index].OnInteract();
            float wait = Application.isEditor ? Resources.Load<AudioClip>("Audio/" + SoundNum(chosenModules[index])).length : BTBLoader.audioClips[Array.FindIndex(BTBLoader.audioClips, s => s.name == SoundNum(chosenModules[index]))].length;
            yield return new WaitForSeconds(wait);
            index = Array.IndexOf(btnPos, parameters[1].ToUpper());
            Buttons[index].OnInteract();
        }
        else
            yield return "sendtochaterror I need exactly two buttons to press!";
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        if (!Application.isEditor)
            while (BTBLoader.audioClips == null) yield return true;
        if (previous != "")
        {
            if (answers[0] != previous && answers[1] != previous)
            {
                GetComponent<KMBombModule>().HandlePass();
                moduleSolved = true;
                yield break;
            }
            else if (answers[0] == previous)
            {
                Buttons[chosenModules.IndexOf(answers[1])].OnInteract();
                float wait = Application.isEditor ? Resources.Load<AudioClip>("Audio/" + SoundNum(answers[1])).length : BTBLoader.audioClips[Array.FindIndex(BTBLoader.audioClips, s => s.name == SoundNum(answers[1]))].length;
                yield return new WaitForSeconds(wait);
                yield break;
            }
            else
            {
                Buttons[chosenModules.IndexOf(answers[0])].OnInteract();
                float wait = Application.isEditor ? Resources.Load<AudioClip>("Audio/" + SoundNum(answers[0])).length : BTBLoader.audioClips[Array.FindIndex(BTBLoader.audioClips, s => s.name == SoundNum(answers[0]))].length;
                yield return new WaitForSeconds(wait);
                yield break;
            }
        }
        Buttons[chosenModules.IndexOf(answers[0])].OnInteract();
        float wait2 = Application.isEditor ? Resources.Load<AudioClip>("Audio/" + SoundNum(answers[0])).length : BTBLoader.audioClips[Array.FindIndex(BTBLoader.audioClips, s => s.name == SoundNum(answers[0]))].length;
        yield return new WaitForSeconds(wait2);
        Buttons[chosenModules.IndexOf(answers[1])].OnInteract();
        wait2 = Application.isEditor ? Resources.Load<AudioClip>("Audio/" + SoundNum(answers[1])).length : BTBLoader.audioClips[Array.FindIndex(BTBLoader.audioClips, s => s.name == SoundNum(answers[1]))].length;
        yield return new WaitForSeconds(wait2);
    }
}