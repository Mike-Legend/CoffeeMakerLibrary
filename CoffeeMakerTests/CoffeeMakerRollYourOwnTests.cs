using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMakerLibrary;

namespace CoffeeMakerTests
{
    [TestClass]
    public class CoffeeMakerRollYourOwnTests
    {

        [TestMethod]
        public void RYOTest1()
        {
            // ARRANGE
            // Call Fill() to fill the coffee maker.            
            CoffeeMakerRollYourOwnContainer waterContainer = new CoffeeMakerRollYourOwnContainer();
            CoffeeMakerRollYourOwnContainer coffeeContainer = new CoffeeMakerRollYourOwnContainer();
            CoffeeMaker coffee = new CoffeeMaker(waterContainer, coffeeContainer);
            coffee.Fill();

            // ACT
            // Call MakeCoffee() requesting a Grande(3).
            coffee.MakeCoffee(Portion.Grande);

            // ASSERT
            // Assert that the coffee volume is now 7 using the CoffeeVolume property.
            // Assert that the water volume is now 7 using the WaterVolume property.
            Assert.AreEqual(7, coffee.CoffeeVolume);
            Assert.AreEqual(7, coffee.WaterVolume);
        }

        [TestMethod]
        public void RYOTest2()
        {
            // ARRANGE
            // Set the coffee to 8 using the CoffeeVolume property.
            // Set the water to 6 using the WaterVolume property.
            CoffeeMakerRollYourOwnContainer waterContainer = new CoffeeMakerRollYourOwnContainer();
            CoffeeMakerRollYourOwnContainer coffeeContainer = new CoffeeMakerRollYourOwnContainer();
            CoffeeMaker coffee = new CoffeeMaker(waterContainer, coffeeContainer);
            coffee.CoffeeVolume = 8;
            coffee.WaterVolume = 6;

            // ACT 
            // MakeCoffee() requesting a Tall(2).
            coffee.MakeCoffee(Portion.Tall);

            // ASSERT
            // Assert that the coffee volume is now 6 using the CoffeeVolume property.
            // Assert that the water volume is now 4 using the WaterVolume property.
            Assert.AreEqual(6, coffee.CoffeeVolume);
            Assert.AreEqual(4, coffee.WaterVolume);
        }

        [TestMethod]
        public void RYOTest3()
        {
            // ARRANGE
            // Set the coffee to 5 using the CoffeeVolume property.
            // Set the water to 5 using the WaterVolume property. 
            CoffeeMakerRollYourOwnContainer waterContainer = new CoffeeMakerRollYourOwnContainer();
            CoffeeMakerRollYourOwnContainer coffeeContainer = new CoffeeMakerRollYourOwnContainer();
            CoffeeMaker coffee = new CoffeeMaker(waterContainer, coffeeContainer);
            coffee.CoffeeVolume = 5;
            coffee.WaterVolume = 5;

            // ACT
            // Clean() the coffee maker.
            coffee.Clean();

            // ASSERT
            // Assert that the coffee volume is now 0 using the IsEmpty property.
            Assert.AreEqual(true, coffee.IsEmpty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RYOTest4()
        {
            // ARRANGE
            // Set the coffee to 4 using the CoffeeVolume property.
            // Set the water to 2 using the WaterVolume property. 
            CoffeeMakerRollYourOwnContainer waterContainer = new CoffeeMakerRollYourOwnContainer();
            CoffeeMakerRollYourOwnContainer coffeeContainer = new CoffeeMakerRollYourOwnContainer();
            CoffeeMaker coffee = new CoffeeMaker(waterContainer, coffeeContainer);
            coffee.CoffeeVolume = 4;
            coffee.WaterVolume = 2;

            // ACT
            // MakeCoffee requesting a Grande(3).
            coffee.MakeCoffee(Portion.Grande);

            // EXPECTED EXCEPTION
            // Check that an InvalidOperationException is thrown.           
        }
    }

}
