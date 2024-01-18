using System;
using System.Collections.Generic;
using System.Threading;
namespace ProducerConsumer;
public class Buffer<T>
{
    // Die Warteschlange (Queue), die die Elemente des Buffers enthält
    private Queue<T> buffer;
    // Die maximale Größe des Buffers
    private int size;
    // Ein Mutex (Mutex: "Mutual Exclusion") zum Sperren kritischer Abschnitte
    private object mutex = new object();

    // Konstruktor, der einen Buffer mit der angegebenen Größe erstellt
    public Buffer(int bufferSize)
    {
        buffer = new Queue<T>(bufferSize);
        size = bufferSize;
    }
    // Push auf Buffer
    public void Push(T element)
    {
        // Verwende ein Mutex, um den Zugriff auf den kritischen Abschnitt zu synchronisieren
        lock (mutex)
        {
            // Überprüfe, ob der Buffer voll ist, wenn ja: wird exception
            if (buffer.Count >= size)
            {
                throw new InvalidOperationException("Buffer is full");
            }
            // Füge das Element zum Buffer hinzu
            buffer.Enqueue(element);
        }
    }

    // Pop aus dem Buffer
    public T Pop()
    {
        // Verwende ein Mutex, um den Zugriff auf den kritischen Abschnitt zu synchronisieren
        lock (mutex)
        {
            // Überprüfe, ob der Buffer leer ist
            if (buffer.Count == 0)
            {
                // Wenn ja, wirf eine Exception
                throw new InvalidOperationException("Buffer is empty");
            }
            // Entferne und gib das erste Element aus dem Buffer zurück
            return buffer.Dequeue();
        }
    }

    // Methode zum Überprüfen, ob der Buffer voll ist
    public bool Full()
    {
        // Verwende ein Mutex, um den Zugriff auf den kritischen Abschnitt zu synchronisieren
        lock (mutex)
        {
            // Gib zurück, ob die Anzahl der Elemente im Buffer gleich der maximalen Größe ist
            return buffer.Count >= size;
        }
    }

    // Methode zum Überprüfen, ob der Buffer leer ist
    public bool Empty()
    {
        // Verwende ein Mutex, um den Zugriff auf den kritischen Abschnitt zu synchronisieren
        lock (mutex)
        {
            // Gib zurück, ob die Anzahl der Elemente im Buffer gleich null ist
            return buffer.Count == 0;
        }
    }
}
