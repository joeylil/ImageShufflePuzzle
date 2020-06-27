using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace test
{
    class gridChange
    {
        private int _row;

        public int row
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
            }
        }

        private int _column;

        public int column
        {
            get
            {
                return _column;
            }
            set
            {
                _column = value;
            }
        }

        private Image _imageToAdd;

        public Image imageToAdd
        {
            get
            {
                return _imageToAdd;
            }
            set
            {
                _imageToAdd = value;
            }
        }

        private Image _imageToDelete;

        public Image imageToDelete
        {
            get
            {
                return _imageToDelete;
            }
            set
            {
                _imageToDelete = value;
            }
        }
    }
}
