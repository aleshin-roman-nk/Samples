using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindiwConvertation
{
	public class MainPresenter
	{
		IManRepo _repo;
		IMainView _mainView;

		public MainPresenter(IMainView v)
		{
			_mainView = v;
			_repo = new ManRepo();

			_mainView.DisplayMen(_repo.GetAll());

			_mainView.StartEdit += _mainView_StartEdit;
		}

		private void _mainView_StartEdit(object sender, Man e)
		{
			(new ManForm()).Go(e, ManFormEndHandler);
		}

		void ManFormEndHandler(ViewResult res)
		{
			if (res.Ok)
			{
				MessageBox.Show((res.Data as Man).Name);
			}
		}
	}
}
