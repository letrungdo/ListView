using ListView.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ListView.ViewModels
{
	public class CellAppearanceViewModel : ViewModelBase
	{
        INavigationService _navigationService;

        private ObservableCollection<HoaQua> _listHoaQua;
        public ObservableCollection<HoaQua> ListHoaQua
        {
            get { return _listHoaQua; }
            set { SetProperty(ref _listHoaQua, value); }
        }
       
        public CellAppearanceViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            ObservableCollection<HoaQua> ds = new ObservableCollection<HoaQua>();
            ds.Add(new HoaQua { Title = "Tiêu đề 1", SubTitle = "content 1", Image="icon.png"});
            ds.Add(new HoaQua { Title = "Tiêu đề 1", SubTitle = "content 1", Image = "icon.png" });

            ListHoaQua = ds;

           
        }
        //
       

    }
}
