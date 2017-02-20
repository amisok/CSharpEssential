using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.IO;

namespace Serializer
{
    public partial class Form1 : Form
    {
        int[][] array;

        public Form1()
        {
            array = new int[20][];
            for (int i = 0; i < 20; i++)
            {
                array[i] = new int[15];
            }
            InitializeComponent();
        }

        private void RandomFill(int[][] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rand.Next(0, 15);
                }
            }
        }

        private void PrintRawData(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                string tmp = "";
                for (int j = 0; j < array[i].Length; j++)
                {
                    tmp = tmp + array[i][j].ToString() + " ";
                }
                listBoxRawData.Items.Add(tmp);
            }
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            RandomFill(array);
            PrintRawData(array);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            FileStream stream = new FileStream(textBoxFileName.Text, FileMode.Create);
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(int[][]));
            json.WriteObject(stream, array);
            stream.Close();

            StreamReader reader = new StreamReader(textBoxFileName.Text);
            listBoxJsonData.Items.Add(reader.ReadToEnd());
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

        }
    }
}
