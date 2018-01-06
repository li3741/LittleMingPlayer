using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleMingPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigHelper.InitConfig();
        }
        PlayerHelper player = PlayerHelper.Inst();
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                player.PlayList.Add(open.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.Play(0, true);
            player.SetPlayTime(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            player.Stop();
            player.Dispose();
            base.OnFormClosing(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            player.Rewind();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                player.PlayList.AddRange(System.IO.Directory.GetFiles(folder.SelectedPath, "*.mp3", System.IO.SearchOption.AllDirectories));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            player.PlayNext();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            player.PlayPreview();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var hosting = HostingHelper.InitHosting();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            InstallHelper.InstallServce();
        }
    }
}
