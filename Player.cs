using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Pong
{
    public class Player : Movable
    {
        public String ipaddress { set; get; }
        public int playerSpeedX { set; get; }
        public int playerSpeedY { set; get; }
        public bool isDead { set; get; }

        public Player()
        {
            this.Location = new Point(20, 20);
            this.Size = new Size(20, 20);
            this.playerSpeedX = 0;
            this.playerSpeedY = 3;
            this.isDead = false;
            ipaddress = "127.0.0.1";
        }

        public Player(int x, int y, int xSpeed, int ySpeed, Color color, String ip)
        {
            this.Location = new Point(x, y);
            this.Size = new Size(20, 20);
            this.playerSpeedX = xSpeed;
            this.playerSpeedY = ySpeed;
            this.BackColor = color;
            this.ipaddress = ip;
        }

        public void move()
        {
            this.Location = new Point(Location.X + playerSpeedX, Location.Y + playerSpeedY);
        }
    }

}