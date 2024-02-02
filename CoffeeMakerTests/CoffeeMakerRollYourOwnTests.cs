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
            CoffeeMaker coffee = new CoffeeMaker();
            coffee.Fill();

            // ACT
            // Call MakeCoffee() requesting a Grande(3).
            coffee.MakeCoffee(Portion.Grande);

            // ASSERT
            // Assert that the coffee volume is now 7 using the CoffeeVolume property.
            // Assert that the water volume is now 7 using the WaterVolume property.
            Assert.AreEqual(coffee.CoffeeVolume, 7);
        }

        [TestMethod]
        public void RYOTest2()
        {
            // ARRANGE
            // Set the coffee to 8 using the CoffeeVolume property.
            // Set the water to 6 using the WaterVolume property.

            // ACT 
            // MakeCoffee() requesting a Tall(2).

            // ASSERT
            // Assert that the coffee volume is now 6 using the CoffeeVolume property.
            // Assert that the water volume is now 4 using the WaterVolume property.
        }

        [TestMethod]
        public void RYOTest3()
        {
            // ARRANGE
            // Set the coffee to 5 using the CoffeeVolume property.
            // Set the water to 5 using the WaterVolume property. 

            // ACT
            // Clean() the coffee maker.

            // ASSERT
            // Assert that the coffee volume is now 0 using the IsEmpty property.
        }

        [TestMethod]
        public void RYOTest4()
        {
            // ARRANGE
            // Set the coffee to 4 using the CoffeeVolume property.
            // Set the water to 2 using the WaterVolume property. 

            // ACT
            // MakeCoffee requesting a Grande(3).

            // EXPECTED EXCEPTION
            // Check that an InvalidOperationException is thrown.
        }
    }

}
