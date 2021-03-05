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
    public SpriteRenderer[] Icons;

    //Logging
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    private string[] AudioOrder = {"0", "7", "14", "21", "42", "64", "81", "501", "...?", "% Grey", "❖", "100 Levels of Defusal", "1000 Words", "101 Dalmatians", "15 Mystic Lights", "16 Coins", "1D Maze", "3 LEDs", "3D Maze", "3D Tunnels", "3x3 Grid", "9-Ball", "A Message", "A Mistake", "A-maze-ing Buttons", "A>N<D", "aa", "AAAAA", "Abstract Sequences", "Accelerando", "Access Codes", "Accumulation", "Addition", "Adjacent Letters", "Adventure Game", "Affine Cycle", "Air Traffic Controller", "Alchemy", "Algebra", "Alien Filing Colors", "Alliances", "Alpha", "Alpha-Bits", "Alphabet", "Alphabet Numbers", "Alphabet Tiles", "Alphabetical Order", "Alphabetical Ruling", "Alphabetize", "Amnesia", "Amusement Parks", "Anagrams", "Annoying Arrows", "Another Keypad Module", "Answering Can Be Fun", "Answering Questions", "Antichamber", "Arithmelogic", "Arrow Talk", "Ars Goetia Identification", "Art Appreciation", "ASCII Art", "ASCII Maze", "Assembly Code", "Astrological", "Astrology", "Atbash Cipher", "Audio Keypad", "Audio Morse", "B-Machine", "Baba Is Who?", "Baccarat", "Back Buttons", "Backgrounds", "Bad Wording", "Badugi", "Bamboozled Again", "Bamboozling Button", "Bamboozling Button Grid", "Bamboozling Time Keeper", "Bandboozled Again", "Bartending", "Bases", "Basic Morse", "Battleship", "Baybayin Words", "Bean Sprouts", "Beanboozled Again", "Beans", "Benedict Cumberbatch", "Big Bean", "Big Circle", "Binary", "Binary Grid", "Binary LEDs", "Binary Puzzle", "Binary Tree", "Birthdays", "Bitmaps", "Bitwise Operations", "Black Arrows", "Black Cipher", "Black Hole", "Blackjack", "Blind Alley", "Blind Arrows", "Blind Maze", "Blinkstop", "Block Stacks", "Blockbusters", "Bloxx", "Blue", "Blue Arrows", "Blue Cipher", "Bob Barks", "Boggle", "Bomb Corp. Filing", "Bomb Diffusal", "Bone Apple Tea", "Boob Tube", "Boolean Keypad", "Boolean Maze", "Boolean Venn Diagram", "Boolean Wires", "Boomdas", "Boot Too Big", "Boozleglyph Identification", "BoozleTalk", "Bordered Keys", "Bottom Gear", "Bowling", "Boxing", "Braille", "Brainf---", "Brawler Database", "Breaktime", "Bridge", "Bridges", "British Slang", "Broken Binary", "Broken Buttons", "Broken Guitar Chords", "Broken Karaoke", "Brown Bricks", "Brown Cipher", "Brush Strokes", "Burger Alarm", "Burglar Alarm", "Burnout", "Busy Beaver", "Butterflies", "Button Grid", "Button Masher", "Button Messer", "Button Order", "Button Sequence", "BuzzFizz", "Caesar Cipher", "Caesar Cycle", "Caesar's Maths", "Calculus", "Calendar", "Capacitor Discharge", "Catchphrase", "Cell Lab", "Censorship", "Chalices", "Challenge & Contact", "Chamber No. 5", "Character Codes", "Character Shift", "Cheap Checkout", "Cheat Checkout", "Cheep Checkout", "Chess", "Chicken Nuggets", "Chilli Beans", "Chinese Counting", "Chinese Strokes", "Chinese Zodiac", "Chord Progressions", "Chord Qualities", "Christmas Presents", "Cistercian Numbers", "Co-op Harmony Sequence", "Code Cracker", "Codenames", "Coffee Beans", "Coffeebucks", "Collapse", "Colo(u)r Talk", "Color Addition", "Color Braille", "Color Decoding", "Color Generator", "Color Hexagons", "Color Match", "Color Math", "Color Morse", "Color Numbers", "Color One Two", "Color Punch", "Color-Cycle Button", "Colored Buttons", "Colored Hexabuttons", "Colored Keys", "Colored Letters", "Colored Squares", "Colored Switches", "Colorful Dials", "Colorful Insanity", "Colorful Madness", "Colour Catch", "Colour Code", "Colour Flash", "Coloured Arrows", "Combination Lock", "Command Prompt", "Common Sense", "Commuting", "Complex Keypad", "Complexity", "Complicated Buttons", "Complicated Wires", "Conditional Buttons", "Connected Monitors", "Connection Check", "Connection Device", "Constellations", "Cookie Jars", "Cooking", "Cool Beans", "Coordinates", "Corners", "Corridors", "Cosmic", "Countdown", "Crackbox", "Crazy Speak", "Crazy Talk", "Crazy Talk With A K", "Creation", "Cruel Binary", "Cruel Boolean Maze", "Cruel Countdown", "Cruel Digital Root", "Cruel Garfield Kart", "Cruel Keypads", "Cruel Match 'em", "Cruel Piano Keys", "Cruel Stars", "Cruel Ten Seconds", "Cruello", "Cryptic Cycle", "Cryptic Password", "Cryptography", "Currents", "Curriculum", "Cursed Double-Oh", "D-CIPHER", "D-CODE", "D-CRYPT", "DACH Maze", "Daylight Directions", "Deaf Alley", "Decay", "Decimation", "Deck Creating", "Decolored Squares", "Desert Bus", "Determinants", "DetoNATO", "Devilish Eggs", "Dictation", "Diffusion", "Digisibility", "Digit String", "Digital Cipher", "Digital Clock", "Digital Dials", "Digital Grid", "Digital Root", "Dimension Disruption", "Diophantine Equations", "Directional Button", "Discolored Squares", "Disordered Keys", "Divided Squares", "Divisible Numbers", "DNA Mutation", "Dominoes", "Don't Touch Anything", "Double Arrows", "Double Color", "Double Expert", "Double Knob", "Double Listening", "Double Pitch", "Double Screen", "Double-Oh", "Dr. Doctor", "Dragon Energy", "Draw", "Dreamcipher", "Drive-In Window", "Duck, Duck, Goose", "Dumb Waiters", "Dungeon", "Dungeon 2nd Floor", "Earthbound", "Echolocation", "Edgework", "eeB gnillepS", "egg", "Eight Pages", "Elder Futhark", "Elder Password", "Emoji Math", "Emotiguy Identification", "Encrypted Dice", "Encrypted Equations", "Encrypted Hangman", "Encrypted Morse", "Encrypted Values", "Encryption Bingo", "English Entries", "English Test", "Entry Number Four", "Entry Number One", "Equations", "Equations X", "Error Codes", "Etch-A-Sketch", "Etterna", "European Travel", "Even Or Odd", "Exoplanets", "Extended Password", "Factoring", "Factory Maze", "Fake Beans", "Fast Math", "Faulty Accelerando", "Faulty Backgrounds", "Faulty Binary", "Faulty Butterflies", "Faulty Chinese Counting", "Faulty Digital Root", "Faulty RGB Maze", "Faulty Seven Segment Displays", "Faulty Sink", "Fencing", "Festive Piano Keys", "Fifteen", "Filibuster", "Find The Date", "Five Letter Words", "FizzBuzz", "Flag Identification", "Flags", "Flash Memory", "Flashing Arrows", "Flashing Lights", "Flavor Text", "Flavor Text EX", "Flip The Coin", "Floor Lights", "Flower Patch", "Follow the Leader", "Following Orders", "Font Select", "Footnotes", "Foreign Exchange Rates", "Forget Any Color", "Forget Enigma", "Forget Everything", "Forget Infinity", "Forget It Not", "Forget Maze Not", "Forget Me Later", "Forget Me Not", "Forget Me Now", "Forget Perspective", "Forget The Colors", "Forget Them All", "Forget This", "Forget Us Not", "Forget's Ultimate Showdown", "Four Lights", "Four-Card Monte", "Fractal Maze", "Frankenstein's Indicator", "Free Parking", "Free Password", "Friendship", "Fruits", "Functional Mapping", "Functions", "Funny Numbers", "Gadgetron Vendor", "Game of Life Cruel", "Game of Life Simple", "Garfield Kart", "Gatekeeper", "Genetic Sequence", "Geometry Dash", "Gettin' Funky", "Ghost Movement", "Gnomish Puzzle", "Going Backwards", "Golf", "Goofy's Game", "Gradually Watermelon", "Graffiti Numbers", "Graphic Memory", "Gray Cipher", "Greek Calculus", "Greek Letter Grid", "Green Arrows", "Green Cipher", "Grid Matching", "Gridlock", "Grocery Store", "Gryphons", "Guess Who?", "Guitar Chords", "h", "Harmony Sequence", "Hearthur", "Heraldry", "Hereditary Base Notation", "Hex To Decimal", "Hexamaze", "Hexiom", "hexOrbits", "hexOS", "Hidden Colors", "Hide and Seek", "Hieroglyphics", "Higher Or Lower", "Hill Cycle", "Hinges", "Hogwarts", "Hold On", "Hold Ups", "Hole in One", "Homophones", "Horrible Memory", "Hot Potato", "HTTP Response", "Human Resources", "Hunting", "Hyperactive Numbers", "Hyperneedy", "Ice Cream", "Icon Reveal", "Iconic", "Identifying Soulless", "Identity Parade", "IKEA", "Increasing Indices", "Indentation", "Indigo Cipher", "Ingredients", "Insanagrams", "Insane Talk", "Instructions", "int##", "Integer Trees", "Interpunct", "Intervals", "Iñupiaq Numerals", "IPA", "Jack Attack", "Jackbox.TV", "Jaden Smith Talk", "Jailbreak", "Jellybeans", "Jenga", "Johnson Solids", "Jukebox.WAV", "Jumble Cycle", "Just Numbers", "Juxtacolored Squares", "Kahoot!", "Kanji", "KayMazey Talk", "Keep Clicking", "Keypad", "Keypad Combinations", "Keypad Directionality", "Keypad Lock", "Keypad Magnified", "Keypad Maze", "Keywords", "Kidney Beans", "Kilo Talk", "Kim's Game", "Knob", "Know Your Way", "Kooky Keypad", "Krazy Talk", "Kudosudoku", "Kugelblitz", "Kyudoku", "Ladder Lottery", "Ladders", "Langton's Ant", "Large Free Password", "Large Password", "Lasers", "Laundry", "LED Encryption", "LED Grid", "LED Math", "Left and Right", "LEGOs", "Letter Grid", "Letter Keys", "Letter Layers", "Life Iteration", "Light Bulbs", "Light Cycle", "Lights On", "Lights Out", "Lightspeed", "Lines of Code", "Linq", "Lion's Share", "Listening", "Literally Crying", "Literally Nothing", "Literally Something", "Lockpick Maze", "Logic", "Logic Gates", "Logic Statement", "Logical Buttons", "Logical Operators", "Lombax Cubes", "Long Beans", "Look and Say", "Loopover", "Lousy Chess", "Lucky Dice", "Lunchtime", "Lying Indicators", "Lyrical Nonsense", "M&Ms", "M&Ns", "Mad Memory", "Mafia", "Mahjong", "Maintenance", "Malfunctions", "Manometers", "Marble Tumble", "Marco Polo", "Maritime Flags", "Mashematics", "Masher The Bottun", "Mastermind Cruel", "Mastermind Restricted", "Mastermind Simple", "Masyu", "Match 'em", "Matchematics", "Math", "Matrices", "Maze", "Maze Scrambler", "Maze³", "Mazematics", "Mazery", "Mechanus Cipher", "Mega Man 2", "Melodic Message", "Melody Sequencer", "Memorable Buttons", "Memory", "Mental Math", "Metamem", "Meter", "Micro-Modules", "Microcontroller", "Microphone", "Mii Identification", "Mindlock", "Minecraft Cipher", "Minecraft Parody", "Minecraft Survival", "Mineseeker", "Mineswapper", "Minesweeper", "Misery Squares", "Mislocation", "Misordered Keys", "Modern Cipher", "Module Homework", "Module Listening", "Module Maze", "Module Movements", "Module Rick", "Modules Against Humanity", "Modulo", "Modulus Manipulation", "Monsplode Trading Cards", "Monsplode, Fight!", "More Code", "Morse Buttons", "Morse Code", "Morse Identification", "Morse War", "Morse-A-Maze", "Morsematics", "Mortal Kombat", "Motion Sense", "Mouse In The Maze", "Multicolored Switches", "Multitask", "Murder", "Musher The Batten", "Musical Transposition", "Mystery Module", "Mystery Widget", "Mystic Maze", "Mystic Square", "N&Ms", "N&Ns", "Name Changer", "Name Codes", "Natures", "Naughty or Nice", "Navinums", "NeeDeez Nuts", "Needlessly Complicated Button", "Needy Flower Mash", "Needy Game of Life", "Needy Mrs Bob", "Needy Piano", "Negation", "Negativity", "Neutralization", "Neutrinos", "Newline", "Next In Line", "Nomai", "Nonogram", "Not Capacitor Discharge", "Not Complicated Wires", "Not Keypad", "Not Knob", "Not Maze", "Not Memory", "Not Morse Code", "NOT NOT", "Not Password", "Not Simaze", "Not the Button", "Not Timer", "Not Venting Gas", "Not Who's on First", "Not Wire Sequence", "Not Wiresword", "Number Nimbleness", "Number Pad", "Numbered Buttons", "Numbers", "NumberWang", "Numerical Knight Movement", "Object Shows", "Odd Mod Out", "Odd One Out", "Old Fogey", "OmegaDestroyer", "OmegaForget", "One Links To All", "One-Line", "Only Connect", "Orange Arrows", "Orange Cipher", "Ordered Keys", "Organization", "Orientation Cube", "osu!", "Outrageous", "Painting", "Palindromes", "Pandemonium Cipher", "Papa's Pizzeria", "Partial Derivatives", "Partitions", "Party Time", "Passcodes", "Passport Control", "Password", "Password Destroyer", "Password Generator", "Pattern Cube", "Pattern Lock", "Pay Respects", "Periodic Table", "Perplexing Wires", "Perspective Pegs", "Phosphorescence", "Piano Keys", "Pickup Identification", "Pictionary", "Pie", "Pigpen Cycle", "Pigpen Rotations", "Pitch Perfect", "Pixel Art", "Pixel Cipher", "Pixel Number Base", "Placeholder Talk", "Planets", "Plant Identification", "Playfair Cipher", "Playfair Cycle", "Plug-Ins", "Plumbing", "Pocket Planes", "Poetry", "Point of Order", "Poker", "Polygons", "Polyhedral Maze", "Polyrhythms", "Pong", "Popufur", "Pow", "Press The Shape", "Press X", "Prime Checker", "Prime Encryption", "Prime Time", "Probing", "Purgatory", "Purple Arrows", "Puzzword", "QR Code", "Quaternions", "Quaver", "Question Mark", "Quick Arithmetic", "Quick Time Events", "Quintuples", "Quiplash", "Quiz Buzz", "Quote Crazy Talk End Quote", "Qwirkle", "Radiator", "Raiding Temples", "Railway Cargo Loading", "Rainbow Arrows", "Ramboozled Again", "Random Number Generator", "Rapid Buttons", "Rapid Subtraction", "Reaction", "Rebooting M-OS", "Recolored Switches", "Recorded Keys", "Red", "Red Arrows", "Red Cipher", "Red Herring", "Red Light Green Light", "Refill that Beer!", "Reflex", "Reformed Role Reversal", "ReGret-B Filtering", "ReGrettaBle Relay", "Regular Crazy Talk", "Regular Hexpressions", "Regular Sudoku", "Remote Math", "Reordered Keys", "Repo Selector", "Resistors", "Retirement", "Reverse Alphabetize", "Reverse Morse", "Reverse Polish Notation", "Reversed Edgework", "RGB Arithmetic", "RGB Hypermaze", "RGB Logic", "RGB Maze", "RGB Sequences", "Rhythm Test", "Rhythms", "Risky Wires", "Robot Programming", "Rock-Paper-Scissors-Lizard-Spock", "Roger", "Role Reversal", "Roman Art", "Roman Numerals", "Rotary Phone", "Rotating Squares", "Rotten Beans", "Round Keypad", "RPS Judging", "RSA Cipher", "Rubik's Clock", "Rubik's Cube", "Rules", "Rullo", "Rune Match I", "Rune Match II", "Rune Match III", "S.E.T.", "Safety Safe", "Safety Square", "Saimoe Maze", "Saimoe Pad", "Scalar Dials", "Scavenger Hunt", "Schlag den Bomb", "Screensaver", "Scripting", "Sea Bear Attacks", "Sea Shells", "Security Council", "Semabols", "Semamorse", "Semaphore", "Sequences", "Settlers of KTaNE", "Seven Choose Four", "Seven Deadly Sins", "Seven Wires", "Shape Memory", "Shape Shift", "Shapes And Bombs", "Shell Game", "Shifted Maze", "Shifting Maze", "Shikaku", "Shoddy Chess", "Shortcuts", "Shuffled Strings", "Siffron", "Signals", "Silenced Simon", "Silhouettes", "Silly Slots", "Silo Authorization", "Simon Forgets", "Simon Literally Says", "Simon Samples", "Simon Says", "Simon Scrambles", "Simon Screams", "Simon Selects", "Simon Sends", "Simon Shrieks", "Simon Simons", "Simon Sings", "Simon Smiles", "Simon Sounds", "Simon Speaks", "Simon Spins", "Simon Squawks", "Simon Stages", "Simon Stashes", "Simon States", "Simon Stops", "Simon Stores", "Simon Stumbles", "Simon Subdivides", "Simon Swindles", "Simon's On First", "Simon's Sequence", "Simon's Stages", "Simon's Star", "Simon's Ultimate Showdown", "Sink", "SixTen", "Skewed Slots", "Skinny Wires", "Skyrim", "Small Circle", "Snack Attack", "Snakes and Ladders", "Snap!", "Snooker", "Snowflakes", "Solitaire Cipher", "Sonic & Knuckles", "Sonic the Hedgehog", "Sorting", "Sound Design", "Souvenir", "Soy Beans", "Space", "Space Invaders Extreme", "Spangled Stars", "Speak English", "Spelling Bee", "Spelling Buzzed", "Spinning Buttons", "Splitting The Loot", "Sporadic Segments", "Spot the Difference", "SpriteClub Betting Simulation", "Square Button", "Stable Time Signatures", "Stack'em", "Stacked Sequences", "Stained Glass", "Standard Button Masher", "Standard Crazy Talk", "Stars", "State of Aggregation", "Sticky Notes", "Stock Images", "Street Fighter", "Strike/Solve", "Striped Keys", "Subscribe to Pewdiepie", "Subways", "Sueet Wall", "Sugar Skulls", "Superlogic", "Switches", "Switching Maze", "Symbol Cycle", "Symbolic Colouring", "Symbolic Coordinates", "Symbolic Password", "Symbolic Tasha", "Symmetries Of A Square", "SYNC-125 [3]", "Synchronization", "Synesthesia", "Synonyms", "T-Words", "Table Madness", "Taco Tuesday", "Tallordered Keys", "Tangrams", "Tap Code", "Tasha Squeals", "Tax Returns", "Teal Arrows", "Tech Support", "Telepathy", "Tell Me When", "Tell Me Why", "Ten Seconds", "Ten-Button Color Code", "Tennis", "Tenpins", "Ternary Converter", "Ternary Tiles", "Terraria Quiz", "TetraVex", "Tetriamonds", "Tetris", "Tetris Sprint", "Text Field", "The 1, 2, 3 Game", "The 12 Days of Christmas", "The Arena", "The Bioscanner", "The Black Page", "The Block", "The Bulb", "The Burnt", "The Button", "The Calculator", "The Clock", "The Close Button", "The Code", "The Colored Maze", "The Console", "The Crafting Table", "The Cruel Duck", "The cRule", "The Crystal Maze", "The Cube", "The Dealmaker", "The Deck of Many Things", "The Dials", "The Digit", "The Duck", "The Exploding Pen", "The Festive Jukebox", "The Fidget Spinner", "The Furloid Jukebox", "The Gamepad", "The Giant's Drink", "The Great Void", "The Hangover", "The Heart", "The Hexabutton", "The Hidden Value", "The High Score", "The Hypercube", "The Hyperlink", "The iPhone", "The Jack-O'-Lantern", "The Jewel Vault", "The Jukebox", "The Kanye Encounter", "The Klaxon", "The Labyrinth", "The Legendre Symbol", "The London Underground", "The Matrix", "The Missing Letter", "The Modkit", "The Moon", "The Necronomicon", "The Number", "The Number Cipher", "The Octadecayotton", "The Overflow", "The Pentabutton", "The Plunger Button", "The Radio", "The Rule", "The Samsung", "The Screw", "The Sequencyclopedia", "The Shaker", "The Simpleton", "The Speaker", "The Sphere", "The Stare", "The Stock Market", "The Stopwatch", "The Sun", "The Swan", "The Switch", "The Time Keeper", "The Triangle", "The Triangle Button", "The Troll", "The Twin", "The Ultracube", "The Very Annoying Button", "The Wire", "The Witness", "The World's Largest Button", "The Xenocryst", "Think Fast", "Thinking Wires", "Third Base", "Thread the Needle", "Three Cryptic Steps", "Tic Tac Toe", "Time Accumulation", "Time Signatures", "Timezone", "Timing is Everything", "Toolmods", "Toolneedy", "Toon Enough", "Topsy Turvy", "Totally Accurate Minecraft Simulator", "Tower of Hanoi", "Towers", "Training Text", "Transmission Transposition", "Transmitted Morse", "Treasure Hunt", "Triamonds", "Triangle Buttons", "Tribal Council", "Turn The Key", "Turn The Keys", "Turtle Robot", "Two Bits", "Two Persuasive Buttons", "Type Racer", "Typing Tutor", "Übermodule", "Ultimate Cipher", "Ultimate Custom Night", "Ultimate Cycle", "Ultimate Tic Tac Toe", "Ultra Digital Root", "Ultralogic", "UltraStores", "Uncolored Squares", "Uncolored Switches", "Unfair Cipher", "Unfair's Cruel Revenge", "Unfair's Revenge", "Unicode", "Unordered Keys", "Unown Cipher", "Unrelated Anagrams", "Updog", "USA Maze", "V", "Validation", "Valued Keys", "Valves", "Varicolored Squares", "Vcrcs", "Vectors", "Venn Diagrams", "Venting Gas", "Vexillology", "Video Poker", "Vigenère Cipher", "Violet Cipher", "Visual Impairment", "Wack Game of Life", "Waste Management", "Wavetapping", "Web Design", "Weird Al Yankovic", "Westeros", "What's on Second", "White Arrows", "White Cipher", "Whiteout", "Who's on First", "Who's That Monsplode?", "Widdershins", "Wild Side", "Wingdings", "Wire Ordering", "Wire Placement", "Wire Sequence", "Wire Spaghetti", "Wires", "Wolf, Goat, and Cabbage", "Wonder Cipher", "Word Scramble", "Word Search", "Working Title", "X", "X-Ray", "X01", "XmORse Code", "Y", "Yahtzee", "Yellow Arrows", "Yellow Cipher", "Yes and No", "Zener Cards", "Zoni", "Zoo", "+"};
    private string[][] Groups = new string[139][] {
    new string[96]{"Air Traffic Controller", "Alphabetical Order", "Antichamber", "Atbash Cipher", "Bamboozling Time Keeper", "Black Cipher", "Blue Cipher", "Brown Cipher", "Busy Beaver", "Button Masher", "Button Messer", "Button Order", "Caesar Cipher", "Calendar", "Code Cracker", "Color Generator", "D-CIPHER", "Digital Cipher", "Double Color", "Dr. Doctor", "Dreamcipher", "Filibuster", "Follow the Leader", "Forget Any Color", "Forget Me Later", "Frankenstein's Indicator", "Gadgetron Vendor", "Gatekeeper", "Gray Cipher", "Green Cipher", "Hearthur", "Higher Or Lower", "Indigo Cipher", "Loopover", "Maze Scrambler", "Mechanus Cipher", "Melody Sequencer", "Meter", "Microcontroller", "Minecraft Cipher", "Mineseeker", "Mineswapper", "Minesweeper", "Modern Cipher", "Murder", "Name Changer", "Not Timer", "OmegaDestroyer", "Orange Cipher", "Pandemonium Cipher", "Password Destroyer", "Password Generator", "Pixel Cipher", "Playfair Cipher", "Point of Order", "Poker", "Popufur", "Prime Checker", "Quaver", "Radiator", "Random Number Generator", "Red Cipher", "Repo Selector", "Roger", "RSA Cipher", "Screensaver", "Snooker", "Solitaire Cipher", "Standard Button Masher", "Street Fighter", "Ternary Converter", "The Bioscanner", "The Calculator", "The Dealmaker", "The Fidget Spinner", "The Hangover", "The Kanye Encounter", "The Missing Letter", "The Number", "The Number Cipher", "The Shaker", "The Speaker", "The Time Keeper", "The Wire", "Totally Accurate Minecraft Simulator", "Type Racer", "Typing Tutor", "Ultimate Cipher", "Unfair Cipher", "Unown Cipher", "Video Poker", "Vigenère Cipher", "Violet Cipher", "White Cipher", "Wonder Cipher", "Yellow Cipher"},
    new string[63]{"7", "❖", "Accumulation", "Addition", "Ars Goetia Identification", "Art Appreciation", "Bamboozling Button", "Boozleglyph Identification", "Color Addition", "Color-Cycle Button", "Creation", "Decimation", "Dictation", "Diffusion", "Dimension Disruption", "Directional Button", "DNA Mutation", "Dungeon", "Echolocation", "Emotiguy Identification", "Encrypted Hangman", "Flag Identification", "Gradually Watermelon", "Hereditary Base Notation", "Indentation", "LED Encryption", "Life Iteration", "Masher The Bottun", "Mii Identification", "Mislocation", "Modulus Manipulation", "Morse Identification", "Musher The Batten", "Musical Transposition", "Needlessly Complicated Button", "Negation", "Neutralization", "Not the Button", "Organization", "Pickup Identification", "Plant Identification", "Prime Encryption", "Rapid Subtraction", "Reaction", "Reverse Polish Notation", "Silenced Simon", "Silo Authorization", "SpriteClub Betting Simulation", "Square Button", "State of Aggregation", "Synchronization", "The Button", "The Close Button", "The Hexabutton", "The Octadecayotton", "The Pentabutton", "The Plunger Button", "The Triangle Button", "The Very Annoying Button", "The World's Largest Button", "Time Accumulation", "Transmission Transposition", "Validation"},
    new string[54]{"Alchemy", "Astrology", "Badugi", "Binary", "Binary Tree", "Blind Alley", "Bone Apple Tea", "Broken Binary", "Broken Karaoke", "Colorful Insanity", "Complexity", "Cruel Binary", "Cryptography", "Deaf Alley", "Digisibility", "Dragon Energy", "Faulty Binary", "Flash Memory", "Forget Infinity", "Four-Card Monte", "Gettin' Funky", "Graphic Memory", "Heraldry", "Horrible Memory", "Hyperneedy", "Jackbox.TV", "Kanji", "Keypad Directionality", "Ladder Lottery", "Laundry", "Mad Memory", "Mazery", "Memory", "Minecraft Parody", "Modules Against Humanity", "Negativity", "Not Memory", "Old Fogey", "Pictionary", "Poetry", "Purgatory", "Rune Match III", "Shape Memory", "Spelling Bee", "SYNC-125 [3]", "Telepathy", "Toolneedy", "Topsy Turvy", "Turn The Key", "V", "Vexillology", "Wire Spaghetti", "Yahtzee", "Zoni"},
    new string[42]{"Alphabetical Ruling", "Bad Wording", "Bartending", "Bomb Corp. Filing", "Bowling", "Boxing", "Chinese Counting", "Color Decoding", "Commuting", "Cooking", "Deck Creating", "Digit String", "Don't Touch Anything", "Double Listening", "Factoring", "Faulty Chinese Counting", "Fencing", "Forget Everything", "Free Parking", "Functional Mapping", "Grid Matching", "Hunting", "Keep Clicking", "Listening", "Literally Crying", "Literally Nothing", "Literally Something", "Module Listening", "Painting", "Plumbing", "Probing", "Railway Cargo Loading", "Red Herring", "ReGret-B Filtering", "Robot Programming", "RPS Judging", "Scripting", "Sorting", "Symbolic Colouring", "Timing is Everything", "Wavetapping", "Wire Ordering"},
    new string[41]{"Adjacent Letters", "Alien Filing Colors", "Alphabet Numbers", "Blockbusters", "Boolean Wires", "Cistercian Numbers", "Color Numbers", "Colored Letters", "Complicated Wires", "Connected Monitors", "Corners", "Divisible Numbers", "Dumb Waiters", "Following Orders", "Forget The Colors", "Funny Numbers", "Graffiti Numbers", "Hidden Colors", "Hyperactive Numbers", "Just Numbers", "Ladders", "Lasers", "Letter Layers", "Logical Operators", "Lying Indicators", "Manometers", "Natures", "Not Complicated Wires", "Numbers", "Perplexing Wires", "Resistors", "Risky Wires", "Seven Wires", "Skinny Wires", "Snakes and Ladders", "Stable Time Signatures", "Thinking Wires", "Time Signatures", "Towers", "Vectors", "Wires"},
    new string[36]{"100 Levels of Defusal", "Affine Cycle", "Astrological", "Big Circle", "Binary Puzzle", "Boggle", "Bomb Diffusal", "Caesar Cycle", "Cryptic Cycle", "European Travel", "Game of Life Simple", "Gnomish Puzzle", "Hex To Decimal", "Hill Cycle", "Jumble Cycle", "Light Cycle", "Marble Tumble", "Mastermind Simple", "Minecraft Survival", "Periodic Table", "Pigpen Cycle", "Playfair Cycle", "Qwirkle", "Reformed Role Reversal", "Role Reversal", "Security Council", "Small Circle", "Symbol Cycle", "The Crafting Table", "The Legendre Symbol", "The Triangle", "Thread the Needle", "Tribal Council", "Ultimate Cycle", "Word Scramble", "Working Title"},
    new string[34]{"1D Maze", "3D Maze", "ASCII Maze", "Birthdays", "Blind Maze", "Boolean Maze", "Catchphrase", "Cruel Boolean Maze", "DACH Maze", "Factory Maze", "Faulty RGB Maze", "Faulty Seven Segment Displays", "Fractal Maze", "Hexamaze", "Keypad Maze", "Lockpick Maze", "Maze", "Module Maze", "Morse-A-Maze", "Mouse In The Maze", "Mystic Maze", "Not Maze", "Not Simaze", "Polyhedral Maze", "RGB Hypermaze", "RGB Maze", "Saimoe Maze", "Shifted Maze", "Shifting Maze", "Subways", "Switching Maze", "The Colored Maze", "The Crystal Maze", "USA Maze"},
    new string[34]{"101 Dalmatians", "A-maze-ing Buttons", "Answering Questions", "Back Buttons", "Bitwise Operations", "Broken Buttons", "Chord Progressions", "Colored Buttons", "Colored Hexabuttons", "Complicated Buttons", "Conditional Buttons", "Constellations", "Daylight Directions", "Diophantine Equations", "Encrypted Equations", "Equations", "Functions", "Gryphons", "Instructions", "Keypad Combinations", "Logical Buttons", "Malfunctions", "Memorable Buttons", "Morse Buttons", "Numbered Buttons", "Partitions", "Pigpen Rotations", "Quaternions", "Rapid Buttons", "Regular Hexpressions", "Simon Simons", "Spinning Buttons", "Triangle Buttons", "Two Persuasive Buttons"},
    new string[20]{"3D Tunnels", "Alphabet Tiles", "Colorful Dials", "Digital Dials", "Intervals", "Iñupiaq Numerals", "Quintuples", "Raiding Temples", "Roman Numerals", "Scalar Dials", "Semabols", "Signals", "Simon Samples", "Simon Scrambles", "Simon Smiles", "Simon Stumbles", "Simon Swindles", "Sonic & Knuckles", "Ternary Tiles", "The Dials"},
    new string[20]{"Bordered Keys", "Chord Qualities", "Colored Keys", "Cruel Piano Keys", "Disordered Keys", "English Entries", "Festive Piano Keys", "Increasing Indices", "Integer Trees", "Letter Keys", "Misordered Keys", "Ordered Keys", "Piano Keys", "Recorded Keys", "Reordered Keys", "Striped Keys", "Tallordered Keys", "Turn The Keys", "Unordered Keys", "Valued Keys"},
    new string[19]{"0", "Accelerando", "Cruello", "Cursed Double-Oh", "DetoNATO", "Double-Oh", "Drive-In Window", "Encryption Bingo", "Faulty Accelerando", "Hot Potato", "Marco Polo", "Modulo", "Needy Piano", "Rullo", "The Overflow", "The Radio", "Tic Tac Toe", "Ultimate Tic Tac Toe", "Yes and No"},
    new string[19]{"Annoying Arrows", "Black Arrows", "Blind Arrows", "Blue Arrows", "Coloured Arrows", "Dominoes", "Double Arrows", "Flashing Arrows", "Green Arrows", "LEGOs", "Neutrinos", "Object Shows", "Orange Arrows", "Purple Arrows", "Rainbow Arrows", "Red Arrows", "Teal Arrows", "White Arrows", "Yellow Arrows"},
    new string[16]{"Abstract Sequences", "Alliances", "Bases", "Bridges", "Colored Switches", "Eight Pages", "Multicolored Switches", "Recolored Switches", "RGB Sequences", "Sequences", "Simon Stages", "Simon's Stages", "Stacked Sequences", "Stock Images", "Switches", "Uncolored Switches"},
    new string[16]{"42", "Baba Is Who?", "Blue", "Color One Two", "Guess Who?", "Kudosudoku", "Kyudoku", "Masyu", "Mega Man 2", "osu!", "Regular Sudoku", "Rune Match II", "Shikaku", "The Hidden Value", "The Screw", "Zoo"},
    new string[14]{"Assembly Code", "Colour Code", "D-CODE", "Lines of Code", "More Code", "Morse Code", "Not Morse Code", "QR Code", "Tap Code", "Ten-Button Color Code", "The Code", "Unicode", "Who's That Monsplode?", "XmORse Code"},
    new string[12]{"Arrow Talk", "BoozleTalk", "Colo(u)r Talk", "Crazy Talk", "Insane Talk", "Jaden Smith Talk", "KayMazey Talk", "Kilo Talk", "Krazy Talk", "Placeholder Talk", "Regular Crazy Talk", "Standard Crazy Talk"},
    new string[11]{"% Grey", "aa", "AAAAA", "Crazy Talk With A K", "Decay", "IPA", "Know Your Way", "Look and Say", "ReGrettaBle Relay", "Taco Tuesday", "X-Ray"},
    new string[11]{"Cryptic Password", "Elder Password", "Extended Password", "Free Password", "Large Free Password", "Large Password", "Not Password", "Not Wiresword", "Password", "Puzzword", "Symbolic Password"},
    new string[11]{"Arithmelogic", "Cosmic", "Iconic", "Logic", "Module Rick", "Quick Arithmetic", "RGB Arithmetic", "RGB Logic", "Superlogic", "Ultralogic", "Weird Al Yankovic"},
    new string[10]{"Audio Keypad", "Boolean Keypad", "Complex Keypad", "Keypad", "Kooky Keypad", "Not Keypad", "Number Pad", "Round Keypad", "Saimoe Pad", "The Gamepad"},
    new string[10]{"Combination Lock", "Digital Clock", "Gridlock", "Keypad Lock", "Mindlock", "Pattern Lock", "Rock-Paper-Scissors-Lizard-Spock", "Rubik's Clock", "The Block", "The Clock"},
    new string[10]{"Button Sequence", "Co-op Harmony Sequence", "Genetic Sequence", "Harmony Sequence", "Maintenance", "Not Wire Sequence", "Phosphorescence", "Simon's Sequence", "Spot the Difference", "Wire Sequence"},
    new string[10]{"Beans", "Chilli Beans", "Coffee Beans", "Cool Beans", "Fake Beans", "Jellybeans", "Kidney Beans", "Long Beans", "Rotten Beans", "Soy Beans"},
    new string[10]{"21", "81", "501", "Answering Can Be Fun", "Entry Number One", "Hole In One", "Rune Match I", "The Simpleton", "The Sun", "X01"},
    new string[9]{"Calculus", "Colorful Madness", "Greek Calculus", "Identifying Soulless", "Number Nimbleness", "Outrageous", "Table Madness", "The 12 Days of Christmas", "The Witness"},
    new string[9]{"Colored Squares", "Decolored Squares", "Discolored Squares", "Divided Squares", "Juxtacolored Squares", "Misery Squares", "Rotating Squares", "Uncolored Squares", "Varicolored Squares"},
    new string[8]{"Burnout", "Cheap Checkout", "Cheat Checkout", "Cheep Checkout", "Lights Out", "Odd Mod Out", "Odd One Out", "Whiteout"},
    new string[8]{"3x3 Grid", "Bamboozling Button Grid", "Binary Grid", "Button Grid", "Digital Grid", "Greek Letter Grid", "LED Grid", "Letter Grid"},
    new string[8]{"64", "Dungeon 2nd Floor", "Entry Number Four", "Grocery Store", "Morse War", "Semaphore", "Seven Choose Four", "The High Score"},
    new string[7]{"Color Math", "Emoji Math", "Fast Math", "LED Math", "Math", "Mental Math", "Remote Math"},
    new string[7]{"Algebra", "Alpha", "Etterna", "Forget Enigma", "Jenga", "Symbolic Tasha", "The Arena"},
    new string[7]{"Ghost Movement", "Logic Statement", "Numerical Knight Movement", "Retirement", "Visual Impairment", "Waste Management", "Wire Placement"},
    new string[7]{"Bamboozled Again", "Bandboozled Again", "Beanboozled Again", "Ramboozled Again", "SixTen", "Tell Me When", "The Exploding Pen"},
    new string[7]{"Brown Bricks", "Hieroglyphics", "Mashematics", "Matchematics", "Mazematics", "Morsematics", "The Matrix"},
    new string[7]{"BuzzFizz", "Chalices", "Hinges", "Human Resources", "Matrices", "Simon Stashes", "Terraria Quiz"},
    new string[7]{"Audio Morse", "Basic Morse", "Color Morse", "Encrypted Morse", "Reverse Morse", "Semamorse", "Transmitted Morse"},
    new string[7]{"Another Keypad Module", "Game of Life Cruel", "Mastermind Cruel", "Mystery Module", "The cRule", "The Rule", "Übermodule"},
    new string[6]{"Hold On", "Lights On", "Siffron", "The Klaxon", "The Necronomicon", "The Swan"},
    new string[6]{"ASCII Art", "Cruel Garfield Kart", "Garfield Kart", "Pixel Art", "Roman Art", "The Heart"},
    new string[6]{"Forget It Not", "Forget Maze Not", "Forget Me Not", "Forget Us Not", "NOT NOT", "Turtle Robot"},
    new string[6]{"Christmas Presents", "Currents", "Determinants", "Ingredients", "Module Movements", "Sporadic Segments"},
    new string[6]{"Equations X", "Flavor Text EX", "Press X", "Reflex", "TetraVex", "X"},
    new string[6]{"Chess", "hexOS", "Lousy Chess", "Rebooting M-OS", "Shoddy Chess", "Vcrcs"},
    new string[6]{"Alpha-Bits", "Coordinates", "hexOrbits", "Kugelblitz", "Symbolic Coordinates", "Two Bits"},
    new string[6]{"Orientation Cube", "Pattern Cube", "Rubik's Cube", "The Cube", "The Hypercube", "The Ultracube"},
    new string[6]{"Cruel Digital Root", "Digital Root", "Faulty Digital Root", "Kahoot!", "Splitting The Loot", "Ultra Digital Root"},
    new string[5]{"Plug-Ins", "Seven Deadly Sins", "Simon Spins", "Tenpins", "Widdershins"},
    new string[5]{"Anagrams", "Insanagrams", "Tangrams", "Unrelated Anagrams", "Venn Diagrams"},
    new string[5]{"Colour Flash", "Geometry Dash", "int##", "Needy Flower Mash", "Quiplash"},
    new string[5]{"Nomai", "Pie", "Subscribe to Pewdiepie", "Tell Me Why", "Y"},
    new string[5]{"Bloxx", "Crackbox", "The Festive Jukebox", "The Furloid Jukebox", "The Jukebox"},
    new string[5]{"Adventure Game", "Goofy's Game", "Kim's Game", "Shell Game", "The 1, 2, 3 Game"},
    new string[5]{"Cruel Match 'em", "Curriculum", "Match 'em", "Metamem", "Stack'em"},
    new string[5]{"Lion's Share", "Mystic Square", "Safety Square", "Symmetries Of A Square", "The Stare"},
    new string[5]{"1000 Words", "Baybayin Words", "Five Letter Words", "Keywords", "T-Words"},
    new string[5]{"14", "B-Machine", "Big Bean", "Double Screen", "Fifteen"},
    new string[5]{"Faulty Sink", "Linq", "Sink", "The Giant's Drink", "The Hyperlink"},
    new string[5]{"Access Codes", "Character Codes", "Error Codes", "Name Codes", "Passcodes"},
    new string[4]{"Benedict Cumberbatch", "Color Match", "Colour Catch", "Flower Patch"},
    new string[4]{"Blackjack", "Chinese Zodiac", "Jack Attack", "Snack Attack"},
    new string[4]{"Breaktime", "Lunchtime", "Party Time", "Prime Time"},
    new string[4]{"Connection Device", "Encrypted Dice", "Lucky Dice", "Naughty or Nice"},
    new string[4]{"Left and Right", "Monsplode, Fight!", "Red Light Green Light", "Ultimate Custom Night"},
    new string[4]{"15 Mystic Lights", "Flashing Lights", "Floor Lights", "Four Lights"},
    new string[4]{"Alphabetize", "Butterflies", "Faulty Butterflies", "Reverse Alphabetize"},
    new string[4]{"Countdown", "Cruel Countdown", "Forget's Ultimate Showdown", "Simon's Ultimate Showdown"},
    new string[4]{"Double Knob", "Knob", "Needy Mrs Bob", "Not Knob"},
    new string[4]{"Cookie Jars", "Cruel Stars", "Spangled Stars", "Stars"},
    new string[4]{"Brawler Database", "Pixel Number Base", "Space", "Third Base"},
    new string[4]{"Cruel Ten Seconds", "Ten Seconds", "Tetriamonds", "Triamonds"},
    new string[4]{"IKEA", "Mafia", "Papa's Pizzeria", "The Sequencyclopedia"},
    new string[4]{"Shuffled Strings", "Simon Sings", "The Deck of Many Things", "Wingdings"},
    new string[4]{"Bottom Gear", "Refill that Beer!", "Souvenir", "The Sphere"},
    new string[4]{"Mystery Widget", "The Digit", "The Modkit", "The Stock Market"},
    new string[4]{"Black Hole", "Passport Control", "The Console", "The Troll"},
    new string[4]{"Microphone", "Rotary Phone", "The iPhone", "Timezone"},
    new string[4]{"9-Ball", "Forget Them All", "One Links To All", "Sueet Wall"},
    new string[3]{"Not Venting Gas", "Stained Glass", "Venting Gas"},
    new string[3]{"Newline", "Next In Line", "One-Line"},
    new string[3]{"Backgrounds", "Faulty Backgrounds", "Simon Sounds"},
    new string[3]{"...?", "Elder Futhark", "Question Mark"},
    new string[3]{"Foreign Exchange Rates", "Logic Gates", "Simon States"},
    new string[3]{"A Message", "Melodic Message", "Wolf, Goat, and Cabbage"},
    new string[3]{"Chicken Nuggets", "Exoplanets", "Planets"},
    new string[3]{"Common Sense", "Lyrical Nonsense", "Motion Sense"},
    new string[3]{"S.E.T.", "Alphabet", "OmegaForget"},
    new string[3]{"Edgework", "Module Homework", "Reversed Edgework"},
    new string[3]{"Not Who's on First", "Simon's On First", "Who's on First"},
    new string[3]{"Battleship", "Censorship", "Friendship"},
    new string[3]{"Forget This", "Tennis", "Tetris"},
    new string[3]{"Corridors", "Simon Stores", "UltraStores"},
    new string[2]{"Flags", "Maritime Flags"},
    new string[2]{"Block Stacks", "Sea Bear Attacks"},
    new string[2]{"Boolean Venn Diagram", "Nonogram"},
    new string[2]{"British Slang", "NumberWang"},
    new string[2]{"Bitmaps", "Collapse"},
    new string[2]{"Keypad Magnified", "Wild Side"},
    new string[2]{"Needy Game of Life", "Wack Game of Life"},
    new string[2]{"Sound Design", "Web Design"},
    new string[2]{"Forget Me Now", "Pow"},
    new string[2]{"Earthbound", "The London Underground"},
    new string[2]{"Color Hexagons", "Polygons"},
    new string[2]{"Monsplode Trading Cards", "Zener Cards"},
    new string[2]{"Capacitor Discharge", "Not Capacitor Discharge"},
    new string[2]{"Amusement Parks", "Bob Barks"},
    new string[2]{"Burger Alarm", "Burglar Alarm"},
    new string[2]{"Silly Slots", "Skewed Slots"},
    new string[2]{"A Mistake", "Jailbreak"},
    new string[2]{"Braille", "Color Braille"},
    new string[2]{"Polyrhythms", "Rhythms"},
    new string[2]{"3 LEDs", "Binary LEDs"},
    new string[2]{"Devilish Eggs", "Perspective Pegs"},
    new string[2]{"Flavor Text", "Training Text"},
    new string[2]{"Font Select", "Only Connect"},
    new string[2]{"Pay Respects", "Simon Selects"},
    new string[2]{"M&Ms", "N&Ms"},
    new string[2]{"Unfair's Cruel Revenge", "Unfair's Revenge"},
    new string[2]{"M&Ns", "N&Ns"},
    new string[2]{"eeB gnillepS", "Three Cryptic Steps"},
    new string[2]{"English Test", "Rhythm Test"},
    new string[2]{"Silhouettes", "Simon Forgets"},
    new string[2]{"Simon Literally Says", "Simon Says"},
    new string[2]{"Crazy Speak", "Hide and Seek"},
    new string[2]{"Simon Shrieks", "Simon Speaks"},
    new string[2]{"Ice Cream", "Space Invaders Extreme"},
    new string[2]{"Amnesia", "Synesthesia"},
    new string[2]{"Character Shift", "Shape Shift"},
    new string[2]{"Double Pitch", "The Switch"},
    new string[2]{"Brush Strokes", "Chinese Strokes"},
    new string[2]{"Footnotes", "Sticky Notes"},
    new string[2]{"Mahjong", "Pong"},
    new string[2]{"Broken Guitar Chords", "Guitar Chords"},
    new string[2]{"Micro-Modules", "Rules"},
    new string[2]{"The Cruel Duck", "The Duck"},
    new string[2]{"Scavenger Hunt", "Treasure Hunt"},
    new string[2]{"+", "Desert Bus"},
    new string[2]{"NeeDeez Nuts", "Shortcuts"},
    new string[2]{"FizzBuzz", "QuizBuzz"},
    new string[107]{"Cell Lab", "Cruel Keypads", "Challenge & Contact", "Valves", "A>N<D", "Langton's Ant", "Snap!", "Multitask", "Think Fast", "Mortal Kombat", "Caesar's Maths", "Simon Subdivides", "Chamber No. 5", "Bean Sprouts", "Baccarat", "Sonic the Hedgehog", "Golf", "Strike/Solve", "Schlag den Bomb", "Command Prompt", "Shapes And Bombs", "HTTP Response", "Blinkstop", "Simon Stops", "Simon's Star", "Boomdas", "The Stopwatch", "Identity Parade", "The Black Page", "Safety Safe", "Snowflakes", "Codenames", "Settlers of KTaNE", "Pocket Planes", "Press The Shape", "Find The Date", "h", "Jukebox.WAV", "Mastermind Restricted", "Johnson Solids", "What's on Second", "Going Backwards", "The Jack-O'-Lantern", "Double Expert", "Red", "Brainf---", "egg", "Connection Check", "Sea Shells", "Simon Sends", "Quick Time Events", "Etch-A-Sketch", "The Burnt", "Tax Returns", "Word Search", "Lightspeed", "Hexiom", "Icon Reveal", "Text Field", "Tasha Squeals", "Simon Screams", "Bridge", "Boot Too Big", "Pitch Perfect", "Skyrim", "Synonyms", "The Twin", "Tetris Sprint", "The Labyrinth", "D-CRYPT", "The Xenocryst", "Speak English", "Forget Perspective", "Partial Derivatives", "Maze³", "Palindromes", "Homophones", "Quote Crazy Talk End Quote", "Westeros", "Draw", "Toolmods", "Updog", "Tower of Hanoi", "The Great Void", "Flip The Coin", "16 Coins", "Simon Squawks", "The Jewel Vault", "Tech Support", "Hogwarts", "Boob Tube", "Lombax Cubes", "The Moon", "Duck, Duck, Goose", "Fruits", "Encrypted Values", "Toon Enough", "Coffeebucks", "The Bulb", "Light Bulbs", "Sugar Skulls", "Navinums", "Color Punch", "The Samsung", "Interpunct", "Hold Ups", "Spelling Buzzed"},
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
        chosenGroup = UnityEngine.Random.Range(0,138); //Don't do non-rhyme group at the bottom
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
            randomGroup = UnityEngine.Random.Range(0,139); //non-rhymes are okay here
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

        ShowTheDamnIcons();
    }

    void ShowTheDamnIcons() {
        for (int i = 0; i < 8; i++) {
            Icons[i].sprite = Resources.Load<Sprite>(WaitASec(chosenModules[i]));
        }
    }

    string WaitASec (string s) {
        switch (s) {
            case "...?": return "puncuationMarks"; break; //mispelling intentional!
            case "A>N<D": return "A_N_D"; break;
            case "Maze³": return "Maze^3"; break;
            case "Jukebox.WAV": return "JukeboxWAV"; break;
            case "Jellybeans": return "Jelly Beans"; break; //ok this is just a mistake on my part
            case "Lion's Share": return "Lion’s Share"; break; //the fancy apostrophes make me want to pull my hair out
            case "Who's That Monsplode?": return "Who’s That Monsplode"; break;
            case "Who's on First": return "Who’s on First"; break;
            case "Rubik's Cube": return "Rubik’s Cube"; break;
            case "Rubik's Clock": return "Rubik’s Clock"; break;
            case "Simon's Stages": return "Simon’s Stages"; break;
            case "Simon's Sequence": return "Simon’s Sequence"; break;
            default: return s; break;
        }
    }

    void ButtonPress(KMSelectable button) {
        for (int l = 0; l < 8; l++) {
            if (button == Buttons[l]) {
            Audio.PlaySoundAtTransform(SoundNum(chosenModules[l]), transform);
                if (!moduleSolved) {
                    if (presses % 2 == 0) {
                        previous = chosenModules[l];
                    } else {
                        if (previous == chosenModules[l]) {
                            GetComponent<KMBombModule>().HandleStrike();
                        } else {
                            if ((previous == answers[0] || previous == answers[1]) && (chosenModules[l] == answers[0] || chosenModules[l] == answers[1])) {
                                GetComponent<KMBombModule>().HandlePass();
                                moduleSolved = true;
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
}
