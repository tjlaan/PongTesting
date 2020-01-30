using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Pong
{
    public class GameController
    {
        Form mainForm;

        // need to update this to reflect new scoring system...
        protected int PointsPlayer { get; set; }
        public void PaddleCollision(Line line, Player player)
        {
            if (player.Bounds.IntersectsWith(line.Bounds)) {
                player.playerSpeedX = 0;
                player.playerSpeedY = 0;
                player.isDead = true;
            }

        }
        public void CollisionGameArea(Player player)
        {
            if (player.Location.Y + player.Size.Height + 40 > mainForm.Height || player.Location.Y < 0 || player.Location.X + player.Size.Width + 20 > mainForm.Width || player.Location.X < 0)
            {
                player.playerSpeedX = 0;
                player.playerSpeedY = 0;
                player.isDead = true;
            }
        }

        public GameController(Form form)
        {
            mainForm = form;
        }

    }
}