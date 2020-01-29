using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Pong
{
    public partial class GameArea : Form

    {
        Messager m;
        Game game;
        const int GameAreaWidth = 1248;
        const int GameAreaHeight = 720;
        const int Speed = 3;
        public GameArea()
        {

            //InitializeComponent();
            this.Height = GameAreaHeight;
            this.Width = GameAreaWidth;
            this.StartPosition = FormStartPosition.CenterScreen;
            game = new Game(this);
            m = new Messager();
            KeyDown += new KeyEventHandler(OnKeyDown);

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (game.player.playerSpeedY == 0)
                    {
                        return;
                    }
                    game.player.playerSpeedX = -Speed;
                    game.player.playerSpeedY = 0;
                    break;
                case Keys.Right:
                    if (game.player.playerSpeedY == 0)
                    {
                        return;
                    }
                    game.player.playerSpeedX = Speed;
                    game.player.playerSpeedY = 0;
                    break;
                case Keys.Up:
                    if (game.player.playerSpeedX == 0)
                    {
                        return;
                    }
                    game.player.playerSpeedX = 0;
                    game.player.playerSpeedY = -Speed;
                    break;
                case Keys.Down:
                    if (game.player.playerSpeedX == 0)
                    {
                        return;
                    }
                    game.player.playerSpeedX = 0;
                    game.player.playerSpeedY = Speed;
                    break;
            }
            Line newLine = new Line(game.player);
            game.currentLines[game.player] = newLine;
            game.lines.Add(newLine);
        }


        private void GameArea_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}