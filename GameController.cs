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
            }

        }
        public void CollisionGameArea(Player obj)
        {
            if (obj.Location.Y > mainForm.Height - obj.Height * 3 || obj.Location.Y < 0)
            {
                //obj.ballSpeedY = -obj.ballSpeedY;
            }
            else if (obj.Location.X > mainForm.Width)
            {
                //PointsPlayer += 1;
                //obj.resetBall();
            }
            else if (obj.Location.X < 0)
            {
                //obj.resetBall();
            }
        }

        public GameController(Form form)
        {
            mainForm = form;
        }

    }
}