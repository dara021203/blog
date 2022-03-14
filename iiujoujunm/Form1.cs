using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iiujoujunm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            DialogResult respuesta;

            string ruta;
            openFileDialog1.Title = "Abrir archivo de texto";
            openFileDialog1.Filter = "archivo de texto|*.txt";
            openFileDialog1.FileName = "";
            respuesta = openFileDialog1.ShowDialog();
            if (respuesta == DialogResult.OK)
            {
                ruta = openFileDialog1.FileName;
                FileStream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                StreamReader leer = new StreamReader(archivo);
                string linea = leer.ReadLine();
                rtvblog.Text = linea;
            }
            else
            {
                MessageBox.Show("Cancelaste abrir archivo");

            }
        } 





     private void saveToolStripMenuItem_Click(object sender, EventArgs e)
            {
            if (rtvblog.Text == "")
            {
                MessageBox.Show(" Ingrese un  texto");
            }
            else
            {
                agregar();

            }
        }
        public void agregar()
        {
            saveFileDialog1.FileName = ".txt";
            var N = saveFileDialog1.ShowDialog();
            if (N == DialogResult.OK)
            {
                using (var savefile = new System.IO.StreamWriter(saveFileDialog1.FileName))
                {
                    savefile.Write(rtvblog.Text);
                }
            }
            treeView1.Nodes.Add(saveFileDialog1.FileName);
            rtvblog.Text = "";

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rtvblog_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void estiloDeFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtvblog.Text == "")
            {
                MessageBox.Show(" Debe escribir algo");
            }
            else
            {
                FontDialog estilo = new FontDialog();
                estilo.Font = rtvblog.Font;
                if (estilo.ShowDialog() == DialogResult.OK)
                    rtvblog.Font = estilo.Font;
            }


          
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            if (rtvblog.Text == "")
            {
                MessageBox.Show(" Debe escribir algo");
            }
            else
            {
                ColorDialog color = new ColorDialog();
                if (color.ShowDialog() == DialogResult.OK)
                    rtvblog.ForeColor = color.Color;

            }
           



        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea guardar?"," NUEVO ", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                agregar();
            }
            else if (result == DialogResult.No)
            {
                rtvblog.Clear();
            }
            else if (result == DialogResult.Cancel)
            {

            }

            rtvblog.Clear();
            
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
    } 
