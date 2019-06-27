using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.AccessControl;

namespace GeneralLabelerStation
{
    public partial class Form_Password : Form
    {
        RegistryKey openregedit = Registry.LocalMachine;
        RegistryKey opensystem ;
        RegistryKey openhostar;

        string shostarAdmin;
        string shostarEngineer;
        string shostarOP;
        //密码确认 1-密码错误 2-管理员密码正确 3-工程师密码正确 4-操作员密码正确
        public Form_Password()
        {
            InitializeComponent();
        }

        private void Form_Password_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            //设置默认确认取消按钮
            this.AcceptButton = bOK;
            //焦点设置在密码框
            this.ActiveControl = tBPassword;

            try
            {
                //查询注册表信息
                opensystem = openregedit.OpenSubKey("SYSTEM", true);
                if (opensystem == null)
                {
                    //存在率100% 不做防呆
                    //opensystem = openregedit.CreateSubKey("system");
                }
                else
                {
                    openhostar = opensystem.OpenSubKey("hostar", true);
                    if (openhostar == null)
                    {
                        openhostar = opensystem.CreateSubKey("hostar");
                        openhostar.SetValue("admin", "666666");
                        openhostar.SetValue("engineer", "666666");
                        openhostar.SetValue("OP", "666666");
                    }
                }
                shostarAdmin = openhostar.GetValue("admin").ToString();
                shostarEngineer = openhostar.GetValue("engineer").ToString();
                shostarOP = openhostar.GetValue("OP").ToString();
            }
            catch { }

            comboBox1.Items.Clear();
            if (Form_Main.VariableSys.LanguageFlag == 1)
            {
                this.Text = "Log in";
                label2.Text = "Name";
                label1.Text = "Password";
                comboBox1.Items.Add("Operator");
                comboBox1.Items.Add("Engineer");
                comboBox1.Items.Add("Manager");
                bOK.Text = "OK";
                bCancel.Text = "Cancel";
            }
            else
            {
                this.Text = "用户登录";
                label2.Text = "用户名称";
                label1.Text = "密码";
                comboBox1.Items.Add("运行-操作员");
                comboBox1.Items.Add("调试-工程师");
                comboBox1.Items.Add("管理-管理员");
                bOK.Text = "确定";
                bCancel.Text = "取消";
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
             if( tBPassword.Text == "")
             {
                 Variable.PassWordOK = 1;//NG
                 if (Form_Main.VariableSys.LanguageFlag == 1)
                 {
                     MessageBox.Show("Password can not be empty!", "Info");
                 }
                 else
                 {
                     MessageBox.Show("密码不能为空！", "友情提示");
                 }
                 tBPassword.Focus();
                 return;
             }
             else
             {
                 switch (comboBox1.SelectedIndex)
                 {
                     case 0:
                         if (tBPassword.Text == shostarOP)//密码正确
                         {
                             Variable.PassWordOK = 4;//OK
                             this.Close();
                         }
                         else
                         {
                             Variable.PassWordOK = 1;//NG
                             if (Form_Main.VariableSys.LanguageFlag == 1)
                             {
                                 MessageBox.Show("wrong password!", "Info");
                             }
                             else
                             {
                                 MessageBox.Show("密码错误！", "友情提示");
                             }
                             tBPassword.Text = "";
                             tBPassword.Focus();
                             return;
                         }
                         break;
                     case 1:
                         if (tBPassword.Text == shostarEngineer)//密码正确
                         {
                             Variable.PassWordOK = 3;//OK
                             this.Close();
                         }
                         else
                         {
                             Variable.PassWordOK = 1;//NG
                             if (Form_Main.VariableSys.LanguageFlag == 1)
                             {
                                 MessageBox.Show("wrong password!", "Info");
                             }
                             else
                             {
                                 MessageBox.Show("密码错误！", "友情提示");
                             }
                             tBPassword.Text = "";
                             tBPassword.Focus();
                             return;
                         }
                         break;
                     case 2:
                         if (tBPassword.Text == shostarAdmin)//密码正确
                         {
                             Variable.PassWordOK = 2;//OK
                             this.Close();
                         }
                         else
                         {
                             Variable.PassWordOK = 1;//NG
                             if (Form_Main.VariableSys.LanguageFlag == 1)
                             {
                                 MessageBox.Show("Password wrong!", "Info");
                             }
                             else
                             {
                                 MessageBox.Show("密码错误！", "友情提示");
                             }
                             
                             tBPassword.Text = "";
                             tBPassword.Focus();
                             return;
                         }
                         break;
                 }
             }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            tBPassword.Text = "";
            this.Close();
        }

        private void tBPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "")
            {
                tBPassword.Text = "";
                this.Close();
            }
        }
    }
}
