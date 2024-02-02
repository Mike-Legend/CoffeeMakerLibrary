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
            int water = 0;
            int coffee = 0;           
            Mock<IContainer> watercontain = new Mock<IContainer>();
            Mock<IContainer> coffeecontain = new Mock<IContainer>();
            watercontain.Setup(x => x.GetVolume()).Returns(() => water);
            watercontain.Setup(x => x.SetVolume(It.IsAny<int>())).Callback((int y) => water = y);         
            watercontain.Setup(x => x.DispensePortion(It.IsAny<int>())).Callback((int y) => water -= y);
            watercontain.Setup(x => x.Fill()).Callback(() => water = 10);
            watercontain.Setup(x => x.IsEmpty).Returns(() => water == 0);
            watercontain.Setup(x => x.Empty()).Callback(() => water = 0);
            coffeecontain.Setup(x => x.GetVolume()).Returns(() => coffee);
            coffeecontain.Setup(x => x.SetVolume(It.IsAny<int>())).Callback((int y) => coffee = y);
            coffeecontain.Setup(x => x.DispensePortion(It.IsAny<int>())).Callback((int y) => { coffee -= y; if (coffee < 0) throw new InvalidOperationException(); });
            coffeecontain.Setup(x => x.Fill()).Callback(() => coffee = 10);
            coffeecontain.Setup(x => x.IsEmpty).Returns(() => coffee == 0);
            coffeecontain.Setup(x => x.Empty()).Callback(() => coffee = 0);
            CoffeeMaker coffeeMaker = new CoffeeMaker(watercontain.Object, coffeecontain.Object);
            coffeeMaker.Fill();

            // ACT
            // Call MakeCoffee() requesting a Grande(3).
            coffeeMaker.MakeCoffee(Portion.Grande);

            // ASSERT
            // Assert that the coffee volume is now 7 using the CoffeeVolume property.
            // Assert that the water volume is now 7 using the WaterVolume property.
            Assert.AreEqual(7, coffeeMaker.CoffeeVolume);
            Assert.AreEqual(7, coffeeMaker.WaterVolume);        
        }

        [TestMethod]
        public void MOQTest2()
        {
            // ARRANGE
            // Set the coffee to 8 using the CoffeeVolume property.
            // Set the water to 6 using the WaterVolume property.
            int water = 0;
            int coffee = 0;
            Mock<IContainer> watercontain = new Mock<IContainer>();
            Mock<IContainer> coffeecontain = new Mock<IContainer>();
            watercontain.Setup(x => x.GetVolume()).Returns(() => water);
            watercontain.Setup(x => x.SetVolume(It.IsAny<int>())).Callback((int y) => water = y);
            watercontain.Setup(x => x.DispensePortion(It.IsAny<int>())).Callback((int y) => { water -= y; if (water < 0) throw new InvalidOperationException(); });
            watercontain.Setup(x => x.Fill()).Callback(() => water = 10);
            watercontain.Setup(x => x.IsEmpty).Returns(() => water == 0);
            watercontain.Setup(x => x.Empty()).Callback(() => water = 0);
            coffeecontain.Setup(x => x.GetVolume()).Returns(() => coffee);
            coffeecontain.Setup(x => x.SetVolume(It.IsAny<int>())).Callback((int y) => coffee = y);
            coffeecontain.Setup(x => x.DispensePortion(It.IsAny<int>())).Callback((int y) => { coffee -= y; if (coffee < 0) throw new InvalidOperationException(); });
            coffeecontain.Setup(x => x.Fill()).Callback(() => coffee = 10);
            coffeecontain.Setup(x => x.IsEmpty).Returns(() => coffee == 0);
            coffeecontain.Setup(x => x.Empty()).Callback(() => coffee = 0);
            CoffeeMaker coffeeMaker = new CoffeeMaker(watercontain.Object, coffeecontain.Object);
            coffeeMaker.CoffeeVolume = 8;
            coffeeMaker.WaterVolume = 6;

            // ACT 
            // MakeCoffee() requesting a Tall(2).
            coffeeMaker.MakeCoffee(Portion.Tall);

            // ASSERT
            // Assert that the coffee volume is now 6 using the CoffeeVolume property.
            // Assert that the water volume is now 4 using the WaterVolume property.
            Assert.AreEqual(6, coffeeMaker.CoffeeVolume);
            Assert.AreEqual(4, coffeeMaker.WaterVolume);
        }

        [TestMethod]
        public void MOQTest3()
        {
            // ARRANGE
            // Set the coffee to 5 using the CoffeeVolume property.
            // Set the water to 5 using the WaterVolume property. 
            int water = 0;
            int coffee = 0;
            Mock<IContainer> watercontain = new Mock<IContainer>();
            Mock<IContainer> coffeecontain = new Mock<IContainer>();
            watercontain.Setup(x => x.GetVolume()).Returns(() => water);
            watercontain.Setup(x => x.SetVolume(It.IsAny<int>())).Callback((int y) => water = y);
            watercontain.Setup(x => x.DispensePortion(It.IsAny<int>())).Callback((int y) => { water -= y; if (water < 0) throw new InvalidOperationException(); });
            watercontain.Setup(x => x.Fill()).Callback(() => water = 10);
            watercontain.Setup(x => x.IsEmpty).Returns(() => water == 0);
            watercontain.Setup(x => x.Empty()).Callback(() => water = 0);
            coffeecontain.Setup(x => x.GetVolume()).Returns(() => coffee);
            coffeecontain.Setup(x => x.SetVolume(It.IsAny<int>())).Callback((int y) => coffee = y);
            coffeecontain.Setup(x => x.DispensePortion(It.IsAny<int>())).Callback((int y) => { coffee -= y; if (coffee < 0) throw new InvalidOperationException(); });
            coffeecontain.Setup(x => x.Fill()).Callback(() => coffee = 10);
            coffeecontain.Setup(x => x.IsEmpty).Returns(() => coffee == 0);
            coffeecontain.Setup(x => x.Empty()).Callback(() => coffee = 0);
            CoffeeMaker coffeeMaker = new CoffeeMaker(watercontain.Object, coffeecontain.Object);
            coffeeMaker.CoffeeVolume = 5;
            coffeeMaker.WaterVolume = 5;

            // ACT
            // Clean() the coffee maker.
            coffeeMaker.Clean();

            // ASSERT
            // Assert that the coffee volume is now 0 using the IsEmpty property.
            Assert.AreEqual(true, coffeeMaker.IsEmpty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MOQTest4()
        {
            // ARRANGE
            // Set the coffee to 4 using the CoffeeVolume property.
            // Set the water to 2 using the WaterVolume property. 
            int water = 0;
            int coffee = 0;
            Mock<IContainer> watercontain = new Mock<IContainer>();
            Mock<IContainer> coffeecontain = new Mock<IContainer>();
            watercontain.Setup(x => x.GetVolume()).Returns(() => water);
            watercontain.Setup(x => x.SetVolume(It.IsAny<int>())).Callback((int y) => water = y);
            watercontain.Setup(x => x.DispensePortion(It.IsAny<int>())).Callback((int y) => { water -= y; if (water < 0) throw new InvalidOperationException(); });
            watercontain.Setup(x => x.Fill()).Callback(() => water = 10);
            watercontain.Setup(x => x.IsEmpty).Returns(() => water == 0);
            watercontain.Setup(x => x.Empty()).Callback(() => water = 0);
            coffeecontain.Setup(x => x.GetVolume()).Returns(() => coffee);
            coffeecontain.Setup(x => x.SetVolume(It.IsAny<int>())).Callback((int y) => coffee = y);
            coffeecontain.Setup(x => x.DispensePortion(It.IsAny<int>())).Callback((int y) => { coffee -= y; if (coffee < 0) throw new InvalidOperationException(); });
            coffeecontain.Setup(x => x.Fill()).Callback(() => coffee = 10);
            coffeecontain.Setup(x => x.IsEmpty).Returns(() => coffee == 0);
            coffeecontain.Setup(x => x.Empty()).Callback(() => coffee = 0);
            CoffeeMaker coffeeMaker = new CoffeeMaker(watercontain.Object, coffeecontain.Object);
            coffeeMaker.CoffeeVolume = 4;
            coffeeMaker.WaterVolume = 2;

            // ACT
            // MakeCoffee requesting a Grande(3).
            coffeeMaker.MakeCoffee(Portion.Grande);

            // EXPECTED EXCEPTION
            // Check that an InvalidOperationException is thrown.
        }


        [TestMethod]
        public void MOQTest5()
        {
            // ARRANGE
            int water = 0;
            int coffee = 0;
            Mock<IContainer> watercontain = new Mock<IContainer>();
            Mock<IContainer> coffeecontain = new Mock<IContainer>();
            watercontain.Setup(x => x.GetVolume()).Returns(() => water);
            watercontain.Setup(x => x.SetVolume(It.IsAny<int>())).Callback((int y) => water = y);
            watercontain.Setup(x => x.DispensePortion(It.IsAny<int>())).Callback((int y) => { water -= y; if (water < 0) throw new InvalidOperationException(); });
            watercontain.Setup(x => x.Fill()).Callback(() => water = 10);
            watercontain.Setup(x => x.IsEmpty).Returns(() => water == 0);
            watercontain.Setup(x => x.Empty()).Callback(() => water = 0);
            coffeecontain.Setup(x => x.GetVolume()).Returns(() => coffee);
            coffeecontain.Setup(x => x.SetVolume(It.IsAny<int>())).Callback((int y) => coffee = y);
            coffeecontain.Setup(x => x.DispensePortion(It.IsAny<int>())).Callback((int y) => { coffee -= y; if (coffee < 0) throw new InvalidOperationException(); });
            coffeecontain.Setup(x => x.Fill()).Callback(() => coffee = 10);
            coffeecontain.Setup(x => x.IsEmpty).Returns(() => coffee == 0);
            coffeecontain.Setup(x => x.Empty()).Callback(() => coffee = 0);
            CoffeeMaker coffeeMaker = new CoffeeMaker(watercontain.Object, coffeecontain.Object);

            // ACT
            // Clean() the CoffeeMaker.
            coffeeMaker.Clean();

            // VERIFY
            // Verify that cleaning the CoffeeMaker calls the water containers Clean() once.
            // Verify that cleaning the CoffeeMaker calls the coffee containers Clean() twice.
            watercontain.Verify(x => x.Clean(), Times.Once());
            coffeecontain.Verify(x => x.Clean(), Times.Exactly(2));
        }

    }
}
