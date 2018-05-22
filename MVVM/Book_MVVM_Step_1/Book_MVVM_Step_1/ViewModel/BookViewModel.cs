using Book_MVVM_Step_1.Model;

namespace Book_MVVM_Step_1.ViewModel
{
    public class BookViewModel
    {
        private Book _book;

        public BookViewModel()
        {
            _book = GetBook();
        }

        public string Title
        {
            get { return _book.Title; }
            set { _book.Title = value; }
        }

        public string Author
        {
            get { return _book.Author; }
            set { _book.Author = value; }
        }

        public double Price
        {
            get { return _book.Price; }
            set { _book.Price = value; }
        }

        private Book GetBook()
        {
            //Simuliert das Laden eines Buches aus der Datenbank
            return new Book() { Title = "Herr der Ringe - Die Gefährten", Author = "Tolkien", Price = 56.95 };
        }
    }
}
