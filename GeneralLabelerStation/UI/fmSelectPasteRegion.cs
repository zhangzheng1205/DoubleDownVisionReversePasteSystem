using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralLabelerStation.UI
{
    public partial class fmSelectPasteRegion : Form
    {
        public fmSelectPasteRegion()
        {
            InitializeComponent();
        }

        public List<string> DisRegions = new List<string>();

        public List<string> AllRegions = new List<string>();

        private void bOk_Click(object sender, EventArgs e)
        {
            DisRegions = new List<string>();
            for(int i = 0; i < this.cbPasteRegionList.Items.Count;++i)
            {
                if(this.cbPasteRegionList.GetItemCheckState(i) == CheckState.Unchecked)
                {
                    DisRegions.Add(this.cbPasteRegionList.Items[i].ToString());
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void fmSelectPasteRegion_Load(object sender, EventArgs e)
        {
            AllRegions = new List<string>();
            for (int i = 0; i < Form_Main.Instance.RUN_PASTEInfo.Length; ++i)
            {
                for(int j = 0; j < Form_Main.Instance.RUN_PASTEInfo[i].Region.Length; ++j)
                {
                    if(!AllRegions.Contains(Form_Main.Instance.RUN_PASTEInfo[i].Region[j]))
                    {
                        AllRegions.Add(Form_Main.Instance.RUN_PASTEInfo[i].Region[j]);
                    }
                }
            }

            this.cbPasteRegionList.Items.Clear();
            for (int i = 0; i < AllRegions.Count; ++i)
            {
                if (this.DisRegions.Contains(AllRegions[i]))
                    this.cbPasteRegionList.Items.Add(AllRegions[i], false);
                else
                    this.cbPasteRegionList.Items.Add(AllRegions[i], true);
            }
        }
    }
}
