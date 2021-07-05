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
        public List<PictureBox> pictures = new List<PictureBox>();
        public int compAgregados = 0;
        public int cantAgregados;
        public int cordX = 10;
        public int cordY = 10;

        public Form1()
        {
            inicializarArray();

            agregarSlots(25);

            dibujarSlots();

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

            int numSlot = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!array[i, j].Equals("-"))
                    {
                        if (array[i, j].Equals("Armadura de oro+9")) agregarObjetoInventario(imageArmadura, numSlot);
                        if (array[i, j].Equals("Escudo de batalla+9")) agregarObjetoInventario(imageEscudo, numSlot);
                        if (array[i, j].Equals("Espada envenenada+9")) agregarObjetoInventario(imageEspada, numSlot);
                    }
                    numSlot++;
                }
            }
        }

        public void agregarObjetoInventario(Bitmap image, int numSlot)
        {
            pictures[numSlot].Image = (Image)image;
        }

        private void agregarSlots(int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                PictureBox newPicture = new PictureBox();
                compAgregados++;
                Personalizar(newPicture);
                pictures.Add(newPicture);
            }
        }

        private void Personalizar(PictureBox pic)
        {
            Size medidas = new Size(100, 100);
            pic.Size = medidas;

            cantAgregados++;

            Point punto;

            if (compAgregados > 1)
            {
                if (cantAgregados == 6)
                {
                    cordY += 110;
                    cordX = 10;
                    compAgregados = 1;
                    cantAgregados = 1;
                }
                else cordX += 110;

                punto = new Point(cordX, cordY);
            }
            else
            {
                punto = new Point(cordX, cordY);
            }

            pic.Location = punto;

            pic.BorderStyle = BorderStyle.FixedSingle;
        }

        private void dibujarSlots()
        {
            foreach (PictureBox item in pictures)
            {
                this.Controls.Add(item);
            }
        }
    }
}
