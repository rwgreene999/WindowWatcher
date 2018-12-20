using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using System.Windows.Forms;

namespace WindowWatcher
{
    public class OperationalParameters
    {
        public OperationalParameters()
        {
            Mapper.CreateMap<OperationalParameters, OperationalParameters>();
        }
        public enum TopMethod
        {
            Undefined,
            TopAndAllowOther,
            TopAndKeepTop,
            None,
        }
        public TopMethod Method { get; set; }
        public bool Sound { get; set; }
        public int RefreshSeconds { get; set; }
        public int RefreshCount { get; set; }
        public bool Lync { get; set; }
        public bool User { get; set; }
        public string UserSearch{ get; set; }
        public bool Flash { get; set; }
        public bool WindowsStartup { get; set; }
        public bool BeenHereBefore { get; set; }

	    public int msSeekNewLyncs { get; set; }
        public int msRecheckLyncExist { get; set; }
        public bool verbose { get; set; }
        public bool active { get; set; }
        public bool showHelp { get; set; }
        public bool Paused { get; set; }
        public DateTime PausedTimeout { get; set; }
        public bool FlashDesktopOnNewDiscovery { get; set; }
        public bool FlashDesktopOnNewDiscoveryRandomSide { get; set; }
        public int SoundOption { get; set; }
        public bool RenotificationByWindowTop { get; set; }
        public bool RenotificationByToast { get; set; }

        internal OperationalParameters Clone()
        {
            var newop = new OperationalParameters();
            Mapper.Map(this, newop);
            return newop; 
        }

        internal void Adopt(OperationalParameters TempOp)
        {
            Mapper.Map(TempOp, this);
        }


        internal void LoadParametersSettings()
        {
            var settings = WindowWatcher.Properties.Settings.Default;
            Sound = settings.UseSound;
            RefreshSeconds = settings.RefreshSeconds;
            RefreshCount = settings.RefreshCount;
            if (RefreshCount < 1 )
            {
                RefreshCount = int.MaxValue; 
            }
            Lync = settings.Lync;
            UserSearch = settings.UserSearch;
            if (UserSearch.Length < 1)
            {
                User = false;
            }
            else
            {
                User = true; 
            }
            Flash = settings.Flash;
            msSeekNewLyncs = settings.msSeekNewLyncs;
            msRecheckLyncExist = settings.msRecheckLyncExist; 
            verbose = settings.Verbose;
            WindowsStartup = settings.WindowsStartUP;
            if (settings.TopMethod == "TopAndKeepTop")
            {
                Method = TopMethod.TopAndKeepTop; 
            }
            else
            {
                Method = TopMethod.TopAndAllowOther; 
            }
            BeenHereBefore = settings.BeenHereBefore;
            FlashDesktopOnNewDiscovery = settings.FlashAllWindowsOnNewDiscovery;
            FlashDesktopOnNewDiscoveryRandomSide = settings.FlashAllWIndowsOnNewDiscoveryRandom; 
            SoundOption = settings.SoundOption;
            RenotificationByToast = settings.RenotificationByToast;
            RenotificationByWindowTop = settings.RenotificationByWindowTop; 
            


        }
        internal void SaveParametersSettings()
        {
            var settings = WindowWatcher.Properties.Settings.Default;

            if (Method == TopMethod.TopAndKeepTop)
            {
                settings.TopMethod = "TopAndKeepTop";
            }
            else
            {
                settings.TopMethod = "TopAndAllowOthers"; 
            }
            settings.UseSound = Sound;
            settings.RefreshSeconds = RefreshSeconds;
            settings.RefreshCount = RefreshCount;
            settings.Lync = Lync;
            settings.UserSearch = UserSearch;
            settings.Flash = Flash;
            settings.msSeekNewLyncs = msSeekNewLyncs;
            settings.msRecheckLyncExist = msRecheckLyncExist;
            settings.Verbose = verbose;
            settings.WindowsStartUP = WindowsStartup;
            settings.BeenHereBefore = true;
            settings.FlashAllWindowsOnNewDiscovery = FlashDesktopOnNewDiscovery;
            settings.FlashAllWIndowsOnNewDiscoveryRandom = FlashDesktopOnNewDiscoveryRandomSide; 
            settings.SoundOption = SoundOption;
            settings.RenotificationByToast = RenotificationByToast;
            settings.RenotificationByWindowTop = RenotificationByWindowTop; 

            settings.Save(); 
        }

        public Action<string> UpdateFormFromTask;
        public Action<Form> AddFormToMessagePump;


    }
}
