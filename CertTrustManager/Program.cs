using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertTrustManager
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (args != null && args.Length > 0)
			{
				AttachConsole(ATTACH_PARENT_PROCESS);
				CertTrustHelper helper = new CertTrustHelper();
				if (args[0].ToLower() == "trust")
				{
					string error = helper.TrustCertificate();
					if (error != null)
						Console.Error.WriteLine(error);
					else
						Console.Write(helper.IsCertTrusted() ? "trusted" : "untrusted");
				}
				else if (args[0].ToLower() == "untrust")
				{
					string error = helper.UntrustCertificate();
					if (error != null)
						Console.Error.WriteLine(error);
					else
						Console.Write(helper.IsCertTrusted() ? "trusted" : "untrusted");
				}
				else if (args[0].ToLower() == "istrusted")
				{
					string error = helper.Load();
					if (error != null)
						Console.Error.WriteLine(error);
					else
						Console.Write(helper.IsCertTrusted() ? "trusted" : "untrusted");
				}
				else
				{
					FileInfo fiExe = new FileInfo(Application.ExecutablePath);
					Console.WriteLine("Usage: " + fiExe.Name + " [trust|untrust|istrusted]");
					Console.WriteLine("\t\ttrust - The embedded certificate will be trusted");
					Console.WriteLine("\t\tuntrust - The embedded certificate will be untrusted");
					Console.WriteLine("\t\tistrusted - application will write \"trusted\" or \"untrusted\" to stdout");
				}
				return;
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AttachConsole(uint dwProcessId);
		const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;  // default value if not specifing a process 
	}
}
