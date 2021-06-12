using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic.Models;
using System.Runtime.InteropServices;
using Logic;

namespace View
{
    public partial class Form1 : Form
    {
        public static List<ViewAnimal> animals = new();
        private bool isCarnivore;
        private int size;
        private int points;
        private int id;

        public Form1()
        {
            InitializeComponent();
        }

        // private void Form1_Load(object sender, EventArgs e)
        // {
        //     AllocConsole();
        // }
        //
        // [DllImport("kernel32.dll", SetLastError = true)]
        // [return: MarshalAs(UnmanagedType.Bool)]
        // static extern bool AllocConsole();

        // type
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

        // size
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
            ViewAnimal animal = new ViewAnimal(id, isCarnivore, size, points);
            animals.Add(animal);
            listBox1.Items.Add(animal);
            id++;
            Console.WriteLine("dsadhaisudhasdusahdusada");
        }

        // run logic
        private void button2_Click(object sender, EventArgs e)
        {
            Logic.Program.Main();
        }
    }
}
