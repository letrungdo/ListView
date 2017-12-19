using ListView.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListView.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        // private readonly NhanVien _item;
        //
        INavigationService _navigationService { get; set; }

        private ObservableCollection<NhanVien> _listNhanVien;

        public ObservableCollection<NhanVien> ListNhanVien
        {
            get { return _listNhanVien; }
            set { SetProperty(ref _listNhanVien, value);
                OnPropertyChanged(nameof(ListNhanVien));//
            }
        }
        //

        public DelegateCommand CellAppearanceClick { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand<NhanVien> ItemAppearingCommand { get; set; }
        public MyRepository _myRepository { get; set; }


        //Pull to refresh
        //public ICommand RefreshCommand
        //{
        //    get
        //    {
        //        return new Command(() =>
        //        {
        //            IsRefreshing = true;

        //            RefreshData();

        //            IsRefreshing = false;
        //        });
        //    }
        //}

        private ObservableCollection<NhanVien> LoadData()
        {

            ObservableCollection<NhanVien> aNhanVen = new ObservableCollection<NhanVien>();
            for (var i = 0; i < 35; i++)
            {
                aNhanVen.Add(new NhanVien { Ten = "Nhan Vien Load" + i });
                ///aNhanVen.Add(new NhanVien("Nhan vien " + i.ToString()));  // chú ý 0 tạo hàm khởi tạo kiểu này=>Lỗi
            }
            return aNhanVen;

        }

        //private bool _isRefreshing = false;
        //public bool IsRefreshing
        //{
        //    get { return _isRefreshing; }
        //    set
        //    {
        //        _isRefreshing = value;
        //        OnPropertyChanged(nameof(IsRefreshing));
        //    }
        //}
        //To let the user know that we are working on something
        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        //Refresh command
        Command _refreshCommand;
        public Command RefreshCommand
        {
            get
            {
                return _refreshCommand;
            }
        }
        //

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";
            _navigationService = navigationService;

            _myRepository = MyRepository.GetInstance();

            //_item = item;
            ObservableCollection<NhanVien> aNhanVen = new ObservableCollection<NhanVien>();

            for (var i = 0; i < 35; i++)
            {
                aNhanVen.Add(new NhanVien { Ten = "Nhan Vien" + i });
                ///aNhanVen.Add(new NhanVien("Nhan vien " + i.ToString()));  // chú ý 0 tạo hàm khởi tạo kiểu này=>Lỗi
            }
            ListNhanVien = aNhanVen;

            //
            CellAppearanceClick = new DelegateCommand(cellAppearance);

            //Load more
            ItemAppearingCommand = new DelegateCommand<NhanVien>((x) =>
            {
                NhanVien nv = ListNhanVien.Last();
                if (x.Ten == nv.Ten)
                {
                    Reload(nv.ID + 1);
                }
            });

            //pull to refresh
            _refreshCommand = new Command(async () => await RefreshList());

          

        }
       

        async Task RefreshList()
        {
            IsRefreshing = true;
            ListNhanVien = null;
            ListNhanVien = LoadData();
            IsRefreshing = false;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        private void cellAppearance()
        {
            Debug.WriteLine("btn Click OK");
            _navigationService.NavigateAsync("CellAppearance");
        }

        public void Reload(int last)
        {
            var foo = _myRepository.GetNext(last);
            foreach (var item in foo)
            {
                ListNhanVien.Add(item);
            }
        }
    }
}
