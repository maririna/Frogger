using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapFrog {

	[Serializable]
	public class Frog {
		public Point Location { get; set; }
		public int Radius { get; set; }
		public bool noMoreUp { get; set; }
		public bool IsTouched { get; set; }
		public bool OnStart { get; set; }

		public Frog(Point p) { //zema sredina od tekoven width posle vo form i ja crta najdolu
			this.Location = p;
			this.Radius = 25;
			this.IsTouched = false;
			this.noMoreUp = false;
			this.OnStart = true;
		}

		public void Jump(char c, int w,int h) {
			OnStart = false; //za da se smeni slikata vo skokacka

			if (c == 'w') { //ad kraen uslov
				if (Location.Y > 10) { //plus proveri dali ima drvo od gore
					Location = new Point(Location.X, Location.Y - 55);
				}
				else noMoreUp = true;
			}
			else if (c == 's') { //ad kraen uslov
				if (Location.Y < h - 100) {
					Location = new Point(Location.X, Location.Y + 55);
				}
			}
			else if (c == 'a') { //ad kraen uslov
				if (Location.X > 10) {
					Location = new Point(Location.X - 55, Location.Y);
				}
			}
			else if (c == 'd') { //ad kraen uslov
				if (Location.X < w - 100) {
					Location = new Point(Location.X + 55, Location.Y);
				}
			}
		}

		//check paths
		public void Draw(Graphics g) {
			
			if (noMoreUp) {
				Image frogBitmap = new Bitmap(@"E:\FINKI\II GODINA\IV semestar\ВИЗУЕЛНО ПРОГРАМИРАЊЕ\PROEKTNA\LeapFrog\LeapFrog\Pictures\happyFrog.png");//so drag and drop od resources fileot od solution explorer stavi ovde happy frog
				g.DrawImage(frogBitmap, Location);
			}
			else if (IsTouched) {
				Image frogBitmap = new Bitmap(@"E:\FINKI\II GODINA\IV semestar\ВИЗУЕЛНО ПРОГРАМИРАЊЕ\PROEKTNA\LeapFrog\LeapFrog\Pictures\smashed.png");//smashed
				g.DrawImage(frogBitmap, Location);
			}
			else if (OnStart) {
				Image frogBitmap = new Bitmap(@"E:\FINKI\II GODINA\IV semestar\ВИЗУЕЛНО ПРОГРАМИРАЊЕ\PROEKTNA\LeapFrog\LeapFrog\Pictures\frog.png");//frog
				g.DrawImage(frogBitmap, Location);
			}
			else {
				Image frogBitmap = new Bitmap(@"E:\FINKI\II GODINA\IV semestar\ВИЗУЕЛНО ПРОГРАМИРАЊЕ\PROEKTNA\LeapFrog\LeapFrog\Pictures\frog1.png");//frog
				g.DrawImage(frogBitmap, Location);
			}

		}


		public Boolean isHitBy(Vehicle v) { //funkcionira taman do not edit :)))))
			if (v.toRight) {//proveruva samo desni dve tocki napred
				double xr = Math.Pow(Location.X - v.Location.X +v.Width/2, 2); //centar na zaba so dolu desno tocka od preden desen del od kola
				double yr = Math.Pow(Location.Y - v.Location.Y + v.Height / 2, 2); //isto, po y
				Boolean firstCond = (Radius >= Math.Sqrt(xr + yr)); //dali ja dopira toj agol

				double x1r = Math.Pow(Location.X - v.Location.X + v.Width / 2, 2); //centar na zaba so gore desno tocka od preden desen del od kola
				double y1r = Math.Pow(Location.Y - v.Location.Y - v.Height / 2, 2); //isto, po y
				Boolean secondCond = (Radius >= Math.Sqrt(xr + yr));

				return (firstCond && secondCond); //dali ja dopira prednata strana od kolata
			}

			else {//proveruva samo levi dve tocki na kolata/busot jer se dvizi na levo 
				double xr = Math.Pow(Location.X - v.Location.X - v.Width / 2, 2); //centar na zaba so dolu levo tocka od preden desen del od kola
				double yr = Math.Pow(Location.Y - v.Location.Y + v.Height / 2, 2); //isto, po y
				Boolean firstCond = (Radius >= Math.Sqrt(xr + yr));

				double x1r = Math.Pow(Location.X - v.Location.X - v.Width / 2, 2); //centar na zaba so gore levo tocka od preden desen del od kola
				double y1r = Math.Pow(Location.Y - v.Location.Y - v.Height / 2, 2); //isto, po y
				Boolean secondCond = (Radius >= Math.Sqrt(xr + yr));

				return (firstCond && secondCond); //dali ja dopira prednata strana od kolata
			}
		}

		//THIS TO BE IMPLEMENTED TO PREVENT FROG FROM MOVING
	/*	public Boolean touchesTree(string side) {
			if (side == "u") {
				return touchesFromUp();
			}
			else if (side == "d") {
				return touchesFromDown();
			}
			if (side == "l") {
				return touchesFromLeft();
			}
			if (side == "r") {
				return touchesFromRight();
			}
		}
		*/



	}

}
