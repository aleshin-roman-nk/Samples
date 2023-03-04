using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogHistory
{
	public class NoteRec
	{
		public DateTime Date { get; set; }
		public string Text { get; set; }

		public string Title
		{
			get
			{
				return $"{Date.ToString("dd-MM-yyyy HH:mm:ss")}";
			}
		}

		public NoteRec(DateTime dt, string text)
		{
			Date = dt;
			Text = text;
		}
	}
}
