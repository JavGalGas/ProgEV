using System.Collections.Generic;

namespace Classes
{
    public class ChessUtils
    {
        public static int _movCount;

        public static void IncrementMoveCount()
        {
            _movCount++;
        }

        public static bool CanFigureMoveTo(ChessFigure figure, int targetX, int targetY)//deberia de comprobar la lista de ChessGame
        {
            if (!ChessBoard.IsOnBoard(targetX, targetY) || !ChessGame.IsInList(figure))
                return false;
            else if (figure.GetFigureType() == FigureType.KNIGHT)
                return AllowedKnightMove(figure, targetX, targetY);
            else if (figure.GetFigureType() == FigureType.PAWN)
                return AllowedPawnMove(figure, targetX, targetY);
            else if (figure.GetFigureType() == FigureType.KING)
                return AllowedKingMove(figure, targetX, targetY);
            else if (figure.GetFigureType() == FigureType.QUEEN)
                return AllowedQueenMove(figure, targetX, targetY);
            else if (figure.GetFigureType() == FigureType.BISHOP)
                return AllowedBishopMove(figure, targetX, targetY);
            else if (figure.GetFigureType() == FigureType.ROOK)
                return AllowedRookMove(figure, targetX, targetY);
            return false;
        }


        public static int GetMovementCount()
        {
            return _movCount;
        }
        public static bool HasBeenMoved()
        {
            return _movCount == _movCount+1;
        }


        public static ChessFigure? GetFigureAt(int x, int y, List<ChessFigure> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                ChessFigure figure = list[i];
                if(x==figure.GetX() && y==figure.GetY())
                {
                    return figure;
                }
            }
            return null;
        }
        public static bool AllowedKnightMove(ChessFigure figure, int targetX, int targetY)
        {
            int x=figure.GetX(), y=figure.GetY();
            if(targetX==x+2 || targetX==x-2)
                return (targetY == y++ || targetY == y--);
            else if(targetX==x++ || targetX==x--)
                return (targetY == y+2 || targetY==y-2);
            return false;

        }
        public static bool AllowedKingMove(ChessFigure figure, int targetX, int targetY)
        {
            int x = figure.GetX(), y = figure.GetY();
            if(figure.GetMoveNum()==0 && targetX == x-2 && targetY == y)
            {
                return true;
            }
            for(int i = x-1; i<x+1;i++)
            {
                for (int j = y - 1; j < y + 1; j++)
                {
                    if (i == x && j == y)
                        continue;
                    else if(i==targetX && j == targetY)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        public static bool AllowedRookMove(ChessFigure figure, int targetX, int targetY)
        {
            int x = figure.GetX(), y = figure.GetY();
            if(x==targetX)
            {
                for (int i = 0; i < ChessBoard.GetY(); i++)
                {
                    if (i == y)
                        continue;
                    else if (i == targetY)
                        return true;
                }
            }
            if (y == targetY)
            {
                for (int i = 0; i < ChessBoard.GetX(); i++)
                {
                    if (i == x)
                        continue;
                    else if (i == targetX)
                        return true;
                }
            }
            return false;
        }
        public static bool AllowedBishopMove(ChessFigure figure, int targetX, int targetY)
        {
            int x = figure.GetX(), y = figure.GetY();
            int xDiff = Math.Abs(targetX - x);
            int yDiff = Math.Abs(targetY - y);
            if (xDiff == yDiff)
                return true;
            return false;
        }
        public static bool AllowedPawnMove(ChessFigure figure, int targetX, int targetY)
        {
            int x = figure.GetX(), y = figure.GetY();
            if(targetX == x)
            {
                if(targetY == y+1)
                    return true;
                else if (targetY == y+2 && figure.GetMoveNum()==0)
                    return true;
            }
            if((targetX == x+1 || targetX == x-1)&& targetY==y+1)
            {
                return true;
            }
            return false;
        }
        public static bool AllowedQueenMove(ChessFigure figure, int targetX, int targetY)
        {
            int x = figure.GetX(), y = figure.GetY();
            if(AllowedRookMove(figure, targetX, targetY)||AllowedBishopMove(figure, targetX, targetY))
                return true;
            return false;
        }
        
        public static Random r = new Random();
        public static int GetRandom()
        {
            return r.Next();
        }
        public static int GetRandomBetween(int min, int max)
        {
            return r.Next(min,max);
        }
    }     
}
