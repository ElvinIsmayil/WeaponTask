using System.Media;

namespace WeaponTaskHelper
{
    public class WeaponSoundHelper
    {
        public static void PlayReload()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\Elvin\Desktop\C#\Console Apps\WeaponTask\WeaponTask\WeaponTask\Sounds\ak47-reload.wav");
                soundPlayer.PlaySync();
                soundPlayer.Stop();
            }
        }

        public static void PlaySingle()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\Elvin\Desktop\C#\Console Apps\WeaponTask\WeaponTask\WeaponTask\Sounds\ak47-single.wav");
                soundPlayer.PlaySync();
                soundPlayer.Stop();
            }
        }public static void PlayBurst()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\Elvin\Desktop\C#\Console Apps\WeaponTask\WeaponTask\WeaponTask\Sounds\ak47-burst.wav");
                soundPlayer.PlaySync();
                soundPlayer.Stop();
            }
        }public static void PlayAutomatic()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\Elvin\Desktop\C#\Console Apps\WeaponTask\WeaponTask\WeaponTask\Sounds\ak-47-automatic.wav");
                soundPlayer.PlaySync();
                soundPlayer.Stop();
            }
        }
    }
}
