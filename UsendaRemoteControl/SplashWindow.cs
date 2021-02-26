using System;
namespace UsendaRemoteControl
{
    public partial class SplashWindow : Gtk.Window
    {
        public SplashWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            //this.image1.SetFromImage()
            this.image1 = Gtk.Image.LoadFromResource("logo.png");

        }
    }
}
