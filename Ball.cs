using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Pong
{
    public class Ball : Movable
    {
        public Ball(Player player)
        {
            this.Location = player.Location;
            this.Size = new Size(20, 20);
            this.BackColor = ControlPaint.Light(player.BackColor, (float) 0.50);
        }
    }
}