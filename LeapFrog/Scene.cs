using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapFrog {

	[Serializable]
	public class Scene {

		Random R = new Random();
		List<Tree> listTrees;
		List<Vehicle> listVehicles;
		public Frog frog { get; set; }
		public int livesLeft { get; set; }
		public int points { get; set; }
		public bool gameIsOver { get; set; }
		
		public int Width { get; set; }
		public int Height { get; set; }

		public Scene(int w, int h) {
			this.listVehicles = new List<Vehicle>();
			this.listTrees = new List<Tree>();
			this.livesLeft = 2;
			this.points = 0;
			this.Width = w;
			this.Height = h;
			this.gameIsOver = false;
		}

		public void AddFrog() {
			this.frog = new Frog(new Point((Width / 2)-40, Height - 150));
		}

		public void AddVehicle() {
			int r = R.Next(10000);
			Vehicle v;
			Point p;
			//these starts from left
			if (r % 2 == 0) {
				if (r % 7 == 0) {
					
					p = new Point(Width +r%15, (Height / 2) - 20); //lane2 middle
					v = new Bus(p);
					v.toRight = false; 
				}
				else {
					p = new Point(0, this.Height / 2 + 30); //lane 3 down
					v = new Car(p);
					v.toRight = true;
				}	
			}
			//these starts from right
			else  {
				p = new Point(0, this.Height / 2 - 75); //lane1 (upper)
				v = new Car(p);
				v.toRight = true;
			}
			listVehicles.Add(v);
		}

		//for moving the vehicles
		public void Move() {
			foreach (Vehicle v in listVehicles) {
				v.Move();
			}

		}

		public void Draw(Graphics g) {
			DrawMotorway(g);
			frog.Draw(g);
			foreach (Vehicle v in listVehicles) {
				v.Draw(g);
			}
			foreach (Tree t in listTrees) {
				t.Draw(g);
			}
		
		}

		public void DrawMotorway(Graphics g) {
			Pen pen = new Pen(Color.DimGray, 52);
			Pen pen1 = new Pen(Color.LightGray, 30);
			Pen penDash = new Pen(Color.WhiteSmoke, 2);
			penDash.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

			g.DrawLine(pen, 0, this.Height / 2 - 52, this.Width, this.Height / 2 - 52);

			g.DrawLine(pen, 0, this.Height / 2, this.Width, this.Height / 2);
		
			g.DrawLine(pen, 0, this.Height / 2 + 52, this.Width, this.Height / 2 + 52);
			
			//dash
			g.DrawLine(penDash, 0, this.Height / 2 - 26, this.Width, this.Height / 2 - 26);
			g.DrawLine(penDash, 0, this.Height / 2 + 26, this.Width, this.Height / 2 + 26);

			

			

			g.DrawLine(pen1, 0, this.Height / 2 + 90, this.Width, this.Height / 2 + 90);
			g.DrawLine(pen1, 0, this.Height / 2 - 90, this.Width, this.Height / 2 - 90);
			pen.Dispose();
		}

		//============
		public void AddTrees() { //static for a start
			//Gore od patekata
			Tree t5 = new Tree(new Point(0, Height / 2 - 150));
			Tree t6 = new Tree(new Point(50 + Width / 5, Height / 2 - 150));
			Tree t7 = new Tree(new Point(Width / 2 + 60, Height / 2 - 150));
			Tree t8 = new Tree(new Point(Width - 70, Height / 2 - 150));
			listTrees.Add(t5);
			listTrees.Add(t6);
			listTrees.Add(t7);
			listTrees.Add(t8);

			//Dolu od patekata
			Tree t1 = new Tree(new Point(0, Height / 2 + 62));
			Tree t2 = new Tree(new Point(80 + Width / 5, Height / 2 + 62));
			Tree t3 = new Tree(new Point(Width / 2 + 50, Height / 2 + 62));
			Tree t4 = new Tree(new Point(Width - 70, Height / 2 + 62));
			listTrees.Add(t1);
			listTrees.Add(t2);
			listTrees.Add(t3);
			listTrees.Add(t4);
		}
		//============

		internal void CheckSmashed() {
			foreach(Vehicle v in listVehicles) {
				if (frog.isHitBy(v)) {
					frog.IsTouched = true;
					if (livesLeft > 0) {
						livesLeft--;
						Reset(); // implement smashed frog, wait 1 sec, then only move frog to start, cars still moving 
					}
					else {
						gameIsOver=true; //implement frog dead, dialog want to play another..
					}

				}
			}
		}


		internal void Reset() {
			System.Threading.Thread.Sleep(1500);
			frog.OnStart = true;
			frog = new Frog(new Point((Width / 2) - 40, Height - 150));
		}
		}

}
