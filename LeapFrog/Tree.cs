using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapFrog {
	public class Tree {
		Point Location;
		int rad { get; set; } //use to check if frog touches

		public Tree(Point p) {
			Location = p;
			this.rad = 30;
		}

		public void Draw(Graphics g) {
			Image frogBitmap = new Bitmap(@"E:\FINKI\II GODINA\IV semestar\ВИЗУЕЛНО ПРОГРАМИРАЊЕ\PROEKTNA\LeapFrog\LeapFrog\Pictures\tree1.png");//tree picture
			g.DrawImage(frogBitmap, Location);

		}
	}
}
