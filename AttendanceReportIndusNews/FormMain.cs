using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceReportIndusNews
{
    public partial class FormMain : Form
    {
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonImportFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog_Excel.ShowDialog();
        }

        public void OpenFileDialog_Excel_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = OpenFileDialog_Excel.FileName;
            string extension = Path.GetExtension(filePath);
            string header = "YES";
            string conStr, sheetName;

            conStr = string.Empty;
            switch (extension)
            {
                case ".xls": //EXCEL 97-03
                    conStr = string.Format(Excel03ConString, filePath, header);
                    break;

                case ".xlsx": //EXCEL 07-HIGHER
                    conStr = string.Format(Excel07ConString, filePath, header);
                    break;
            }

            //Get name of the first sheet of Excel file
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    con.Close();
                }
            }

            //Read data from the first sheet of Excel file
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter oda = new OleDbDataAdapter())
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandText = "SELECT * FROM ["+ sheetName +"]";
                        cmd.Connection = con;
                        con.Open();
                        oda.SelectCommand = cmd;
                        oda.Fill(dt);
                        con.Close();

                        dt = dt.DefaultView.ToTable(true, "Ac-No", "Name", "sTime", "sDate");
                        DataGridView_Excel.DataSource = dt;

                        //Group Employee Id and DateTime
                        var date = dt.AsEnumerable().GroupBy(s => s.Field<DateTime>("sDate")).ToList();
                        var employeeId = dt.AsEnumerable().GroupBy(s => s.Field<string>("Ac-No"));
                        var byAccount = employeeId.ToDictionary(g => g.Key, g => g.Select(s => s.Field<DateTime>("sTime").ToString("MM/dd/yyyy HH:mm")).ToArray());

                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("Id");
                        dataTable.Columns.Add("Check-In");
                        dataTable.Columns.Add("Check-Out");
                        dataTable.Columns.Add("Duration");
                        foreach (var item in byAccount)
                        {
                            for (int i = 0; i < date.Count; i++)
                            {
                                DataRow dataRow = dataTable.NewRow();
                                dataRow["Id"] = item.Key;
                                dataRow["Check-In"] = item.Value.Min();
                                dataRow["Check-Out"] = item.Value.Max();
                                dataTable.Rows.Add(dataRow);

                                DataGridView_Excel.DataSource = dataTable;
                            }
                            
                        }

                       
                    }
                }
            }
        }
    }
}
