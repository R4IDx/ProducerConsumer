using ProducerConsumer;
using NUnit.Framework;

namespace ProducerConsumerUnittests;

[TestFixture]
public class CarTests
{
    [Test]
    public void Car_Constructor_ShouldSetModel()
    {
        // Arrange
        string expectedModel = "TestModel";

        // Act
        Car car = new Car(expectedModel);

        // Assert
        Assert.That(car.Model, Is.EqualTo(expectedModel));
    }

    [Test]
    public void Car_Model_Property_ShouldBeSettable()
    {
        // Arrange
        Car car = new Car("InitialModel");
        string newModel = "NewModel";

        // Act
        car.Model = newModel;

        // Assert
        Assert.That(car.Model, Is.EqualTo(newModel));
    }

    [Test]
    public void Car_Model_Property_ShouldBeGettable()
    {
        // Arrange
        string expectedModel = "TestModel";
        Car car = new Car(expectedModel);

        // Act
        string retrievedModel = car.Model;

        // Assert
        Assert.That(retrievedModel, Is.EqualTo(expectedModel));
    }
}