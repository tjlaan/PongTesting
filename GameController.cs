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

        protected int PointsPlayer { get; set; }
        public void PaddleCollision(Player player, Ball ball)
        {
            if (ball.Bounds.IntersectsWith(player.Bounds)) { }
                //ball.ballSpeedX = -ball.ballSpeedX;
        }
        public void CollisionGameArea(Ball obj)
        {
            if (obj.Location.Y > mainForm.Height - obj.Height * 3 || obj.Location.Y < 0)
            {
                //obj.ballSpeedY = -obj.ballSpeedY;
            }
            else if (obj.Location.X > mainForm.Width)
            {
                PointsPlayer += 1;
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