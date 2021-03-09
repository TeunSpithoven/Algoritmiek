using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // ---------------------------------------------------------VRAAG 1------------------------------------------------------
        
        // als er op de knop wordt geklikt:
        private void button1_Click(object sender, EventArgs e)
        {
            // roept functie aan en gebruikt daarbij de input van de numericupdown
            int output = Vraag1(Convert.ToInt32(numericUpDown1.Value));
            textBox1.Text = Convert.ToString(output);
        }

        
        // som van alle veelvouden van 3 en 5 onder het ingegeven getal
        //vb: in = 10 uit= 3+5+6+9 = 23
        public int Vraag1(int input)
        {
            int sum =0;

            // voor ieder getal vanaf 0 tot input:
            for (int i = 0; i < input; i++)
            {
                // als i een veelvoud is van 3 word hij bij het totaal opgeteld
                int drieCheck = i % 3;
                if (drieCheck == 0) { sum = sum + i; }
                // als i een veelvoud is van 5 word hij bij het totaal opgeteld
                int vijfCheck = i % 5;
                if (vijfCheck == 0) { sum = sum + i; }
            }
            return sum;
        }

        // ---------------------------------------------------------VRAAG 2------------------------------------------------------

        // fibonnaci-reeks: 1, 2 wordt de volgende 3. daarna is het dus 2, 3 wordt 5. 8,13,21,34
        // opdracht: de som van alle even nummers onder 4 miljoen

        public int Vraag2(int input)
        {
            int som = 2;
            int getal1 = 1;
            int getal2 = 2;
            int tussenGetal = 1;
            
            while (tussenGetal <= input)
            {
                //het volgende getal in de reeks:
                tussenGetal = getal2 + getal1;
                
                // als die even is wordt hij opgeteld
                if (tussenGetal % 2 == 0)
                {
                    som += tussenGetal;
                }
                
                // de getallen voor de berekening schuiven een plaats naar rechts op
                getal1 = getal2;
                getal2 = tussenGetal;
            }

            return som;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // roept functie aan en gebruikt daarbij de input van de numericupdown
            int output = Vraag2(Convert.ToInt32(numericUpDown2.Value));
            textBox2.Text = Convert.ToString(output);
        }
    }
}
