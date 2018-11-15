using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace ADONET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BUS_Suppliers bus = new BUS_Suppliers();
            dataGridView1.DataSource = bus.getSuppliers();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Save all modified rows?","Warning",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                BUS_Suppliers bus = new BUS_Suppliers();
                bus.updateSuppliers((DataTable)dataGridView1.DataSource);
            }
            refreshData();
        }

        void refreshData()
        {
            BUS_Suppliers bus = new BUS_Suppliers();
            dataGridView1.DataSource = bus.getSuppliers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all selected rows?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                BUS_Suppliers bus = new BUS_Suppliers();
                bus.deleteSuppliers(dataGridView1);
            }
            refreshData();
        }
    }
}
