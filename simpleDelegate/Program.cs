using System.ComponentModel;
using System.Threading.Channels;

class Program
{
    public delegate void GruzchikHandler(string msg);
    class Gruzchik
    {
        GruzchikHandler gruzdel;

        public void HealthGruzchik(GruzchikHandler gruzcall)
        {
            gruzdel = gruzcall;
        }

        public int Weight { get; set; } // вес, который несет грузчик

        public int MaxWeight { get; set; }

        public string Name { get; set; }

        bool gruzchikIsDead; // punks not dead, а грузчик -  может!

        public Gruzchik(int weight, int maxWeight, string name)
        {
            Weight = weight;
            MaxWeight = maxWeight;
            Name = name;
        }

        public void Sostoyanie(int energy)
        {
            if (gruzchikIsDead)
            {
                if(gruzdel != null)
                {
                    gruzdel("грузчик не выдержал и умер");
                }
            }
            else
            {
                Weight += energy;
                if( 10 == (MaxWeight - Weight)
                    && gruzdel != null)
                {
                    gruzdel("господи, как я заебался");
                }
                if(Weight >= MaxWeight)
                {
                    gruzchikIsDead = true;
                }
                else
                {
                    Console.WriteLine($"{Name} тащит {Weight}");
                }
            }
        }
    }


    
    static void Main(string[] args)
    {
        Gruzchik Vasya = new Gruzchik(10,100, "Vasyan");

        Vasya.HealthGruzchik(Print);

        Console.WriteLine($"{Vasya.Name} приступил к работе");
        for (int i = 0; i < 6; i++)
        {
            
            Vasya.Sostoyanie(20);
            
        }

    }

    static void Print(string message)
    {
        
        Console.WriteLine($"=> {message}");

    }
   














}




        





 