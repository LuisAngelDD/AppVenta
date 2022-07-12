using System.Threading.Tasks;
using System.Windows.Input;
using App_renta_libros.repositorio;
using GalaSoft.MvvmLight.Command;
using Xamarin.Essentials;

namespace App_renta_libros.viewmodel
{
    internal class VMProducts : BaseViewModel
    {
        RProducto repositoriProducto = new RProducto();

        public VMProducts()
        {
            InsertMethod();
        }

        #region Attributes
        public bool isRefreshing = false;
        public object listViewSource;
        #endregion

        #region Proporties
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public object ListViewSource
        {
            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }
        #endregion

        #region Commands
        public ICommand InsertComand
        {
            get
            {
                return new RelayCommand(InsertMethod);
            }
        }
        #endregion

        #region Methods
        private async void InsertMethod()
        {
            this.IsRefreshing = true;
            await LoadData();
            this.IsRefreshing = false;
        }
        public async void search(string name)
        {
            this.IsRefreshing = true;
            await LoadDataS(name);
            this.IsRefreshing = false;
        }

        public async Task LoadData()
        {
            this.ListViewSource = await repositoriProducto.GetAll();
        }
        public async Task LoadDataS(string name)
        {
            this.ListViewSource = await repositoriProducto.GetAllByName(name);
        }
        #endregion
    }
}
