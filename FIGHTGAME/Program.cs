// lägger till så man kan använda SoundPlayer som spelar ljudfiler
using System.Media;
internal class Program
{
    static void SettingsMenu(ref SoundPlayer settings, ref bool optionsSettings, ref int choiceSettings, ref int PlayerHp, ref int ChickenHp, ref int FoxHp, ref int GoblinHp, ref string MusicMute, ref bool MusicMuteDoStuff, ref int CatHp, ref int AntHp, ref int[] EnemyHps, ref int PlayerMaxHp, ref int PrevMaxHp)
    {
        if (!MusicMuteDoStuff)
        {
            settings.PlayLooping();
        }
        // Medans man är i settings menu så kommer den köra den här settings UI
        while (optionsSettings)
        {
            Console.Clear();
            Console.WriteLine($" * Settings menu * \n-------------------\n");
            Console.WriteLine($"   Player stats");
            Console.WriteLine($"   Chicken stats");
            Console.WriteLine($"   Fox stats");
            Console.WriteLine($"   Goblin stats");
            Console.WriteLine($"   Cat stats");
            Console.WriteLine($"   God of Ants stats");
            Console.WriteLine($"   Turn {MusicMute} music");
            Console.WriteLine("   Exit Settings");
            Console.SetCursorPosition(1, choiceSettings);
            Console.Write(">");

            // Den kollar på vilken tangentbordsknapp du trycker på
            var key = Console.ReadKey(true);
            // Hindrar en från att gå för långt upp eller för långt ner.
            if (key.Key == ConsoleKey.UpArrow && choiceSettings > 3) { choiceSettings--; }
            else if (key.Key == ConsoleKey.DownArrow && choiceSettings < 10) { choiceSettings++; }
            else if (key.Key == ConsoleKey.Enter)
            {
                // Fixar så att när man trycker på mute knappen så ändras texten till on eller off beroende på om den är på eller av.
                if (MusicMuteDoStuff) { MusicMute = "off"; } else { MusicMute = "on"; }
                switch (choiceSettings)
                {
                    // case 3 - 7, Man kan ändra HP för alla karaktärer.
                    case 3:
                        Console.Clear();
                        Console.WriteLine("How much health should you have? (Max 400HP)\n");
                        Console.WriteLine($"You currently have {PlayerMaxHp} HP");
                        Console.WriteLine("Just type the number, don't end it with HP at the end.\n");
                        Console.Write("> ");
                        // PrevMaxHp finns för om man skriver in ett ogiltigt svar så blir custom hp till det förra talet så det inte görs om till 0 eller något dåligt.
                        // Sätter PrevMaxHp till vad PlayerMaxHps nuvarande värde är så den kan användas som en template.
                        PrevMaxHp = PlayerMaxHp;
                        // Den här under ser till att bara tal får skrivas in, allt annat gör om hp till deras current value.
                        if (int.TryParse(Console.ReadLine(), out PlayerMaxHp))
                        {
                            // Gör om 0 eller negativa tal till vad det var förut (PrevMaxHp). Gör också om sin custom HP så att den inte blir för hög.
                            if (PlayerMaxHp < 1 || PlayerMaxHp > 400)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid answer detected\nRestoring to previous value...");
                                Task.Delay(2000).Wait();
                                // Oj! Talet var ogiltigt. Gör om det ogiltigt talet till vad det var förut så det inte blir knas.
                                PlayerMaxHp = PrevMaxHp;
                            }
                            else
                            {
                                // Säger att ditt giltiga svar är nu ditt nuvarande HP.
                                Console.Clear();
                                Console.WriteLine($"Okay! Your HP is now {PlayerMaxHp}.");
                                Task.Delay(2000).Wait();
                            }
                        }
                        else 
                        {
                            // Lämnar man in ett tomt svar så gör den om sin HP till vad det var förut. Annars händer det att sitt HP blir till 0.
                            PlayerMaxHp = PrevMaxHp;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("How much health should the chicken have? (Max 400HP)\n");
                        Console.WriteLine($"The chicken currently has {EnemyHps[0]} HP");
                        Console.WriteLine("Just type the number, don't end it with HP at the end.\n");
                        Console.Write("> ");
                        // EnemyHps[0] menas att det tar ut hp av vilken fiende som är på den platsen i Arrayn. Chicken är 0 i Arrayen för den är på första plats (0).
                        PrevMaxHp = EnemyHps[0];
                        if (int.TryParse(Console.ReadLine(), out EnemyHps[0]))
                        {
                            if (EnemyHps[0] < 1 || EnemyHps[0] > 400)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid answer detected\nRestoring to previous value...");
                                Task.Delay(2000).Wait();
                                EnemyHps[0] = PrevMaxHp;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"Okay! The chickens HP is now {EnemyHps[0]}.");
                                Task.Delay(2000).Wait();
                            }
                        }
                        else 
                        {
                            EnemyHps[0] = PrevMaxHp;
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("How much health should the fox have? (Max 400HP)\n");
                        Console.WriteLine($"The fox currently has {EnemyHps[1]} HP");
                        Console.WriteLine("Just type the number, don't end it with HP at the end.\n");
                        Console.Write("> ");
                        PrevMaxHp = EnemyHps[1];
                        if (int.TryParse(Console.ReadLine(), out EnemyHps[1]))
                        {
                            if (EnemyHps[1] < 1 || EnemyHps[1] > 400)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid answer detected\nRestoring to previous value...");
                                Task.Delay(2000).Wait();
                                EnemyHps[1] = PrevMaxHp;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"Okay! The foxs HP is now {EnemyHps[1]}.");
                                Task.Delay(2000).Wait();
                            }
                        }
                        else 
                        {
                            EnemyHps[1] = PrevMaxHp;
                        }
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("How much health should the goblin have? (Max 400HP)\n");
                        Console.WriteLine($"The goblin currently has {EnemyHps[2]} HP");
                        Console.WriteLine("Just type the number, don't end it with HP at the end.\n");
                        Console.Write("> ");
                        PrevMaxHp = EnemyHps[2];
                        if (int.TryParse(Console.ReadLine(), out EnemyHps[2]))
                        {
                            if (EnemyHps[2] < 1 || EnemyHps[2] > 400)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid answer detected\nRestoring to previous value...");
                                Task.Delay(2000).Wait();
                                EnemyHps[2] = PrevMaxHp;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"Okay! The goblins HP is now {EnemyHps[2]}.");
                                Task.Delay(2000).Wait();
                            }
                        }
                        else 
                        {
                            EnemyHps[2] = PrevMaxHp;
                        }
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("How much health should the cat have? (Max 200HP)\n");
                        Console.WriteLine($"The cat currently has {EnemyHps[3]} HP");
                        Console.WriteLine("Just type the number, don't end it with HP at the end.\n");
                        Console.Write("> ");
                        PrevMaxHp = EnemyHps[3];
                        if (int.TryParse(Console.ReadLine(), out EnemyHps[3]))
                        {
                            if (EnemyHps[3] < 1 || EnemyHps[3] > 200)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid answer detected\nRestoring to previous value...");
                                Task.Delay(2000).Wait();
                                EnemyHps[3] = PrevMaxHp;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"Okay! The cats HP is now {EnemyHps[3]}.");
                                Task.Delay(2000).Wait();
                            }
                        }
                        else 
                        {
                            EnemyHps[3] = PrevMaxHp;
                        }
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

        // Lägger ljudfiler till programmet och gör variablerna till ett ljud.
        SoundPlayer battle = new SoundPlayer(@"battle.wav");
        SoundPlayer victory = new SoundPlayer(@"victory.wav");
        SoundPlayer encounter = new SoundPlayer(@"encounter.wav");
        SoundPlayer lose = new SoundPlayer(@"gameover.wav");
        SoundPlayer settings = new SoundPlayer(@"settings.wav");
        SoundPlayer kamehameha = new SoundPlayer(@"lol.wav");

        // Massa grejer som definierar variabler.
        int oddsOfSuccess, TakenDamage, oddsOfCrit, YourDamage;
        bool block = false;
        bool Restart = false;
        int choice = 0;
        int choiceSettings = 3;
        bool options = true;
        bool optionsSettings = true;
        int PlayerHp = 200;
        int PlayerMaxHp = 200;
        int PrevMaxHp = 0;
        int ChickenHp = 75;
        int FoxHp = 100;
        int GoblinHp = 150;
        int CatHp = 50;
        int AntHp = 10;
        string MusicMute = "off";
        bool MusicMuteDoStuff = false;
        bool SpecialAttackToggle = false;

        // Array för alla olika fiendernas namn
        string[] EnemyName = { "Chicken", "Fox", "Goblin", "Cat", "Ant" };
        // Array för fiendernas hp
        int[] EnemyHps = { ChickenHp, FoxHp, GoblinHp, CatHp, AntHp };

        Console.CursorVisible = false;
        // Main menu
        while (true)
        {
            Console.WriteLine("Turn based fighting game v1.3\nBy Nicolás TE21B");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("\nWrite start to start the game\nWrite info to learn more about the game\nWrite settings to modify game");
            Console.Write("\n> ");
            // Göra om sitt svar till liten bokstav och tar bort alla tomma mellanrum 
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
                // Alla ref behövdes för funktionen skulle fungera. Jag vet inte exakt varför det här händer, jag hade problem och visste inte alls hur man skulle fixa men sen fixade en 3:a det genom att göra den här långa ref kedja.
                // UPDATE: Sebastian webbutvecklingslärare såg det här och satt med mig i typ 15 minuter och lärde mig att det skulle vara bättre med att använda Class.
                SettingsMenu(ref settings, ref optionsSettings, ref choiceSettings, ref PlayerHp, ref ChickenHp, ref FoxHp, ref GoblinHp, ref MusicMute, ref MusicMuteDoStuff, ref CatHp, ref AntHp, ref EnemyHps, ref PlayerMaxHp, ref PrevMaxHp);
                // Stänger av settings musiken
                settings.Stop();
                Console.Clear();
            }
            // Visar information till hur spelet fungerar
            else if (TitleScreenInput == "info" || TitleScreenInput == "information")
            {
                Console.Clear();
                Console.WriteLine("----------------- Information -----------------");
                Console.WriteLine("> There are 5 enemies you can encounter.\n\n> Each enemy has different amount of HP.\n\n> The chicken is light as a feather which makes\n  him a fast and dangerous enemy!\n  It gives him more crit chance!\n\n> You can modify the game by typing settings.\n  in the title screen.\n\n> When the enemies are charging their\n  special attack, it's best you dodge!\n\n> The cat is too cute, try dodging it.\n\n> If you encounter The God of Ants, run.");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("\nPress enter to go back");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                // Skriver man något annat än det som är tillgängligt skickas man tillbaka till main menu
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
            // Väljer ut en slumpmässig fiende från RandomEnemy Array
            int RandomEnemy = rand.Next(5);
            // int RandomEnemy = 0;
            // Gör EnemyMaxHP till den valde fiendes hp.
            int EnemyMaxHP = EnemyHps[RandomEnemy];
            PlayerHp = PlayerMaxHp;

            // Om man stängde av musiken i settings så spelas inte encounter ljudet
            if (!MusicMuteDoStuff)
            {
                encounter.Play();
            }
            // Liten animation att man stötte på en fiende
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
            // Samma som ovan, stänger av musiken beroende på om inställningen är på eller inte.
            if (!MusicMuteDoStuff)
            {
                battle.PlayLooping();
            }
            // Hela slagsmålet som körs i en loop. CheckForWin och CheckForLose körs för att kolla om man har vunnit eller förlorat, om det stämmer så slutar loopen.
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
                // Nu är det fiendens turn. Den gör sin attack och sen checkar om jag har förlorat.
                EnemyAttackYou();
                CheckForWin();
                CheckForLose();
                Task.Delay(2000).Wait();
                // Nu är det min turn igen.
            }

            // Hela min turn, den körs i while loopen tills den blir stoppad av antingen CheckForWin eller CheckForLose
            void YourTurn()
            {
                while (options)
                {
                    Console.Clear();
                    // Skriver ut min hp
                    ShowHealthPlayer();
                    // Skriver ut fiendes hp
                    ShowHealthEnemy();
                    // Placerar den långa linjen på rad 25 och färgar den grön
                    Console.SetCursorPosition(0, 25);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    // UI för sina moves med descriptions till höger.
                    Console.WriteLine("   Light attack    -    Always hits but low damage");
                    Console.WriteLine("   Heavy attack    -    High risk but big damage");
                    Console.WriteLine("   Dodge Attack    -    Protect yourself from an enemy attack");
                    // Placerar sin pil beroende på vilken move man selectar
                    Console.SetCursorPosition(1, choice + 26);
                    Console.Write(">");
                    // Skriver ut fiendens ASCII-art
                    EnemyArt();

                    var key = Console.ReadKey(true);
                    // Kollar om input är lika med Up arrow och choice > 0 stoppar så man inte går out of bounds. Choice-- gör så man kan gå ner.
                    if (key.Key == ConsoleKey.UpArrow && choice > 0) { choice--; }
                    // Samma sak som ovan fast för när man går ner och choice++ stoppar så man inte kan gå hur långt ner som man vill.
                    else if (key.Key == ConsoleKey.DownArrow && choice < 2) { choice++; }
                    // Om input är enter på nån av alternativen så kommer den göra sin attack.
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        switch (choice)
                        {
                            case 0:
                                // Skriver ut sin attack results längst upp i hörnet efter man har selectat LowAttack
                                Console.SetCursorPosition(0, 0);
                                LowAttack();
                                break;
                            case 1:
                                // Samma som ovan fast med HighAttack
                                Console.SetCursorPosition(0, 0);
                                HighAttack();
                                break;
                            case 2:
                                // Samma som ovan fast med BlockAttack
                                Console.SetCursorPosition(0, 0);
                                BlockAttack();
                                break;
                        }
                        // När man har selectat sin move så färgar den gröna linjen till röd för att visa att det är inte din turn längre.
                        Console.SetCursorPosition(0, 25);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.SetCursorPosition(0, 2);
                        break;
                    }
                }
            }

            // Skriver ut mitt HP, den skriver ut den röda och sen den gröna.
            // Gröna är på den röda och försvinner beroende på hur mycket HP man har förlorat.
            // När gröna försvinner ser man det röda som är under den gröna.
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
                Console.WriteLine($"HP: {PlayerHp}/{PlayerMaxHp}" + " ");
            }

            // Samma som ovan fast för fiender. HP och namnet beror på vilken fiende det är man möter.
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
                // Skriver ut fiendernas namn och hur mycket HP de har
                if (EnemyName[RandomEnemy] == "Chicken")
                {
                    Console.SetCursorPosition(59, 4);
                    Console.WriteLine("Chicken");
                    Console.SetCursorPosition(58, 6);
                    Console.WriteLine($"HP: {EnemyHps[RandomEnemy]}/{EnemyMaxHP}" + " ");
                }
                else if (EnemyName[RandomEnemy] == "Fox")
                {
                    Console.SetCursorPosition(59, 4);
                    Console.WriteLine("Fox");
                    Console.SetCursorPosition(55, 6);
                    Console.WriteLine($"HP: {EnemyHps[RandomEnemy]}/{EnemyMaxHP}" + " ");
                }
                else if (EnemyName[RandomEnemy] == "Goblin")
                {
                    Console.SetCursorPosition(60, 4);
                    Console.WriteLine("Goblin");
                    Console.SetCursorPosition(55, 6);
                    Console.WriteLine($"HP: {EnemyHps[RandomEnemy]}/{EnemyMaxHP}" + " ");
                }
                else if (EnemyName[RandomEnemy] == "Cat")
                {
                    Console.SetCursorPosition(61, 4);
                    Console.WriteLine("Cat");
                    Console.SetCursorPosition(55, 6);
                    Console.WriteLine($"HP: {EnemyHps[RandomEnemy]}/{EnemyMaxHP}" + " ");
                }
                else
                {
                    Console.SetCursorPosition(57, 4);
                    Console.WriteLine($"God of Ants");
                    Console.SetCursorPosition(58, 6);
                    Console.WriteLine($"HP: {EnemyHps[RandomEnemy]}/{EnemyMaxHP}" + " ");
                }
                Console.SetCursorPosition(0, 3);
            }

            // LowAttack moves
            void LowAttack()
            {
                // Liten rolig grej jag la till, om fienden är en katt så kan man inte skada den för den är för gullig. Du skulle väl inte vilja skada en katt, eller hur?
                if (EnemyName[RandomEnemy] == "Cat")
                {
                    Console.WriteLine("You missed because the cat was too cute.");
                    return;
                }
                // Du kan inte skada en gud.
                if (EnemyName[RandomEnemy] == "Ant")
                {
                    Console.WriteLine("You are too weak to hurt him.");
                    return;
                }
                // Räknar ut ett tal för oddsOfCrit och sen kollar om variabeln stämmer med det slumpmässiga talet så kör den if-statement.
                oddsOfCrit = rand.Next(1, 11);
                if (oddsOfCrit == 10)
                {
                    // Om man critar så väljer den ett slumpmässig mängd damage som är högre än vanlig hit.
                    YourDamage = rand.Next(40, 51);
                    // Fienden förlorar hp beroende på vad YourDamage blev.
                    EnemyHps[RandomEnemy] -= YourDamage;
                    Console.WriteLine("- CRITICAL HIT -");
                    Console.WriteLine($"You hit the {EnemyName[RandomEnemy]} for {YourDamage} damage!");
                    // Fiendens HP uppdateras efter sin attack.
                    ShowHealthEnemy();
                }
                else
                {
                    // Om man inte critar så blir det en normal attack som är mycket svagare.
                    YourDamage = rand.Next(10, 21);
                    EnemyHps[RandomEnemy] -= YourDamage;
                    Console.WriteLine($"You hit the {EnemyName[RandomEnemy]} for {YourDamage} damage.");
                    ShowHealthEnemy();
                }
            }

            // Pretty much samma som LowAttack fast istället räknar ut om sin big damage attack lyckades slå fienden, om den misslyckas så säger den att man missade.
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
                if (oddsOfSuccess > 4)
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

            // Blockerar man så sätter den block boolen till true och säger att man tar ut sin shield.
            void BlockAttack()
            {
                block = true;
                Console.WriteLine("You took out your shield.");
            }

            // Ganska slarvigt skrivet men det funkar!
            void EnemyAttackYou()
            {
                // Om man valde "Dodge attack" (void BlockAttack) så skippar den hela fiendens chans att attackera och säger att man blockerade fiendes attack.
                if (!block)
                {
                    // Om EnemyName[RandomEnemy] är "Ant" så dödar den dig instantly
                    if (EnemyName[RandomEnemy] == "Ant")
                    {
                        Console.WriteLine($"The {EnemyName[RandomEnemy]} used their godly powers to obliterate you for 99999 damage.");
                        PlayerHp -= 99999;
                        // Uppdaterar din HP
                        ShowHealthPlayer();
                        return;
                    }
                    // Om SpecialAttackToggle sattes på från if-satsen som är under den här så kommer fienden använda sin special attack och ta 100 damage.
                    if (SpecialAttackToggle)
                    {
                        Console.WriteLine($"The {EnemyName[RandomEnemy]} used their special attack and hit you for 100 damage!");
                        PlayerHp -= 100;
                        // Stänger av SpecialAttackToggle så nästa move är inte en till special attack.
                        SpecialAttackToggle = false;
                        ShowHealthPlayer();
                        return;
                    }
                    else { }
                    // Om oddsOfSuccess är 9 eller 10 så kommer fienden chargea upp sin special attack och sätter på SpecialAttackToggle.
                    // Nästa move är guaranterat att bli fiendens special attack om man inte har blockat.
                    oddsOfSuccess = rand.Next(1, 11);
                    if (oddsOfSuccess > 8)
                    {
                        Console.WriteLine($"The {EnemyName[RandomEnemy]} is charging up a special attack!");
                        SpecialAttackToggle = true;
                        return;
                    }
                    // Om talet inte stämde så kör den fiendens andra attacker.
                    else
                    {
                        // Kycklingen har större chans att crita dig (50% istället för 10%) om den misslyckas kör den en svagare normal attack
                        if (EnemyName[RandomEnemy] == "Chicken")
                        {
                            oddsOfCrit = rand.Next(1, 7);
                            if (oddsOfCrit > 3)
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
                    // Om fienden inte är en katt, myra eller kyckling så körs den här istället
                    oddsOfSuccess = rand.Next(1, 7);
                    // 5/6 att den successfully får till en attack annars missar den.
                    if (oddsOfSuccess > 1)
                    {
                        // 10% att den critar
                        oddsOfCrit = rand.Next(1, 11);
                        if (oddsOfCrit == 10)
                        {
                            TakenDamage = rand.Next(50, 76);
                            Console.WriteLine("- CRITICAL HIT -");
                            Console.WriteLine($"The {EnemyName[RandomEnemy]} hit you for {TakenDamage} damage!");
                            PlayerHp -= TakenDamage;
                            ShowHealthPlayer();
                        }
                        // Om den inte critar så gör det en normal attack
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
                // Om man blockar fiendens attack och om den fienden är katten så kommer den springa in i din shield och skada sig själv.
                else if (EnemyName[RandomEnemy] == "Cat")
                {
                    Console.WriteLine("The cat ran into your shield and hit their head");
                    EnemyHps[RandomEnemy] -= 25;
                    ShowHealthEnemy();
                }
                else if (EnemyName[RandomEnemy] == "Ant")
                {
                    battle.Stop();
                    Console.WriteLine("Blocking my attack? It is futile.");
                    Task.Delay(2000).Wait();
                    Console.WriteLine("I, the God of ants, am an unstoppable force!");
                    Task.Delay(3000).Wait();
                    Console.WriteLine("I shall give you divine punishment!\n");
                    Task.Delay(3000).Wait();
                    Console.WriteLine($"The {EnemyName[RandomEnemy]} used their godly powers to obliterate you for \n999999999 damage!");
                    PlayerHp -= 999999999;
                    ShowHealthPlayer();
                    Task.Delay(4000).Wait();
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("I am not done with you...");
                    Task.Delay(2500).Wait();
                    Console.WriteLine("Say goodbye to your game!");
                    Task.Delay(2500).Wait();
                    kamehameha.Play();
                    Task.Delay(1000).Wait();
                    Console.WriteLine("Kame...");
                    Task.Delay(1500).Wait();
                    Console.WriteLine("Hame...");
                    Task.Delay(1500).Wait();
                    Console.WriteLine("HA!!!!!!!");
                    Task.Delay(1000).Wait();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Task.Delay(1000).Wait();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    Task.Delay(1000).Wait();
                    Environment.Exit(0);
                }
                // Blockera fienden attack och om de hade chargeat sin special attack så skulle den stängas av
                else
                {
                    Console.WriteLine($"You blocked the enemies attack.");
                    SpecialAttackToggle = false;
                }
                // Stänger av block så nästa enemy attack inte blockeras också lol
                block = false;
            }

            // Checkar ifall man har vunnit
            void CheckForWin()
            {
                // Om fiendens HP är under eller lika med 0 så kommer den stoppa musiken och spela victory låt
                if (EnemyHps[RandomEnemy] <= 0)
                {
                    if (!MusicMuteDoStuff)
                    {
                        battle.Stop();
                        victory.Play();
                    }
                    // På grund av sättet katten förlorar så skrevs victory texten i fel rad och blandades ihop med victory texten
                    // Jag fixade katt problemet men när det inte var en katt så skrev den extra tom rad så jag gjorde bara så här och problemet löste sig
                    if (EnemyName[RandomEnemy] != "Cat")
                    {
                        Console.SetCursorPosition(0, 1);
                    }
                    // Grön text som säger att du vann
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine($"You have defeated the {EnemyName[RandomEnemy]}!");
                    Console.WriteLine("\nYou win!");
                    Task.Delay(4000).Wait();
                    Console.Clear();
                    // Frågar om du vill köra igen
                    PlayAgain();
                }
            }

            // Checkar ifall man har förlorat
            void CheckForLose()
            {
                // I princip samma grej som CheckForWin men istället ifall du får slut på HP
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

            // Frågar om man vill spela igen
            void PlayAgain()
            {
                Console.ResetColor();
                Console.WriteLine("Do you want to play again?\n(Y/N)");
                string PlayAgain = Console.ReadLine().ToLower();
                // Lägger till möjliga svar man svarar med om man vill köra igen, jag la till extra alternativ för mina
                // playtesters var dumma nog och skrev andra saker än "y" som "sure" eller "ja"
                if (PlayAgain != "y" && PlayAgain != "yes" && PlayAgain != "ja" && PlayAgain != "sure")
                {
                    Environment.Exit(0);
                }
                else
                // Om man vill köra igen så resettas fiendens HP till deras default value.
                {
                    Restart = true;
                    victory.Stop();
                    Console.Clear();
                    EnemyHps[RandomEnemy] = EnemyMaxHP;
                    SpecialAttackToggle = false;
                }
            }

            // Här har vi alla fina ASCII-arts av fienderna
            void EnemyArt()
            {
                // Sätter ASCII-arten på mitten av skärmen.
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(@"                 
                                                       '\__
                                                        (o )     ___
                                                        <>(_)(_)(___)
                                                          < < > >
                                                          ' ' ` `");
                    Console.ResetColor();
                }
            }
        }
    }
}