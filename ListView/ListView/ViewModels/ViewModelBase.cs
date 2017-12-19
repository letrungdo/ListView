using ListView.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListView.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        //public DelegateCommand CellAppearanceClick { get; set; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            //CellAppearanceClick = new DelegateCommand(cellAppearance);


        }
        //private void cellAppearance()
        //{
        //    NavigationService.NavigateAsync("CellAppearance");
        //}


        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}
