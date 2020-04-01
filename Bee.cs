using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nature
{
    class Bee
    {
        public int VisitedFlowers { get; set; }
        private bool fly;
        public bool Fly
        {
            get
            {
                return fly;
            }
            set
            {
                fly = value;
                if (fly)
                {
                    Console.WriteLine("Bee starts to fly");
                    OnStartFly();
                }
                else
                {
                    Console.WriteLine("Bee flies to sleep");
                }
            }
        }
        public void GetTime(object sender, PropertyChangedEventArgs eArg)
        {
            Sun sun = sender as Sun;
            if((sun.Time==Time.Sunrise || sun.Time == Time.Morning) && !Fly)
            {
                Fly = true;
            }
            else if((sun.Time==Time.Sunset || sun.Time == Time.Evening) && Fly)
            {
                Fly = false;
            }
            
        }
        public Bee()
        {
            VisitedFlowers = 0;
        }
        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);
        public event PropertyChangedEventHandler StartFly;
        protected void OnStartFly()
        {
            if (StartFly != null)
            {
                PropertyChangedEventArgs eArg = new PropertyChangedEventArgs("Fly");
                StartFly(this, eArg);
            }
        }
        public void VisitFlower(Flower flower)
        {
            if(flower.Open)
            {
                Console.WriteLine("Bee visits {0}", flower.Name);
                VisitedFlowers += 1;
            }
        }
    
    }
}
