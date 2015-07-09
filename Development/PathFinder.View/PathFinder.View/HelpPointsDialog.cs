using System;
using System.Drawing;
using System.Windows.Forms;

namespace PathFinder.View
{
    public partial class HelpPointsDialog : Form
    {
        public HelpPointsDialog()
        {
            InitializeComponent();
            if (PathGenerator.HelPoints != null)
            {
                foreach (var helpPoint in PathGenerator.HelPoints)
                {
                    HelpPointsGrid.Rows.Add(helpPoint.X, helpPoint.Y);
                }
            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            try
            {
                PathGenerator.HelPoints.Clear();
                foreach (DataGridViewRow record in HelpPointsGrid.Rows)
                {
                    if ((record.Cells["X"].Value == null || String.IsNullOrEmpty(record.Cells["X"].Value.ToString())) ||
                       (record.Cells["Y"].Value == null || String.IsNullOrEmpty(record.Cells["Y"].Value.ToString())))
                    {
                        continue;
                    }
                    var point = new Point(Convert.ToInt32(record.Cells["X"].Value), Convert.ToInt32(record.Cells["Y"].Value));
                    PathGenerator.HelPoints.Add(point);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Incorect row value");
                return;
            }
            this.Close();
        }
    }
}
