using System;
using System.Threading;
namespace ProducerConsumer;
public class Producer
{
    // Der gemeinsame Puffer
    private Buffer<Car> parkingLot;

    // Konstruktor Puffer
    public Producer(Buffer<Car> buffer)
    {
        parkingLot = buffer;
    }

    public void ProduceOneCar()
    {
        // Zufällige Wartezeit, um den Produktionsprozess zu simulieren
        Thread.Sleep(new Random().Next(1000, 3000)); // Zufällige Wartezeit
        // Eine Sperre (Lock), um auf den gemeinsamen Puffer zuzugreifen
        lock (parkingLot)
        {
            // Wenn der Puffer nicht mehr leer ist, wecke alle wartenden Threads (Konsumenten)
            if (parkingLot.Empty()) 
            {
                Monitor.PulseAll(parkingLot);
            }
            // Überprüfe, ob der Puffer nicht voll ist
            if (!parkingLot.Full())
            {
                // Erstelle ein neues Auto mit einem eindeutigen Namen
                Car newCar = new Car("Car_" + Guid.NewGuid().ToString().Substring(0, 4));
                // Platziere das neue Auto im Puffer
                parkingLot.Push(newCar);
                // Konsolenausgabe: AUto hinzugefügt
                Console.WriteLine($"Car {newCar.Model} parks in the parking lot.");
            }
            else
            {
                // Der Parkplatz ist voll, der Produzent muss warten
                Console.WriteLine("Parking lot is full. Producer is sleeping.");
                // Der Produzent wartet auf ein Signal, dass Platz im Puffer frei ist
                Monitor.Wait(parkingLot);
            }
        }
    }
    // Dauerschleife, zu testzwecken ausgelagert
    public void Produce()
    {
        while (true)
        {
            ProduceOneCar();
        }
    }
}