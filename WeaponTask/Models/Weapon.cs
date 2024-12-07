using WeaponTask.Enums;
using WeaponTaskHelper;
using WeaponTask.Exceptions;

namespace WeaponTask.Models
{
    public class Weapon
    {
        private int _bulletCount;
        private int _magazineCapacity;

        
        private const int MaxBulletAllowed = 100;

        public int MagazineCapacity
        {
            get => _magazineCapacity;
            set
            {
                if (value < 0)
                {
                    throw new InvalidWeaponCredentialException("The magazine capacity cannot be less than zero.");
                }

               
                if (value > MaxBulletAllowed)
                {
                    throw new InvalidWeaponCredentialException($"The magazine capacity cannot exceed the maximum allowed value of {MaxBulletAllowed}.");
                }

                if (_bulletCount > value)
                {
                    _bulletCount = value;
                }

                _magazineCapacity = value;
            }
        }

        public int BulletCount
        {
            get => _bulletCount;
            set
            {
                if (value < 0)
                {
                    throw new InvalidWeaponCredentialException("The bullet count cannot be less than zero.");
                }

                
                if (value > _magazineCapacity)
                {
                    throw new InvalidWeaponCredentialException("The bullet count cannot exceed the magazine capacity.");
                }

                if (value > MaxBulletAllowed)
                {
                    throw new InvalidWeaponCredentialException($"The bullet count cannot exceed the maximum allowed value of {MaxBulletAllowed}.");
                }

                _bulletCount = value;
            }
        }

        public FireModeEnum FireMode { get; private set; }




        public Weapon(int magazineCapacity, int bulletCount, FireModeEnum fireMode)
        {
            MagazineCapacity = magazineCapacity;
            BulletCount = bulletCount;
            FireMode = fireMode;
        }

        public void Shoot()
        {
            if (BulletCount <= 0)
            {
                throw new OutOfBulletException("No more bullets left! Please reload.");
            }
            else
            {
                Helper.Ak47();
                Console.WriteLine("Shooting...");
                WeaponSoundHelper.PlaySingle();
                BulletCount--;
            }
        }

        public void Fire(FireModeEnum fireModeEnum)
        {
            if (BulletCount <= 0)
            {
                throw new OutOfBulletException("No more bullets left! Please reload.");
            }
            else
            {
                switch (fireModeEnum)
                {
                    case FireModeEnum.Single:
                        Helper.Ak47();
                        Console.WriteLine("Firing...");
                        WeaponSoundHelper.PlaySingle();
                        BulletCount--;
                        break;

                    case FireModeEnum.Burst:
                        Helper.Ak47();
                        Console.WriteLine("Firing...");
                        WeaponSoundHelper.PlayBurst();
                        BulletCount -= 3;
                        break;
                    case FireModeEnum.Automatic:
                        Helper.Ak47();
                        Console.WriteLine("Firing...");
                        WeaponSoundHelper.PlayAutomatic();
                        BulletCount = 0;
                        break;
                    default:
                        Helper.ChangeTextColor(ConsoleColor.Red, "Invalid Fire Mode");
                        break;
                }
            }
        }

        public int GetRemainingBulletCount()
        {
            int remainingBulletCount = MagazineCapacity - BulletCount;

           
            return remainingBulletCount;
        }

        public void Reload()
        {
            Console.WriteLine("Reloading...");
            WeaponSoundHelper.PlayReload();
            BulletCount = MagazineCapacity;
            Console.WriteLine($"\nReloaded! {BulletCount}/{MagazineCapacity}");
        }

        public void ChangeFireMode(int number)
        {


            FireModeEnum fireModeEnum = number switch
            {
                1 => FireModeEnum.Single,
                2 => FireModeEnum.Burst,
                3 => FireModeEnum.Automatic,
                _ => FireModeEnum.Single
            };

            FireMode = fireModeEnum;

        }


        public void ShowInfo()
        {
            Helper.ChangeTextColor(ConsoleColor.Green,
                $"Weapon Info: \n" +
                $"\nMagazine Capacity: {MagazineCapacity}\n" +
                $"Bullet Count: {BulletCount}\n" +
                $"Fire Mode: {FireMode}\n");

        }

        



    }
}
