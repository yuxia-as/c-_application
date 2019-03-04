using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Game
{
    abstract class Piece : PictureBox
    {
        private static readonly int IMAGE_SIZE = 50;
        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x - IMAGE_SIZE/2, y- IMAGE_SIZE/2);
            this.Size = new Size(IMAGE_SIZE, IMAGE_SIZE);
        }
        public abstract PieceType GetPieceType();
    }
}
