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
		//Image img = new Bitmap(""); //insert filename later here and maybe size?
		
		public Car(Point p) : base(p) {
			this.Speed = 15;
			this.Width = 30;
			this.Height = 15;
			Random random = new Random(); //for color of the cars
			int r = random.Next();
			if (r % 7 == 0) {
				imgFile = new Bitmap(@"E:\FINKI\II GODINA\IV semestar\ВИЗУЕЛНО ПРОГРАМИРАЊЕ\PROEKTNA\LeapFrog\LeapFrog\Pictures\carPinkToRight.png");//so drag and drop od resources fileot od solution explorer stavi ovde car
			}
			else if (r % 3 == 0) {
				imgFile = new Bitmap(@"E:\FINKI\II GODINA\IV semestar\ВИЗУЕЛНО ПРОГРАМИРАЊЕ\PROEKTNA\LeapFrog\LeapFrog\Pictures\carBlueToRight.png");//so drag and drop od resources fileot od solution explorer stavi ovde 
			}
			else {
				imgFile = new Bitmap(@"E:\FINKI\II GODINA\IV semestar\ВИЗУЕЛНО ПРОГРАМИРАЊЕ\PROEKTNA\LeapFrog\LeapFrog\Pictures\carGreenToRight.png");//so drag and drop od resources fileot od solution explorer stavi ovde car
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
		//Image img = new Bitmap(""); //insert filename later here and maybe size?

		public Bus(Point p) : base(p) {
			this.Speed = 5;
			this.Width = 40;
			this.Height = 20;
			imgFile = new Bitmap(@"E:\FINKI\II GODINA\IV semestar\ВИЗУЕЛНО ПРОГРАМИРАЊЕ\PROEKTNA\LeapFrog\LeapFrog\Pictures\busToLeft.png");//so drag and drop od resources fileot od solution explorer stavi ovde bus
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
