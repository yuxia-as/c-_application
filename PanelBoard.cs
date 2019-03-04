using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    class PanelBoard
    {
        private static readonly int OFFSET = 75;
        private static readonly int DISTANCE = 75;
        private static readonly int RADIUS = 10;
        private static Point NO_Match_Point = new Point(-1,-1);
        public Piece[,] piece = new Piece[9, 9];
        private Point lastPlacedNode = NO_Match_Point;
        public Point LastPlacedNode { get { return lastPlacedNode; } }

        public PieceType GetPieceType(int nodeIdX,int nodeIdY)
        {
            if (piece[nodeIdX, nodeIdY] == null)
                return PieceType.none;
            else
                return piece[nodeIdX, nodeIdY].GetPieceType();
        }
        public bool canBePlaced(int x, int y)
        {
            //find the nodeid
            Point nodeId = findPiecePosition(x, y);
            ////if not match point
            if (nodeId == NO_Match_Point)
                return false;
            //else if (nodeId != null)
            //    return false;
            else
                return true;
        }
        public Piece placePiece(int x, int y, PieceType type)
        {
            Point nodeId = findPiecePosition(x, y);
            ////if not match point
            if (nodeId == NO_Match_Point)
                return null;
            if (piece[nodeId.X, nodeId.Y] != null)
                return null;
            Point formPos = convertPosition(nodeId);
            if (type == PieceType.black)
            {
                piece[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            }
            else
            {
                piece[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y);
            }
            //get the last node position
            lastPlacedNode = nodeId;
           return piece[nodeId.X, nodeId.Y];
        }
        
        private Point convertPosition(Point nodeId)
        {
            Point formPosition = new Point();
            formPosition.X = nodeId.X * DISTANCE + OFFSET;
            formPosition.Y = nodeId.Y * DISTANCE + OFFSET;
            return formPosition;

        }
        public Point findPiecePosition(int x,int y)
        {
            int posX = findPiecePosition(x);
            if (posX == -1)
                return NO_Match_Point;
            int posY = findPiecePosition(y);
            if (posY == -1)
                return NO_Match_Point;
            return new Point(posX, posY);
        }
        public int findPiecePosition(int pos)
        {
            int minBoundary = OFFSET - RADIUS;
            int maxBoundary = DISTANCE * 9 - OFFSET + RADIUS;
            if (pos <= minBoundary || pos > maxBoundary)
                return -1;
            int posId = (pos - OFFSET) / DISTANCE;
            int remainder = (pos - OFFSET) % DISTANCE;
            if (remainder <= RADIUS)
                return posId;
            else if (remainder >= DISTANCE - RADIUS)
                return posId + 1;
            else
                return -1;

        }

    }
}
