using System;

class Drone
{
    // Private data members (not accessible from outside)
    private int battery = 100;
    private bool isFlying = false;
    private string direction = "None";

    // Take Off Method
    public void TakeOff()
    {
        if (battery > 20)
        {
            isFlying = true;
            battery -= 10;
            Console.WriteLine("Drone has taken off.");
        }
        else
        {
            Console.WriteLine("Battery too low. Cannot take off.");
        }
    }

    // Move Method
    public void Move(string dir)
    {
        if (isFlying)
        {
            if (battery > 5)
            {
                direction = dir;
                battery -= 5;
                Console.WriteLine("Drone moved towards " + direction);
            }
            else
            {
                Console.WriteLine("Low battery. Cannot move.");
            }
        }
        else
        {
            Console.WriteLine("Drone is not flying. Take off first.");
        }
    }

    // Land Method
    public void Land()
    {
        if (isFlying)
        {
            isFlying = false;
            Console.WriteLine("Drone has landed.");
        }
        else
        {
            Console.WriteLine("Drone is already on the ground.");
        }
    }

    // Check Status Method
    public void CheckStatus()
    {
        Console.WriteLine("Battery Life: " + battery + "%");
        Console.WriteLine("Direction: " + direction);

        if (isFlying)
            Console.WriteLine("Drone is Flying");
        else
            Console.WriteLine("Drone is Not Flying");
    }
}

class Program
{
    static void Main()
    {
        Drone d1 = new Drone();

        d1.CheckStatus();
        d1.TakeOff();
        d1.Move("North");
        d1.Move("East");
        d1.CheckStatus();
        d1.Land();
        d1.CheckStatus();
    }
}
