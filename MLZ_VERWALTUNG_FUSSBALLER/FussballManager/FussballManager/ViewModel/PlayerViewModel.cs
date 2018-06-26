using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FussballManager.Model;
using _20_MvvmFramework;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FussballManager.ViewModel
{
    public class PlayerViewModel : ObservableObject
        {
        private Player player;

        private Image myImage = new Image();
        private BitmapImage biMap = new BitmapImage();

        public PlayerViewModel(Player inplayer)
        {
            player = inplayer;
        }

        #region Properties
        public Player Player
        {
            get { return player; }
            set
            {
                player = value;
                RaisePropertyChanged();
            }
        }

        public Position Position
        {
            get { return player.Position; }
        }

        //public string Name
        //{
        //    get { return player.Name; }
        //    set
        //    {
        //        player.Name = value;
        //        RaisePropertyChanged();
        //    }
        //}

        public string FirstName
        {
            get { return player.FirstName; }
            set
            {
                player.FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string CompleteName
        {
            get { return player.Name + " " + player.FirstName; }
        }

        public int Height
        {
            get { return player.Height; }
            set
            {
                player.Height = value;
                RaisePropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get { return player.BirthDate; }
            set
            {
                player.BirthDate = value;
                RaisePropertyChanged();
            }
        }

        public string PicPath
        {
            get { return player.PicturePath; }
            set
            {
                player.PicturePath = value;
                RaisePropertyChanged();
            }
        }

        public string PositionName
        {
            get { return player.Position.PosName; }
        }

        public int PlayedGames
        {
            get { return player.PlayedGames; }
            set
            {
                player.PlayedGames = value;
                RaisePropertyChanged();
            }
        }

        public int Goals
        {
            get { return player.Goals; }
            set
            {
                player.Goals = value;
                RaisePropertyChanged();
            }
        }

        public int Number
        {
            get { return player.PlayerNumber; }
            set
            {
                player.PlayerNumber = value;
                RaisePropertyChanged();
            }

        }

        public string ImageFile
        {
            //get
            //{
            //    biMap.BeginInit();
            //    biMap.UriSource = new Uri(@"D:\HBU_NDS\GIT_C#SEM_2\MLZ_VERWALTUNG_FUSSBALLER\FussballManager\FussballManager\Application_Data\Pictures", UriKind.Absolute);
            //    biMap.EndInit();
            //    myImage.Stretch = Stretch.Fill;
            //    myImage.Source = biMap;
            //    return myImage.Source;
                
            //}
            //get { return @"D:\HBU_NDS\GIT_C#SEM_2\MLZ_VERWALTUNG_FUSSBALLER\FussballManager\FussballManager\Application_Data\Pictures\breelEmbolo.png"; }
            get { return @"Images\stevenZuber.png"; }
        }
        #endregion
    }
}
