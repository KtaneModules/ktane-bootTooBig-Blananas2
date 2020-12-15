using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class bootTooBigScript : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable[] Buttons;

    //Logging
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    private string[][] Groups = new string[132][] {
        new string[85]{"Air Traffic Controller", "Alphabetical Order", "Antichamber", "Atbash Cipher", "Bamboozling Time Keeper", "Black Cipher", "Blue Cipher", "Busy Beaver", "Button Masher", "Button Messer", "Button Order", "Caesar Cipher", "Calendar", "Color Generator", "D-CIPHER", "Digital Cipher", "Double Color", "Dr. Doctor", "Dreamcipher", "Filibuster", "Follow the Leader", "Forget Any Color", "Forget Me Later", "Frankenstein’s Indicator", "Gadgetron Vendor", "Gatekeeper", "Gray Cipher", "Green Cipher", "Higher Or Lower", "Indigo Cipher", "Loopover", "Maze Scrambler", "Mechanus Cipher", "Melody Sequencer", "Meter", "Microcontroller", "Minecraft Cipher", "Mineseeker", "Minesweeper", "Modern Cipher", "Murder", "Name Changer", "OmegaDestroyer", "Orange Cipher", "Password Destroyer", "Password Generator", "Pixel Cipher", "Playfair Cipher", "Point of Order", "Poker", "Popufur", "Prime Checker", "Quaver", "Radiator", "Random Number Generator", "Red Cipher", "Repo Selector", "Roger", "Snooker", "Standard Button Masher", "Street Fighter", "Ternary Converter", "The Bioscanner", "The Calculator", "The Dealmaker", "The Fidget Spinner", "The Hangover", "The Kanye Encounter", "The Missing Letter", "The Number", "The Number Cipher", "The Time Keeper", "The Wire", "Totally Accurate Minecraft Simulator", "Type Racer", "Typing Tutor", "Ultimate Cipher", "Unfair Cipher", "Unown Cipher", "Video Poker", "Vigenère Cipher", "Violet Cipher", "White Cipher", "Wonder Cipher", "Yellow Cipher"},
        new string[56]{"% Gary", "Alchemy", "Astrology", "Badugi", "Binary", "Binary Tree", "Blind Alley", "Bone Apple Tea", "Broken Binary", "Broken Karaoke", "Colorful Insanity", "Cruel Binary", "Cryptography", "Deaf Alley", "Digisibility", "Dragon Energy", "Faulty Binary", "Flash Memory", "Forget Infinity", "Four-Card Monte", "Gettin’ Funky", "Graphic Memory", "Heraldry", "Horrible Memory", "Hyperneedy", "Jackbox.TV", "Kanji", "Keypad Directionality", "Ladder Lottery", "Laundry", "Mad Memory", "Mazery", "Melody Memory", "Memory", "Minecraft Parody", "Modules Against Humanity", "Negativity", "Not Memory", "Old Fogey", "Pictionary", "Poetry", "Purgatory", "Random Access Memory", "Rune Match III", "Shape Memory", "Spelling Bee", "SYNC-125 [3]", "Telepathy", "Toolneedy", "Topsy Turvy", "Turn The Key", "V", "Vexillology", "Wire Spaghetti", "Yahtzee", "Zoni"},
        new string[55]{"7", "❖", "Accumulation", "Addition", "Ars Goetia Identification", "Art Appreciation", "Bamboozling Button", "Boozleglyph Identification", "Color Addition", "Color-Cycle Button", "Creation", "Dictation", "Dimension Disruption", "Directional Button", "Dungeon", "Echolocation", "Emotiguy Identification", "Encrypted Hangman", "Flag Identification", "Gradually Watermelon", "Hereditary Base Notation", "LED Encryption", "Life Iteration", "Masher The Bottun", "Mislocation", "Modulus Manipulation", "Morse Identification", "Musher The Batten", "Musical Transposition", "Needlessly Complicated Button", "Negation", "Neutralization", "Not the Button", "Organization", "Pickup Identification", "Plant Identification", "Prime Encryption", "Rapid Subtraction", "Reaction", "Reverse Polish Notation", "Silenced Simon", "Silo Authorization", "Square Button", "State of Aggregation", "Synchronization", "The Button", "The Close Button", "The Hexabutton", "The Pentabutton", "The Plunger Button", "The Triangle Button", "The Very Annoying Button", "The World’s Largest Button", "Time Accumulation", "Validation"},
        new string[38]{"Alphabetical Ruling", "Bad Wording", "Bartending", "Boxing", "Chinese Counting", "Color Decoding", "Commuting", "Cooking", "Deck Creating", "Digit String", "Don’t Touch Anything", "Double Listening", "Factoring", "Faulty Chinese Counting", "Fencing", "Forget Everything", "Free Parking", "Grid Matching", "Hunting", "Keep Clicking", "Listening", "Literally Crying", "Literally Nothing", "Module Listening", "Painting", "Plumbing", "Probing", "Railway Cargo Loading", "Red Herring", "ReGret-B Filtering", "Robot Programming", "RPS Judging", "Scripting", "Sorting", "Symbolic Colouring", "Timing is Everything", "Wavetapping", "Wire Ordering"},
        new string[37]{"Adjacent Letters", "Alien Filing Colors", "Alphabet Numbers", "Blockbusters", "Boolean Wires", "Color Numbers", "Complicated Wires", "Connected Monitors", "Corners", "Divisible Numbers", "Dumb Waiters", "Following Orders", "Forget The Colors", "Funny Numbers", "Graffiti Numbers", "Hidden Colors", "Hyperactive Numbers", "Just Numbers", "Lasers", "Letter Layers", "Logical Operators", "Lying Indicators", "Manometers", "Natures", "Not Complicated Wires", "Numbers", "Perplexing Wires", "Resistors", "Risky Wires", "Seven Wires", "Skinny Wires", "Snakes and Ladders", "Thinking Wires", "Time Signatures", "Towers", "Vectors", "Wires"},
        new string[34]{"100 Levels of Defusal", "Affine Cycle", "Big Circle", "Binary Puzzle", "Boggle", "Bomb Diffusal", "Caesar Cycle", "Cryptic Cycle", "European Travel", "Game of Life Simple", "Gnomish Puzzle", "Hex To Decimal", "Hill Cycle", "Jumble Cycle", "Light Cycle", "Marble Tumble", "Mastermind Simple", "Minecraft Survival", "Periodic Table", "Pigpen Cycle", "Playfair Cycle", "Qwirkle", "Reformed Role Reversal", "Role Reversal", "Security Council", "Symbol Cycle", "The Crafting Table", "The Legendre Symbol", "The Triangle", "Thread the Needle", "Tribal Council", "Ultimate Cycle", "Word Scramble", "Working Title"},
        new string[33]{"101 Dalmatians", "A-maze-ing Buttons", "Answering Questions", "Bitwise Operations", "Broken Buttons", "Chord Progressions", "Colored Buttons", "Colored Hexabuttons", "Complicated Buttons", "Conditional Buttons", "Constellations", "Daylight Directions", "Diophantine Equations", "Encrypted Equations", "Equations", "Functions", "Gryphons", "Instructions", "Keypad Combinations", "Logical Buttons", "Malfunctions", "Memorable Buttons", "Morse Buttons", "Numbered Buttons", "Partitions", "Pigpen Rotations", "Quaternions", "Rapid Buttons", "Regular Hexpressions", "Simon Simons", "Spinning Buttons", "Triangle Buttons", "Two Persuasive Buttons"},
        new string[30]{"1D Maze", "3D Maze", "ASCII Maze", "Birthdays", "Blind Maze", "Boolean Maze", "Catchphrase", "Cruel Boolean Maze", "DACH Maze", "Factory Maze", "Faulty RGB Maze", "Faulty Seven Segment Displays", "Hexamaze", "Lockpick Maze", "Maze", "Module Maze", "Morse-A-Maze", "Mouse In The Maze", "Mystic Maze", "Not Maze", "Not Simaze", "Polyhedral Maze", "RGB Maze", "Shifted Maze", "Shifting Maze", "Subways", "Switching Maze", "The Colored Maze", "The Crystal Maze", "USA Maze"},
        new string[19]{"Bordered Keys", "Chord Qualities", "Colored Keys", "Cruel Piano Keys", "Disordered Keys", "English Entries", "Festive Piano Keys", "Increasing Indices", "Integer Trees", "Letter Keys", "Misordered Keys", "Ordered Keys", "Piano Keys", "Recorded Keys", "Reordered Keys", "Striped Keys", "Tallordered Keys", "Turn The Keys", "Unordered Keys"},
        new string[17]{"0", "Accelerando", "Cursed Double-Oh", "DetoNATO", "Double-Oh", "Encryption Bingo", "Faulty Accelerando", "Hot Potato", "Marco Polo", "Modulo", "Needy Piano", "Rullo", "The Overflow", "The Radio", "Tic Tac Toe", "Ultimate Tic Tac Toe", "Yes and No"},
        new string[16]{"Annoying Arrows", "Blind Arrows", "Blue Arrows", "Dominoes", "Double Arrows", "Green Arrows", "LEGOs", "Neutrinos", "Object Shows", "Orange Arrows", "Purple Arrows", "Rainbow Arrows", "Red Arrows", "Teal Arrows", "White Arrows", "Yellow Arrows"},
        new string[15]{"3D Tunnels", "Colorful Dials", "Digital Dials", "Intervals", "Iñupiaq Numerals", "Quintuples", "Raiding Temples", "Roman Numerals", "Scalar Dials", "Semabols", "Signals", "Simon Samples", "Simon Scrambles", "Sonic & Knuckles", "The Dials"},
        new string[15]{"Abstract Sequences", "Alliances", "Bases", "Bridges", "Colored Switches", "Eight Pages", "Multicolored Switches", "Recolored Switches", "RGB Sequences", "Sequences", "Simon Stages", "Simon’s Stages", "Stock Images", "Switches", "Uncolored Switches"},
        new string[15]{"42", "Baba Is Who?", "Blue", "Color One Two", "Guess Who?", "Kudosudoku", "Kyudoku", "Masyu", "Mega Man 2", "osu!", "Rune Match II", "Shikaku", "The Hidden Value", "The Screw", "Zoo"},
        new string[13]{"Assembly Code", "Colour Code", "D-CODE", "Lines of Code", "More Code", "Morse Code", "Not Morse Code", "QR Code", "Tap Code", "Ten-Button Color Code", "The Code", "Unicode", "Who’s That Monsplode?"},
        new string[12]{"Arrow Talk", "BoozleTalk", "Colo(u)r Talk", "Crazy Talk", "Insane Talk", "Jaden Smith Talk", "KayMazey Talk", "Kilo Talk", "Krazy Talk", "Placeholder Talk", "Regular Crazy Talk", "Standard Crazy Talk"},
        new string[11]{"Arithmelogic", "Cosmic", "Iconic", "Logic", "Module Rick", "Quick Arithmetic", "RGB Arithmetic", "RGB Logic", "Superlogic", "Ultralogic", "Weird Al Yankovic"},
        new string[10]{"Combination Lock", "Digital Clock", "Gridlock", "Keypad Lock", "Mindlock", "Pattern Lock", "Rock-Paper-Scissors-Lizard-Spock", "Rubik’s Clock", "The Block", "The Clock"},
        new string[9]{"Boolean Keypad", "Complex Keypad", "Keypad", "Kooky Keypad", "Not Keypad", "Number Pad", "Round Keypad", "Saimoe Pad", "The Gamepad"},
        new string[9]{"% Grey", "aa", "Crazy Talk With A K", "IPA", "Know Your Way", "Look and Say", "ReGrettaBle Relay", "Taco Tuesday", "X-Ray"},
        new string[9]{"Button Sequence", "Co-op Harmony Sequence", "Genetic Sequence", "Harmony Sequence", "Maintenance", "Not Wire Sequence", "Simon’s Sequence", "Spot the Difference", "Wire Sequence"},
        new string[9]{"Colored Squares", "Decolored Squares", "Discolored Squares", "Divided Squares", "Juxtacolored Squares", "Misery Squares", "Rotating Squares", "Uncolored Squares", "Varicolored Squares"},
        new string[8]{"Burnout", "Cheap Checkout", "Cheat Checkout", "Cheep Checkout", "Lights Out", "Odd Mod Out", "Odd One Out", "Whiteout"},
        new string[8]{"Calculus", "Colorful Madness", "Greek Calculus", "Identifying Soulless", "Number Nimbleness", "Outrageous", "Table Madness", "The Witness"},
        new string[8]{"Cryptic Password", "Elder Password", "Extended Password", "Not Password", "Not Wiresword", "Password", "Puzzword", "Symbolic Password"},
        new string[8]{"64", "Dungeon 2nd Floor", "Entry Number Four", "Grocery Store", "Morse War", "Semaphore", "Seven Choose Four", "The High Score"},
        new string[8]{"21", "501", "Answering Can Be Fun", "Hole In One", "Rune Match I", "The Simpleton", "The Sun", "X01"},
        new string[7]{"Color Math", "Emoji Math", "Fast Math", "LED Math", "Math", "Mental Math", "Remote Math"},
        new string[7]{"Algebra", "Alpha", "Etterna", "Forget Enigma", "Jenga", "Symbolic Tasha", "The Arena"},
        new string[7]{"3x3 Grid", "Bamboozling Button Grid", "Binary Grid", "Button Grid", "Digital Grid", "Greek Letter Grid", "LED Grid"},
        new string[7]{"Brown Bricks", "Hieroglyphics", "Mashematics", "Matchematics", "Mazematics", "Morsematics", "The Matrix"},
        new string[7]{"BuzzFizz", "Chalices", "Hinges", "Human Resources", "Matrices", "Simon Stashes", "Terraria Quiz"},
        new string[7]{"Audio Morse", "Basic Morse", "Color Morse", "Encrypted Morse", "Reverse Morse", "Semamorse", "Transmitted Morse"},
        new string[7]{"Another Keypad Module", "Game of Life Cruel", "Mastermind Cruel", "Mystery Module", "The cRule", "The Rule", "Übermodule"},
        new string[6]{"ASCII Art", "Cruel Garfield Kart", "Garfield Kart", "Pixel Art", "Roman Art", "The Heart"},
        new string[6]{"Orientation Cube", "Pattern Cube", "Rubik’s Cube", "The Cube", "The Hypercube", "The Ultracube"},
        new string[5]{"Anagrams", "Insanagrams", "Tangrams", "Unrelated Anagrams", "Venn Diagrams"},
        new string[5]{"Benedict Cumberbatch", "Color Match", "Colour Catch", "Flower Patch", "The Stopwatch"},
        new string[5]{"Forget It Not", "Forget Me Not", "Forget Us Not", "NOT NOT", "Turtle Robot"},
        new string[5]{"Cruel Match ’em", "Curriculum", "Match ’em", "Metamem", "Stack’em"},
        new string[5]{"Logic Statement", "Retirement", "Visual Impairment", "Waste Management", "Wire Placement"},
        new string[5]{"Christmas Presents", "Currents", "Determinants", "Ingredients", "Module Movements"},
        new string[5]{"Equations X", "Flavor Text EX", "Press X", "Reflex", "TetraVex"},
        new string[5]{"Bamboozled Again", "Beanboozled Again", "SixTen", "Tell Me When", "The Exploding Pen"},
        new string[5]{"Lion’s Share", "Mystic Square", "Safety Square", "Symmetries Of A Square", "The Stare"},
        new string[5]{"Chess", "hexOS", "Lousy Chess", "Shoddy Chess", "Vcrcs"},
        new string[5]{"1000 Words", "Baybayin Words", "Five Letter Words", "Keywords", "T-Words"},
        new string[5]{"Beans", "Cool Beans", "Jellybeans", "Long Beans", "Rotten Beans"},
        new string[5]{"Plug-Ins", "Seven Deadly Sins", "Simon Spins", "Tenpins", "Widdershins"},
        new string[5]{"Alpha-Bits", "Coordinates", "Kugelblitz", "Symbolic Coordinates", "Two Bits"},
        new string[4]{"Blackjack", "Chinese Zodiac", "Jack Attack", "Snack Attack"},
        new string[4]{"Colour Flash", "Geometry Dash", "int##", "Needy Flower Mash"},
        new string[4]{"Breaktime", "Lunchtime", "Party Time", "Prime Time"},
        new string[4]{"Connection Device", "Encrypted Dice", "Lucky Dice", "Naughty or Nice"},
        new string[4]{"Left and Right", "Monsplode, Fight!", "Red Light Green Light", "Ultimate Custom Night"},
        new string[4]{"Alphabetize", "Butterflies", "Faulty Butterflies", "Reverse Alphabetize"},
        new string[4]{"Bloxx", "Crackbox", "The Festive Jukebox", "The Jukebox"},
        new string[4]{"Lights On", "Siffron", "The Necronomicon", "The Swan"},
        new string[4]{"Cookie Jars", "Cruel Stars", "Spangled Stars", "Stars"},
        new string[4]{"Adventure Game", "Goofy’s Game", "Kim’s Game", "Shell Game"},
        new string[4]{"Brawler Database", "Pixel Number Base", "Space", "Third Base"},
        new string[4]{"Cruel Ten Seconds", "Ten Seconds", "Tetriamonds", "Triamonds"},
        new string[4]{"14", "B-Machine", "Double Screen", "Fifteen"},
        new string[4]{"Faulty Sink", "Sink", "The Giant’s Drink", "The Hyperlink"},
        new string[4]{"Shuffled Strings", "Simon Sings", "The Deck of Many Things", "Wingdings"},
        new string[4]{"Bottom Gear", "Refill that Beer!", "Souvenir", "The Sphere"},
        new string[4]{"Black Hole", "Passport Control", "The Console", "The Troll"},
        new string[4]{"Microphone", "Rotary Phone", "The iPhone", "Timezone"},
        new string[4]{"9-Ball", "Forget Them All", "One Links To All", "Sueet Wall"},
        new string[4]{"Cruel Digital Root", "Digital Root", "Faulty Digital Root", "Splitting The Loot"},
        new string[3]{"Not Venting Gas", "Stained Glass", "Venting Gas"},
        new string[3]{"Nomai", "Pie", "Subscribe to Pewdiepie"},
        new string[3]{"15 Mystic Lights", "Flashing Lights", "Four Lights"},
        new string[3]{"Countdown", "Cruel Countdown", "Simon’s Ultimate Showdown"},
        new string[3]{"Backgrounds", "Faulty Backgrounds", "Simon Sounds"},
        new string[3]{"Knob", "Needy Mrs Bob", "Not Knob"},
        new string[3]{"...?", "Elder Futhark", "Question Mark"},
        new string[3]{"Foreign Exchange Rates", "Logic Gates", "Simon States"},
        new string[3]{"A Message", "Melodic Message", "Wolf, Goat, and Cabbage"},
        new string[3]{"Chicken Nuggets", "Exoplanets", "Planets"},
        new string[3]{"Common Sense", "Lyrical Nonsense", "Motion Sense"},
        new string[3]{"Alphabet", "OmegaForget", "S.E.T."},
        new string[3]{"Shitass Says", "Simon Literally Says", "Simon Says"},
        new string[3]{"Edgework", "Module Homework", "Reversed Edgework"},
        new string[3]{"Not Who’s on First", "Simon’s On First", "Who’s on First"},
        new string[3]{"Battleship", "Censorship", "Friendship"},
        new string[3]{"Forget This", "Tennis", "Tetris"},
        new string[3]{"The Digit", "The Modkit", "The Stock Market"},
        new string[3]{"Character Codes", "Error Codes", "Passcodes"},
        new string[2]{"Flags", "Maritime Flags"},
        new string[2]{"Block Stacks", "Sea Bear Attacks"},
        new string[2]{"Boolean Venn Diagram", "Nonogram"},
        new string[2]{"British Slang", "NumberWang"},
        new string[2]{"Needy Game of Life", "Wack Game of Life"},
        new string[2]{"Alphabet Tiles", "Ternary Tiles"},
        new string[2]{"Sound Design", "Web Design"},
        new string[2]{"Forget Me Now", "Pow"},
        new string[2]{"Earthbound", "The London Underground"},
        new string[2]{"Even Or Odd", "SimpSquad"},
        new string[2]{"Color Hexagons", "Polygons"},
        new string[2]{"Monsplode Trading Cards", "Zener Cards"},
        new string[2]{"Capacitor Discharge", "Not Capacitor Discharge"},
        new string[2]{"Burger Alarm", "Burglar Alarm"},
        new string[2]{"Silly Slots", "Skewed Slots"},
        new string[2]{"A Mistake", "Jailbreak"},
        new string[2]{"Braille", "Color Braille"},
        new string[2]{"3 LEDs", "Binary LEDs"},
        new string[2]{"Devilish Eggs", "Perspective Pegs"},
        new string[2]{"Flavor Text", "Training Text"},
        new string[2]{"Font Select", "Only Connect"},
        new string[2]{"Pay Respects", "Simon Selects"},
        new string[2]{"M&Ms", "N&Ms"},
        new string[2]{"Unfair’s Cruel Revenge", "Unfair’s Revenge"},
        new string[2]{"M&Ns", "N&Ns"},
        new string[2]{"English Test", "Rhythm Test"},
        new string[2]{"Silhouettes", "Simon Forgets"},
        new string[2]{"IKEA", "Mafia"},
        new string[2]{"Simon Shrieks", "Simon Speaks"},
        new string[2]{"Ice Cream", "Space Invaders Extreme"},
        new string[2]{"Amnesia", "Synesthesia"},
        new string[2]{"Character Shift", "Shape Shift"},
        new string[2]{"Double Pitch", "The Switch"},
        new string[2]{"Brush Strokes", "Chinese Strokes"},
        new string[2]{"Footnotes", "Sticky Notes"},
        new string[2]{"Mahjong", "Pong"},
        new string[2]{"Broken Guitar Chords", "Guitar Chords"},
        new string[2]{"Simon Stores", "UltraStores"},
        new string[2]{"Micro-Modules", "Rules"},
        new string[2]{"The Cruel Duck", "The Duck"},
        new string[2]{"Scavenger Hunt", "Treasure Hunt"},
        new string[2]{"NeeDeez Nuts", "Shortcuts"},
        new string[2]{"FizzBuzz", "Quiz Buzz"}//, ADD EXTRA NO RHYME GROUP
    };
    int chosenGroup = -1;
    private List<string> chosenModules = new List<string> { };
    string secondModule = "";
    private List<int> groupsUsed = new List<int> { };
    int randomGroup = -1;

    void Awake () {
        moduleId = moduleIdCounter++;
        foreach (KMSelectable button in Buttons) {
            button.OnInteract += delegate () { ButtonPress(button); return false; };
        }
    }

    // Use this for initialization
    void Start () {
        chosenGroup = UnityEngine.Random.Range(0,132);
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
            randomGroup = UnityEngine.Random.Range(0,132);
            for (int j = 0; j < groupsUsed.Count(); j++) {
                if (randomGroup == groupsUsed[j]) {
                    goto TryADifferentGroup;
                }
            }
            chosenModules.Add(Groups[randomGroup][UnityEngine.Random.Range(0,Groups[randomGroup].Count())]);
        }

        Debug.Log(chosenModules[0] + " | " + chosenModules[1]);
    }

    void ButtonPress(KMSelectable button) {
        for (int l = 0; l < 8; l++) {
            if (button == Buttons[l]) {
                Debug.Log("eXish is " + l);
            }
        }
    }

}
