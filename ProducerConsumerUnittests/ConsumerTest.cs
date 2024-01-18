using ProducerConsumer;
using NUnit.Framework;

namespace ProducerConsumerUnittests;

[TestFixture]
public class ConsumerTests
{
    [Test]
    public void ConsumeOneCar_WhenParkingLotNotEmpty_ShouldRemoveCarFromParkingLot()
    {
        // Arrange
        var buffer = new Buffer<Car>(1); // Kleiner Puffer für Testzwecke
        buffer.Push(new Car("Car1")); // Füllen Sie den Puffer
        var consumer = new Consumer(buffer);

        // Act
        consumer.ConsumeOneCar();

        // Assert
        Assert.That(buffer.Empty, Is.True); // Überprüfe,ob der Car Enfernt wurde
    }
}