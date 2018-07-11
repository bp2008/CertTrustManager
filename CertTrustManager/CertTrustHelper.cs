using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertTrustManager
{
	public class CertTrustHelper
	{
		public X509Certificate2 cert = null;
		public int exeLength = 0;
		public string certName = "";
		private bool isLoaded = false;
		private const string noCert = "No embedded certificate";
		public CertTrustHelper()
		{
		}
		public string Load()
		{
			if (isLoaded)
				return cert == null ? noCert : null;
			isLoaded = true;
			FileInfo fiExe = new FileInfo(Application.ExecutablePath);
			exeLength = (int)fiExe.Length;
			using (FileStream fs = new FileStream(fiExe.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				if (fs.Length > 24)
				{
					fs.Seek(-24, SeekOrigin.End);
					if (ByteUtil.ReadUtf8(fs, 12) == "EmbeddedCert")
					{
						exeLength = ByteUtil.ReadInt32(fs);
						int certLength = ByteUtil.ReadInt32(fs);
						int certNameLength = ByteUtil.ReadInt32(fs);
						fs.Seek(exeLength, SeekOrigin.Begin);
						byte[] certBytes = ByteUtil.ReadNBytes(fs, certLength);
						cert = new X509Certificate2(certBytes);
						certName = ByteUtil.ReadUtf8(fs, certNameLength);
					}
				}
			}
			return cert == null ? noCert : null;
		}
		public string TrustCertificate()
		{
			Load();
			if (cert == null)
				return noCert;
			X509Store caStore = null;
			try
			{
				caStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
				caStore.Open(OpenFlags.ReadWrite);
				if (!caStore.Certificates.Contains(cert))
					caStore.Add(cert);
			}
			catch (Exception ex)
			{
				caStore?.Close();
				return "Failed to trust certificate: " + ex.ToString();
			}
			finally
			{
				caStore?.Close();
			}
			return null;
		}

		public string UntrustCertificate()
		{
			Load();
			if (cert == null)
				return noCert;
			X509Store caStore = null;
			try
			{
				caStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
				caStore.Open(OpenFlags.ReadWrite);
				if (caStore.Certificates.Contains(cert))
					caStore.Remove(cert);
			}
			catch (Exception ex)
			{
				caStore?.Close();
				return "Failed to untrust certificate: " + ex.ToString();
			}
			finally
			{
				caStore?.Close();
			}
			return null;
		}
		public bool IsCertTrusted()
		{
			Load();
			if (cert == null)
				return false;
			X509Store caStore = null;
			try
			{
				caStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
				caStore.Open(OpenFlags.ReadOnly);
				return caStore.Certificates.Contains(cert);
			}
			catch (Exception)
			{
				return false;
			}
			finally
			{
				caStore?.Close();
			}
		}
	}
}
