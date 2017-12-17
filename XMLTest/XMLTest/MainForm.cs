using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlFunctions;

namespace XMLTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string strOutput = "";
            XMLErrorCode nRet = XmlFuncs.GetXmlData("11.xml", "/WorkData/CCD_Data/CCD1", "ExposureTime", ref strOutput);
            Console.WriteLine(strOutput);
            Console.WriteLine(nRet);

            int nOutput = 0;
            nRet = XmlFuncs.GetXmlData("11.xml", "/WorkData/Index_Station", "PC2_C_Port", ref nOutput);
            Console.WriteLine(nOutput);
            Console.WriteLine(nRet);

            long lOutput = 0;
            nRet = XmlFuncs.GetXmlData("11.xml", "/WorkData/Index_Station", "PC1_C_Port", ref lOutput);
            Console.WriteLine(lOutput);
            Console.WriteLine(nRet);

            double dOutput = 0;
            nRet = XmlFuncs.GetXmlData("11.xml", "/WorkData/Index_Station", "PC2_C_Port", ref dOutput);
            Console.WriteLine(dOutput);
            Console.WriteLine(nRet);

            bool bOutput = false;
            nRet = XmlFuncs.GetXmlData("11.xml", "/WorkData/Store_Station", "TrayEmpytSRCheck", ref bOutput);
            Console.WriteLine(bOutput);
            Console.WriteLine(nRet);            

            byte byOutput = 0;
            nRet = XmlFuncs.GetXmlData("11.xml", "/WorkData/Unloader_Station", "NozzleNumber", ref byOutput);
            Console.WriteLine(byOutput);
            Console.WriteLine(nRet);
        }
    }
}
