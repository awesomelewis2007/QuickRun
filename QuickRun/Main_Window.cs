﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace QuickRun
{
	public partial class MainWindow : Form
	{
		private ContextMenu contextMenu1;
		private MenuItem menuItem1;


		public MainWindow()
		{
			InitializeComponent();
			components = new Container();
			contextMenu1 = new ContextMenu();
			menuItem1 = new MenuItem();
			
			contextMenu1.MenuItems.AddRange(
				new MenuItem[] {menuItem1});
			
			menuItem1.Index = 0;
			menuItem1.Text = "E&xit Quickrun";
			menuItem1.Click += new EventHandler(menuItem1_Click);
			Trayicon.ContextMenu = contextMenu1;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Version.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
			Trayicon.BalloonTipIcon = ToolTipIcon.Info;
			Trayicon.BalloonTipText = "Welome to quick run";
			Trayicon.BalloonTipTitle = "QuickRun " + Assembly.GetEntryAssembly().GetName().Version;
			Trayicon.ShowBalloonTip(500);
			Run.FlatAppearance.BorderSize = 0;
		}

		private void Exit_onclick(object sender, EventArgs e)
		{
			Exit_Warning f2 = new Exit_Warning();
			f2.ShowDialog();
		}

		private void Run_onclick(object sender, EventArgs e)
		{
			string strCmdText;
			strCmdText = Args.Text;
			if (strCmdText == "Enter Arguments")
			{
				strCmdText = "";
			}
			try
			{
				//Try create a minimized window, with the Command and Argument text.
				System.Diagnostics.Process.Start(Command.Text, strCmdText);
				this.WindowState = FormWindowState.Minimized;
				Command.Text = "Enter Command";
				Args.Text = "Enter Arguments (Optional)";
				this.Hide();
				//Create a notification to notify the user that QuickRun is running in the background as the system tray.
				Trayicon.BalloonTipIcon = ToolTipIcon.Info;
				Trayicon.BalloonTipText = "To open it click on the system tray icon (it could be hidden in the arrow).";
				Trayicon.BalloonTipTitle = "QuickRun is running in the background";
				Trayicon.ShowBalloonTip(500);
			}
			catch (Exception)
			{
				Error f3 = new Error();
				f3.ShowDialog();
			}

		}
		private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)

			{

				string strCmdText;
				strCmdText = Args.Text;
				if (strCmdText == "Enter Arguments (Optional)")
				{
					strCmdText = "";
				}
				try
				{
					//Try create a minimized window, with the Command and Argument text.
					System.Diagnostics.Process.Start(Command.Text, strCmdText);
					this.WindowState = FormWindowState.Minimized;
					Command.Text = "Enter Command";
					Args.Text = "Enter Arguments (Optional)";
					this.Hide();
					//Create a notification to notify the user that QuickRun is running in the background as the system tray.
					Trayicon.BalloonTipIcon = ToolTipIcon.Info;
					Trayicon.BalloonTipText = "To open it click on the system tray icon (it could be hidden in the arrow).";
					Trayicon.BalloonTipTitle = "QuickRun is running in the background";
					Trayicon.ShowBalloonTip(500);
				}
				catch (Exception)
				{
					Error f3 = new Error();
					f3.ShowDialog();
				}
				this.WindowState = FormWindowState.Minimized;
				this.Hide();
			}
		}

		private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void HideButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
			this.Hide();
		}

		private void cmd_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("cmd", "");
		}
		private void explorer_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("explorer", "");
		}

		private void about_Click(object sender, EventArgs e)
		{
			Info info = new Info();
			info.ShowDialog();
		}

		private void menuItem1_Click(object sender, EventArgs a)
		{
			this.Close();
		}
	}
}
