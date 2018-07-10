using System.Collections.Generic;
using Microsoft.Win32;
using FussballManager.Model;
using System.IO;

namespace FussballManager
{
    public class ChangePlayerPicture
    {
        private string _picDirectoryPath;
        private string _oldPicturePath;
        private string _newPicturePath;
        private bool _pictureChanged = false;

        public ChangePlayerPicture(string picDirectoryPath)
        {
            _picDirectoryPath = picDirectoryPath;
        }

        private bool PictureExist(string picPath) //Kontrolle ob Bild existiert
        {
            if (File.Exists(picPath))
                return true;
            else
                return false;
        }

        private void DeletePicture(string picPath)
        {
            if(Path.GetFileNameWithoutExtension(picPath) != "anonymus")
                File.Delete(picPath);
        }

        private bool SearchInDirectory(string pictureName) //Suchen ob Bildname schon vorhanden ist
        {
            List<string> allPicturesAtDirectory = new List<string>();
            bool result = false;

            //Alle vorhandenen Bilder laden
            foreach (string picPath in Directory.GetFiles(_picDirectoryPath))
            {
                allPicturesAtDirectory.Add(picPath);
            }

            //Kontrolle ob Bildname schon vorhanden ist
            foreach (string picturePath in allPicturesAtDirectory)
            {
                if (picturePath.Contains(pictureName) == true)
                    result = true;
            }
            return result;
        }

        public void SaveNewPicture(Player player) //Neu definiertes Bild für Spieler speichern
        {
            if (_pictureChanged)
            {
                string newPictureName;
                string newPicutreExtension;
                string genPicturePath;

                //Kontrolle ob neues Bild noch vorhanden ist
                if (PictureExist(_newPicturePath))
                {
                    //Kontrolle ob altes Bild noch vorhanden ist -> löschen
                    if (PictureExist(_oldPicturePath))
                        DeletePicture(_oldPicturePath);
                }

                //Neuer Name für Bilddatei generieren
                newPicutreExtension = Path.GetExtension(_newPicturePath);
                newPictureName = $"{player.FirstName}{player.Name}{newPicutreExtension}";

                //Kontrolle ob neuer Name bereits vorhanden ist
                while (SearchInDirectory(newPictureName))
                {
                    newPictureName = $"{player.FirstName}{player.Name}_1{newPicutreExtension}";
                }

                //Neuer Pfad erzeugen und in Spieler speichern
                genPicturePath = $"{_picDirectoryPath}{newPictureName}";

                player.PicturePath = genPicturePath;

                //Neues Bild in standard Verzeichniss mit neuem Namen kopieren
                File.Copy(_newPicturePath, genPicturePath);
                ThrowChanges();
            }
        }

        public void SetNewPicture(Player player) //Neues Bild für Spieler definieren
        {
            _pictureChanged = false;
            _oldPicturePath = player.PicturePath;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Bild ändern",
                Filter = "jpg Dateien (*.jpg)|*.jpg|png Dateien (*.pgn)|*.png|Alle Dateien (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _newPicturePath = openFileDialog.FileName;
                player.PicturePath = _newPicturePath;
                _pictureChanged = true;
            }
        }

        public void ThrowChanges()
        {
            _pictureChanged = false;
            _oldPicturePath = "";
            _newPicturePath = "";
        }
    }
}
