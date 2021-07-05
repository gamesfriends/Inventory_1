using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_1
{
    public partial class Form1 : Form
    {
        public static string[,] array = new string[5, 5];

        public Form1()
        {
            inicializarArray();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agregarObjeto("Armadura de oro+9", 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            agregarObjeto("Escudo de batalla+9", 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            agregarObjeto("Espada envenenada+9", 2);
        }

        public static void inicializarArray()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array[i, j] = "-";
                }
            }
        }

        public static void agregarObjeto(string nombreDeObjeto, int lugaresOcupa)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (array[i, j].Equals("-") && lugaresOcupa == 1)
                    {
                        array[i, j] = nombreDeObjeto;
                        return;
                    }

                    if (array[i, j].Equals("-") && lugaresOcupa == 2)
                    {
                        if (i != 4)
                        {
                            if (array[i + 1, j].Equals("-") && i != 4)
                            {
                                array[i, j] = nombreDeObjeto;
                                array[i + 1, j] = nombreDeObjeto;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string textoMostrar = "";

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    textoMostrar += $"{i}-{j}: {array[i, j]}   //   ";
                }
                textoMostrar += "\r\n";
            }

            MessageBox.Show(textoMostrar);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ruta = "C:/Users/psalvi/source/repos/Inventory_1/Inventory_1/images/Armadura.jpg";
            Bitmap imageArmadura = new Bitmap(ruta);

            ruta = "C:/Users/psalvi/source/repos/Inventory_1/Inventory_1/images/Escudo.jpg";
            Bitmap imageEscudo = new Bitmap(ruta);

            ruta = "C:/Users/psalvi/source/repos/Inventory_1/Inventory_1/images/Espada.jpg";
            Bitmap imageEspada = new Bitmap(ruta);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!array[i, j].Equals("-"))
                    {
                        if (array[i, j].Equals("Armadura de oro+9")) agregarObjetoInventario(i, j, imageArmadura);
                        if (array[i, j].Equals("Escudo de batalla+9")) agregarObjetoInventario(i, j, imageEscudo);
                        if (array[i, j].Equals("Espada envenenada+9")) agregarObjetoInventario(i, j, imageEspada);
                    }
                }
            }
        }

        public void agregarObjetoInventario(int x, int y, Bitmap image)
        {
            if (x == 0 && y == 0) image_0_0.Image = (Image)image;
            if (x == 0 && y == 1) image_0_1.Image = (Image)image;
            if (x == 0 && y == 2) image_0_2.Image = (Image)image;
            if (x == 0 && y == 3) image_0_3.Image = (Image)image;
            if (x == 0 && y == 4) image_0_4.Image = (Image)image;

            if (x == 1 && y == 0) image_1_0.Image = (Image)image;
            if (x == 1 && y == 1) image_1_1.Image = (Image)image;
            if (x == 1 && y == 2) image_1_2.Image = (Image)image;
            if (x == 1 && y == 3) image_1_3.Image = (Image)image;
            if (x == 1 && y == 4) image_1_4.Image = (Image)image;

            if (x == 2 && y == 0) image_2_0.Image = (Image)image;
            if (x == 2 && y == 1) image_2_1.Image = (Image)image;
            if (x == 2 && y == 2) image_2_2.Image = (Image)image;
            if (x == 2 && y == 3) image_2_3.Image = (Image)image;
            if (x == 2 && y == 4) image_2_4.Image = (Image)image;

            if (x == 3 && y == 0) image_3_0.Image = (Image)image;
            if (x == 3 && y == 1) image_3_1.Image = (Image)image;
            if (x == 3 && y == 2) image_3_2.Image = (Image)image;
            if (x == 3 && y == 3) image_3_3.Image = (Image)image;
            if (x == 3 && y == 4) image_3_4.Image = (Image)image;

            if (x == 4 && y == 0) image_4_0.Image = (Image)image;
            if (x == 4 && y == 1) image_4_1.Image = (Image)image;
            if (x == 4 && y == 2) image_4_2.Image = (Image)image;
            if (x == 4 && y == 3) image_4_3.Image = (Image)image;
            if (x == 4 && y == 4) image_4_4.Image = (Image)image;
        }
    }
}
