using Book_MVVM_Step_4.Model;
using System.ComponentModel;
using System.Windows.Input;
using _20_MvvmFramework;

namespace Book_MVVM_Step_4.ViewModel
{
    public class BookViewModel : ObservableObject
    {
        private Book _book;

        public BookViewModel()
        {
            _book = GetBook();
        }

        public string Title
        {
            get { return _book.Title; }
            set
            {
                _book.Title = value;
                PropertyChanged2?.Invoke(this, new PropertyChangedEventArgs("Title"));
                //RaisePropertyChanged();
            }
        }

        public string Author
        {
            get { return _book.Author; }
            set
            {
                _book.Author = value;
                RaisePropertyChanged();
                //PropertyChanged2?.Invoke(this, new PropertyChangedEventArgs("Author"));
            }
        }

        public double Price
        {
            get { return _book.Price; }
            set
            {
                _book.Price = value;
                PropertyChanged2?.Invoke(this, new PropertyChangedEventArgs("Price"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged2;

        private void RaisePropertyChanged2(string propertyName)
        {   
            //Variante A
            //PropertyChangedEventHandler handler = PropertyChanged;
            //if (handler != null)
            //{
            //    handler(this, new PropertyChangedEventArgs(propertyName));
            //}

            //Variante B
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}

            //Variante C - Operator ?. fragt Ergebniss auf NULL ab
            PropertyChanged2?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Book GetBook()
        {
            //Simuliert das Laden eines Buches aus der Datenbank
            return new Book() { Title = "Herr der Ringe - Die Gefährten", Author = "Tolkien", Price = 56.95 };
        }


        #region Commands

        void UpdateTitleCommandExecute()
        {
            Title = Title + " T";
        }

        void UpdateAuthorCommandExecute()
        {
            Author = Author + " A";
        }

        bool UpdateTitleCommandCanExecute()
        {
            return true;
        }

        public ICommand UpdateTitle
        {
            get
            {
                return new RelayCommand(UpdateTitleCommandExecute, UpdateTitleCommandCanExecute);
            }
        }

        public ICommand UpdateAuthor
        {
            get
            {
                return new RelayCommand(UpdateAuthorCommandExecute, UpdateTitleCommandCanExecute);
            }
        }


        #endregion
    }
}
