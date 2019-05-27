using System;
using System.Collections;

namespace Workshop
{
    // idea of improvement.. Create Weak/Strong/Boss monster
    // by implementing a interface Monster.
    class Program
    {
        private static Random random = new Random();
        public static ArrayList warriorsAlive = new ArrayList();
        public static ArrayList deadWarriors = new ArrayList();
        private static int score = 0;
        public static int nbrOfDead = 0;

        static void Main(string[] args)
        {

            int bossKilled = 0;
            int strongMonsterKilled = 0;
            int weakMonsterKilled = 0;
            int i = 0;
            string name;

            //allow the user to create 4 warriors
            while (i < 4)
            {
                Console.WriteLine("Give the name of your Warrior {0} ", i);
                name = Console.ReadLine();
                Warrior war = new Warrior(name);
                warriorsAlive.Add(war);
                i++;
            }

            do //while the player has warriors alive
            {
                Warrior war = (Workshop.Warrior)warriorsAlive[0];
                while (war.IsAlive()) //as long as the current warrior is alive create monster to fight
                {
                    int number = Dice.ThrowDice(3);
                    switch (number)
                    {
                        case 1:  //create a weak monster
                            WeakMonster monsterW = new WeakMonster();
                            while (monsterW.IsAlive())
                            {
                                war.Attack(monsterW);
                                if (monsterW.IsAlive())
                                {
                                    monsterW.Attack(war);
                                    if (!war.IsAlive())
                                        break;
                                }
                            }
                            if (!monsterW.IsAlive())
                            {
                                score += monsterW.GetPoint();
                                weakMonsterKilled++;
                            }
                            break;
                        case 2:  //create a strong monster
                            StrongMonster monsterS = new StrongMonster();
                            while (monsterS.IsAlive())
                            {
                                war.Attack(monsterS);
                                if (monsterS.IsAlive())
                                {
                                    monsterS.Attack(war);
                                    if (!war.IsAlive())
                                        break;
                                }
                            }
                            if (!monsterS.IsAlive())
                            {
                                score += monsterS.GetPoint();
                                monsterS.DropItem(war);
                                strongMonsterKilled++;
                            }
                            break;
                        case 3: //create a boss
                            BossMonster boss = new BossMonster();
                            while (boss.IsAlive())
                            {
                                war.Attack(boss);
                                if (boss.IsAlive())
                                {
                                    boss.Attack(war);
                                    if (!war.IsAlive())
                                        break;
                                }
                            }
                            if (!boss.IsAlive())
                            {
                                boss.DropItem(war);
                                score += boss.GetPoint();
                                bossKilled++;
                            }

                            break;
                    }
                }
                nbrOfDead++;
            } while (nbrOfDead != 4); //end of game

            Console.WriteLine("All your warriors are dead...");
            Console.WriteLine("You still manage to get a score of {0}", score);
            Console.WriteLine("You killed {0} weak monsters, \n{1} strong monsters, \n{2} boss.", weakMonsterKilled, strongMonsterKilled, bossKilled);
        }
    }

    public class Warrior
    {
        //const + variables
        private const int DAMAGE = 10;
        private int lifePoint; // { get; private set; }
        private bool alive;
        private string name;
        private int damage;

        //constructor
        public Warrior(String name)
        {
            this.name = name;
            this.lifePoint = 100;
            this.damage = DAMAGE;
            this.alive = true;
        }

        //attack on monsters
        public void Attack(WeakMonster monster)
        {
            int att = ThrowDice(this.damage);
            Console.WriteLine("Hitting monster with {0}", att);
            monster.GotHit(att);
            Console.WriteLine("Monster is left with {0}", monster.GetLifePoint());
        }

        public void Attack(StrongMonster monster)
        {
            int att = ThrowDice(this.damage);
            Console.WriteLine("Hitting monster with {0}", att);
            monster.GotHit(att);
            Console.WriteLine("Monster is left with {0}", monster.GetLifePoint());
        }

        public void Attack(BossMonster boss)
        {
            int att = ThrowDice(this.damage);
            Console.WriteLine("Hitting boss with {0}", att);
            boss.GotHit(att);
            Console.WriteLine("Boss is left with {0}", boss.GetLifePoint());
        }

        //when the warrior receive damage
        public void GotHit(int damageReceived)
        {
            int currentHealth = this.GetLifePoint();
            int newHealth = currentHealth - damageReceived;

            if (newHealth <= 0)
            {
                this.SetAlive(false);
                this.SetLifePoint(0);
                Program.warriorsAlive.Remove(this);
                Program.deadWarriors.Add(this);
            }
            else
            {
                this.SetLifePoint(newHealth);
            }
        }

        //heal a warrior
        public void Heal()
        {
            Console.WriteLine("{0} used potion.", this.name);
            int currentHealth = this.GetLifePoint();
            int newHealth = currentHealth + 25;
            if (newHealth > 100)
                this.SetLifePoint(100);
            else
                this.SetLifePoint(newHealth);
        }

        //revive a warrior
        public void Revive()
        {
            Program.deadWarriors.Remove(this);
            this.SetAlive(true);
            this.SetLifePoint(100);
            Program.warriorsAlive.Add(this);
        }

        //allow to use the throw dive method from the Dice class within the warrior class
        public int ThrowDice(int valeur)
        {
            return Dice.ThrowDice(valeur);
        }

        //getters and setters
        public string GetName()
        {
            return this.name;
        }
        public int GetLifePoint()
        {
            return this.lifePoint;
        }

        public void SetLifePoint(int lifePoint)
        {
            this.lifePoint = lifePoint;
        }

        public bool IsAlive()
        {
            return this.alive;
        }

        public void SetAlive(bool alive)
        {
            this.alive = alive;
        }
    }

    public class WeakMonster
    {
        //const + variables
        private const int DAMAGE = 3;
        private const int POINTS = 10;
        private int lifePoint; //{ get; private set; }
        private bool alive; // { get; private set; }
        private int points;
        private int damage;

        //constructor
        public WeakMonster()
        {
            this.alive = true;
            this.lifePoint = 50;
            this.damage = DAMAGE;
            this.points = POINTS;
        }

        //when the monster attack a warrior   @param warrior getting hit
        public void Attack(Warrior war)
        {
            int att = ThrowDice(this.damage);
            Console.WriteLine("Monster attack {0} dealing {1} dmg.", war.GetName(), att);
            war.GotHit(att);
        }

        //when the monster receive damage
        public void GotHit(int damageReceived)
        {
            int currentHealth = GetLifePoint();
            int newHealth = currentHealth - damageReceived;

            if (newHealth <= 0)
            {
                this.SetAlive(false);
                this.SetLifePoint(0);
            }
            else
            {
                this.SetLifePoint(newHealth);
            }
        }

        //allow to use the throw dive method from the Dice class within the warrior class
        public int ThrowDice(int value)
        {
            return Dice.ThrowDice(value);
        }

        //getters and setters
        public int GetLifePoint()
        {
            return this.lifePoint;
        }

        public void SetLifePoint(int lifePoint)
        {
            this.lifePoint = lifePoint;
        }

        public bool IsAlive()
        {
            return this.alive;
        }

        public void SetAlive(bool alive)
        {
            this.alive = alive;
        }

        public int GetPoint()
        {
            return POINTS;
        }
    }

    public class StrongMonster
    {
        //const + variables
        private const int DAMAGE = 5;
        private const int POINTS = 20;
        private int lifePoint; //{ get; private set; }
        private bool alive; // { get; private set; }
        private int points;
        private int damage;

        //constructor
        public StrongMonster()
        {
            this.alive = true;
            this.lifePoint = 100;
            this.damage = DAMAGE;
            this.points = POINTS;
        }

        //when the monster attack a warrior   @param warrior getting hit
        public void Attack(Warrior war)
        {
            int att = ThrowDice(this.damage);
            Console.WriteLine("Monster attack {0} dealing {1} dmg.", war.GetName(), att);
            war.GotHit(att);
        }

        //when the monster receive damage
        public void GotHit(int damageReceived)
        {
            int currentHealth = this.GetLifePoint();
            int newHealth = currentHealth - damageReceived;

            if (newHealth <= 0)
            {
                this.SetAlive(false);
                this.SetLifePoint(0);
            }
            else
            {
                this.SetLifePoint(newHealth);
            }
        }

        //allow to use the throw dive method from the Dice class within the warrior class
        public int ThrowDice(int value)
        {
            return Dice.ThrowDice(value);
        }

        //check if the player get a potion or not.
        public void DropItem(Warrior war)
        {
            int success = ThrowDice(2);
            if (success == 1)
            {
                war.Heal();
            }
        }

        //getters and setters
        public int GetLifePoint()
        {
            return this.lifePoint;
        }

        public void SetLifePoint(int lifePoint)
        {
            this.lifePoint = lifePoint;
        }

        public bool IsAlive()
        {
            return this.alive;
        }

        public void SetAlive(bool alive)
        {
            this.alive = alive;
        }

        public int GetPoint()
        {
            return POINTS;
        }
    }

    public class BossMonster
    {
        //const + variables
        private const int DAMAGE = 7;
        private const int POINTS = 100;
        private int lifePoint; //{ get; private set; }
        private bool alive; // { get; private set; }
        private int points;
        private int damage;

        //constructor
        public BossMonster()
        {
            this.alive = true;
            this.lifePoint = 150;
            this.damage = DAMAGE;
            this.points = POINTS;
        }

        //when the monster attack a warrior   @param warrior getting hit
        public void Attack(Warrior war)
        {
            int att = ThrowDice(this.damage);
            Console.WriteLine("Boss attack {0} dealing {1} dmg.", war.GetName(), att);
            war.GotHit(att);
        }

        //when the monster receive damage
        public void GotHit(int damageReceived)
        {
            int currentHealth = this.GetLifePoint();
            int newHealth = currentHealth - damageReceived;

            if (newHealth <= 0)
            {
                this.SetAlive(false);
                this.SetLifePoint(0);
            }
            else
            {
                this.SetLifePoint(newHealth);
            }
        }

        //allow to use the throw dive method from the Dice class within the warrior class
        public int ThrowDice(int value)
        {
            return Dice.ThrowDice(value);
        }

        //check if the player get a potion or not.  
        public void DropItem(Warrior currentWar)
        {
            int success = ThrowDice(2);

            //got the loot
            if (success == 1)
            {
                if (Program.deadWarriors.Count == 0)
                {
                    currentWar.Heal();
                    currentWar.Heal();
                }
                else
                {
                    Warrior war = (Workshop.Warrior)Program.deadWarriors[0];
                    Program.deadWarriors.Remove(war);
                    Program.nbrOfDead--;
                    war.Revive();
                    Program.warriorsAlive.Add(war);
                }
            }
        }

        //getters and setters
        public int GetLifePoint()
        {
            return this.lifePoint;
        }

        public void SetLifePoint(int lifePoint)
        {
            this.lifePoint = lifePoint;
        }

        public bool IsAlive()
        {
            return this.alive;
        }

        public void SetAlive(bool alive)
        {
            this.alive = alive;
        }

        public int GetPoint()
        {
            return POINTS;
        }
    }

    public static class Dice
    {
        private static Random random = new Random();

        //throw a dice of 6 faces
        public static int ThrowDice()
        {
            return random.Next(1, 7);
        }

        //throw a dice of value faces
        public static int ThrowDice(int value)
        {
            return random.Next(1, value + 1);
        }
    }
}