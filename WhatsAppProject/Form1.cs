namespace WhatsAppProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WhatsAppSendMessage w = new WhatsAppSendMessage();
            //w.SendMessageWithImage("Hello World, Filipe Brito", "C:\\Users\\Max\\Pictures\\temp\\teste.jpg", "@GroupTest");
            w.SendMessageWithEmoji("Hello World", new List<string> { "robo" }, "@GroupTest");
        }
    }
}
