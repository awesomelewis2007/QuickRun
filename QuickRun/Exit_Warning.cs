﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickRun
{
	public partial class Exit_Warning : Form
	{
		public Exit_Warning()
		{
			InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}

		private void Exit_button_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Cancel_button_Click(object sender, EventArgs e)
		{
			Hide();
		}
	}
}
