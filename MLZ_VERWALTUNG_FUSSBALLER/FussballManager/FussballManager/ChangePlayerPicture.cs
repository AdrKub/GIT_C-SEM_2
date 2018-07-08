using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using FussballManager.Model;
using System.IO;

namespace FussballManager
{
    public class ChangePlayerPicture
    {
        private string _picDirectoryPath;
        private bool PictureExist(string picPath)
        {
            if (File.Exists(picPath))
                return true;
            else
                return false;
        }

        private void DeletePicture(string picPath)
        {
            File.Delete(picPath);
        }

        private void SaveNewPicture(string picPath)
        {
            File.Copy(picPath, _picDirectoryPath);
        }


        public void SetNewPicture(Player player, string picDirectoryPath)
        {
            _picDirectoryPath = picDirectoryPath;
            string newPath;
            string oldPath = player.PicturePath;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Bild ändern";
            openFileDialog.Filter = "jpg Dateien (*.jpg)|*.jpg|png Dateien (*.pgn)|*.png|Alle Dateien (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                newPath = openFileDialog.FileName;
                if (PictureExist(oldPath))
                {

                }
            }
        }
    }
}
