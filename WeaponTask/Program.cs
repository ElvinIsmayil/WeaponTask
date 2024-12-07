using WeaponTask.Enums;
using WeaponTask.Exceptions;
using WeaponTask.Models;
using WeaponTaskHelper;

namespace WeaponTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon weapon = null; 

            while (weapon == null)
            {
                try
                {
                    int magazineCapacity;
                    do
                    {
                        Helper.ChangeTextColor(ConsoleColor.Green, "Enter Magazine Capacity:");
                        if (!int.TryParse(Console.ReadLine(), out magazineCapacity) || magazineCapacity <= 0)
                        {
                            Helper.ChangeTextColor(ConsoleColor.Red, "Invalid input! Please enter a positive integer for magazine capacity.");
                        }
                        else
                        {
                            break;
                        }
                    } while (true); 

                    int bulletCount;
                    do
                    {
                        Helper.ChangeTextColor(ConsoleColor.Green, "Enter Bullet Count:");
                        if (!int.TryParse(Console.ReadLine(), out bulletCount) || bulletCount < 0 || bulletCount > magazineCapacity)
                        {
                            Helper.ChangeTextColor(ConsoleColor.Red, $"Invalid input! Please enter a number between 0 and {magazineCapacity} for bullet count.");
                        }
                        else
                        {
                            break;
                        }
                    } while (true); 

                    int fireModeIndex;
                    do
                    {
                        Helper.ChangeTextColor(ConsoleColor.Yellow,
                           "\nChoose Fire Mode:\n" +
                           "1 - Single\n" +
                           "2 - Burst\n" +
                           "3 - Automatic\n");
                        Helper.ChangeTextColor(ConsoleColor.Green, "Enter Fire Mode:");
                        if (!int.TryParse(Console.ReadLine(), out fireModeIndex) || fireModeIndex < 1 || fireModeIndex > 3)
                        {
                            Helper.ChangeTextColor(ConsoleColor.Red, "Invalid input! Please enter a number between 1 and 3 for fire mode.");
                        }
                        else
                        {
                            break;
                        }
                    } while (true); 

                    FireModeEnum fireModeEnum = fireModeIndex switch
                    {
                        1 => FireModeEnum.Single,
                        2 => FireModeEnum.Burst,
                        3 => FireModeEnum.Automatic
                    };

                    weapon = new Weapon(magazineCapacity, bulletCount, fireModeEnum);

                    Helper.ChangeTextColor(ConsoleColor.Green, "\nThe Weapon has been successfully created!");
                    Helper.ChangeTextColor(ConsoleColor.Green,
                        $"\nDetails:\n" +
                        $"Magazine Capacity: {weapon.MagazineCapacity}\n" +
                        $"Bullet Count: {weapon.BulletCount}\n" +
                        $"Fire Mode: {weapon.FireMode}\n");
                }
                catch (Exception ex)
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, $"Error: {ex.Message}");
                    Console.WriteLine("\nLet's try again...\n");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            ConsoleKeyInfo keyinfo;
            do
            {
                Console.Clear();
                Helper.ChangeTextColor(ConsoleColor.Green,
                "-----------Main Menu------------\n" +
                "\n0 - Information\n" +
                "1 - Shoot\n" +
                "2 - Fire\n" +
                "3 - GetRemainingBulletCount\n" +
                "4 - Reload\n" +
                "5 - ChangeFireMode\n" +
                "6 - Edit\n" +
                "Escape - Exit\n");

                keyinfo = Console.ReadKey(intercept: true);

                switch (keyinfo.Key)
                {
                    case ConsoleKey.D0:
                        Console.Clear();
                        weapon.ShowInfo();
                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D1:
                        Console.Clear();
                        try
                        {
                            weapon.Shoot();
                        }
                        catch (OutOfBulletException ex)
                        {
                            Helper.ChangeTextColor(ConsoleColor.Red, ex.Message);
                        }
                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        try
                        {
                            weapon.Fire(weapon.FireMode);
                        }
                        catch (OutOfBulletException ex)
                        {
                            Helper.ChangeTextColor(ConsoleColor.Red, ex.Message);
                        }
                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        int remainingBulletCount = weapon.GetRemainingBulletCount();
                        if (remainingBulletCount == 0)
                        {
                            Console.WriteLine("The weapon is fully loaded!");
                        }
                        else
                        {
                            Console.WriteLine($"The remaining bullet count to fully load the weapon is: {remainingBulletCount}");
                        }
                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        remainingBulletCount = weapon.GetRemainingBulletCount();
                        if (remainingBulletCount == 0)
                        {
                            Console.WriteLine("The weapon is already fully loaded!");
                        }
                        else
                        {
                            weapon.Reload();
                        }
                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        Helper.ChangeTextColor(ConsoleColor.Yellow,
                           "Choose Fire Mode:\n" +
                           "1 - Single\n" +
                           "2 - Burst\n" +
                           "3 - Automatic\n");

                        Helper.ChangeTextColor(ConsoleColor.Green, "Enter Fire Mode:");

                        
                        FireModeEnum previousFireMode = weapon.FireMode;

                        
                        int newFireModeIndex = int.Parse(Console.ReadLine());
                        weapon.ChangeFireMode(newFireModeIndex);

                      
                        Helper.ChangeTextColor(ConsoleColor.Green,
                            $"\nThe Fire Mode has been successfully changed from {previousFireMode} to {weapon.FireMode}.");

                        

                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D6:
                        Console.Clear();
                        ConsoleKeyInfo editKeyInfo;

                        do
                        {
                            Console.Clear();
                            Helper.ChangeTextColor(ConsoleColor.Green, "-----------Edit Menu------------\n");
                            Console.WriteLine("\n1 - Change Magazine Capacity");
                            Console.WriteLine("2 - Change Bullet Count");
                            Console.WriteLine("Escape - Return to Main Menu");

                            editKeyInfo = Console.ReadKey(intercept: true);

                            switch (editKeyInfo.Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    int previousMagazineCapacity = weapon.MagazineCapacity;
                                    Console.WriteLine("Enter new magazine capacity:");
                                    int newMagazineCapacity = int.Parse(Console.ReadLine());
                                    weapon.MagazineCapacity = newMagazineCapacity;
                                    Console.WriteLine($"\nMagazine capacity updated from {previousMagazineCapacity} to {newMagazineCapacity}");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();
                                    break;

                                case ConsoleKey.D2:
                                    Console.Clear();
                                    int previousBulletCount = weapon.BulletCount;
                                    Console.WriteLine("Enter new bullet count:");
                                    int newBulletCount = int.Parse(Console.ReadLine());
                                    weapon.BulletCount = newBulletCount;
                                    Console.WriteLine($"\nBullet count updated from {previousBulletCount} to {newBulletCount}");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();
                                    break;

                                case ConsoleKey.Escape:
                                    Console.Clear();
                                    Console.WriteLine("Returning to main menu...");
                                    Thread.Sleep(1000);
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("Invalid option. Please choose again.");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();
                                    break;
                            }

                        } while (editKeyInfo.Key != ConsoleKey.Escape);

                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("Exiting the program...");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid operation. Press any key to return to the main menu...");
                        Console.ReadKey();
                        break;
                }
            } while (keyinfo.Key != ConsoleKey.Escape);
        }
    }
}
