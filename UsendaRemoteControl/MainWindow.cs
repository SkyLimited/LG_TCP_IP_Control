using System;
using System.IO;
using System.Net.Sockets;
using Gtk;
using Newtonsoft.Json.Linq;

public partial class MainWindow : Gtk.Window
{
    private string IP;
    private int Port;
    private TcpClient _tc;

    private bool pwrstate = false;
    private int sndlvl = 32;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {


        this.Build();
        var bb = File.ReadAllBytes("logo.png");
        this.Icon = new Gdk.Pixbuf(bb);
        this.image1.Pixbuf = new Gdk.Pixbuf(bb);

        var img = new Image();
        img.Pixbuf = new Gdk.Pixbuf(File.ReadAllBytes("Power.png"));
        this.btnPower.Image = img;

        var imgvp = new Image();
        imgvp.Pixbuf = new Gdk.Pixbuf(File.ReadAllBytes("VolPlus.png"));
        this.btnVolPlus.Image = imgvp;

        var imgvm = new Image();
        imgvm.Pixbuf = new Gdk.Pixbuf(File.ReadAllBytes("VolMinus.png"));
        this.btnVolMinus.Image = imgvm;

        var imglft = new Image();
        imglft.Pixbuf = new Gdk.Pixbuf(File.ReadAllBytes("Left.png"));
        var imgup = new Image();
    
        imgup.Pixbuf = new Gdk.Pixbuf(File.ReadAllBytes("Up.png"));
        var imgdwn = new Image();
    
        imgdwn.Pixbuf =  new Gdk.Pixbuf(File.ReadAllBytes("Down.png"));
        var imgrght = new Image();
    

        imgrght.Pixbuf = new Gdk.Pixbuf(File.ReadAllBytes("Right.png"));
        var imgsets = new Image();
    
        imgsets.Pixbuf = new Gdk.Pixbuf(File.ReadAllBytes("Sets.png"));


        this.btnLeft.Image = imglft;
        this.btnUp.Image = imgup;
        this.btnRight.Image = imgrght;
        this.btnDown.Image = imgdwn;
        this.btnSets.Image = imgsets;


        this.image16.Pixbuf = new Gdk.Pixbuf(File.ReadAllBytes("InpSource.png"));
        this.image5.Pixbuf = new Gdk.Pixbuf(File.ReadAllBytes("brgthns.png"));

        var j = File.ReadAllText("settings.json");
        var d = JToken.Parse(j);
        IP = (string)d["ip"] ;
        Port = (int)d["port"];
        btnPower.Clicked += btnPowerClick;
        btnVolMinus.Clicked += btnVolMinusClick;
        btnVolPlus.Clicked += btnVolPlusClick;
        cbInput.Changed += inpChanged;
        cbBright.Changed += brChanged;

        btnLeft.Clicked += leftClick;
        btnDown.Clicked += downClick;
        btnRight.Clicked += rightClick;
        btnUp.Clicked += upClick;
        btnSets.Clicked += setsClick;

        this.ModifyBg(StateType.Normal, new Gdk.Color(255,255,255));

    }

    void BtnDown_Clicked(object sender, EventArgs e)
    {
    }


    private void leftClick(object sender, EventArgs e)
    {
        var x = makeConn();
        if (!x)
            return;

        var code = "07";
        try
        {
            NetworkStream stream = _tc.GetStream();
            string response = "mc 00 " + code + "\r";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(response);
            stream.Write(data, 0, data.Length);

            _tc.Close();
            _tc.Dispose();
        }
        catch (Exception ez)
        {
            ShowMessage(this, "Panel command send failure", ez.Message);
        }

    }

    private void rightClick(object sender, EventArgs e)
    {
        var x = makeConn();
        if (!x)
            return;

        var code = "06";
        try
        {
            NetworkStream stream = _tc.GetStream();
            string response = "mc 00 " + code + "\r";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(response);
            stream.Write(data, 0, data.Length);

            _tc.Close();
            _tc.Dispose();
        }
        catch (Exception ez)
        {
            ShowMessage(this, "Panel command send failure", ez.Message);
        }
    }

    private void upClick(object sender, EventArgs e)
    {
        var x = makeConn();
        if (!x)
            return;

        var code = "40";
        try
        {
            NetworkStream stream = _tc.GetStream();
            string response = "mc 00 " + code + "\r";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(response);
            stream.Write(data, 0, data.Length);

            _tc.Close();
            _tc.Dispose();
        }
        catch (Exception ez)
        {
            ShowMessage(this, "Panel command send failure", ez.Message);
        }
    }

    private void downClick(object sender, EventArgs e)
    {
        var x = makeConn();
        if (!x)
            return;

        var code = "41";
        try
        {
            NetworkStream stream = _tc.GetStream();
            string response = "mc 00 " + code + "\r";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(response);
            stream.Write(data, 0, data.Length);

            _tc.Close();
            _tc.Dispose();
        }
        catch (Exception ez)
        {
            ShowMessage(this, "Panel command send failure", ez.Message);
        }
    }

    private void setsClick(object sender, EventArgs e)
    {
        var x = makeConn();
        if (!x)
            return;
       
        var code = "43";
        try
        {
            NetworkStream stream = _tc.GetStream();
            string response = "mc 00 " + code + "\r";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(response);
            stream.Write(data, 0, data.Length);

            _tc.Close();
            _tc.Dispose();
        }
        catch (Exception ez)
        {
            ShowMessage(this, "Panel command send failure", ez.Message);
        }
    }


    private void brChanged(object sender, EventArgs e)
    {
        var x = makeConn();
        if (!x)
            return;
        var codeInt = cbBright.Active;
        var code = "";
        switch (codeInt)
        {
            case 0: code = "00"; break;
            case 1: code = "01"; break;
            case 2: code = "02"; break;
            case 3: code = "03"; break;
            case 4: code = "04"; break;
        }
        try
        {
            NetworkStream stream = _tc.GetStream();
            string response = "jq 00 " + code + "\r";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(response);
            stream.Write(data, 0, data.Length);

            _tc.Close();
            _tc.Dispose();
        }
        catch (Exception ez)
        {
            ShowMessage(this, "Panel command send failure", ez.Message);
        }
    }

    private void inpChanged(object sender, EventArgs e)
    {
        var x = makeConn();
        if (!x)
            return;
        var code = "";
        var codeInt = cbInput.Active;
        switch (codeInt)
        {
            case 0: code = "a0"; break;
            case 1: code = "a1"; break;
            case 2: code = "a2"; break;
            case 3: code = "a3"; break;
        }
        try
        {

            NetworkStream stream = _tc.GetStream();
            string response = "xb 00 " + code + "\r";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(response);
            stream.Write(data, 0, data.Length);

            _tc.Close();
            _tc.Dispose();
        }
        catch (Exception ex)
        {
            ShowMessage(this, "Panel command send failure", ex.Message);
        }
    }

    private void btnVolMinusClick(object sender, EventArgs e)
    {
        var x = makeConn();
        if (!x)
            return;
        if (sndlvl == 0)
            return;
        try
        {
            sndlvl--;
            NetworkStream stream = _tc.GetStream();
            string response = "kf 00 "+sndlvl.ToString()+"\r";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(response);
            stream.Write(data, 0, data.Length);

            _tc.Close();
            _tc.Dispose();
        }
        catch (Exception ex)
        {
            ShowMessage(this, "Panel command send failure", ex.Message);
        }
    }

    private void btnVolPlusClick(object sender, EventArgs e)
    {
        var x = makeConn();
        if (!x)
            return;
        if (sndlvl == 64)
            return;
        try
        {
            sndlvl++;
            NetworkStream stream = _tc.GetStream();
            string response = "kf 00 " + sndlvl.ToString() + "\r";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(response);
            stream.Write(data, 0, data.Length);

            _tc.Close();
            _tc.Dispose();
        }
        catch (Exception ex)
        {
            ShowMessage(this, "Panel command send failure", ex.Message);
        }
    }

    private void btnPowerClick(object sender, EventArgs e)
    {
       var x = makeConn();
        if (!x)
            return;
        try
        {
            NetworkStream stream = _tc.GetStream();
            string response = "ka 00 00\r";
            if (!pwrstate)
                response = "ka 00 01\r";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(response);
            stream.Write(data, 0, data.Length);
            pwrstate = !pwrstate;
            _tc.Close();
            _tc.Dispose();
        }
        catch(Exception ex)
        {
            ShowMessage(this, "Panel command send failure", ex.Message);
        }
    }

    private bool makeConn()
    {
        _tc = new TcpClient();
        try
        {
            _tc.Connect(IP, Port);
            return true;
        }
        catch (Exception e)
        {
            ShowMessage(this, "Panel connection failure", e.Message);
            return false;
        }

    }

        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    void ShowMessage(Window parent, string title, string message)
    {
        Dialog dialog = null;
        try
        {
            dialog = new Dialog(title, parent,
                DialogFlags.DestroyWithParent | DialogFlags.Modal,
                ResponseType.Ok);
            dialog.VBox.Add(new Label(message));
            dialog.ShowAll();

            dialog.Run();
        }
        finally
        {
            if (dialog != null)
                dialog.Destroy();
        }
    }
}
