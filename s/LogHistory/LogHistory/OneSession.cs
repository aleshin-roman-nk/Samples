using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogHistory
{
	public class OneSession
	{
		List<NoteRec> _log = new List<NoteRec>();
		public IEnumerable<NoteRec> Items => _log;

		/// <summary>
		/// Исходник, хранится в бд
		/// </summary>
		public string data_source
		{
			get
			{
				return ser();
			}
			set
			{
				_log = deser(value);
			}
		}

		public void AddNote(DateTime dt, string text)
		{
			_log.Add(new NoteRec(dt, text));
		}

		public string Html
		{
			get
			{
				StringBuilder str = new StringBuilder();

				string alert_primary = ".alert-primary { color: #004085; background-color: #cce5ff; border-color: #b8daff;}";
				
				string alert = ".alert " +
					"{font-family: Roboto Condensed, sans-serif;" +
					"position: relative; " +
					"padding: 0.75mm 1.25mm; " +
					"margin-bottom: 1mm; " +
					"border: 2px solid transparent;" +
					"-webkit-border-radius: 15px;}";

				string html = "html { background-color: #74b9ff;}";

				string styles = $"<style>{html}{alert}{alert_primary}</style>";

				str.Append(styles);

				foreach (var item in _log.AsEnumerable().Reverse())
				{
					var ttt = item.Text.Replace("\n", "<br>");

					str.Append("<div class=\"alert alert-primary\">");
					str.Append($"<b>{item.Title}</b>");
					str.Append($"<p>{ttt}</p></div>");
				}

				return str.ToString();
			}
		}

		private string ser()
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(_log);
		}

		private List<NoteRec> deser(string str)
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<List<NoteRec>>(str);
		}
	}
}
