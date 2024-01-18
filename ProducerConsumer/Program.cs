using System;
using System.Collections.Generic;
using System.Threading;
namespace ProducerConsumer;

public class Program
{
    public static void Main()
    {
        RunProgram();
    }

    public static void RunProgram()
    {
        // Festlegen der Anzahl von Produzenten und Konsumenten
        int numProducers = 2;
        int numConsumers = 3;

        // Erstellen eines Puffers für Autos mit der Größe 10
        Buffer<Car> parkingBuffer = new Buffer<Car>(10);

        // Starten Produzenten-Threads
        List<Thread> producerThreads = StartProducerThreads(numProducers, parkingBuffer);

        // Starten Konsumenten-Threads
        List<Thread> consumerThreads = StartConsumerThreads(numConsumers, parkingBuffer);

        // Warten auf eine Benutzereingabe, um das Programm offen zu halten
        Console.ReadLine();

        
        foreach (Thread producerThread in producerThreads)
        {
            producerThread.Join();
        }

        foreach (Thread consumerThread in consumerThreads)
        {
            consumerThread.Join();
        }
    }
    // Startet die Produzenten-Threads
    public static List<Thread> StartProducerThreads(int numProducers, Buffer<Car> parkingBuffer)
    {
        List<Thread> producerThreads = new List<Thread>();
        for (int i = 0; i < numProducers; i++)
        {
            // Erstellt einen Produzenten und den zugehörigen Thread
            Producer producer = new Producer(parkingBuffer);
            Thread producerThread = new Thread(new ThreadStart(producer.Produce));
            // Fügt den Thread zur Liste hinzu und startet ihn
            producerThreads.Add(producerThread);
            producerThread.Start();
        }
        return producerThreads;
    }
    // Startet die Konsumer-Threads
    public static List<Thread> StartConsumerThreads(int numConsumers, Buffer<Car> parkingBuffer)
    {
        List<Thread> consumerThreads = new List<Thread>();
        for (int i = 0; i < numConsumers; i++)
        {
            // Erstellt einen Konsumenten und den zugehörigen Thread
            Consumer consumer = new Consumer(parkingBuffer);
            Thread consumerThread = new Thread(new ThreadStart(consumer.Consume));
            // Fügt den Thread zur Liste hinzu und startet ihn
            consumerThreads.Add(consumerThread);
            consumerThread.Start();
        }
        return consumerThreads;
    }
}