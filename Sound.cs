using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NAudio.Dsp;
using NAudio.Wave;

namespace WPFTutorial
{
    public class Sound
    {
        private readonly string REMOVETHISPATH = @"G:\Projects\C#\WPF\WPFTutorial\WPFTutorial\audio\";

        public WaveOutEvent audioPlayer = new WaveOutEvent();
        private AudioFileReader audioFileReader;
        public SoundEnums name;
        public bool repeats = true;


        public Sound(SoundEnums _name, bool _repeats = true)
        {
            name = _name;
            repeats = _repeats;

            var path = REMOVETHISPATH + @$"{name}.wav";
            audioFileReader = new AudioFileReader(path);
        }

        // Play the audio
        public void Play()
        {
            audioPlayer = new WaveOutEvent();
            audioPlayer.PlaybackStopped += Loop;

            audioPlayer.Init(audioFileReader);

            audioFileReader.Position = 0;
            audioPlayer.Play();
        }
        
        // Stop playing the audio
        public void Stop()
        {
            // Completely delete audioplayer
            if (audioPlayer != null) 
            {
                audioPlayer.Stop();
                audioPlayer.PlaybackStopped -= Loop;
                audioPlayer.Dispose();
                audioPlayer = null;
            }
        }

        // Called event to restart audio if it ends
        private void Loop(object sender, StoppedEventArgs e)
        {
            if (repeats)
            {
                audioFileReader.Position = 0;
                audioPlayer?.Play(); // Play audio if not null
            }
        }
    }

    // When you add a sound file to 'audio', make sure it is a wav and spelled exactly like you put it here
    public enum SoundEnums
    {
        none, // Basically used as a NULL
        coldWind,
        creepyWind,
        thunder,
        thunder1,
        thunder2,
        doorslam,
        creepyInside,

        // Unused Yet
        lab1,
        lab2,

    }

}
