using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameControl
    {
        private PanelBoard p = new PanelBoard();
        private PieceType currentPlayer = PieceType.black;
        public PieceType winner = PieceType.none;

        public bool canBePlaced(int x, int y)
        {
            return p.canBePlaced(x, y);
        }
        public Piece placePiece(int x, int y)
        {
            Piece piece = p.placePiece(x, y, currentPlayer);
            if (piece != null)
            {
                checkWinner();
                if (currentPlayer == PieceType.black)
                {
                    currentPlayer = PieceType.white;
                }
                else
                {
                    currentPlayer = PieceType.black;
                }
                return piece;
            }
            return null;
        }
        public Piece[,] getPieces()
        {
            Piece[,] piece = p.piece;
            return piece;
        }

        private void checkWinner()
        {
            winner = PieceType.none;
            int centerX = p.LastPlacedNode.X;
            int centerY = p.LastPlacedNode.Y;
            //find 9 direction from this piece
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for(int yDir = -1; yDir <= 1; yDir++)
                {
                    //remove the check of the center one(xDir=0,yDir=0)
                    if (xDir == 0 && yDir == 0)
                        continue;


                    int count = 1;
                    while (count < 5)
                    {
                        int targetX = centerX + count*xDir;
                        int targetY = centerY + count*yDir;
                        if (targetX < 0 || targetX >= 9 || targetY < 0 || targetY >= 9 ||
                            p.GetPieceType(targetX, targetY) != currentPlayer)
                            break;

                        count++;
                    }
                    if (count == 5)
                    {
                        winner = currentPlayer;                    
                    }
                }
            }
            
        }
    }
}
