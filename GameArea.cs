using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public delegate void UpdatePlayer(Player p, string jsonPlayer);

        Messager m;
        Game game;
        const int GameAreaWidth = 1248;
        const int GameAreaHeight = 720;
        const int Speed = 3;
        public GameArea()
        {

            //InitializeComponent();
            Height = GameAreaHeight;
            Width = GameAreaWidth;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.Black;
            m = new Messager(this);
            m.MessageReceived += new Messager.MessageReceivedHandler(addPlayer);
            game = new Game(this);
            KeyDown += new KeyEventHandler(OnKeyDown);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void startGame(Player p)
        {
            m.sendMessage(p);
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            game.player.showBorder();

            if(game.livingPlayers.Count < 2)
            {
                Controls.Clear();
                game = new Game(this);
            }
            else if (!game.player.isDead)
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
                m.sendMessage(game.player);
            }
        }

        public void addPlayer(string jsonPlayer)
        {
            JObject jsonObject = JObject.Parse(jsonPlayer);
            bool exists = false;
            string ip = (string)jsonObject.GetValue("ipaddress");
            if (ip == game.player.ipaddress)
            {
                exists = true;
            } 
            else
            {
                foreach (Player p in game.playerList)
                {
                    if (p != game.player && p.ipaddress == ip)
                    {
                        if (!p.isDead)
                        {
                            Invoke(new UpdatePlayer(game.updatePlayer), p, jsonPlayer);
                        }
                        exists = true;
                    }
                }

                if (!exists)
                {
                    Invoke(new Messager.MessageReceivedHandler(game.addNewPlayer), jsonPlayer);
                }

            }
        }

        private void GameArea_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}