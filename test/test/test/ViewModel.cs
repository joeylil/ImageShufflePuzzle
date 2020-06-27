using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace test
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
       

        private string _topLeftImage =  "";

        public string topLeftImage
        {
            get { return _topLeftImage; }

            set
            {
                _topLeftImage = value;
                NotifyPropertyChanged();
            }
        }

        private string _topMiddleImage = "Images/10.png";

        public string topMiddleImage
        {
            get { return _topMiddleImage; }

            set
            {
                _topMiddleImage = value;
                NotifyPropertyChanged();
            }
        }

        private string _topRightImage = "Images/20.png";

        public string topRightImage
        {
            get { return _topRightImage; }

            set
            {
                _topRightImage = value;
                NotifyPropertyChanged();
            }
        }

        private string _centreLeftImage = "Images/01.png";

        public string centreLeftImage
        {
            get { return _centreLeftImage; }

            set
            {
                _centreLeftImage = value;
                NotifyPropertyChanged();
            }
        }

        private string _centreMiddleImage = "Images/11.png";

        public string centreMiddleImage
        {
            get { return _centreMiddleImage; }

            set
            {
                _centreMiddleImage = value;
                NotifyPropertyChanged();
            }
        }

        private string _centreRightImage = "Images/21.png";

        public string centreRightImage
        {
            get { return _centreRightImage; }

            set
            {
                _centreRightImage = value;
                NotifyPropertyChanged();
            }
        }

        private string _bottomLeftImage = "Images/02.png";

        public string bottomLeftImage
        {
            get { return _bottomLeftImage; }

            set
            {
                _bottomLeftImage = value;
                NotifyPropertyChanged();
            }
        }

        private string _bottomMiddleImage = "Images/12.png";

        public string bottomMiddleImage
        {
            get { return _bottomMiddleImage; }

            set
            {
                _bottomMiddleImage = value;
                NotifyPropertyChanged();
            }
        }

        private string _bottomRightImage = "Images/22.png";

        public string bottomRightImage
        {
            get { return _bottomRightImage; }

            set
            {
                _bottomRightImage = value;
                NotifyPropertyChanged();
            }
        }
        private string _wins;

        public string wins
        {
            get
            {
                return string.Format("Wins: {0}", numberWins);
            }
            set
            {
                _wins = string.Format("Wins: {0}", numberWins);
                NotifyPropertyChanged();
            }
        }

        private int _numberWins = 0;

        public int numberWins
        {
            get
            {
                return _numberWins;
            }
            set
            {
                _numberWins = value;
            }
        }

    }
}
