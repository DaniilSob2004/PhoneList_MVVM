using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneListMVVM
{
    // model class
    public class Phone : INotifyPropertyChanged
    {
        private string? title;
        private string? company;
        private int price;

        public Phone(string title = "Title", string company = "Company", int price = 0)
        {
            Title = title;
            Company = company;
            Price = price;
        }

        public string? Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string? Company
        {
            get => company;
            set
            {
                company = value;
                OnPropertyChanged("Company");
            }
        }
        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
