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
			timerCreate.Interval = 650;
			timerCreate.Tick += new EventHandler(timerCreate_Tick);
			timerCreate.Start();

			//timer for moving
			timerMove = new Timer();
			timerMove.Interval = 50;
			timerMove.Tick += new EventHandler(timerMove_Tick);
			timerMove.Start();

			DoubleBuffered = true;
		}

		private void timerCreate_Tick(object sender, EventArgs e) {
			scene.AddVehicle();
			Invalidate(true);
		}

		private void timerMove_Tick(object sender, EventArgs e) {
			scene.Move();
			scene.CheckSmashed();
			
			if (scene.gameIsOver == true) {
				timerMove.Stop();
				timerCreate.Stop();
				Invalidate(true);
				if (MessageBox.Show("You Lose!\n Start from Beginning?", "GAME OVER!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
					scene = new Scene(Width, Height);
					scene.AddFrog();
					scene.AddVehicle();
					scene.AddTrees();
					timerMove.Start();
					timerCreate.Start();
				}
				else {
					Close();
				}
				
			}
			Invalidate(true);
		}

		//fix scene draw here
		private void Form1_Paint(object sender, PaintEventArgs e) {
			//e.Graphics.Clear(Color.Transparent);
			
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
				if (MessageBox.Show("Yay you won!\n Play another?", "Congratualtions!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
					
					scene = new Scene(Width, Height);
					scene.AddFrog();
					scene.AddVehicle();
					scene.AddTrees();
					timerCreate.Start();
					timerMove.Start();
					Invalidate(true);
				}
				else {
					Close();
				}
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
			lblStatus.Text = " Lives left " + scene.livesLeft;
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e) {
			scene = new Scene(Width, Height);
			scene.AddFrog();
			scene.AddVehicle();
			scene.AddTrees();
			timerCreate.Start();
			timerMove.Start();
			Invalidate(true);
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			timerMove.Stop();
			timerCreate.Stop();
			if(MessageBox.Show("LeapFrog game by Marina and Sofija. \n\nThe frog should get to the other side without getting hit!", "About the game", MessageBoxButtons.OK)== System.Windows.Forms.DialogResult.OK) {
				timerMove.Start();
				timerCreate.Start();
			}
		}
	}
}
