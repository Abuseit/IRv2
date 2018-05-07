using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IRv2
{
    public partial class Form1 : Form
    {
        
        TextWriter _writer = null;
        string srtfilename = "";
        public Form1()
        {
            InitializeComponent();

        }

        private void FormConsole_Load(object sender, EventArgs e)
	        {
	             // Инстанциируем writer
	             _writer = new TextBoxStreamWriter(textBox1);
	             // Перенаправляем выходной поток консоли
	            Console.SetOut(_writer);
	            Console.WriteLine("Теперь вывод перенаправляется в textbox");
	        }

    private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                srtfilename = openFileDialog1.FileName;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
               
                Process p = new Process
                {
                    StartInfo = new ProcessStartInfo("cmd")
                    {
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true
                    }
                };
                p.Start();
                p.StandardInput.WriteLine("cd C:\\darknet\\build\\darknet\\x64");
                p.StandardInput.WriteLine("darknet_no_gpu.exe detector test data/coco.data cfg/yolov2.cfg yolov2.weights -i 0 -thresh 0.25 " + srtfilename);
                p.StandardInput.WriteLine("exit");
                p.WaitForExit();
                Console.WriteLine("OUTPUT = {0}", p.StandardOutput.ReadToEnd());
            }

            if (radioButton2.Checked)
            {

            }
            if (radioButton3.Checked)
            {

            }

        }


    }
}