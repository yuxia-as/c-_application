using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        //public PieceType type = PieceType.black;

        //private bool isBlack = true;
        private GameControl con = new GameControl();
        
        public Form1()
        {
            InitializeComponent();
            Height = Properties.Resources.board.Height;
            Width = Properties.Resources.board.Height;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = con.placePiece(e.X, e.Y);
            
            if(piece != null)
            {
                this.Controls.Add(piece);
                if (con.winner == PieceType.black)
                {
                    MessageBox.Show("Black wins!");
                    removePiece();
                }

                else if (con.winner == PieceType.white)
                {
                    MessageBox.Show("White wins!");
                    removePiece();
                }
            }
            
      
        }
        private void removePiece()
        {
            Piece[,] pieces = con.getPieces();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (pieces[i, j] != null)
                    {
                        
                        this.Controls.Remove(pieces[i, j]);
                        pieces[i, j] = null;
                    }
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (con.canBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = DefaultCursor;
            }
        }
    }
}
