using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.IO;

namespace AreaMeter
{
	public partial class FormHelp : Form
	{
		public FormHelp()
		{
			InitializeComponent();
			try
			{
				Assembly assembly = Assembly.GetExecutingAssembly();
                Stream streamHelp = assembly.GetManifestResourceStream("AreaMeter.Help.rtf");
				richTextBox1.LoadFile(streamHelp, RichTextBoxStreamType.RichText);
				//string[] names = assembly.GetManifestResourceNames();
                //ResourceManager resMan = new ResourceManager("AreaMeter.Help.rtf", assembly);
				//FileStream fileHelp = assembly.GetFile(nameFile);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
