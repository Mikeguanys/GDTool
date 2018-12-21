using GDateBase2v.SQLServer;
using GDateBase2v.MySQL;
using GDCreateTool.Comm;
using GDCreateTool.Comm.Enum;
using InsideComm;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using GDCreateTool.Model;
using System.IO;

namespace GDCreateTool
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            FormComm FCom = new FormComm(this);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                LoadModelCondition();
                var r = LoadBaseTable();
                foreach (var item in r)
                {
                    ltbleft.Items.Add(item.TableName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常："+ex.Message);
            }            
        }
        /// <summary>
        /// 加载数据库的表
        /// </summary>
        private List<BaseTable> LoadBaseTable()
        {
            string BaseType = DataConnection.DBInfo.BaseName;
            DataTable dt = new DataTable();
            if (BaseType == EDType.MySQL.ToString())
            {                
                MySQLBSHelper MySQL = new MySQLBSHelper(PComm.ConnectionName);
                dt = MySQL.BsDataTable($"select table_name as TableName from information_schema.tables where table_schema = '{DataConnection.DBInfo.DataName}' order by TABLE_NAME asc ");
            }
            else if (BaseType == EDType.SQLServer.ToString())
            {
                SQLServerBSHelper SqlServer = new SQLServerBSHelper(PComm.ConnectionName);
                dt = SqlServer.BsDataTable("SELECT name as TableName FROM SysObjects Where XType = 'U' or XType='V' ORDER BY Name");
            }
            return dt.ToModel<BaseTable>();
        }
        /// <summary>
        /// 加载条件枚举。
        /// </summary>
        private void LoadModelCondition()
        {
            cklmodel.Items.Clear();
            var r = SysTool.EnumToList<ModelType>();
            foreach (var item in r)
            {
                cklmodel.Items.Add(item);
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ltbleft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ltbleft.SelectedIndex > -1)
            {
                ltbright.Items.Add(ltbleft.Text);
                ltbleft.Items.RemoveAt(ltbleft.SelectedIndex);
            }            
        }

        private void ltbright_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ltbright.SelectedIndex > -1)
            {
                ltbleft.Items.Add(ltbright.Text);
                ltbright.Items.RemoveAt(ltbright.SelectedIndex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTableName.Text))
            {
                MessageBox.Show("请填写表名");               
            }
            else
            {
                for (int i = 0; i < ltbleft.Items.Count; i++)
                {
                    if (ltbleft.Items[i].Equals(txtTableName.Text))
                    {
                        ltbleft.SelectedIndex = i;
                    }
                }                             
            }
        }
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateFile_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 窗口生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateWinds_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 模板设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 打开生成的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "CreateFile";
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            System.Diagnostics.Process.Start(filepath);
        }
    }
}
