using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;

namespace mp3Player
{
	public partial class Form1 : Form
	{
		string _file = "But what if you really need to change the ballance how are we gonna be able to do that.wav";

		//SoundPlayer player = new SoundPlayer();

		int stream = -1;

		public Form1()
		{
			InitializeComponent();

			Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(stream != -1)
			{
				Bass.BASS_ChannelStop(stream);
				Bass.BASS_StreamFree(stream);
			}

			stream = Bass.BASS_StreamCreateFile(_file, 0, 0, BASSFlag.BASS_DEFAULT);
			Bass.BASS_ChannelFlags(stream, BASSFlag.BASS_SAMPLE_LOOP, BASSFlag.BASS_SAMPLE_LOOP);


			Bass.BASS_ChannelPlay(stream, false);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (stream != -1)
			{
				Bass.BASS_ChannelStop(stream);
				Bass.BASS_StreamFree(stream);
			}
		}

		//private void play()
		//{
		//	player.Stop();
		//	player.SoundLocation = _file;
		//	player.Play();
		//}
	}
}
