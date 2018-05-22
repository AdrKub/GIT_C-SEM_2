using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LINQ_XML_4_3
{
    public partial class Form1 : Form
    {
        XDocument books;
        List<string> bookID = new List<string>();
        string Test;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            books = XDocument.Load(@"..\..\boats.xml");
            var booklist = from _book in books.Descendants("book")
                           select _book;
            foreach(var _b in booklist)
            {
                bookID.Add((string)_b.Attribute("id"));
            }
            LstBx_Books.DataSource = null;
            LstBx_Books.DataSource = bookID;
        }

        private void LstBx_Books_SelectedIndexChanged(object sender, EventArgs e)
        {
            var booklist = from _book in books.Descendants("book")
                           where _book.Attribute("id").Value == LstBx_Books.Text
                           select _book;

            foreach (var _b in booklist)
            {
                Lbl_Author.Text = (String)_b.Element("author");
                Lbl_Title.Text = (String)_b.Element("title");
                Lbl_Genre.Text = (String)_b.Element("genre");
                Lbl_Price.Text = (String)_b.Element("price");
                Lbl_PubDate.Text = (String)_b.Element("publish_date");
                Lbl_Description.Text = (String)_b.Element("description");
            }
        }
    }
}
