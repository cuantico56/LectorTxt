using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LectorTxt.WS_ECUADOR;

namespace LectorTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }

     

      

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK);
            {
                textBox1.Text = openFileDialog1.FileName;
            
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textfile;
            textfile = textBox1.Text;
            string cadena =File.ReadAllText(textfile);
            string[] arreglo = cadena.Split('|');
            for (int i = 0; i < arreglo.Length; i++) {

              
            
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button11.BackColor = Color.White;
            timer1.Enabled = true;
            richTextBox1.Text = string.Empty;
            richTextBox2.Text = string.Empty;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
                openFileDialog1.Dispose();
            }

           
            
            WS_ECUADOR.Integracion samir = new WS_ECUADOR.Integracion();  //Creamos el objeto samir




            //*************CONVERTIMOS EL ARCHIVO A BASE 64 y enviamos a Web Service***********************       

            string archivo = textBox2.Text;
            byte[] bytes = File.ReadAllBytes(archivo);


            
            var resp = samir.Factura("1792433738001", "1792433738001_INT", "EQPCWF6Q7KRM", bytes, archivo);
            richTextBox2.Text = "Procesando informacion,espere.....";
            MessageBox.Show("Enviada informacion");
            int rej = 0;
            while (rej < 650000)
            {
                rej++;
            }
           
            

            if (resp.Procesado == false)
            {
                richTextBox2.Text = "***********NO fue procesado*********" + "\n" + "Error Nro: " + resp.NumeroError + "\n" + "Menssaje: " + resp.MensajeError + "\n" + "Nro Autorización: " + resp.NrodeAutorizacion + "\n";
                timer1.Enabled = false;
                timer1.Stop();
                button11.BackColor = Color.White;
            }
            else {
                richTextBox2.Text = "*********Mensaje recibido*******" + "\n"+ "Error Nro: " + resp.NumeroError + "\n" + "Menssaje: " + resp.MensajeError + "\n" + "Nro Autorización: " + resp.NrodeAutorizacion + "\n";
                timer1.Enabled = false;
                timer1.Stop();
                button11.BackColor = Color.White;
            }
            
            richTextBox1.Text = resp.XMLTimbrado;

            //var timbre = samir.TimbresRestantes("1792433738001_INT", "EQPCWF6Q7KRM", "1792433738001");
            //richTextBox1.Text = "La Cantidad de Folios restantes son:" + timbre.NrodeTickets;

            //***************************************************************************
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            string col = button11.BackColor.Name;  
           
            
          switch (col)
            {

                case "White":

                    button11.BackColor = Color.Green;
                 
                    break;


                case "Green":

                    button11.BackColor = Color.White;

                    break;
            }




    }
    }
}
