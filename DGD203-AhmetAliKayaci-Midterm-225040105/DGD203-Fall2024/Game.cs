namespace SuperHeroSimulation
{
    public class Game
    {
        #region VARIABLES
        private Player _player;
        private Boss _boss;
        private int _turnCount;
        #endregion
        
        #region METHODS
        public void StartGame()
        {
            Console.WriteLine("Welcome to the Super Hero Simulation!");
            ChooseHero();  
            StartBossFight();  
        }

        private void ChooseHero()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Choose your strength level (1-10):");
            int strength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose your speed level (1-10):");
            int speed = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose your intelligence level (1-10):");
            int intelligence = Convert.ToInt32(Console.ReadLine());

            _player = new Player(name, strength, speed, intelligence);
            _player.DisplayStats();
        }

        private void StartBossFight()
        {
            _boss = new Boss("Boss", 100, 15);
            Console.WriteLine("Boss fight starts!");

            _turnCount = 0;

            while (_boss.IsAlive() && _turnCount < 4)
            {
                _boss.TakeDamage(0); 
                string bossAttackSide = _boss.BossAttack(); 
                if (_player.Intelligence < 5)
                {
                    Console.WriteLine("Your intelligence is low, you cannot predict which side the boss will attack from!");
                }
                else
                {
                    Console.WriteLine($"The boss will attack from the {bossAttackSide} side with his sword!");
                }

                Console.WriteLine("Which direction will you dodge?");
                Console.WriteLine("1 - Left");
                Console.WriteLine("2 - Right");
                int dodgeChoice = Convert.ToInt32(Console.ReadLine());

                bool dodgeSuccess = (dodgeChoice == 1 && bossAttackSide == "right") || (dodgeChoice == 2 && bossAttackSide == "left");
                if (dodgeSuccess)
                {
                    Console.WriteLine("You dodged successfully!");

                    if (_player.Speed < 5)
                    {
                        Console.WriteLine("But your speed is low, you were slow and got a little hurt!");
                        _player.TakeDamage(_boss.Damage / 2); 
                    }
                }
                else
                {
                    Console.WriteLine("You dodged the wrong way! The boss hit you.");
                    _player.TakeDamage(100); 
                    break;
                }
                Console.WriteLine("It's time for your counter-attack!");
                Console.WriteLine("1 - Head");
                Console.WriteLine("2 - Chest");
                int attackChoice = Convert.ToInt32(Console.ReadLine());
                string attackTarget = attackChoice == 1 ? "head" : "chest";
                int damageDealt = _player.CalculateDamage(attackTarget);
                _boss.TakeDamage(damageDealt);

                Console.WriteLine($"{_player.Name} dealt {damageDealt} damage to the {attackTarget}.");
                if (!_boss.IsAlive())
                {
                    Console.WriteLine($"{_player.Name} defeated the boss!");
                    break;
                }

                _turnCount++;
            }

            if (_turnCount == 4 && _boss.IsAlive())
            {
                Console.WriteLine("You couldn't defeat the boss! The game is over.");
            }
        }
        #endregion
    }
}
