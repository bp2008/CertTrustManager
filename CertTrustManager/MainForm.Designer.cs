namespace CertTrustManager
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnTrust = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblCertName = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblCurrentlyTrusted = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.createNewTrustManagerFromcerFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnTrust
			// 
			this.btnTrust.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTrust.Enabled = false;
			this.btnTrust.Location = new System.Drawing.Point(12, 59);
			this.btnTrust.Name = "btnTrust";
			this.btnTrust.Size = new System.Drawing.Size(339, 33);
			this.btnTrust.TabIndex = 0;
			this.btnTrust.Text = "Trust Certificate";
			this.btnTrust.UseVisualStyleBackColor = true;
			this.btnTrust.Click += new System.EventHandler(this.btnTrust_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Certificate Name:";
			// 
			// lblCertName
			// 
			this.lblCertName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCertName.Location = new System.Drawing.Point(108, 9);
			this.lblCertName.Name = "lblCertName";
			this.lblCertName.Size = new System.Drawing.Size(243, 13);
			this.lblCertName.TabIndex = 2;
			this.lblCertName.Text = "...";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Currently Trusted:";
			// 
			// lblCurrentlyTrusted
			// 
			this.lblCurrentlyTrusted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurrentlyTrusted.Location = new System.Drawing.Point(108, 33);
			this.lblCurrentlyTrusted.Name = "lblCurrentlyTrusted";
			this.lblCurrentlyTrusted.Size = new System.Drawing.Size(243, 13);
			this.lblCurrentlyTrusted.TabIndex = 4;
			this.lblCurrentlyTrusted.Text = "No";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewTrustManagerFromcerFileToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(289, 26);
			// 
			// createNewTrustManagerFromcerFileToolStripMenuItem
			// 
			this.createNewTrustManagerFromcerFileToolStripMenuItem.Name = "createNewTrustManagerFromcerFileToolStripMenuItem";
			this.createNewTrustManagerFromcerFileToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
			this.createNewTrustManagerFromcerFileToolStripMenuItem.Text = "Create New Trust Manager From .cer File";
			this.createNewTrustManagerFromcerFileToolStripMenuItem.Click += new System.EventHandler(this.createNewTrustManagerFromcerFileToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Certificate|*.cer";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(363, 102);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.lblCurrentlyTrusted);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblCertName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnTrust);
			this.Name = "MainForm";
			this.Text = "Certificate Trust Manager";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnTrust;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblCertName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblCurrentlyTrusted;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem createNewTrustManagerFromcerFileToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}

