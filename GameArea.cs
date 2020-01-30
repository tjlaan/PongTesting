using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tron
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
            m.MessageReceived += new Messager.MessageReceivedHandler(processMessage);
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
                    case Keys.Enter:
                        game.gameStarted = true;
                        game.player.isActive = true;
                        m.sendMessage(game.player);
                        break;

                }
                Line newLine = new Line(game.player);
                game.currentLines[game.player] = newLine;
                game.lines.Add(newLine);
                m.sendMessage(game.player);
            }
        }

        public void processMessage(string jsonPlayer)
        {
            JObject jsonObject = JObject.Parse(jsonPlayer);
            string ip = (string)jsonObject.GetValue("ipaddress");
            if (ip != game.player.ipaddress)
            {
                bool activePlayer = (bool)jsonObject.GetValue("isActive");
                bool exists = false;

                foreach (Player p in game.playerList)
                {
                    if (p != game.player && p.ipaddress == ip)
                    {
                        if (!p.isDead)
                        {
                            if (activePlayer)
                            {
                                game.gameStarted = true;
                            }
                            Invoke(new UpdatePlayer(game.updatePlayer), p, jsonPlayer);
                        }
                        exists = true;
                    }
                }

                if (!exists)
                {
                    if(!activePlayer)
                    {
                        foreach (Player p in game.playerList)
                        {
                            m.sendMessage(p);
                        }
                        Invoke(new Messager.MessageReceivedHandler(game.addNewPlayer), jsonPlayer);
                    }
                }

            }
        }

        private void GameArea_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}