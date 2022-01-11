using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoMultiObjectEdit
{
	public class MainPresenter
	{
		private readonly OpenObjectManager _openObjectManager;
		private readonly ObjRepo _objRepo;
		IMainView _mainView;

		public MainPresenter(IMainView v)
		{
			_openObjectManager = new OpenObjectManager();
			_mainView = v;

			_objRepo = new ObjRepo();

			_mainView.OpenDoc += _mainView_OpenDoc;
			_objRepo.DbChanged += _objRepo_DbChanged;
			// >>> 06-01-2022 21:29
			// все правильно - главный презентер имеет доступ к репозиторию.далее см. OpenObjectManager.cs, [1]
			_openObjectManager.Save += _openObjectManager_Save;
			_openObjectManager.OpenWindowsCountChanged += _openObjectManager_OpenWindowsCountChanged;

			_mainView.Display(_objRepo.GetAll());
		}

		private void _openObjectManager_OpenWindowsCountChanged(object sender, int e)
		{
			_mainView.OpenWindowCount = e;
		}

		private void _openObjectManager_Save(object sender, Obj e)
		{
			_objRepo.Save(e);
			_mainView.Display(_objRepo.GetAll());
		}

		private void _objRepo_DbChanged(object sender, EventArgs e)
		{
			_mainView.Display(_objRepo.GetAll());
		}

		private void _mainView_OpenDoc(object sender, Obj e)
		{
			_openObjectManager.Open(e);
		}
	}
}
