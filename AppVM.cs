using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneListMVVM
{
    public class AppVM : INotifyPropertyChanged
    {
        private Phone? selectedPhone;
        private string titleSelect;
        private string companySelect;
        private int priceSelect;

        private MyCommand addCommand;
        private MyCommand removeCommand;
        public ObservableCollection<Phone> Phones { get; set; }

        public MyCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    return addCommand = new MyCommand(execute_ =>
                    {
                        Phone phone = new Phone(TitleSelect, CompanySelect, PriceSelect);
                        SelectedPhone = phone;
                        Phones.Insert(0, phone);
                    });
                }
                else return addCommand;
            }
        }

        public MyCommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                {
                    return removeCommand = new MyCommand(execute_ =>
                    {
                        Phones.Remove(SelectedPhone);
                    });
                }
                else return removeCommand;
            }
        }

        public Phone? SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;

                if (TitleSelect != value.Title) TitleSelect = value.Title;
                if (CompanySelect != value.Company) CompanySelect = value.Company;
                if (PriceSelect != value.Price) PriceSelect = value.Price;

                OnPropertyChanged("SelectedPhone");
            }
        }

        public string TitleSelect
        {
            get { return titleSelect; }
            set
            {
                titleSelect = value;
                SelectedPhone.Title = value;
                OnPropertyChanged("TitleSelect");
            }
        }

        public string CompanySelect
        {
            get { return companySelect; }
            set
            {
                companySelect = value;
                SelectedPhone.Company = value;
                OnPropertyChanged("CompanySelect");
            }
        }

        public int PriceSelect
        {
            get { return priceSelect; }
            set
            {
                priceSelect = value;
                SelectedPhone.Price = value;
                OnPropertyChanged("PriceSelect");
            }
        }

        public AppVM()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone { Title="iPhone 14", Company = "Apple", Price = 41499 },
                new Phone { Title="Samsung Galaxy S22", Company = "Samsung", Price = 50299 },
                new Phone { Title="Xiaomi 12", Company = "Xiaomi", Price = 25999 },
                new Phone { Title="Samsung Galaxy Fold 4", Company = "Samsung", Price = 79999 }
            };
            SelectedPhone = new Phone();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
