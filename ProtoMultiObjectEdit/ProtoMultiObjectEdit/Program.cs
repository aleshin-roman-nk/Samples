using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtoMultiObjectEdit
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Form1 form = new Form1();	

			MainPresenter mainPresenter = new MainPresenter((IMainView)form);

			Application.Run(form);
		}
	}
}
