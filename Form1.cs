using System.Diagnostics;
using Timer = System.Threading.Timer;

namespace WF_ClickMaster
{
    public partial class Form1 : Form
    {
        private List<int> records = new List<int>();
        private int _clickCount = 0;
        private int _time = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_clickCount == 0) timer1.Start();

            button1.Text = (++_clickCount).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (++_time != 20) return;
            else
            {
                timer1.Stop();
                button1.Enabled = false;

                DialogResult replay;
                if (_clickCount > GetBestClicks())
                {
                    replay = MessageBox.Show("NEW BEST RECORD: " + _clickCount + "\nCONTINUE?", "TIME OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    replay = MessageBox.Show("BEST RECORD: " + GetBestClicks() + "\nCONTINUE?", "TIME OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                records.Add(_clickCount);

                if (replay == DialogResult.Yes)
                {
                    button1.Text = "START";
                    _clickCount = 0;
                    _time = 0;
                    button1.Enabled = true;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private int GetBestClicks()
        {
            int hrecord = 0;

            foreach (var temp in records)
            {
                if (hrecord < temp) hrecord = temp;
            }

            return hrecord;
        }
    }
}