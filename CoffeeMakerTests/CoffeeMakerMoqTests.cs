using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMakerLibrary;
using Moq;

namespace CoffeeMakerTests
{
    [TestClass]
    public class CoffeeMakerMoqTests
    {
        [TestMethod]
        public void MOQTest1()
        {
            // ARRANGE
            // Call Fill() to fill the coffee maker.
            Mock<IContainer> contain = new Mock<IContainer>();
            // ACT
            // Call MakeCoffee() requesting a Grande(3).

            // ASSERT
            // Assert that the coffee volume is now 7 using the CoffeeVolume property.
            // Assert that the water volume is now 7 using the WaterVolume property.
        }

        [TestMethod]
        public void MOQTest2()
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
        public void MOQTest3()
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
        public void MOQTest4()
        {
            // ARRANGE
            // Set the coffee to 4 using the CoffeeVolume property.
            // Set the water to 2 using the WaterVolume property. 

            // ACT
            // MakeCoffee requesting a Grande(3).

            // EXPECTED EXCEPTION
            // Check that an InvalidOperationException is thrown.
        }


        [TestMethod]
        public void MOQTest5()
        {
            // ARRANGE

            // ACT
            // Clean() the CoffeeMaker.

            // VERIFY
            // Verify that cleaning the CoffeeMaker calls the water containers Clean() once.
            // Verify that cleaning the CoffeeMaker calls the coffee containers Clean() twice.
        }

    }
}
