using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace GeneralLabelerStation.Tool
{
    public partial class frm_AutoOpimzitePaste : Form
    {
        public frm_AutoOpimzitePaste(DataGridView view)
        {
            InitializeComponent();
            this.view = view;
        }

        public DataGridView view = null;

        /// <summary>
        /// 选择需要分配的吸嘴
        /// </summary>
        public CheckedIndexCollection NzChecked
        {
            get
            {
                return this.checkedListBox1.CheckedIndices;
            }
        }

        /// <summary>
        /// 贴附顺序调整模式
        /// </summary>
        public int OpimtzteMode
        {
            get
            {
                if(this.radioButton1.Checked)
                    return 0;
                else if(this.radioButton2.Checked)
                    return 1;
                else if (this.radioButton3.Checked)
                    return 2;
                else if (this.radioButton4.Checked)
                    return 3;
                return 0;
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (this.NzChecked.Count == 0)
                return;

            List<Tuple<int, PointF>> pasteIndex = new List<Tuple<int, PointF>>();
            for(int rowIndex = 0; rowIndex < view.RowCount -1;++rowIndex)
            {
                PointF xy = new PointF();
                xy.X = float.Parse(view.Rows[rowIndex].Cells[2].Value.ToString());
                xy.Y = float.Parse(view.Rows[rowIndex].Cells[3].Value.ToString());
                pasteIndex.Add(new Tuple<int, PointF>(rowIndex, xy));
            }

            // 排序
            pasteIndex.Sort((a,b) => {
                if (a.Item2.X < b.Item2.X)
                    return 1;
                else if (a.Item2.X == b.Item2.X)
                    return 0;
                else
                    return -1;
            });

            int everNzLen = pasteIndex.Count / 4;
            if (pasteIndex.Count % 4 != 0) everNzLen++;

            //int pcsCount = 0;
            //int nz = 0;
            //for(int everIndex = 0; everIndex < everNzLen; ++everIndex)
            //{
            //    if(pcsCount < pasteIndex.Count)
            //    {
            //        int nz = pcsCount / everNzLen;
            //        view.Rows[pasteIndex[pcsCount].Item1].Cells[10].Value = nz + 1;
            //        everIndex++;
            //        pcsCount++;
            //    }
            //    else
            //    {
            //        nz++;
            //        everIndex = 0;
            //        break;
            //    }
            //}

            for (int i = 0; i < pasteIndex.Count; ++i)
            {
                int nzIndex = 0;
                if (everNzLen > 0)
                {
                    nzIndex = i / everNzLen;
                }

                view.Rows[pasteIndex[i].Item1].Cells[10].Value = nzIndex + 1;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
