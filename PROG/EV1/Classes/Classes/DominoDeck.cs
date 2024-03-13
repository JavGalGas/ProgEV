namespace Classes
{
    public class DominoDeck
    {
        private static List<DominoPiece> _pieceList = new List<DominoPiece>();  /*Esto ya está escrito en la relación, cuando lo escribimos en Método relacional*/

        public static DominoPiece? ExtractPieceAt(int index)
        {
            if(index < 0 || index >= _pieceList.Count)
            {
                var p = _pieceList[index];
                _pieceList.RemoveAt(index);
                return p;
            }
            return null;
        }

        public static DominoPiece? ExtractPiece()
        {
            int random = GetRandomBetween(0, _pieceList.Count - 1);
            return ExtractPieceAt(random);
        }

        public int GetPieceCount()
        {
            return _pieceList.Count;
        }

        public void AddPiece(DominoPiece? piece) //añade una pieza a la lista DominoPiece
        {
            if (piece == null)
                return;
            if (ContainsPiece(piece) == false)
                _pieceList.Add(piece);
        }

        public DominoPiece? GetPieceAt(int index) //saca los valores de la ficha de la lista DominoPiece, de la posicion index
        {
            if (index < 0 || index >= _pieceList.Count)
            {
                DominoPiece piece = _pieceList[index];
                piece.GetValue1();
                piece.GetValue2();
                return piece;
            }
            return null;
        }

        public void Swap(DominoPiece p1, DominoPiece p2) //cambia las posiciones de dos fichas de domino de la lista
        {
            DominoPiece aux = p1;
            p1= p2;
            p2= aux;
        }

        public void Shuffle() 
        {
            for(int i=0; i < _pieceList.Count; i++) 
            {
                DominoPiece p1 = _pieceList[ChessUtils.GetRandomBetween(0,GetPieceCount()-1)];
                DominoPiece p2 = _pieceList[ChessUtils.GetRandomBetween(0, GetPieceCount() - 1)];
                Swap(p1, p2);
            }
        }

        public bool ContainsPiece(DominoPiece piece)
        {
            if(piece == null)
                return false;
            for(int i = 0; i < GetPieceCount(); i++)
            {
                if(_pieceList[i].IsEquals(piece))
                    return true;
            }
            return false;
        }

        public int IndexOf(DominoPiece piece)
        {
            if (piece == null)
                return -1;
            for (int i = 0; i < GetPieceCount()-1; i++)
            {
                if (piece.IsEquals(GetPieceAt(i)))
                    return i;
            }
            return -1;
        }


        private static Random r = new Random();
        public static int GetRandomBetween(int min, int max)
        {
            int dif = max - min + 1;
            return min + (r.Next() % dif);
        }

    }
}
