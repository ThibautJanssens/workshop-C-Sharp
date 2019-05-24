using System;
namespace Workshop
{
    class Program
    {
        private static Random random = new Random();
        private static int score = 0;
        private static Warrior[] warriors = new Warrior[4];
        static void Main(string[] args)
        {
            
            int i = 0;
            
            while(i < 4){
                Console.WriteLine("");
                Warrior war = new Warrior(150);

                warriors[i] = war;
                i++;
            }
        }

        private static void Jeu1()
        {
            
            int cptFacile = 0;
            int cptDifficile = 0;
            while (war.isAlive)
            {
                MonstreFacile monstre = FabriqueDiceMonstre();
                while (monstre.isAlive && war.isAlive)
                {
                    war.Attaque(monstre);
                    if (monstre.isAlive)
                        monstre.Attaque(war);
                }

                if (war.isAlive)
                {
                    if (monstre is MonstreDifficile)
                        cptDifficile++;
                    else
                        cptFacile++;
                }
                else
                {
                    Console.WriteLine("Snif, vous êtes mort...");
                    break;
                }
            }
            Console.WriteLine("Bravo !!! Vous avez tué {0} monstres faciles et {1} monstres difficiles. Vous avez {2} points.", cptFacile, cptDifficile, cptFacile + cptDifficile * 2);
        }
    }

    public class WeakMonster
    {
        private const int damage = 3;
        private const int points = 10;
        private int lifePoint { get; private set; }
        private bool alive { get; private set; }
        public WeakMonster()
        {
            this.alive = true;
            this.lifePoint = 50;
            this.damage = damage;
            this.points = points;
        }

        public void Attack(Warrior war)
        {
            war.GotHit(ThrowDice(this.damage));
        }

        public void GotHit(int damageReceived)
        {
            int currentHealth = LifePoint.get();
            int newHealth = currentHealth - damageReceived;
            
            if(this.newHealth <= 0){
                alive.set(false);
                LifePoint.set(0);
            }else{
                LifePoint.set(newHealth);
            }
        }

        public int ThrowDice(int valeur)
        {
            return Dice.ThrowDice(valeur);
        }
/*
        public int getLifePoint(){
            return this.lifePoint;
        }

        public void setLifePoint(int lifePoint){
            this.lifePoint = lifePoint;
        }
 */
    }

    public static class Dice
    {
        private static Random random = new Random();

        public static int ThrowDice()
        {
            return random.Next(1, 7);
        }

        public static int ThrowDice(int valeur)
        {
            return random.Next(1, valeur+1);
        }
    }

//TODO BOSS
    public class Boss
    {
        public int LifePoint = 150;
        public bool isAlive
        {
            get { return LifePoint > 0; }
        }

        public Boss(int points)
        {
            LifePoint = points;
        }

        public void Attaque(Warrior personnage)
        {
            int nbPoints = ThrowDice(26);
            personnage.SubitDicegats(nbPoints);
        }

        public void SubitDicegats(int valeur)
        {
            LifePoint -= valeur;
        }

        private int ThrowDice(int valeur)
        {
            return Dice.ThrowDice(valeur);
        }
    }

//TO DO 
    public class MonstreDifficile : WeakMonster 
    {
        private const int DicegatsSort = 5;

        public override void Attaque(Warrior Warrior)
        {
            base.Attaque(Warrior);
            Warrior.SubitDicegats(SortMagique());
        }

        private int SortMagique()
        {
            int valeur = Dice.ThrowDice();
            if (valeur == 6)
                return 0;
            return DicegatsSort * valeur;
        }
    }

    public class Warrior
    {
        public int lifePoint { get; private set; }

        public const int DAMAGE = 10;
        public bool isAlive
        {
            get { return this.lifePoint > 0; }
        }

        public Warrior(String name)
        {
            this.name = name;
            this.lifePoint = 100;
            this.damage = DAMAGE;
        }

        public void Attack(WeakMonster monster)
        {
            monster.GotHit(ThrowDice(this.damage));
            if (monster.getLifePoint() <= 0)
                monstre.SubitDicegats();
        }

        public void Attaque(Boss boss)
        {
            int nbPoints = ThrowDice(26);
            boss.SubitDicegats(nbPoints);
        }

        public int ThrowDice(int valeur)
        {
            return Dice.ThrowDice(valeur);
        }

        public void SubitDicegats(int Dicegats)
        {
            if (!BouclierFonctionne())
                LifePoint -= Dicegats;
        }
    }
}
