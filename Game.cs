using System;
using System.Collections;
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
    class Game
    {
        public Timer gameTime;
        // int gameTimeInterval=1;
        public Player player;
        //  public AI ai;
        public Form form;
        public GameController controller;
        public ArrayList playerList;
        public Dictionary<Player, Line> currentLines;
        public ArrayList lines;

        public KeyEventHandler KeyDown { get; private set; }

        public Game(Form form)
        {
            this.form = form;
            controller = new GameController(form);
            gameTime = new Timer();
            gameTime.Enabled = true;
            gameTime.Interval = 1;
            gameTime.Tick += new EventHandler(OnGameTimeTick);

            Movable.mainForm = form;
            playerList = new ArrayList();
            currentLines = new Dictionary<Player, Line>();
            lines = new ArrayList();

            player = new Player();
            //player.Location = new Point(form.Width / 2 - player.Width / 2, player.Height / 2 - player.Height / 2);
            player.BackColor = Color.HotPink;
            playerList.Add(player);
            currentLines[player] =  new Line(player);
            lines.Add(currentLines[player]);

            Player player2 = new Player(form.Width / 2 - player.Width / 2, form.Height / 2 - player.Height / 2, 0, -3, Color.Blue, "127.0.0.1");
            playerList.Add(player2);
            currentLines[player2] = new Line(player2);
            lines.Add(currentLines[player2]);
        }

        void OnGameTimeTick(object sender, EventArgs e)
        {
            //Ball newBall = ball;
            foreach(Player bike in playerList)
            {
                currentLines[bike].update(bike);
                bike.move();
                controller.CollisionGameArea(bike);
                foreach (Line line in lines)
                {
                    controller.PaddleCollision(line, bike);
                }
            }
        }

    }
}