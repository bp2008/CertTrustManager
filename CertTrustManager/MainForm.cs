using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertTrustManager
{
	public partial class MainForm : Form
	{
		CertTrustHelper helper = new CertTrustHelper();
		public MainForm()
		{
			InitializeComponent();
			this.Text = "Certificate Trust Manager " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		private void createNewTrustManagerFromcerFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
			DialogResult dr = openFileDialog1.ShowDialog(this);
			if (dr == DialogResult.OK)
			{
				// Write a copy of this exe with the specified certificate embedded.
				FileInfo fiCer = new FileInfo(openFileDialog1.FileName);
				string nameNoExt = fiCer.Name.Remove(fiCer.Name.Length - fiCer.Extension.Length);
				byte[] cer = File.ReadAllBytes(fiCer.FullName);
				FileInfo fiExe = new FileInfo(Application.ExecutablePath);
				byte[] exe;
				using (FileStream fs = fiExe.OpenRead())
					exe = ByteUtil.ReadNBytes(fs, helper.exeLength);
				using (FileStream fs = new FileStream(nameNoExt + "-TrustManager.exe", FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
				{
					fs.Write(exe, 0, exe.Length);
					fs.Write(cer, 0, cer.Length);
					int cerNameLength = ByteUtil.WriteUtf8(nameNoExt, fs);
					ByteUtil.WriteUtf8("EmbeddedCert", fs);
					ByteUtil.WriteInt32(exe.Length, fs);
					ByteUtil.WriteInt32(cer.Length, fs);
					ByteUtil.WriteInt32(cerNameLength, fs);
				}
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			string error = helper.Load();
			if (error != null)
				lblCertName.Text = error;
			else
			{
				lblCertName.Text = helper.certName;
				btnTrust.Enabled = true;
				SetTrustedText();
			}
		}

		private void btnTrust_Click(object sender, EventArgs e)
		{
			if (helper.IsCertTrusted())
				helper.UntrustCertificate();
			else
				helper.TrustCertificate();
			SetTrustedText();
		}
		private void SetTrustedText()
		{
			if (helper.IsCertTrusted())
			{
				lblCurrentlyTrusted.Text = "Yes";
				btnTrust.Text = "Untrust Certificate";
			}
			else
			{
				lblCurrentlyTrusted.Text = "No";
				btnTrust.Text = "Trust Certificate";
			}
		}
	}
}
