using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AndroidStringTranslate
{
    public partial class MainForm : Form
    {
        private string apkPath;

        private DataTable dataTable
            ;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                apkPath = file.FileName;
                Text = apkPath;
                bindData();
            }
        }

       private void bindData()
        {
            dataTable = new DataTable("fcstXML"); //建立一张叫做fcstXML的表  
            //创建列  
            dataTable.Columns.Add(new DataColumn("key", typeof(string)));
            dataTable.Columns.Add(new DataColumn("简体", typeof(string)));
            dataTable.Columns.Add(new DataColumn("繁体", typeof(string)));

            XElement doc = XElement.Load(apkPath);
            var node = from n in doc.Elements("string") select n;

            foreach (var xnode in node)
            {
                DataRow row = dataTable.NewRow();
                ///读取结点数据，并填充数据行  
                row["key"] = xnode.FirstAttribute.Value;
                row["简体"] = xnode.Value;
                dataTable.Rows.Add(row);
            }
                dataGridView1.DataSource = dataTable;
        }
    }
}
