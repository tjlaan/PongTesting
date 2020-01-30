using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Tron.Objects
{
    public class Player : Movable
    {
        public string ipaddress { set; get; }
        public int playerSpeedX { set; get; }
        public int playerSpeedY { set; get; }
        public bool isDead { set; get; }
        public bool isActive { set; get; }

        public Player()
        {

        }

        public Player(Random rand)
        {
            Location = new Point(rand.Next(0, 1248 - 40 - 20), rand.Next(0, 720 - 60 - 20));
            Size = new Size(20, 20);
            int speed = rand.Next(1, 4);
            switch(speed)
            {
                case 1:
                    playerSpeedX = 0;
                    playerSpeedY = 3;
                    break;
                case 2:
                    playerSpeedX = 0;
                    playerSpeedY = -3;
                    break;
                case 3:
                    playerSpeedX = 3;
                    playerSpeedY = 0;
                    break;
                case 4:
                    playerSpeedX = -3;
                    playerSpeedY = 0;
                    break;
            }
            isDead = false;
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[rand.Next(names.Length)];
            BackColor = Color.FromKnownColor(randomColorName);
            string hostName = Dns.GetHostName();
            ipaddress = Dns.GetHostByName(hostName).AddressList[0].ToString();
            isActive = false;
        }

        public Player(int x, int y, int xSpeed, int ySpeed, Color color, String ip)
        {
            Location = new Point(x, y);
            Size = new Size(20, 20);
            playerSpeedX = xSpeed;
            playerSpeedY = ySpeed;
            BackColor = color;
            ipaddress = ip;
            isActive = false;
        }

        public void move()
        {
            Location = new Point(Location.X + playerSpeedX, Location.Y + playerSpeedY);
        }
    }

}