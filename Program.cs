using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Player 1: Enter your name:");
            Samurai sam = new Samurai(Console.ReadLine());
            Console.WriteLine("Player 2: Enter your name:");
            Ninja nancy = new Ninja(Console.ReadLine());
            Console.WriteLine("Player 3: Enter your name:");
            Wizard wally = new Wizard(Console.ReadLine());
            Human[] heroes = new Human[]{sam, nancy, wally};
            Zombie zack = new Zombie();
            Zombie zoe = new Zombie();
            Spider sally = new Spider();
            Enemy[] enemies = new Enemy[]{zack, zoe, sally};
            string enemyStr = "[0] Zombie Zack, [1] Zombie Zoe, [2] Spider Sally";
            bool inPlay = true;
            int turn = 0;
            string winners;

            while (inPlay) {
                //loop back to first player after 3rd player
                if (turn >= heroes.Length) { turn = 0; }
                Console.WriteLine("{0} {1}, your turn! What would you like to do?",heroes[turn].name, heroes[turn].player_name);
                string attack;
                string victim = "";
                if (heroes[turn] is Samurai) {
                    Samurai.get_options();
                    attack = Console.ReadLine();
                    if (attack == "a" || attack == "d") {
                        victim = askForTarget(enemyStr);
                    }
                    if (attack == "a") {
                        sam.attack(enemies[victim]);
                    }
                    else if (attack == "d") {
                        sam.death_blow(enemies[victim]);
                    }
                    else if (attack == "m") {
                        sam.meditate();
                    }
                    else {
                        Console.WriteLine("Invalid attack. Attack failed.");
                    }
                }
                else if (heroes[turn] is Ninja) {
                    Ninja.get_options();
                    attack = Console.ReadLine();
                    if (attack == "a" || attack == "s") {
                        victim = askForTarget(enemyStr);
                    }
                    if (attack == "a") {
                        nancy.attack(enemies[victim]);
                    }
                    else if (attack == "s") {
                        nancy.steal(enemies[victim]);
                    }
                    else if (attack == "g") {
                        nancy.get_away();
                    }
                    else {
                        Console.WriteLine("Invalid attack. Attack failed.");
                    }
                }
                else if (heroes[turn] is Wizard) {
                    Wizard.get_options();
                    attack = Console.ReadLine();
                    if (attack == "a" || attack == "f") {
                        victim = askForTarget(enemyStr);
                    }
                    if (attack == "a") {
                        wally.attack(enemies[victim]);
                    }
                    else if (attack == "f") {
                        wally.fireball(enemies[victim]);
                    }
                    else if (attack == "h") {
                        wally.heal();
                    }
                    else {
                        Console.WriteLine("Invalid attack. Attack failed.");
                    }
                }
                //victim's turn to attack; can only attack if still alive
                string enemyName = "";
                    if (enemies[victim].health > 0){
                        if (victim == 0) {
                        zack.attack(heroes[turn]);
                        enemyName = "Zombie Zack";
                    }
                    else if (victim == 1) {
                        zoe.attack(heroes[turn]);
                        enemyName = "Zombie Zoe";
                    }
                    else if (victim == 2) {
                        sally.attack(heroes[turn]);
                        enemyName = "Spider Sally";
                    }
                }
                
                Console.WriteLine($"You attacked {enemyName} whose health is now {enemies[victim].health}.");
                Console.WriteLine($"{enemyName} attacks you! Your health is now {heroes[turn].health}.");
                //check each iteration for end of game

                turn++;
            //end turn
            }

        }
        static string askForTarget(string enemies) {
            Console.WriteLine("Who do you want to attack? {0}", enemies);
            string v = Console.ReadLine();
            //validate string input
            // if (v > 2 || v < 0) {
            //     Console.WriteLine("Invalid entry. Try again.");
            //     askForTarget(enemies);
            // }
            return v;
        }
        static string enemiesInPlay(Enemy[] enemies) {
            string enemiesInPlay = "";
            foreach (Enemy e in enemies) {
                if (e.health > 0) {
                    enemiesInPlay += "";
                }
            }
            return enemiesInPlay;
        }
        static void attackEnemy(string type, Enemy[] enemies) {
            if (type == "Samurai") {
                Samurai.get_options();
            }
            else if (type == "Ninja") {
                Ninja.get_options();
            }
            else if (type == "Wizard") {
                Wizard.get_options();
            }
            string attack = Console.ReadLine();
            int victim;
            if ( attack=="a" || (type=="Samurai" && attack=="d") || (type=="Ninja" && attack=="s") || (type=="Wizard" && attack=="f") ) {
                victim = askForTarget(enemiesInPlay(enemies));
            }
            else {
                Console.WriteLine("Invalid attack. Try again.");
                attackEnemy(type, enemies);
            }

        }
    }
}
