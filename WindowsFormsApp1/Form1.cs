using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class Form1 : Form
    {
        NotifyIcon notifyIcon;
        Button button;
        public Form1()
        {
            //InitializeComponent();
            button = new Button();
            button.Location = new Point(10, 10);
            button.Text = "button";
            button.Click += Button_Click;
            this.Controls.Add(button);
            this.ShowInTaskbar = false;
            setComponents();
        }
        private void setComponents()
        {
            notifyIcon = new NotifyIcon();
            // アイコンの設定
            notifyIcon.Icon = new Icon(@"C:\test\img\s.ico");
            // アイコンを表示する
            notifyIcon.Visible = true;
            // アイコンにマウスポインタをあわせたときのテキスト
            notifyIcon.Text = "NotifyIconテスト";

            // コンテキストメニュー
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Text = " & 終了";
            toolStripMenuItem.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem);
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            // NotifyIconのクリックイベント
            notifyIcon.Click += NotifyIcon_Click;
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // アプリケーションの終了
            Application.Exit();
        }

        private void Button_Click(object sender, EventArgs e) //not work
        {
            //バルーンヒントを表示する
            notifyIcon.BalloonTipTitle = "お知らせタイトル";
            notifyIcon.BalloonTipText = "お知らせメッセージ";
            notifyIcon.ShowBalloonTip(5000);
        }
    }
}
