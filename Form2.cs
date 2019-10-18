using LectorTxt.WS_ECUADOR;
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

namespace LectorTxt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

                



            string textfile;
            textfile = textBox13.Text;
            string cadena = File.ReadAllText(textfile);
            string[] arreglo = cadena.Split('|');
            int largo = arreglo.Length;

            arbol.Nodes[0].Nodes.Add(arreglo[30]);

            if (largo > 43)
            {


                // Vayamos guardando los valores del textbox1 hasta el textbox12
                textBox1.Text = arreglo[1];
                textBox2.Text = arreglo[2];
                textBox3.Text = arreglo[3];
                textBox4.Text = arreglo[4];
                textBox5.Text = arreglo[5];
                textBox6.Text = arreglo[6];
                textBox7.Text = arreglo[7];
                textBox8.Text = arreglo[8];
                textBox9.Text = arreglo[9];
                textBox10.Text = arreglo[10];
                textBox11.Text = arreglo[11];
                textBox12.Text = arreglo[12];
                textBox15.Text = arreglo[13];
                textBox16.Text = arreglo[14];
                textBox17.Text = arreglo[15];
                textBox18.Text = arreglo[16];
                textBox19.Text = arreglo[17];
                textBox20.Text = arreglo[18];
                textBox21.Text = arreglo[23];
                textBox22.Text = arreglo[24];
                textBox23.Text = arreglo[25];
                textBox24.Text = arreglo[26];

                //ahora subtotales IVA
                textBox25.Text = arreglo[38];
                textBox26.Text = arreglo[39];
                textBox27.Text = arreglo[40];
                textBox28.Text = arreglo[41];
                textBox29.Text = arreglo[42];
                textBox30.Text = arreglo[43];
                textBox31.Text = arreglo[44];
                textBox32.Text = arreglo[45];
                textBox33.Text = arreglo[46];
                textBox34.Text = arreglo[47];
                textBox35.Text = arreglo[48];
                textBox36.Text = arreglo[49];
                textBox37.Text = arreglo[50];
                textBox38.Text = arreglo[51];
                textBox14.Text = arreglo[52];
                textBox39.Text = arreglo[67];
                textBox40.Text = arreglo[68];
                textBox41.Text = arreglo[69];


                //CONNTABILIZAMOS LA LINEAS DE LOS PRODUCTOS Y LA VOLCAMOS EN EL GRIDVIEW1


                int filastotal = File.ReadAllLines(textfile).Length;
                int fila = filastotal - 2;
                int datatotal = 34 * fila;
                int puntero = 83; //desde aqui comenzaran todos los productos de factura
                int n = 0;
                int m = 0;

                grilla.RowCount = fila+1; //agregamos tantas filas como productos trae la factura


                while (puntero < datatotal + 83)
                {

                    while (n < 20)
                    {
                        grilla.Rows[m].Cells[n].Value = arreglo[puntero];
                        n++;
                        puntero++;

                    }

                    n = 0;
                    m++;
                    puntero += 14; //se agregan 14 campos nulos


                }

            }
            else
            {
                MessageBox.Show("TXT MAL FORMADO,intente con otro archivo");
            }
            
            
           
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox13.Text = openFileDialog1.FileName;
                openFileDialog1.Dispose();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Abrimos el archivo o lo creamos y luego guardamos los valores

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "archivo.txt";
            savefile.Filter= "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            
           
            savefile.ShowDialog(); //Aqui abrimos el directorio y guardamos el archivo

            File.WriteAllText(savefile.FileName, string.Empty);





            using (StreamWriter writer = new StreamWriter(savefile.FileName))
            { 
                //****************primera  parte****************************************
            writer.Write("01" + "|");
            writer.Write( textBox1.Text+"|");
            writer.Write(textBox2.Text + "|");
            writer.Write(textBox3.Text + "|");
            writer.Write(textBox4.Text + "|");
            writer.Write(textBox5.Text + "|");
            writer.Write(textBox6.Text + "|");
            writer.Write(textBox7.Text + "|");
            writer.Write(textBox8.Text + "|");
            writer.Write(textBox9.Text + "|");
            writer.Write(textBox10.Text + "|");
            writer.Write(textBox11.Text + "|");
            writer.WriteLine(textBox12.Text + "|");
            writer.Write("02" + "|");
            writer.Write(textBox16.Text + "|");
            writer.Write(textBox17.Text + "|");
            writer.Write(textBox18.Text + "|");
            writer.Write(textBox19.Text + "|");
            writer.Write(textBox20.Text + "|");
            writer.Write("|"); //campos de guias de remision
            writer.Write("|");
            writer.Write("|");
            writer.Write("|"); //campos de guias de remision
            writer.Write(textBox21.Text + "|");
            writer.Write(textBox22.Text + "|");
            writer.Write(textBox23.Text + "|");
            writer.Write(textBox24.Text + "|");
                int pip = 0;
                while (pip < 11)
                {
                    writer.Write("|");
                    pip++;
                }
                writer.Write(textBox25.Text + "|");
            writer.Write(textBox26.Text + "|");
            writer.Write(textBox27.Text + "|");
            writer.Write(textBox28.Text + "|");
            writer.Write(textBox29.Text + "|");
            writer.Write(textBox30.Text + "|");
            writer.Write(textBox31.Text + "|");
            writer.Write(textBox32.Text + "|");
            writer.Write(textBox33.Text + "|");
            writer.Write(textBox34.Text + "|");
            writer.Write(textBox35.Text + "|");
            writer.Write(textBox36.Text + "|");
            writer.Write(textBox37.Text + "|");

                pip = 0;
                while (pip < 14)
                {
                    writer.Write("|");
                    pip++;
                }

            writer.Write(textBox38.Text + "|");
            writer.Write(textBox14.Text + "|");
            writer.Write(textBox39.Text + "|");
            writer.Write(textBox40.Text + "|");
            writer.Write(textBox41.Text + "|");
                pip = 0;
                while (pip < 12)
                {
                    writer.Write("|");
                    pip++;
                }
                writer.WriteLine("|");


                // *******COLOQUEMOS LOS DATOS DEL GRIDVIEW *****
                                                             int i = 0;
                    while (i < grilla.RowCount-1)
                    {
                        
                        for (int n = 0; n < 20; n++)
                        {
                            writer.Write(grilla.Rows[i].Cells[n].Value+"|");
                        
                        }

                 //*********************************relleno de pipes******************
                    for (int n = 0; n < 14; n++)
                    {
                        writer.Write("|");

                    }
                //*********************************relleno de pipes******************
                        i++;
                        writer.Write("\r");

                     } //fin while 
                   
                
                writer.Close();    
               
            } //fin using


            //*******************QUITAMOS LINEAS VACIAS*********************************
                       
           //Leemos todas la lineas
            string[] strAllLines = File.ReadAllLines(savefile.FileName);
            //Selecciona las lineas que no sean null o blancas
            //Guarda las nuevas lineas en el nuevo fichero
            File.WriteAllLines(savefile.FileName, strAllLines.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray());
            savefile.Dispose();
            //**************************************************************************



            MessageBox.Show("Documento listo,revise si hay entrelineado");


        } // fin boton

        private void button5_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox42.Text = openFileDialog1.FileName;
                openFileDialog1.Dispose();
            }

            WS_ECUADOR.Integracion samir = new WS_ECUADOR.Integracion();  //Creamos el objeto samir

 


            //*************CONVERTIMOS EL ARCHIVO A BASE 64 y enviamos a Web Service***********************       

            string archivo = textBox42.Text;
            byte[] bytes = File.ReadAllBytes(archivo);
           
            var resp=samir.Factura("1792433738001","1792433738001_INT", "EQPCWF6Q7KRM", bytes, archivo);

            
            var timbre=samir.TimbresRestantes("1792433738001_INT", "EQPCWF6Q7KRM", "1792433738001");
            richTextBox1.Text = "La Cantidad de Folios restantes son:"+timbre.NrodeTickets;

            //***************************************************************************


        }// fin boton


      






    } // fin form2
}
