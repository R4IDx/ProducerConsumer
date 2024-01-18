using ProducerConsumer;
using NUnit.Framework;

namespace ProducerConsumerUnittests;

[TestFixture]
public class BufferTests
{
    [Test]
    public void Push_WhenBufferNotFull_ShouldAddElement()
    {
        // Arrange
        var buffer = new Buffer<int>(5);

        // Act
        buffer.Push(42);

        // Assert
        Assert.That(buffer.Full, Is.False);
        Assert.That(buffer.Empty, Is.False);
        Assert.That(buffer.Pop(), Is.EqualTo(42));
    }

    [Test]
    public void Push_WhenBufferFull_ShouldThrowException()
    {
        // Arrange
        var buffer = new Buffer<int>(2);
        buffer.Push(1);
        buffer.Push(2);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => buffer.Push(3));
    }

    [Test]
    public void Pop_WhenBufferNotEmpty_ShouldRemoveAndReturnElement()
    {
        // Arrange
        var buffer = new Buffer<int>(3);
        buffer.Push(1);
        buffer.Push(2);

        // Act
        var result = buffer.Pop();

        // Assert
        Assert.That(result, Is.EqualTo(1));
        Assert.That(buffer.Full, Is.False);
        Assert.That(buffer.Empty, Is.False);
    }

    [Test]
    public void Pop_WhenBufferEmpty_ShouldThrowException()
    {
        // Arrange
        var buffer = new Buffer<double>(4);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => buffer.Pop());
    }

    [Test]
    public void Full_WhenBufferFull_ShouldReturnTrue()
    {
        // Arrange
        var buffer = new Buffer<char>(2);
        buffer.Push('A');
        buffer.Push('B');

        // Act & Assert
        Assert.That(buffer.Full, Is.True);
    }

    [Test]
    public void Full_WhenBufferNotFull_ShouldReturnFalse()
    {
        // Arrange
        var buffer = new Buffer<float>(3);

        // Act & Assert
        Assert.That(buffer.Full, Is.False);
    }
}