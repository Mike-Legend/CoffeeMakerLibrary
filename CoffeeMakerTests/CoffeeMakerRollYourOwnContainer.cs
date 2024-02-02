using System;
using CoffeeMakerLibrary;
using static System.Net.Mime.MediaTypeNames;

namespace CoffeeMakerTests
{
    public class CoffeeMakerRollYourOwnContainer : IContainer
    {
        int coffee;
        public int CoffeeVolume
        {
            get { return coffee; }
            set { coffee = value; }
        }

        bool IContainer.IsEmpty
        {
            get { if (coffee == 0) { return true; } else { return false; } }
        }

        void IContainer.DispensePortion(int portion)
        {
            if (coffee < portion)
            {
                throw new InvalidOperationException();
            }
            else
            {
                coffee -= portion;
            }
        }

        int IContainer.GetVolume()
        {
            return coffee;
        }

        void IContainer.SetVolume(int volume)
        {
            coffee = volume;
        }

        void IContainer.Empty()
        {
            coffee = 0;
        }

        void IContainer.Fill()
        {
            coffee = 10;
        }

        void IContainer.Clean()
        {
            coffee = 0;         
        }
    }

}
