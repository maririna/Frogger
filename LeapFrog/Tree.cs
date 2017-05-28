using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapFrog {
	public class Tree {
		public Point Location { get; set; }
		public int Radius { get; set; } //use to check if frog touches

		public Tree(Point p) {
			Location = p;
			this.Radius = 30;
		}

		public void Draw(Graphics g) {
			Image frogBitmap = new Bitmap("../../Resources/tree1.png");//tree picture
			g.DrawImage(frogBitmap, Location);

		}
	}
}
