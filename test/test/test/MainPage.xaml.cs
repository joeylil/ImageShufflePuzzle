using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;


namespace test
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ViewModel mainView = new ViewModel();
        Random random = new System.Random();
        int randomMoves = 10;
        public MainPage()
        {
            InitializeComponent();            
            BindingContext = mainView;           
            randomiseBoard();
        }
      

        private void Left(object sender, SwipedEventArgs e)
        {
            var image = (Image)sender;
            var gridChildren = mainGrid.Children;

            int column = Grid.GetColumn(image);
            int row = Grid.GetRow(image);

            if(column == 0)
            {
                return;
            }
            else
            {
                trySlidePieces(row, column - 1, image);
            }
            checkWinCondition();
        }
        

        private void Right(object sender, SwipedEventArgs e)
        {
            var image = (Image)sender;
            var gridChildren = mainGrid.Children;

            int column = Grid.GetColumn(image);
            int row = Grid.GetRow(image);

            if (column == 2)
            {
                return;
            }
            else
            {
                trySlidePieces(row, column + 1, image);
            }
            checkWinCondition();
        }

        private void Up(object sender, SwipedEventArgs e)
        {
            var image = (Image)sender;
            var gridChildren = mainGrid.Children;

            int column = Grid.GetColumn(image);
            int row = Grid.GetRow(image);

            if (row == 0)
            {
                return;
            }
            else
            {
                trySlidePieces(row - 1, column, image);
            }
            checkWinCondition();
        }

        private void Down(object sender, SwipedEventArgs e)
        {
            var image = (Image)sender;
            var gridChildren = mainGrid.Children;

            int column = Grid.GetColumn(image);
            int row = Grid.GetRow(image);

            if (row == 2)
            {
                return;
            }
            else
            {
                trySlidePieces(row + 1, column, image);
            }
            checkWinCondition();
        }

        public async void checkWinCondition()
        {
            int count = 0;
            var gridChildren = mainGrid.Children;

            foreach (Image image in gridChildren.OfType<Image>())
            {
                if (String.Format("File: Images/{0}{1}.png", Grid.GetColumn(image).ToString(), Grid.GetRow(image).ToString()) == image.Source.ToString())
                {
                    count++;
                }
            }

            if (count == 8)
            {
                await DisplayAlert("Win", "Congratulations: You Win!", "Play Again?");
                mainView.numberWins++;
                mainView.wins = mainView.wins;
                resetBoard();
                randomiseBoard();
            }
        }

        public void randomiseBoard()
        {
            var blankImage =  findLocationOfImage("File: ");

            int column = Grid.GetColumn(blankImage);
            int row = Grid.GetRow(blankImage);


            string lastSwapDirection = "";
            bool moveRight = true;
            bool moveLeft = true;
            bool moveUp = true;
            bool moveDown = true;
            List<bool> moves = new List<bool>();
            moves.Add(moveDown);
            moves.Add(moveUp);
            moves.Add(moveRight);
            moves.Add(moveLeft);

            int choices = 0;
            

            for(int i = 0; i < randomMoves; i++)
            {
                moveRight = true;
                moveLeft = true;
                moveUp = true;
                moveDown = true;

                if (column == 0 && row == 0)
                {
                    moveLeft = false;
                    moveUp = false;
                }
                else if (column == 2 && row == 2)
                {
                    moveRight = false;
                    moveDown = false;

                }
                else if (column == 1 && row == 0)
                {
                    moveUp = false;
                }
                else if (column == 0 && row == 1)
                {
                    moveLeft = false;
                }
                else if (column == 0 && row == 2)
                {
                    moveLeft = false;
                    moveDown = false;
                }
                else if (column == 2 && row == 0)
                {
                    moveRight = false;
                    moveUp = false;
                }
                else if(column == 2 && row == 1)
                {
                    moveRight = false;
                }
                else if(column == 1 && row == 2)
                {
                    moveDown = false;
                }

                while (true)
                {
                    int randomMove = random.Next(0, 4);
                    if (randomMove == 0 && moveUp == true && lastSwapDirection != "Down")
                    {
                        trySlidePieces(row - 1, column, blankImage);
                        row--;
                        lastSwapDirection = "Up";
                        break;
                    }

                    else if(randomMove == 1 && moveDown == true && lastSwapDirection != "Up")
                    {
                        trySlidePieces(row + 1, column, blankImage);
                        row++;
                        lastSwapDirection = "Down";
                        break;
                    }

                    else if (randomMove == 2 && moveLeft == true && lastSwapDirection != "Right")
                    {
                        if(column == 0)
                        {
                            Debug.WriteLine(" ");
                        }
                        trySlidePieces(row, column - 1, blankImage);
                        column--;
                        lastSwapDirection = "Right";
                        break;
                    }

                    else if(randomMove == 3 && moveRight == true && lastSwapDirection != "Left")
                    {
                        trySlidePieces(row, column + 1, blankImage);
                        column++;
                        lastSwapDirection = "Right";
                        break;
                    }                   
                }
            }
        }

        public Image findLocationOfImage(string imageSource)
        {
            var gridChildren = mainGrid.Children;           

            foreach (Image piece in gridChildren.OfType<Image>())
            {
                if (piece.Source.ToString() == imageSource)
                {
                    return piece;
                }
            }
            return null;
        }

        public Image imagePieceInGridLocation(int row, int column)
        {
            var gridChildren = mainGrid.Children;

            foreach (Image piece in gridChildren)
            {
                if (Grid.GetColumn(piece) == column && Grid.GetRow(piece) == row)
                {
                    return piece;
                }
            }
                return null;
        }

        public void trySlidePieces(int rowToSlideTo, int columnToSlideTo, Image image)
        {
            var storePiece = imagePieceInGridLocation(rowToSlideTo, columnToSlideTo);

            if (storePiece.Source.ToString() == "File: " || image.Source.ToString() == "File: ")
            {
                var storeimage = image;
                int imageColumn = Grid.GetColumn(image);
                int imageRow = Grid.GetRow(image);
                var storedPiece = storePiece;
                int pieceColumn = Grid.GetColumn(storePiece);
                int pieceRow = Grid.GetRow(storePiece);

                mainGrid.Children.Remove(storePiece);
                mainGrid.Children.Add(storedPiece, imageColumn, imageRow);
                mainGrid.Children.Remove(image);
                mainGrid.Children.Add(image, pieceColumn, pieceRow);
                return;
            }
            else return;
        }

        public void resetBoard()
        {
            var gridChildren = mainGrid.Children;

            List<gridChange> changeList = new List<gridChange>();

            for(int i = 0; i<gridChildren.Count(); i++)
            {
                Image image = (Image)gridChildren[i];
                gridChange storeChange = new gridChange();

                if (image.Source.ToString() == "File: ")
                {
                    storeChange.row = 0;
                    storeChange.column = 0;
                    storeChange.imageToAdd = image;
                    storeChange.imageToDelete = image;
                    changeList.Add(storeChange);
                }
                else
                {
                    string imageName = image.Source.ToString();


                    storeChange.column = (int)Char.GetNumericValue(imageName[13]);
                    storeChange.row = (int)Char.GetNumericValue(imageName[14]);
                    storeChange.imageToDelete = image;
                    storeChange.imageToAdd = image;

                    changeList.Add(storeChange);
                }
            }

            foreach(gridChange change in changeList)
            {
                mainGrid.Children.Remove(change.imageToDelete);
                mainGrid.Children.Add(change.imageToAdd, change.column, change.row);
            }
        }
        
        private void refreshBoard(object sender, EventArgs e)
        {
            resetBoard();
            randomiseBoard();
        }

        private async void easyMode(object sender, EventArgs e)
        {
            randomMoves = 10;
            await DisplayAlert("Easy Mode", "Easy mode activated, board shuffles: 10 times", "OK");
            resetBoard();
            randomiseBoard();
        }

        private async void mediumMode(object sender, EventArgs e)
        {
            randomMoves = 20;
            await DisplayAlert("Medium Mode", "Medium mode activated, board shuffles: 20 times", "OK");
            resetBoard();
            randomiseBoard();
        }
        private async void hardMode(object sender, EventArgs e)
        {
            randomMoves = 30;
            await DisplayAlert("hard Mode", "Hard mode activated, board shuffles: 30 times", "OK");
            resetBoard();
            randomiseBoard();            
        }
    }
}
