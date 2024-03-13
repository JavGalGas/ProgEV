namespace Classes
{
    public enum ColorType
    {
        BLACK,
        WHITE,
    }
    public enum FigureType
    {
        KNIGHT,
        PAWN,
        KING,
        ROOK,
        BISHOP,
        QUEEN,
    }
    public class ChessFigure
    {
        private int _x, _y;
        private ColorType _color;
        private FigureType _figureType;
        private int _moveNum=0;

        private ChessFigure(int x, int y, ColorType color, FigureType figure)
        {
            _x = x;
            _y = y;
            _color = color;
            _figureType = figure;
        }

        private ChessFigure() 
        { 
        
        }

        /*public bool IsValid()
        {
            if(_color == ColorType.BLACK || _color == ColorType.WHITE)
            {
                switch(_figureType)
                {
                    case Classes.FigureType.PAWN:  return true;
                    case Classes.FigureType.KING:  return true;
                    case Classes.FigureType.ROOK: return true;
                    case Classes.FigureType.KNIGHT: return true;
                    case Classes.FigureType.BISHOP: return true;
                    case Classes.FigureType.QUEEN: return true;
                    default: return false;
                }
            }
            return false;
        }*/
        public int GetMoveNum()
        {
            return _moveNum;
        }
        public int GetX()
        {
            return _x;
        }
        public int GetY()
        {
            return _y;
        }
        public ColorType GetColor()
        {
            //return (IsValid()) ? _color : ColorType.UNKNOWN;
            return _color;
        }
        public FigureType GetFigureType()
        {
            //return (IsValid()) ? _figureType : Classes.FigureType.UNKWOWN;
            return _figureType;
        }
        public void MoveTo(int x, int y)
        {
            if(ChessUtils.CanFigureMoveTo(this, x, y))
            {
                _x = x;
                _y = y;
                _moveNum++;
                ChessUtils.IncrementMoveCount();
            }
        }
        public void Promove(ChessFigure figure, FigureType typePromoved)
        {
            if(figure.GetFigureType()==FigureType.PAWN && figure.GetY()==8)
            {
                ChessFigure? aux = CreateFigure(figure.GetX(), figure.GetY(), figure.GetColor(), typePromoved);
                ChessGame.Swap(figure,aux);
                ChessGame.DeleteFigure(ChessGame.GetFigureCount()-1);
            }
        }

        public static ChessFigure? CreateFigure(int x, int y, ColorType color, FigureType figure)
        {
            /*if(color != ColorType.WHITE || color!= ColorType.BLACK)
            {
                return null;
            }*/
            if(!ChessBoard.IsOnBoard(x,y))
                return null;
            foreach (string value in Enum.GetNames<FigureType>())
            {
                if(figure.ToString()==value)
                {
                    return new ChessFigure(x, y, color, figure);
                }
            }

            //else if (figure != FigureType.QUEEN)
            //    return null;
            //else if (figure != FigureType.KNIGHT)
            //    return null;
            //else if (figure != FigureType.KING)
            //    return null;
            //else if (figure != FigureType.BISHOP)
            //    return null;
            //else if (figure != FigureType.PAWN)
            //    return null;
            //else if (figure != FigureType.ROOK)
            //    return null;
            return new ChessFigure(x, y, color, figure);
        }

        public ChessFigure Clone()
        {
            ChessFigure chessFigure = new ChessFigure(GetX(), GetY(), GetColor(), GetFigureType());
            return chessFigure;
        }

    }

}
