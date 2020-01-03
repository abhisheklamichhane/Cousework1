using DataHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace CourseWorkSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Startup();

            txt_RegisterNo.Text = Read_from_file();

        }

        public void Startup()
        {
            //var handler = new Handler();
            //var dataSet = handler.CreateDataSet();
            //AddSampleData(dataSet);
            //dataSet.WriteXmlSchema(@"D:\StudentCWSchema.xml");
            //dataSet.WriteXml(@"D:\StudentCWData.xml");

            //var dataSet = new DataSet();
            //dataSet.ReadXmlSchema(@"D:\StudentCWSchema.xml");
            //dataSet.ReadXml(@"D:\StudentCWData.xml");

            var i = 0;
        }

        private void AddSampleData(DataSet dataSet)
        {




            var dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "BBA";
            dr["DisplayText"] = "BBA Hons";
            dataSet.Tables["Course"].Rows.Add(dr);

            dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "Network & Communication";
            dr["DisplayText"] = "BCA Network";
            dataSet.Tables["Course"].Rows.Add(dr);

            dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "Programming & Application Development";
            dr["DisplayText"] = "BSc CSIT Application Development";
            dataSet.Tables["Course"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = "Ishwor Sapkota";
            dr["Address"] = "Kathmandu";
            dr["ContactNo"] = "9851220845";
            dr["CourseEnroll"] = 1;
            dr["RegistrationDate"] = DateTime.Today.AddDays(-2);
            dataSet.Tables["Student"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = "Samyam Sapkota";
            dr["Address"] = "Kathmandu";
            dr["ContactNo"] = "9851220846";
            dr["CourseEnroll"] = 2;
            dr["RegistrationDate"] = DateTime.Today.AddDays(-1);
            dataSet.Tables["Student"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = "Safal Sapkota";
            dr["Address"] = "Kathmandu";
            dr["ContactNo"] = "9851220847";
            dr["CourseEnroll"] = 3;
            dr["RegistrationDate"] = DateTime.Today.AddDays(-3);
            dataSet.Tables["Student"].Rows.Add(dr);

        }

        private void AddSampleDataforStd(DataSet dataSet)
        {

            var dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "BBA";
            dr["DisplayText"] = "BBA Hons";
            dataSet.Tables["Course"].Rows.Add(dr);

            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["Name"] = txt_fullName.Text;
            dr1["Address"] = txt_Address.Text;
            dr1["ContactNo"] = txt_ContactNo.Text;
            dr1["CourseEnroll"] = 1;
            dr1["RegistrationDate"] = DateTime.Today.AddDays(-2);
            dataSet.Tables["Student"].Rows.Add(dr1);
        }

        private void AddofStdReport(DataSet dataSet)
        {

            var dr1 = dataSet.Tables["StudentReport"].NewRow();
            dr1["Name"] = txt_fullName.Text;
            dr1["Address"] = txt_Address.Text;
            dr1["ContactNo"] = txt_ContactNo.Text;
            dr1["CourseEnroll"] = 1;
            dr1["RegistrationDate"] = DateTime.Today.AddDays(-2);
            dataSet.Tables["StudentReport"].Rows.Add(dr1);


        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            AddSampleDataforStd(dataSet);
            AddofStdReport(dataSet);

            var regno = txt_RegisterNo.Text;
            var name = txt_fullName.Text;
            //dataSet.WriteXmlSchema(@"D:\StudentCWSchema1.xml");
            dataSet.WriteXml(@"D:\" + name + "CWData" + regno + ".xml");

            dataSet.WriteXml(@"D:\StudentReport.xml");

            Write_to_file(txt_RegisterNo.Text);

            txt_RegisterNo.Text = Read_from_file();

            ClearControls();
        }

        private void Write_to_file(string text)
        {


            System.IO.File.WriteAllText(@"D:\count.txt", text);


        }
        private string Read_from_file()
        {

            string text = System.IO.File.ReadAllText(@"D:\count.txt");

            int i;

            i = int.Parse(text.ToString());
            i = i + 1;

            return i.ToString();

        }

        private void ClearControls()
        {
            txt_fullName.Text = "";
            txt_Address.Text = "";
            txt_Address.Text = "";
        }

        private void LoadStudentData()
        {
            var handler = new Handler();

            var dataSet = new DataSet();

            dataSet.ReadXml(@"D:\informaticsCollege\StudentSchema.xml");

            DataTable dtStd = new DataTable();
            dtStd = dataSet.Tables[1];
            gridStd.DataContext = dtStd.DefaultView;
        }

        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            txt_fullName.Text = "";
            txt_Address.Text = "";
            txt_ContactNo.Text = "";
            txt_RegisterNo.Text = "";
        }
    }
}