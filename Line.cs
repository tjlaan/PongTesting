using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Tron
{
    public class Line : Movable
    {
        public bool horizontal { set; get; }
        public bool negative { set; get; }
        public Line(Player player)
        {
            if (player.playerSpeedX > 0)
            {
                this.Location = new Point(player.Location.X - 1, player.Location.Y);
                horizontal = true;
                negative = false;
                this.Size = new Size(1, 20);
            } 
            else if (player.playerSpeedX < 0)
            {
                this.Location = new Point(player.Location.X + 20, player.Location.Y);
                horizontal = true;
                negative = true;
                this.Size = new Size(1, 20);
            }
            else if (player.playerSpeedY > 0)
            {
                this.Location = new Point(player.Location.X, player.Location.Y - 1);
                horizontal = false;
                negative = false;
                this.Size = new Size(20, 1);
            }
            else
            {
                this.Location = new Point(player.Location.X, player.Location.Y + 20);
                horizontal = false;
                negative = true;
                this.Size = new Size(20, 1);
            }
            
            this.BackColor = ControlPaint.Light(player.BackColor, (float)0.70);
        }

        public void update(Player player)
        {
            if(horizontal)
            {
                this.Size = new Size(this.Size.Width + Math.Abs(player.playerSpeedX), 20);
                if (negative)
                {
                    this.Location = new Point(this.Location.X - Math.Abs(player.playerSpeedX), this.Location.Y);
                }
            } else
            {
                this.Size = new Size(20, this.Size.Height + Math.Abs(player.playerSpeedY));
                if (negative)
                {
                    this.Location = new Point(this.Location.X, this.Location.Y - Math.Abs(player.playerSpeedY));
                }
            }
        }
    }
}