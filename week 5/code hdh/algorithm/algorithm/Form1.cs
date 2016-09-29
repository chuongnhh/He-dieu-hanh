using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace algorithm
{
    public partial class Form1 : Form
    {
        private RL rl;
        private int overhead;// do tre khi chuyen ngu canh
        private int quantum;//
        string ketqua = "";
        int somucuutien;
        public Form1()
        {
            rl = new RL();
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = open.FileName;
                docFile(open.FileName);
            }
        }

        private void docFile(string filePath)
        {
            dgvTienTrinh.Rows.Clear();
            List<string> list_string = new List<string>();

            // tao instance cua StreamReader de doc mot file.
            // lenh using cung duoc su dung de dong StreamReader.
            using (StreamReader sr = new StreamReader(filePath))
            {
                rl.num = int.Parse(sr.ReadLine());// line 1
                overhead = int.Parse(sr.ReadLine());// line 2
                quantum = int.Parse(sr.ReadLine());//line 3
                txtQuantum.Text = quantum.ToString();
                somucuutien = int.Parse(sr.ReadLine());//line 4

                string line;
                // doc va hien thi cac dong trong file cho toi
                // khi tien toi cuoi file. 
                while ((line = sr.ReadLine()) != null)
                {
                    // tai sao phai + 4**
                    string[] tmp = line.Split(' ');

                    Process m = new Process();
                    m.pname = tmp[0];
                    m.tarrive = int.Parse(tmp[1]);
                    m.burst = int.Parse(tmp[2]);
                    m.priority = int.Parse(tmp[3]);
                    rl.m.Enqueue(m);

                    // đưa lên datagrid
                    dgvTienTrinh.Rows.Add(m.pname.ToString());
                    dgvTienTrinh.Rows[dgvTienTrinh.RowCount-1].Cells["Arrival"].Value = m.tarrive;
                    dgvTienTrinh.Rows[dgvTienTrinh.RowCount-1].Cells["Burst"].Value = m.burst;
                    dgvTienTrinh.Rows[dgvTienTrinh.RowCount-1].Cells["Priority"].Value = m.priority;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbAlgorithm.SelectedIndex = 0;
            enableControls(false);
        }

        private int fcfs(RL rl, List<string> cpu)
        {
            dgvKetQua.Rows.Clear();
            rtbGantt.Clear();
            Process m;
            int wt = 0, tt = 0;
            while (rl.m.Count() != 0)
            {
                m = rl.m.Dequeue();


                // tinh toan ket qua, thong ke
                wt = cpu.Count() - m.tarrive;
                tt = wt + m.burst;

                // day ket qua ra man hinh
                dgvKetQua.Rows.Add(m.pname);
                dgvKetQua.Rows[dgvKetQua.RowCount - 1].Cells["WT"].Value = wt;
                dgvKetQua.Rows[dgvKetQua.RowCount - 1].Cells["TT"].Value = tt;
                // cap nhat cpu cho process m
                // in du lieu
                for (int i = 0; i < m.burst; i++)
                {
                    cpu.Add(m.pname);
                    // xuat gantt
                    rtbGantt.AppendText(m.pname + " ");
                }
            }
            return cpu.Count();//thoi gian su dung
        }
        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbThongSo.Items.Clear();
            if (cmbAlgorithm.SelectedIndex == 0)
            {
                cmbThongSo.Visible = false;
            }
            if (cmbAlgorithm.SelectedIndex == 1)
            {
                cmbThongSo.Visible = true;
                cmbThongSo.Items.Add("Chung thủy");
                cmbThongSo.Items.Add("Không chung thủy");
                cmbThongSo.SelectedIndex = 0;
            }
            else if (cmbAlgorithm.SelectedIndex == 2)
            {
                cmbThongSo.Visible = true;
                cmbThongSo.Items.Add("Độc quyền");
                cmbThongSo.Items.Add("Không độc quyền");
                cmbThongSo.SelectedIndex = 0;
            }
        }

        private void dgvTienTrinh_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvTienTrinh.RowCount <= 0)
            {
                enableControls(false);
            }
            else enableControls(true);
        }

        private void enableControls(bool st)
        {
            cmbAlgorithm.Enabled = st;
            cmbThongSo.Enabled = st;
            btnXepLich.Enabled = st;
        }

        private void btnXepLich_Click(object sender, EventArgs e)
        {
            List<string> cpu = new List<string>();
            if (cmbAlgorithm.SelectedIndex == 0)
                fcfs(rl, cpu);
            else if (cmbAlgorithm.SelectedIndex == 1)
            {
                MessageBox.Show("Chưa có làm!!");
            }
            else
            {
                MessageBox.Show("Chưa có làm!!");
            }
        }
    }
}
