using System;
using System.Threading;
namespace ProducerConsumer;
public class Consumer
{
    // Der gemeinsame Puffer
    private Buffer<Car> parkingLot;
    // Konstruktor für Puffer
    public Consumer(Buffer<Car> buffer)
    {
        parkingLot = buffer;
    }
    
    public void ConsumeOneCar()
    {
        // Zufällige Wartezeit, um den Prozess zu simulieren
        Thread.Sleep(new Random().Next(1000, 3000)); // Zufällige Wartezeit
        // Sperre (Lock), um auf den gemeinsamen Puffer zuzugreifen
        lock (parkingLot)
        {
            // Wenn der Puffer nicht mehr voll ist, wecke alle wartenden Threads (Produzenten)
            if (parkingLot.Full())      
            {
                Monitor.PulseAll(parkingLot);
            }
            // Überprüfe, ob der Puffer nicht leer ist
            if (!parkingLot.Empty())
            {
                // Entferne ein Auto aus dem Puffer
                Car removedCar = parkingLot.Pop();
                // Konsolenausgabe: Auto entfernt
                Console.WriteLine($"Car {removedCar.Model} leaves the parking lot.");
            }
            else
            {
                // Der Parkplatz ist leer, der Konsument muss warten
                Console.WriteLine("Parking lot is empty. Consumer is sleeping.");
                // Der Konsument wartet auf ein Signal, dass Autos im Puffer verfügbar sind
                Monitor.Wait(parkingLot);
            }
        }
    }
    // Dauerschleife, zu testzwecken ausgelagert
    public void Consume()
    {
        while (true)
        {
            ConsumeOneCar();
        }
    }
}