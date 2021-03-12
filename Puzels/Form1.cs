using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            textBox1.Clear();
            // roept functie aan en gebruikt daarbij de input van de numericupdown
            int output = Vraag1(Convert.ToInt32(numericUpDown1.Value));
            textBox1.Text = Convert.ToString(output);
        }

        // som van alle veelvouden van 3 en 5 onder het ingegeven getal
        //vb: in = 10 uit= 3+5+6+9 = 23
        public int Vraag1(int input)
        {
            int sum = 0;

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
            textBox2.Clear();
            // roept functie aan en gebruikt daarbij de input van de numericupdown
            int output = Vraag2(Convert.ToInt32(numericUpDown2.Value));
            textBox2.Text = Convert.ToString(output);
        }

        // ---------------------------------------------------------VRAAG 3------------------------------------------------------

        public void Vraag3()
        {
            // decimalen omdat die heel groot mogen zijn
            decimal b;
            decimal a = numericUpDown3.Value;
            
            // zolang a groter is dan 1
            for (b = 2; a > 1; b++)
                //als het huidige getal een priemgetal is
                if (a % b == 0)
                {
                    var x = 0;
                    // kijken hoe vaak dat priemgetal voorkomt
                    while (a % b == 0)
                    {
                        a /= b;
                        x++;
                    }
                    // print de priemfactoren en hoe vaak ze voorkomen
                    textBox3.Text += $"{b} x {x} -- ";
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // zodat je meerdere keren kunt gebruiken maak je de textbox eerst leeg
            textBox3.Clear();
            Vraag3();
        }

        // ---------------------------------------------------------VRAAG 3------------------------------------------------------

        public void Vraag4(int nummerEen, int nummerTwee)
        {
            // het product van de twee invoervelden
            int product = nummerEen * nummerTwee;
            
            // zolang dat product niet gespiegelt kan worden:
            while (SpiegelCheck(product) == false)
            {
                nummerEen++;
                nummerTwee++;
            }
            // als die wel gespiegelt kan worden:
            if (SpiegelCheck(product))
            {
                textBox4.Text = product.ToString();
            }
            
        }

        public bool SpiegelCheck(int product)
        {
            bool returnBool;

            // deze werkt, als je 512 hebt, krijg je {5, 1, 2}
            int[] intArray = GetIntList(product);

            int i = 0;
            while (i < intArray.Length)
            {
                listBox1.Items.Add(intArray[i]);
                i++;
            }

            int a = 0;
            int b = intArray.Length -1;
            int succes = 0;
            
            // maximale lengte is 6 dus 3 keer checken van buiten naar binnen
            while (a <= 3){
                if (intArray[a] == intArray[b])
                {
                    succes++;
                }
                a++;
                b--;
            }

            // als je 3 keer dezelfe hebt is t goed
            if (succes == 3)
            {
                returnBool = true;
            }
            // als dat niet is is het fout
            else
            {
                returnBool = false;
            }

            return returnBool;
        }
        
        // zet een int om naar een array van losse getallen
        public int[] GetIntList(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            Vraag4(Convert.ToInt32(textBoxEen.Text), Convert.ToInt32(textBoxTwee.Text));
        }
    }
}