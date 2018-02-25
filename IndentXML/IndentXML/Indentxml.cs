using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace IndentXML
{
    public partial class Indentxml : MaterialSkin.Controls.MaterialForm
    {
        public Indentxml()
        {
            InitializeComponent();
            var mgr = MaterialSkin.MaterialSkinManager.Instance;
            mgr.AddFormToManage(this);
            mgr.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            mgr.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green600,
                MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Orange700,
                MaterialSkin.TextShade.WHITE);

        }


        public string Ifile { get; } = Pd + "\\Input\\input.xml";
        public string Ofile { get; } = Pd + "\\Output\\output.xml";

        public static string Pd { get; set; } = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName;

        private void btnOutput_Click(object sender, EventArgs e)
        {
            try
            {
                using (var w = new XmlTextWriter(Ofile, new UTF8Encoding()))
                {
                    var doc = new XmlDocument();
                    doc.Load(Ifile);
                    w.Indentation = 4;
                    w.Formatting = Formatting.Indented;
                    doc.Save(w);
                }
                txtOutput.Text = File.ReadAllText(Ofile);
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
        }

        private void Indentxml_Load(object sender, EventArgs e)
        {
            
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Ifile))
                {
                    txtInput.Text = File.ReadAllText(Ifile);
                }
                else
                {
                    MessageBox.Show(@"Please create using TextBox", @"File Not Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
        }
    }
}
