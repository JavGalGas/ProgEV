using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ChessBoard
    {
        private static int _x;
        private static int _y;


        public ChessBoard(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public ChessBoard Clone()
        {
            ChessBoard ChessBoard = new ChessBoard(_x, _y);
            return ChessBoard;
        }
        public static int GetX()
        {
            return _x;
        }
        public static int GetY()
        {
            return _y;
        }
        public ChessBoard GetBoard()
        {
            ChessBoard ChessBoard = new(_x, _y);
            return ChessBoard;
        }
        public static bool IsOnBoard(int x, int y)
        {
            return ((x > 0 && x <= GetX()) && (y > 0 && y <= GetY()));
        }

        public static bool IsThereFigureAt(int x, int y)
        {
            for (int i = 0; i < ChessGame.GetFigureCount(); i++)
            {
                if (ChessGame.GetFigureAt(i).GetX() == x && ChessGame.GetFigureAt(i).GetY() == y)
                    return true;
            }
            return false;
        }

        public static int GetNumFigures(FigureType type)
        {
            switch (type)
            {
                case FigureType.KING:
                case FigureType.QUEEN:
                    return 1;
                case FigureType.KNIGHT:
                case FigureType.BISHOP:
                case FigureType.ROOK:
                    return 2;
                default: return 8;
            }
        }
        public static void Load()
        {
            ChessGame.ClearFigures();
            ChessUtils._movCount = 0;

            foreach (FigureType value in Enum.GetValues<FigureType>())
            {
                int numFigures = GetNumFigures(value);
                for (int i = 0; i < numFigures; i++)
                {
                    LoadPosition(value, ColorType.WHITE);
                    LoadPosition(value, ColorType.BLACK);
                }
            }
        }
        public static void LoadPosition(FigureType figure, ColorType color)
        {
            if (figure == FigureType.KING)
            {
                LoadKingPosition(figure, color);
            }
            else if (figure == FigureType.KNIGHT)
            {
                LoadKnightPosition(figure, color);
            }
            else if (figure == FigureType.QUEEN)
            {
                LoadQueenPosition(figure, color);
            }
            else if (figure == FigureType.BISHOP)
            {
                LoadBishopPosition(figure, color);
            }
            else if (figure == FigureType.ROOK)
            {
                LoadRookPosition(figure, color);
            }
            else if (figure == FigureType.PAWN)
            {
                LoadPawnPosition(figure, color);
            }
        }
        public static void LoadPawnPosition(FigureType figure, ColorType color)
        {
            int x = 2, y = 0;
            if (color == ColorType.WHITE)
            {
                y = 7;
            }
            else if (color == ColorType.BLACK)
            {
                y = 2;
            }
            while (IsThereFigureAt(x, y))
            {
                x++;
            }
            ChessFigure? f1 = ChessFigure.CreateFigure(x, y, color, figure);
            ChessGame.AddFigureInList(f1);
        }
        public static void LoadKnightPosition(FigureType figure, ColorType color)
        {
            int x = 2, y = 0;
            if (color == ColorType.WHITE)
            {
                y = 8;
            }
            else if (color == ColorType.BLACK)
            {
                y = 1;
            }
            if (IsThereFigureAt(x, y))
            {
                x = 7;
            }
            ChessFigure? f1 = ChessFigure.CreateFigure(x, y, color, figure);
            ChessGame.AddFigureInList(f1);
        }
        public static void LoadRookPosition(FigureType figure, ColorType color)
        {
            int x = 1, y = 0;
            if (color == ColorType.WHITE)
            {
                y = 8;
            }
            else if (color == ColorType.BLACK)
            {
                y = 1;
            }
            if (IsThereFigureAt(x, y))
            {
                x = 8;
            }
            ChessFigure? f1 = ChessFigure.CreateFigure(x, y, color, figure);
            ChessGame.AddFigureInList(f1);
        }
        public static void LoadBishopPosition(FigureType figure, ColorType color)
        {
            int x = 3, y = 0;
            if (color == ColorType.WHITE)
            {
                y = 8;
            }
            else if (color == ColorType.BLACK)
            {
                y = 1;
            }
            if (IsThereFigureAt(x, y))
            {
                x = 6;
            }
            ChessFigure? f1 = ChessFigure.CreateFigure(x, y, color, figure);
            ChessGame.AddFigureInList(f1);
        }
        public static void LoadQueenPosition(FigureType figure, ColorType color)
        {
            int x, y;
            if (color == ColorType.WHITE)
            {
                x = 5;
                y = 8;
            }
            else
            {
                x = 1;
                y = 4;
            }
            ChessFigure? f1 = ChessFigure.CreateFigure(x, y, color, figure);
            ChessGame.AddFigureInList(f1);
        }
        public static void LoadKingPosition(FigureType figure, ColorType color)
        {
            int x, y;
            if (color == ColorType.WHITE)
            {
                x = 4;
                y = 8;
            }
            else
            {
                x = 1;
                y = 5;
            }
            ChessFigure? f1 = ChessFigure.CreateFigure(x, y, color, figure);
            ChessGame.AddFigureInList(f1);
        }

    }
}
