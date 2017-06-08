using System;
using System.Collections.Generic;

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
            List<Human> heroes = new List<Human>{sam, nancy, wally};
            Zombie zack = new Zombie("Zack");
            Zombie zoe = new Zombie("Zoe");
            Spider sally = new Spider("Sally");
            List<Enemy> enemies = new List<Enemy>{zack, zoe, sally};
            
            bool inPlay = true;
            int turn = 0;

            while (inPlay) {
                //loop back to first player after 3rd player
                if (turn >= heroes.Count) { turn = 0; }
                Console.WriteLine("{0} {1}, your turn! What would you like to do? (Your health: {2})",heroes[turn].name, heroes[turn].player_name, heroes[turn].health);
                object[] attack = new object[2];
                int victim = -1;
                if (heroes[turn] is Samurai) {
                    attack = attackEnemy("Samurai", enemies);
                    if (attack[1] is int) {
                        victim = (int)attack[1];
                    }
                    if (attack[0] is string) {
                        string action = (string)attack[0];
                        if (action == "a") {
                            sam.attack(enemies[victim]);
                            Console.WriteLine($"You attacked {enemies[victim].play_name}!");
                            printEnemyHealth(enemies[victim].health);
                        }
                        else if (action == "d") {
                            sam.death_blow(enemies[victim]);
                            if (enemies[0].health == 0) {
                                Console.WriteLine($"You successfully performed death blow on {enemies[victim].play_name}! Enemy is down.");
                            }
                            else {
                                Console.WriteLine($"You attempted death blow on {enemies[victim].play_name} but his health was too high. No effect.");
                            }
                            
                        }
                        else {
                            sam.meditate();
                            Console.WriteLine($"You meditated. Your health is now {heroes[turn].health}!");
                        }
                    }
                }
                else if (heroes[turn] is Ninja) {
                    attack = attackEnemy("Ninja", enemies);
                    if (attack[1] is int) {
                        victim = (int)attack[1];
                    }
                    if (attack[0] is string) {
                        string action = (string)attack[0];
                        if (action == "a") {
                            nancy.attack(enemies[victim]);
                            Console.WriteLine($"You attacked {enemies[victim].play_name}!");
                            printEnemyHealth(enemies[victim].health);
                        }
                        else if (action == "s") {
                            nancy.steal(enemies[victim]);
                            Console.WriteLine($"You stole from {enemies[victim].play_name}! Your health is now {heroes[turn].health}.");
                            printEnemyHealth(enemies[victim].health);
                        }
                        else {
                            nancy.get_away();
                            Console.WriteLine($"You got away and your health is now {heroes[turn].health}.");
                        }
                    }
                }
                else if (heroes[turn] is Wizard) {
                    attack = attackEnemy("Wizard", enemies);
                    if (attack[1] is int) {
                        victim = (int)attack[1];
                    }
                    if (attack[0] is string) {
                        string action = (string)attack[0];
                        if (action == "a") {
                            wally.attack(enemies[victim]);
                            Console.WriteLine($"You attacked {enemies[victim].play_name}!");
                            printEnemyHealth(enemies[victim].health);
                        }
                        else if (action == "f") {
                            wally.fireball(enemies[victim]);
                            Console.WriteLine($"You fireballed {enemies[victim].play_name}!");
                            printEnemyHealth(enemies[victim].health);
                        }
                        else {
                            wally.heal();
                            Console.WriteLine($"You healed. Your health is now {heroes[turn].health}.");
                        }
                    }
                }

                if (Enemy != -1) {
                    Enemy v = enemies[victim];
                }
                foreach (Enemy e in enemies) {
                    if (e.health <= 0) {
                        enemies.Remove(e);
                    }
                }
                //victim's turn to attack; can only attack if still alive
                if (enemies.IndexOf(v) != -1){
                    if (v.play_name == "Zack") {
                        zack.attack(heroes[turn]);
                    }
                    else if (v.play_name == "Zoe") {
                        zoe.attack(heroes[turn]);
                    }
                    else if (v.play_name == "Sally") {
                        sally.attack(heroes[turn]);
                    }
                    Console.WriteLine($"Enemy retaliated! Your health is now {heroes[turn].health}");
                }
                
                if (heroes[turn].health <= 0) {
                    Console.WriteLine($"{heroes[turn].player_name} died :(");
                    heroes.Remove(heroes[turn]);
                }
                
                // Console.WriteLine($"{enemyName} attacks you! Your health is now {heroes[turn].health}.");
                //check each iteration for end of game
                if (heroes.Count == 0) {
                    inPlay = false;
                    System.Console.WriteLine("Enemies win :(");
                }
                else if (enemies.Count == 0) {
                    inPlay = false;
                    System.Console.WriteLine("Allies win!!");
                }
                
                turn++;
            //end turn
            
            }
        }
        static void printEnemyHealth(int health) {
            Console.WriteLine($"Enemy's health is now {health}.");
        }
        static int askForTarget(string enemies) {
            Console.WriteLine("Who do you want to attack? {0}", enemies);
            int v = Convert.ToInt16(Console.ReadLine());
            //validate string input
            if (v < 0 || v > 2) {
                Console.WriteLine("Invalid entry. Try again.");
                askForTarget(enemies);
            }
            return v;
        }
        static string enemiesInPlay(List<Enemy> enemies) {
            string enemiesInPlay = "";
            int counter = 0;
            foreach (Enemy e in enemies) {
                enemiesInPlay += $"[{counter}] - {e.play_name} -";
                counter++;
            }
            return enemiesInPlay;
        }
        static object[] attackEnemy(string type, List<Enemy> enemies) {
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
            int victim = -1;
            if ( attack=="a" || (type=="Samurai" && attack=="d") || (type=="Ninja" && attack=="s") || (type=="Wizard" && attack=="f") ) {
                victim = askForTarget(enemiesInPlay(enemies));
            }
            else if ((type=="Samurai" && attack=="m") || (type=="Ninja" && attack=="g") || (type=="Wizard" && attack=="h")) {
                //valid responses
            }
            else {
                Console.WriteLine("Invalid attack. Try again.");
                attackEnemy(type, enemies);
            }
            object[] result = new object[] {attack, victim};
            return result;
        }
    }
}
