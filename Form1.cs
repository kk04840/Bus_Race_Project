using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Race_Project
{
    public partial class Form1 : Form
    {
        String player = "";
        int busNo = 0,plyer1=100,plyer2=100,plyer3=100;
        rnd GetRnd = new rnd();
        int winner = 0;
        ResultDeclare declare = new ResultDeclare();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this task is used to load the amount to set for the bet 
            int y = 1;
            for (y=1;y<=50;y++) {
                select_amount.Items.Add(y.ToString());

            }
        }

        private void john_pl_CheckedChanged(object sender, EventArgs e)
        {
            //this code is used to select the player 
            if (john_pl.Checked == true)
            {
                player = "John";
                prabh_pl.Checked = false;
                roban_pl.Checked = false;
            }
            else {
                prabh_pl.Checked = false;
                roban_pl.Checked = false;
            }
        }

        private void prabh_pl_CheckedChanged(object sender, EventArgs e)
        {
            //this code is used to select the player 
            if (prabh_pl.Checked == true)
            {
                player = "Prabh";
                john_pl.Checked = false;
                roban_pl.Checked = false;
            }
            else
            {
                john_pl.Checked = false;
                roban_pl.Checked = false;
            }

        }

        private void roban_pl_CheckedChanged(object sender, EventArgs e)
        {
            //this code is used to select the player 
            if (roban_pl.Checked == true)
            {
                player = "Roban";
                john_pl.Checked = false;
                prabh_pl.Checked = false;
            }
            else
            {
                prabh_pl.Checked = false;
                john_pl.Checked = false;
            }
        }

        private void bus1_CheckedChanged(object sender, EventArgs e)
        {
            if (bus1.Checked == true)
            {
                busNo = 1;
                bus2.Checked = false;
                bus3.Checked = false;
                bus4.Checked = false;
            }
            else {
                bus2.Checked = false;
                bus3.Checked = false;
                bus4.Checked = false;
            }
        }

        private void bus2_CheckedChanged(object sender, EventArgs e)
        {

            if (bus2.Checked == true)
            {
                busNo = 2;
                bus1.Checked = false;
                bus3.Checked = false;
                bus4.Checked = false;
            }
            else
            {
                bus1.Checked = false;
                bus3.Checked = false;
                bus4.Checked = false;
            }
        }

        private void bus3_CheckedChanged(object sender, EventArgs e)
        {

            if (bus3.Checked == true)
            {
                busNo = 3;
                bus2.Checked = false;
                bus4.Checked = false;
                bus1.Checked = false;
            }
            else
            {
                bus2.Checked = false;
                bus1.Checked = false;
                bus4.Checked = false;
            }
        }

        private void bus4_CheckedChanged(object sender, EventArgs e)
        {

            if (bus4.Checked == true)
            {
                busNo = 4;
                bus2.Checked = false;
                bus3.Checked = false;
                bus1.Checked = false;
            }
            else
            {
                bus2.Checked = false;
                bus3.Checked = false;
                bus1.Checked = false;
            }
        }

        private void setforbet_btn_Click(object sender, EventArgs e)
        {
            if (player.Equals("") || busNo == 0 || select_amount.Text.Equals(""))
            {
                MessageBox.Show("Must need to select the Player and Bus No ");
            }
            else {
                //now set the price of the file
                if (player.Equals("John") && plyer1 > 0)
                {
                    john_pl.Text = "Johan set the bet on " + busNo + " with " + select_amount.Text + " Amount";
                    rungame_btn.Enabled = true;
                }

                else if (player.Equals("Prabh") && plyer2 > 0)
                {
                    prabh_pl.Text = "Prabh set the bet on " + busNo + " with " + select_amount.Text + " Amount";
                    rungame_btn.Enabled = true;
                }

                else if (player.Equals("Roban") && plyer3 > 0)
                {
                    roban_pl.Text = "Roban set the bet on " + busNo + " with " + select_amount.Text + " Amount";
                    rungame_btn.Enabled = true;
                }
                else {
                    MessageBox.Show("Check your balance ");
                }

                player = "";
                busNo = 0;

                john_pl.Checked = false;
                prabh_pl.Checked = false;
                roban_pl.Checked = false;

                bus1.Checked = false;
                bus2.Checked = false;
                bus3.Checked = false;
                bus4.Checked = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            busRace11.Left = busRace11.Left + GetRnd.rd.Next(1, 45);
            busRace12.Left = busRace12.Left + GetRnd.rd.Next(1, 45);
            busRace13.Left = busRace13.Left + GetRnd.rd.Next(1, 45);
            busRace14.Left = busRace14.Left + GetRnd.rd.Next(1, 45);

           // rungame_btn.Text = "" + busRace11.Left;

            if (busRace11.Left>700) {
                winner = 1;
                timer1.Stop();
                timer1.Enabled = false;
                MessageBox.Show("Bus 1 has won the Race ");
                reset();
                
                
            }

            if (busRace12.Left > 700)
            {
                winner = 2;
                timer1.Stop();
                timer1.Enabled = false;
                MessageBox.Show("Bus 2 has won the Race ");
                reset();
                
                
            }

            if (busRace13.Left > 700)
            {
                winner = 3;
                timer1.Stop();
                timer1.Enabled = false;
                MessageBox.Show("Bus 3 has won the Race ");
                reset();
                
                
            }

            if (busRace14.Left > 700)
            {
                winner = 4;
                timer1.Stop();
                timer1.Enabled = false;
                MessageBox.Show("Bus 4 has won the Race ");
                reset();
                
                
            }
        }
        public void reset() {
            String []g = john_pl.Text.Split(' ');
            if (g.Length>8) {
                plyer1=declare.result(plyer1, Convert.ToInt32(g[5]), Convert.ToInt32(g[7]), winner);
                john_pl.Text = "john has " + plyer1;
            }
            String[] h = prabh_pl.Text.Split(' ');
            if (h.Length > 8)
            {
                plyer2 = declare.result(plyer2, Convert.ToInt32(h[5]), Convert.ToInt32(h[7]), winner);
                prabh_pl.Text = "Prabh has " + plyer2;
            }
            String[] i =roban_pl.Text.Split(' ');
            if (i.Length > 8)
            {
                plyer3 = declare.result(plyer3, Convert.ToInt32(i[5]), Convert.ToInt32(i[7]), winner);
                roban_pl.Text = "Roban has " + plyer3;
            }
            busRace11.Left = 60;
            busRace12.Left = 60;
            busRace13.Left = 60;
            busRace14.Left = 60;
            john_pl.Checked = false;
            prabh_pl.Checked = false;
            roban_pl.Checked = false;

            bus1.Checked = false;
            bus2.Checked = false;
            bus3.Checked = false;
            bus4.Checked = false;
            rungame_btn.Enabled = false;


        }
        private void rungame_btn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }
    }
    class rnd {
      public  Random rd = new Random();
    }
}
