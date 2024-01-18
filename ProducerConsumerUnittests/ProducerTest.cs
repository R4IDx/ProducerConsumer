using ProducerConsumer;
using NUnit.Framework;

namespace ProducerConsumerUnittests;

[TestFixture]
public class ProducerTests
{
    [Test]
    public void ProduceOneCar_WhenParkingLotNotFull_ShouldPushCarToParkingLot()
    {
        // Arrange
        var buffer = new Buffer<Car>(1); // Kleiner Puffer für Testzwecke
        var producer = new Producer(buffer);

        // Act
        producer.ProduceOneCar();

        // Assert
        Assert.That(buffer.Full, Is.True); //// Überprüfe,geadded wurde
    }
}