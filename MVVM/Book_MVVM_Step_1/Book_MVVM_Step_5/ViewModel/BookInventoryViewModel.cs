using _20_MvvmFramework;
using Book_MVVM_Step_5.DataAccessLayer;
using Book_MVVM_Step_5.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Book_MVVM_Step_5.ViewModel
{
    public class BookInventoryViewModel
    {
        private readonly BookRepository bookRepository = new BookRepository();
        private ObservableCollection<Book> books = new ObservableCollection<Book>();

        public ObservableCollection<Book> Books
        {
            get { return books; }
            set { books = value; }
        }

        public BookInventoryViewModel()
        {
            for (int i = 0; i<5; i++)
            {
                books.Add(new Book
                {
                    Title = bookRepository.GetRandomTitle(),
                    Author = bookRepository.GetRandomAuthor(),
                    Price = bookRepository.GetRandomPrice()
                });
            }
        }

        public ICommand UpdateAllTitles { get { return new RelayCommand(UpdateTitleExecute, CanUpdateTitleExecute); } }

        void UpdateTitleExecute()
        {
            if (books == null)
                return;

            foreach (var book in books)
            {
                book.Title = bookRepository.GetRandomTitle();
            }
        }

        bool CanUpdateTitleExecute()
        {
            return true;
        }




        public ICommand AddBook { get { return new RelayCommand(AddBookExecute,CanAddBookExecute); } }

        bool CanAddBookExecute()
        {
            return true;
        }

        void AddBookExecute()
        {
            if (books == null)
                return;

            books.Add(new Book
            {
                Title = bookRepository.GetRandomTitle(),
                Author = bookRepository.GetRandomAuthor(),
                Price = bookRepository.GetRandomPrice()
            });
        }
    }
}
