using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeapFrog {

	public partial class Form1 : Form {
		public Scene scene;
		Timer timerCreate;
		Timer timerMove;
		public Form1() {
			InitializeComponent();
			scene = new Scene(Width, Height);
			scene.AddFrog();
			scene.AddVehicle();
			scene.AddTrees();
			//timer for vehicles add or maybe for each type diff- three timers
			timerCreate = new Timer();
			timerCreate.Interval = 850;
			timerCreate.Tick += new EventHandler(timerCreate_Tick);
			timerCreate.Start();


			timerMove = new Timer();
			timerMove.Interval = 50;
			timerMove.Tick += new EventHandler(timerMove_Tick);
			timerMove.Start();

			DoubleBuffered = true;
			//Invalidate(true);
		}

		private void timerCreate_Tick(object sender, EventArgs e) {
			scene.AddVehicle();
			Invalidate(true);
		}

		private void timerMove_Tick(object sender, EventArgs e) {
			scene.Move();
			scene.CheckSmashed();
			Invalidate(true);
		}

		//fix scene draw here
		private void Form1_Paint(object sender, PaintEventArgs e) {
			e.Graphics.Clear(Color.White);
			scene.Draw(e.Graphics);
		}


		//fix scene call to frog here
		private void Form1_KeyPress(object sender, KeyPressEventArgs e) {
			scene.frog.Jump(e.KeyChar, this.Width, this.Height);
			Invalidate(true);
			if (scene.frog.Location.Y <= 10) {
				scene.frog.noMoreUp = true;
				timerMove.Stop();
				timerCreate.Stop();
			}
		}
		//fix this later
		private void Form1_ResizeEnd(object sender, EventArgs e) {
			Invalidate(true);
		}

		private void Form1_ResizeBegin(object sender, EventArgs e) {
			Invalidate(true);
		}

		private void lblStatus_Paint(object sender, PaintEventArgs e) {
			lblStatus.Text = "Points " + scene.points + " Lives left " + scene.livesLeft;
		}
	}
}
