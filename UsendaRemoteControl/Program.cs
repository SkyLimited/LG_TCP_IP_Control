using System;
using Gtk;

namespace UsendaRemoteControl
{


    class MainClass
    {
        private static uint timer;
        private static SplashXWindow spl;
        private static MainWindow win;

        public static void Main(string[] args)
        {
            Application.Init();


            spl = new SplashXWindow();
            spl.Show();


            timer = GLib.Timeout.Add(3000, new GLib.TimeoutHandler(LoadNext));

            win = new MainWindow();
            win.Hide();



            Application.Run();

        }


        public static bool LoadNext()
        {

            spl.Hide();
            win.Show();
            return false;
        }
    }
}
