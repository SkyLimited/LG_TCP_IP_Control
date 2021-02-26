using System;
using System.IO;

namespace UsendaRemoteControl
{
    public partial class SplashXWindow : Gtk.Window
    {
        public SplashXWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            var bb = File.ReadAllBytes("2017120618383238246.jpg");
           
            this.Build();
            this.image1.Pixbuf = new Gdk.Pixbuf(bb);
        }
    }
}
