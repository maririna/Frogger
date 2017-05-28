using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapFrog {
	
	[Serializable]
	public abstract class Vehicle {
		public Point Location { get; set; }
		public Image imgFile { get; set; }
		public int Speed { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public bool toRight { get; set; }
		

		public Vehicle(Point p) {
			Location = p;
		}

		public abstract void Move();
		public abstract void Draw(Graphics g);
		

	}


	public class Car : Vehicle {	
		public Car(Point p) : base(p) {
			this.Speed = 15;
			this.Width = 30;
			this.Height = 15;
			Random random = new Random(); //for color of the cars
			int r = random.Next();
			if (r % 7 == 0) {
				imgFile = new Bitmap("../../Resources/carPinkToRight.png");
			}
			else if (r % 3 == 0) {
				imgFile = new Bitmap("../../Resources/carBlueToRight.png");
			}
			else {
				imgFile = new Bitmap("../../Resources/carGreenToRight.png");
			}
		}

		public override void Draw(Graphics g) {
				Image frogBitmap = new Bitmap(this.imgFile);
				g.DrawImage(frogBitmap, Location);		
		}

		public override void Move() {
			if (toRight) {
				//move left
				Location = new Point(Location.X + Speed, Location.Y);
			}
			else {
				//move right
				Location = new Point(Location.X - Speed, Location.Y);
			}
			
		}
	

	}

	public class Bus : Vehicle {
		public Bus(Point p) : base(p) {
			this.Speed = 5;
			this.Width = 40;
			this.Height = 20;
			imgFile = new Bitmap("../../Resources/busToLeft.png");
		}

		public override void Draw(Graphics g) {
			Image frogBitmap = new Bitmap(this.imgFile);
			g.DrawImage(frogBitmap, Location);
		}

		public override void Move() {
			if (toRight) {
				//move left
				Location = new Point(Location.X + Speed, Location.Y);
			}
			else {
				//move right
				Location = new Point(Location.X - Speed, Location.Y);
			}

		}

	}

}
