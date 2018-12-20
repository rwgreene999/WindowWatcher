using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowWatcher; 

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LyncWatcherIntegrationTest
{
    /// <summary>
    ///  These test require visual or sound confirmation, do you see on the screen what the test indicates 
    /// </summary>
    /// 


    [TestClass]
    public class NotifyFlashAllWindows_Test
    {
        [TestMethod]
        public void TestSound()
        {
            
            NotificationSound.PlaySound(new OperationalParameters { SoundOption = 3 });
            System.Threading.Thread.Sleep(2000); 
            NotificationSound.PlaySound(new OperationalParameters { SoundOption = 2 });
            System.Threading.Thread.Sleep(2000);
            NotificationSound.PlaySound(new OperationalParameters { SoundOption = 1 });
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void TestTopWindows()
        {            
            NotifyFlashAllWindows.Flash(NotifyFlashAllWindows.ScreenSide.top);
        }
        [TestMethod]
        public void TestBottomWindows()
        {
            NotifyFlashAllWindows.Flash(NotifyFlashAllWindows.ScreenSide.bottom);
        }
        [TestMethod]
        public void TestLeftWindows()
        {
            NotifyFlashAllWindows.Flash(NotifyFlashAllWindows.ScreenSide.left);
        }
        [TestMethod]
        public void TestRightWindows()
        {
            NotifyFlashAllWindows.Flash(NotifyFlashAllWindows.ScreenSide.right);
        }
        [TestMethod]
        public void TestRandomWindows()
        {
            NotifyFlashAllWindows.Flash();
            System.Threading.Thread.Sleep(1000);
            NotifyFlashAllWindows.Flash();

        }
        [TestMethod]
        public void TestRazzleDazzleWindows()
        {
            NotifyFlashAllWindows.Flash(NotifyFlashAllWindows.ScreenSide.top);
            NotifyFlashAllWindows.Flash(NotifyFlashAllWindows.ScreenSide.left);
            NotifyFlashAllWindows.Flash(NotifyFlashAllWindows.ScreenSide.bottom);
            NotifyFlashAllWindows.Flash(NotifyFlashAllWindows.ScreenSide.right);

        }
    }

}
