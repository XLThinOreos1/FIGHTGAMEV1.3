using System.Media;
internal class Program
{
    static void SettingsMenu(ref SoundPlayer settings, ref bool optionsSettings, ref int choiceSettings, ref int PlayerHp, ref int ChickenHp, ref int FoxHp, ref int GoblinHp, ref string MusicMute, ref bool MusicMuteDoStuff, ref int CatHp, ref int AntHp)
    {
        if (!MusicMuteDoStuff)
        {
            settings.PlayLooping();
        }
        while (optionsSettings)
        {
            Console.Clear();
            Console.WriteLine($" * Settings menu * \n-------------------\n");
            Console.WriteLine($"   Player stats");
            Console.WriteLine($"   Chicken stats");
            Console.WriteLine($"   Fox stats");
            Console.WriteLine($"   Goblin stats");
            Console.WriteLine($"   Cat stats");
            Console.WriteLine($"   Ant stats");
            Console.WriteLine($"   Turn {MusicMute} music");
            Console.WriteLine("   Exit Settings");
            Console.SetCursorPosition(1, choiceSettings);
            Console.Write(">");

            // Den kollar på vilken tangentbordsknapp du trycker på
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow && choiceSettings > 3) { choiceSettings--; }
            else if (key.Key == ConsoleKey.DownArrow && choiceSettings < 10) { choiceSettings++; }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (MusicMuteDoStuff) { MusicMute = "off"; } else { MusicMute = "on"; }
                switch (choiceSettings)
                {
                    // case 0 - 3, Man kan ändra HP för alla karaktärer.
                    case 3:
                        Console.Clear();
                        Console.WriteLine("How much health should you have? (Max 400HP)\n");
                        Console.WriteLine($"You currently have {PlayerHp} HP");
                        Console.WriteLine("Just type the number, don't end it with HP at the end.\n");
                        Console.Write("> ");
                        // Den här under ser till att bara tal får skrivas in, allt annat gör om hp till deras default value.
                        if (int.TryParse(Console.ReadLine(), out PlayerHp)) { }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("How much health should the chicken have?\n");
                        Console.WriteLine($"The chicken currently have {ChickenHp} HP");
                        Console.WriteLine("Just type the number, don't end it with HP at the end.\n");
                        Console.Write("> ");
                        if (int.TryParse(Console.ReadLine(), out ChickenHp)) { }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("How much health should the fox have?\n");
                        Console.WriteLine($"The fox currently have {FoxHp} HP");
                        Console.WriteLine("Just type the number, don't end it with HP at the end.\n");
                        Console.Write("> ");
                        if (int.TryParse(Console.ReadLine(), out FoxHp)) { }
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("How much health should the goblin have?\n");
                        Console.WriteLine($"The goblin currently have {GoblinHp} HP");
                        Console.WriteLine("Just type the number, don't end it with HP at the end.\n");
                        Console.Write("> ");
                        if (int.TryParse(Console.ReadLine(), out GoblinHp)) { }
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("How much health should the cat have?\n");
                        Console.WriteLine($"The cat currently have {CatHp} HP");
                        Console.WriteLine("Just type the number, don't end it with HP at the end.\n");
                        Console.Write("> ");
                        if (int.TryParse(Console.ReadLine(), out CatHp)) { }
                        break;
                    case 8:
                        settings.Stop();
                        Console.Clear();
                        Console.WriteLine("You can not change perfection.");
                        Console.ReadLine();
                        settings.PlayLooping();
                        break;
                    // Toggle för musik i spelet
                    case 9:
                        if (!MusicMuteDoStuff)
                        {
                            settings.Stop();
                        }
                        else
                        {
                            settings.PlayLooping();
                        }
                        MusicMuteDoStuff = !MusicMuteDoStuff;
                        break;
                    case 10:
                        return;
                }
            }
        }
    }
    private static void Main(string[] args)
    {
        // Ger "rand" variabeln till en random number generator
        Random rand = new Random();

        SoundPlayer battle = new SoundPlayer(@"battle.wav");
        SoundPlayer victory = new SoundPlayer(@"victory.wav");
        SoundPlayer encounter = new SoundPlayer(@"encounter.wav");
        SoundPlayer lose = new SoundPlayer(@"gameover.wav");
        SoundPlayer settings = new SoundPlayer(@"settings.wav");

        int oddsOfSuccess, TakenDamage, oddsOfCrit, YourDamage;
        bool block = false;
        bool Restart = false;
        int choice = 0;
        int choiceSettings = 3;
        bool options = true;
        bool optionsSettings = true;
        int PlayerHp = 200;
        int ChickenHp = 75;
        int FoxHp = 100;
        int GoblinHp = 150;
        int CatHp = 50;
        int AntHp = 10;
        string MusicMute = "off";
        bool MusicMuteDoStuff = false;
        bool SpecialAttackToggle = false;

        string[] EnemyName = { "Chicken", "Fox", "Goblin", "Cat", "Ant" };
        // string[] EnemyName = { "Cat", "Ant" };
        Console.CursorVisible = false;
        int[] EnemyHps = { ChickenHp, FoxHp, GoblinHp, CatHp, AntHp };
        // int[] EnemyHps = { CatHp, AntHp };
        while (true)
        {
            Console.WriteLine("Turn based fighting game v1.2\nBy Nicolás TE21B");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("\nWrite start to start the game\nWrite info to learn more about the game\nWrite settings to modify game");
            Console.Write("\n> ");
            string TitleScreenInput = Console.ReadLine().ToLower();
            TitleScreenInput = TitleScreenInput.Replace(" ", "");
            if (TitleScreenInput == "start")
            {
                Console.Clear();
                break;
            }
            else if (TitleScreenInput == "settings")
            {
                Console.Clear();
                SettingsMenu(ref settings, ref optionsSettings, ref choiceSettings, ref PlayerHp, ref ChickenHp, ref FoxHp, ref GoblinHp, ref MusicMute, ref MusicMuteDoStuff, ref CatHp, ref AntHp);
                settings.Stop();
                Console.Clear();
            }
            else if (TitleScreenInput == "info" || TitleScreenInput == "information")
            {
                Console.Clear();
                Console.WriteLine("----------------- Information -----------------");
                Console.WriteLine("> There are 3 enemies you can encounter.\n\n> Each enemy has different amount of HP.\n\n> The chicken is light as a feather which makes\n  him a fast and dangerous enemy!\n  The chicken is more likely to crit.\n\n> You can modify the game by typing settings.\n  in the title screen.\n\n> When the enemies are charging their\n  special attack, it's best you dodge!\n\n> If you encounter the ant, run.");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("\nPress enter to go back");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You need to type either start or settings");
                Task.Delay(2000).Wait();
                Console.Clear();
            }
        }

        while (true)
        {
            if (Restart)
            {
                Restart = false;
                break;
            }
            int RandomEnemy = rand.Next(0, 5);
            // int RandomEnemy = 4;
            Console.WriteLine($"{RandomEnemy}");
            int EnemyMaxHP = EnemyHps[RandomEnemy];

            if (!MusicMuteDoStuff)
            {
                encounter.Play();
            }
            for (var t = 0; t < 2; t++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Task.Delay(150).Wait();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Task.Delay(150).Wait();
            }
            Task.Delay(1000).Wait();
            if (!MusicMuteDoStuff)
            {
                battle.PlayLooping();
            }
            while (true)
            {
                Console.CursorVisible = false;
                if (Restart)
                {
                    Restart = false;
                    break;
                }
                YourTurn();
                CheckForWin();
                CheckForLose();
                Task.Delay(2000).Wait();
                if (Restart)
                {
                    Restart = false;
                    break;
                }
                EnemyAttackYou();
                CheckForWin();
                CheckForLose();
                Task.Delay(2000).Wait();
            }

            void YourTurn()
            {
                while (options)
                {
                    Console.Clear();
                    ShowHealthPlayer();
                    ShowHealthEnemy();
                    Console.SetCursorPosition(0, 25);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine("   Light attack    -    Always hits but low damage");
                    Console.WriteLine("   Heavy attack    -    High risk but big damage");
                    Console.WriteLine("   Dodge Attack    -    Protect yourself from an enemy attack");
                    Console.SetCursorPosition(1, choice + 26);
                    Console.Write(">");
                    EnemyArt();

                    var key = Console.ReadKey(true);
                    // Kollar om input är lika med Up arrow och choice > 0 stoppar så man inte går out of bounds. Choice-- gör så man kan gå ner.
                    if (key.Key == ConsoleKey.UpArrow && choice > 0) { choice--; }
                    // Samma sak som ovan fast för när man går ner och choice++ stoppar så man inte kan gå hur långt ner som man vill.
                    else if (key.Key == ConsoleKey.DownArrow && choice < 2) { choice++; }
                    // Om input är enter på nån av alternativen så kommer den växla mellan på eller av som en spak.
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        switch (choice)
                        {
                            case 0:
                                Console.SetCursorPosition(0, 0);
                                LowAttack();
                                break;
                            case 1:
                                Console.SetCursorPosition(0, 0);
                                HighAttack();
                                break;
                            case 2:
                                Console.SetCursorPosition(0, 0);
                                BlockAttack();
                                break;
                        }

                        Console.SetCursorPosition(0, 25);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.SetCursorPosition(0, 2);
                        break;
                    }
                }
            }

            void ShowHealthPlayer()
            {
                Console.SetCursorPosition(80, 28);
                for (var i = 0; i < 20; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("█");
                }
                Console.SetCursorPosition(80, 28);
                for (var i = 0; i < PlayerHp / 10; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");
                }
                Console.SetCursorPosition(80, 27);
                Console.ResetColor();
                Console.WriteLine($"HP: {PlayerHp}/200" + " ");
            }

            void ShowHealthEnemy()
            {
                Console.SetCursorPosition(55, 7);
                for (var k = 0; k < EnemyMaxHP / 10; k++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("█");
                }
                Console.SetCursorPosition(55, 7);
                for (var k = 0; k < EnemyHps[RandomEnemy] / 10; k++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");
                }
                Console.ResetColor();
                if (EnemyName[RandomEnemy] == "Chicken")
                {
                    Console.SetCursorPosition(59, 4);
                    Console.WriteLine($"{EnemyName[RandomEnemy]}");
                    Console.SetCursorPosition(58, 6);
                    Console.WriteLine($"HP: {EnemyHps[RandomEnemy]}/75" + " ");
                }
                else if (EnemyName[RandomEnemy] == "Fox")
                {
                    Console.SetCursorPosition(59, 4);
                    Console.WriteLine($"{EnemyName[RandomEnemy]}");
                    Console.SetCursorPosition(55, 6);
                    Console.WriteLine($"HP: {EnemyHps[RandomEnemy]}/100" + " ");
                }
                else if (EnemyName[RandomEnemy] == "Goblin")
                {
                    Console.SetCursorPosition(60, 4);
                    Console.WriteLine($"{EnemyName[RandomEnemy]}");
                    Console.SetCursorPosition(55, 6);
                    Console.WriteLine($"HP: {EnemyHps[RandomEnemy]}/150" + " ");
                }
                else if (EnemyName[RandomEnemy] == "Cat")
                {
                    Console.SetCursorPosition(61, 4);
                    Console.WriteLine($"{EnemyName[RandomEnemy]}");
                    Console.SetCursorPosition(55, 6);
                    Console.WriteLine($"HP: {EnemyHps[RandomEnemy]}/50" + " ");
                }
                else
                {
                    Console.SetCursorPosition(60, 4);
                    Console.WriteLine($"{EnemyName[RandomEnemy]}");
                    Console.SetCursorPosition(58, 6);
                    Console.WriteLine($"HP: {EnemyHps[RandomEnemy]}/10" + " ");
                }
            }

            void LowAttack()
            {
                if (EnemyName[RandomEnemy] == "Cat")
                {
                    Console.WriteLine("You missed because the cat was too cute.");
                    return;
                }
                if (EnemyName[RandomEnemy] == "Ant")
                {
                    Console.WriteLine("You are too weak to hurt him.");
                    return;
                }
                oddsOfCrit = rand.Next(1, 11);
                if (oddsOfCrit is 10)
                {
                    YourDamage = rand.Next(30, 41);
                    EnemyHps[RandomEnemy] -= YourDamage;
                    Console.WriteLine("- CRITICAL HIT -");
                    Console.WriteLine($"You hit the {EnemyName[RandomEnemy]} for {YourDamage} damage!");
                    ShowHealthEnemy();
                }
                else
                {
                    YourDamage = rand.Next(10, 21);
                    EnemyHps[RandomEnemy] -= YourDamage;
                    Console.WriteLine($"You hit the {EnemyName[RandomEnemy]} for {YourDamage} damage.");
                    ShowHealthEnemy();
                }
            }

            void HighAttack()
            {
                if (EnemyName[RandomEnemy] == "Cat")
                {
                    Console.WriteLine("You missed because the cat was too cute.");
                    return;
                }
                if (EnemyName[RandomEnemy] == "Ant")
                {
                    Console.WriteLine("You are too weak to hurt him.");
                    return;
                }
                oddsOfSuccess = rand.Next(1, 7);
                if (oddsOfSuccess is 5 or 6)
                {
                    YourDamage = rand.Next(40, 51);

                    EnemyHps[RandomEnemy] -= YourDamage;
                    Console.WriteLine($"You managed to land the hit and dealt {YourDamage} damage to the {EnemyName[RandomEnemy]}!");
                    ShowHealthEnemy();
                }
                else
                {
                    Console.WriteLine("You missed!");
                }
            }

            void BlockAttack()
            {
                block = true;
                Console.WriteLine("You took out your shield.");
            }

            void EnemyAttackYou()
            {
                if (!block)
                {
                    if (EnemyName[RandomEnemy] == "Ant")
                    {
                        Console.WriteLine($"The {EnemyName[RandomEnemy]} used their godly powers to obliterate you for 99999 damage.");
                        PlayerHp -= 99999;
                        ShowHealthPlayer();
                        return;
                    }
                    if (SpecialAttackToggle)
                    {
                        Console.WriteLine($"The {EnemyName[RandomEnemy]} used their special attack and hit you for 100 damage!");
                        PlayerHp -= 100;
                        SpecialAttackToggle = false;
                        ShowHealthPlayer();
                        return;
                    }
                    else { }
                    oddsOfSuccess = rand.Next(1, 10);
                    if (oddsOfSuccess is 5 or 6)
                    {
                        Console.WriteLine($"The {EnemyName[RandomEnemy]} is charging up a special attack!");
                        SpecialAttackToggle = true;
                        return;
                    }
                    else
                    {
                        if (EnemyName[RandomEnemy] == "Chicken")
                        {
                            oddsOfCrit = rand.Next(1, 6);
                            if (oddsOfCrit is 4 or 5 or 6)
                            {
                                TakenDamage = rand.Next(50, 76);
                                Console.WriteLine("- CRITICAL HIT -");
                                Console.WriteLine($"The {EnemyName[RandomEnemy]} hit you for {TakenDamage} damage!");
                                PlayerHp -= TakenDamage;
                                ShowHealthPlayer();
                                return;
                            }
                            else
                            {
                                TakenDamage = rand.Next(10, 30);
                                Console.WriteLine($"The {EnemyName[RandomEnemy]} hit you for {TakenDamage} damage.");
                                PlayerHp -= TakenDamage;
                                ShowHealthPlayer();
                                return;
                            }
                        }
                    }

                    oddsOfSuccess = rand.Next(1, 7);
                    if (oddsOfSuccess is 2 or 3 or 4 or 5 or 6)
                    {
                        oddsOfCrit = rand.Next(1, 11);
                        if (oddsOfCrit is 10)
                        {
                            TakenDamage = rand.Next(50, 76);
                            Console.WriteLine("- CRITICAL HIT -");
                            Console.WriteLine($"The {EnemyName[RandomEnemy]} hit you for {TakenDamage} damage!");
                            PlayerHp -= TakenDamage;
                            ShowHealthPlayer();
                        }
                        else
                        {
                            TakenDamage = rand.Next(10, 30);
                            Console.WriteLine($"The {EnemyName[RandomEnemy]} hit you for {TakenDamage} damage.");
                            PlayerHp -= TakenDamage;
                            ShowHealthPlayer();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You dodged the attack");
                    }
                }
                else
                {
                    Console.WriteLine($"You blocked the enemies attack.");
                    SpecialAttackToggle = false;
                }
                block = false;
            }

            void CheckForWin()
            {
                if (EnemyHps[RandomEnemy] < 1)
                {
                    if (!MusicMuteDoStuff)
                    {
                        battle.Stop();
                        victory.Play();
                    }
                    Console.SetCursorPosition(0, 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine($"You have defeated the {EnemyName[RandomEnemy]}!");
                    Console.WriteLine("\nYou win!");
                    Task.Delay(4000).Wait();
                    Console.Clear();
                    PlayAgain();
                }
            }

            void CheckForLose()
            {
                if (PlayerHp < 1)
                {
                    if (!MusicMuteDoStuff)
                    {
                        battle.Stop();
                        lose.Play();
                    }
                    Console.SetCursorPosition(0, 3);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine($"The {EnemyName[RandomEnemy]} has defeated you.");
                    Console.WriteLine("\nYou died.");
                    Task.Delay(4000).Wait();
                    Console.Clear();
                    PlayAgain();
                }
            }

            void PlayAgain()
            {
                Console.ResetColor();
                Console.WriteLine("Do you want to play again?\n(Y/N)");
                string PlayAgain = Console.ReadLine().ToLower();
                if (PlayAgain != "y" && PlayAgain != "yes" && PlayAgain != "ja" && PlayAgain != "sure")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Restart = true;
                    victory.Stop();
                    Console.Clear();
                    PlayerHp = 200; EnemyHps[RandomEnemy] = EnemyMaxHP;
                    SpecialAttackToggle = false;
                }
            }

            void EnemyArt()
            {
                Console.SetCursorPosition(80, 9);
                if (EnemyName[RandomEnemy] == "Chicken")
                {
                    Console.Write(@"
                                                              __//
                                                            /.__.\
                                                            \ \/ /
                                                         '__/    \
                                                          \-      )
                                                           \_____/
                                                        _____|_|____");
                }
                else if (EnemyName[RandomEnemy] == "Fox")
                {
                    Console.Write(@"
                                                    |\_/|,,_____,~~`
                                                    (. .)~~     )`~}}
                                                     \o/\ /---~\\ ~}}
                                                       _//    _// ~}"
                    );
                }
                else if (EnemyName[RandomEnemy] == "Goblin")
                {
                    Console.Write(@"                  
                                                            .-""-.
                                                      |\   /      \   /|
                                                      | \ / =.  .= \ / |
                                                      \( \   o\/o   / )/
                                                       \_, '-/  \-' ,_/
                                                         /   \__/   \
                                                         \ \__/\__/ /
                                                       ___\        /___
                                                     /`    \      /    `\
                                                    /       '----'       \");
                }
                else if (EnemyName[RandomEnemy] == "Cat")
                {
                    Console.Write(@"                                    
                                                                      _..
                                                     /}_{\           /.-'
                                                    ( o o )-.___...-'/
                                                    ==._.==         ;
                                                         \   _..._ /,
                                                         {_;/   {_//");
                }
                else
                {
                    Console.Write(@"                 
                                                       '\__
                                                        (o )     ___
                                                        <>(_)(_)(___)
                                                          < < > >
                                                          ' ' ` `");
                }
            }
        }
    }
}
