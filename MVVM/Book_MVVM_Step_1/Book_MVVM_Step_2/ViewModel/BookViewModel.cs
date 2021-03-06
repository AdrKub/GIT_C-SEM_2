﻿using Book_MVVM_Step_2.Model;
using System.ComponentModel;

namespace Book_MVVM_Step_2.ViewModel
{
    public class BookViewModel : INotifyPropertyChanged
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
                RaisePropertyChanged("Title");
            }
        }

        public string Author
        {
            get { return _book.Author; }
            set
            {
                _book.Author = value;
                RaisePropertyChanged("Author");
            }
        }

        public double Price
        {
            get { return _book.Price; }
            set
            {
                _book.Price = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Book GetBook()
        {
            //Simuliert das Laden eines Buches aus der Datenbank
            return new Book() { Title = "Herr der Ringe - Die Gefährten", Author = "Tolkien", Price = 56.95 };
        }
    }
}
