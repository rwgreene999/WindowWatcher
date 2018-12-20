using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Media;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("WindowWatcherIntegrationTest")]

namespace WindowWatcher
{
    static class NotificationSound
    {
        static public void PlaySound(OperationalParameters op)
        {
            // WIP: some day users might be able to pick their sounds and that will be passed in op
            // System.Media.SystemSounds.Asterisk.Play();
            string sound = "POP2.WAV"; 
            if ( op.SoundOption == 2 )
            {
                sound = "Shipbell.wav";
            }
            else if (op.SoundOption == 3)
            {
                sound = "WIPE.WAV";
            }
            var noise = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("WindowWatcher." + sound);
            SoundPlayer simpleSound = new SoundPlayer(noise);
            simpleSound.Play();
            
        }
    }
}
