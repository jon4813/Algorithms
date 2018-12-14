using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class SnakeGame
    {
        private const int BoardHeight = 20;
        private const int BoardWidth = 20;
        private readonly byte[,] _board = new byte[BoardHeight, BoardWidth];
        private readonly Location[] _body = new Location[BoardHeight * BoardWidth];
        private Location _point;
        private const int BodyValue = 1;
        private const int PointValue = 2;

        public SnakeGame()
        {
            ResetBody();
        }

        private void ResetBody()
        {
            for (int i = 0; i < _body.Length; i++)
            {
                _body[i] = null;
            }
            _body[0] = new Location { X = (int)(BoardWidth * 0.5), Y = (int)(BoardHeight * 0.7) };
            _body[1] = new Location { X = _body[0].X + 1, Y = _body[0].Y };
            _body[2] = new Location { X = _body[0].X + 2, Y = _body[0].Y };
        }

        private void MakeAStep(MoveDirection direction)
        {
            int lastIndex = 0;
            for (int i = 0; i < _body.Length; i++)
            {
                if (_body[i] == null)
                {
                    lastIndex = i - 1;
                    break;
                }
            }

            for (int i = lastIndex; i > 0; i--)
            {

                _body[i].X = _body[i - 1].X;
                _body[i].Y = _body[i - 1].Y;
            }

            switch (direction)
            {
                case MoveDirection.Left:
                    if (_body[0].X > 0)
                        --_body[0].X;
                    break;
                case MoveDirection.Up:

                    if (_body[0].Y > 0)
                        _body[0].Y--;
                    break;
                case MoveDirection.Right:
                    if (_body[0].X < BoardWidth - 1)
                        _body[0].X++;

                    break;
                case MoveDirection.Down:
                    if (_body[0].Y < BoardHeight - 1)
                        _body[0].Y++;
                    break;                
            }
        }

        private void ClearBoard()
        {            
            for (int i = 0; i < BoardHeight; i++)
            {
                for (int j = 0; j < BoardWidth; j++)
                {
                    _board[i, j] = 0;
                }
            }
        }

        private void Merge()
        {
            ClearBoard();
            foreach (var location in _body.Where(location => location != null))
            {
                _board[location.Y, location.X] = BodyValue;
            }

            //_board[_point.Y, _point.X] = _pointValue;
        }

        private void AteFood()
        {
            for (int i = 0; i < _body.Length; i++)
            {
                if (_body[i] == null)
                {
                    _body[i] = new Location {X = _body[i - 1].X};
                }
            }
        }

        private void PrintBoard()
        {
            for (int i = 0; i < BoardHeight; i++)
            {
                for (int j = 0; j < BoardWidth; j++)
                {
                    Console.Write($" {_board[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        MoveDirection _direction = MoveDirection.Left;

        public void Game()
        {
            ResetBody();
            ClearBoard();

            Task.Run(() =>
            {
                while (true)
                {
                    Merge();
                    PrintBoard();
                    MakeAStep(_direction);
                    Thread.Sleep(500);
                    Console.WriteLine();
                }
            });

            while (true)
            {

                switch (Console.ReadKey(true).Key.ToString().ToUpper())
                {
                    case "W":
                        _direction = MoveDirection.Up;
                        break;
                    case "S":
                        _direction = MoveDirection.Down;
                        break;
                    case "A":
                        _direction = MoveDirection.Left;
                        break;
                    case "D":
                        _direction = MoveDirection.Right;
                        break;
                    case "Q":
                        return;
                }
            }
        }
    }

    enum MoveDirection
    {
        Undefined,
        Left,
        Up,
        Right,
        Down
    }

    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
