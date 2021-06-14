using Logic.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Enum = Logic.Enum;

namespace View
{
    public partial class Form1 : Form
    {
        private List<Animal> Animals = new();
        private bool isCarnivore;
        private int size;
        private int points;
        private int id;

        public Form1()
        {
            InitializeComponent();
        }

        // select type
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == radioButton1)
            {
                isCarnivore = true;
            }
            else
            {
                isCarnivore = false;
            }
        }

        // select size
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == radioButton3)
            {
                size = 0;
                points = 1;
            }
            else if (sender == radioButton4)
            {
                size = 1;
                points = 3;
            }
            else
            {
                size = 2;
                points = 5;
            }
        }

        // add to list
        private void button1_Click(object sender, EventArgs e)
        {
            Animal animal = new(id++, isCarnivore, size, points);
            Animals.Add(animal);
            listBox1.Items.Add($"id: {animal.Id}, isCarnivore: {animal.IsCarnivore}, size:  {animal.Size}");
        }

        // run logic and print train
        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Train train = new Train();
            
            string space = "              ";
            listBox2.Items.Add(space + "    _____");
            listBox2.Items.Add(space + " ___ |[]|_n__n_I_c");
            listBox2.Items.Add(space + "|___||__|###|____}");
            listBox2.Items.Add(space + " O-O--O-O+++--O-O");

            PrintWagons(train.WagonFiller(Animals));
        }

        private void PrintWagons(List<Wagon> wagons)
        {
            foreach (var wagon in wagons)
            {
                switch (wagon.Id)
                {
                    case < 10:
                        listBox2.Items.Add($"              -----{wagon.Id}-----");
                        break;

                    case < 100:
                        listBox2.Items.Add($"              -----{wagon.Id}----");
                        break;

                    case < 1000:
                        listBox2.Items.Add($"              ----{wagon.Id}----");
                        break;

                    case < 10000:
                        listBox2.Items.Add($"              ----{wagon.Id}---");
                        break;

                    case < 100000:
                        listBox2.Items.Add($"              ---{wagon.Id}---");
                        break;
                }

                string infoSpace = "              ";
                foreach (var animal in wagon.Animals)
                {
                    // print de bijbehorende eetgewoonte
                    if (animal.IsCarnivore == true)
                        listBox2.Items.Add($"{infoSpace}|{Enum.IsCarnivore.Carnivore}|");
                    else
                        listBox2.Items.Add($"{infoSpace}|{Enum.IsCarnivore.Herbivore}|");

                    switch (animal.Size)
                    {
                        // print de bijbehorende grootte
                        case 0:
                            listBox2.Items.Add($"{infoSpace}|  {Enum.Sizes.Small}     |");
                            break;

                        case 1:
                            listBox2.Items.Add($"{infoSpace}| {Enum.Sizes.Medium} |");
                            break;

                        case 2:
                            listBox2.Items.Add($"{infoSpace}|  {Enum.Sizes.Large}      |");
                            break;

                        default:
                            listBox2.Items.Add("Invalid Size!");
                            break;
                    }
                    listBox2.Items.Add($"{infoSpace}|                 |");
                }

                if (wagon.Points < 10)
                    listBox2.Items.Add($"{infoSpace}---0{wagon.Points}pts---");
                else
                    listBox2.Items.Add($"{infoSpace}---{wagon.Points}pts---");

                listBox2.Items.Add("                      |     ");
            }
        }
    }
}