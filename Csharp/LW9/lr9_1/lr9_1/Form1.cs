namespace lr9_1
{
    public partial class Form1 : Form
    {
        Katok K;

        public Form1()
        {
            InitializeComponent();
            Random R = new Random();

            K = new Katok(R.Next(3, 8));
            K.Parent = this;
            K.Size = ClientSize;

            K.Anchor = (AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right |
                AnchorStyles.Top);
        }
    }
}
