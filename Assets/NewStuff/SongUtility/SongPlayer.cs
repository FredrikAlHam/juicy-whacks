using System;
using System.Timers;
using UnityEngine;

namespace AudioUtilities
{
    public class SongPlayer : IDisposable
    {
        public Beat Beat { get; private set; } = new Beat() { holeIndecies = new int[] { 0, 0, 0, 0, 0, 0 } };
        public bool IsPlaying { get; private set; } = false;
        private Song song = null;
        public int BeatIndex { get; private set; } = 0;
        private Timer beatTimer = new Timer();


        public void Play(Song song)
        {
            this.song = song;
            Play();
        }
        public void Play()
        {
            BeatIndex = 0;
            beatTimer.Interval = 60000 / Convert.ToDouble(song.bpm)/*ms per beat*/ / 4 /* to sixteenths*/;
            IsPlaying = true;
            beatTimer.Elapsed += BeatTimer_Elapsed;
            beatTimer.Start();
        }
        public void Pause()
        {
            beatTimer.Enabled = !beatTimer.Enabled;
        }
        private void BeatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (BeatIndex >= song.beats.Length)
            {
                IsPlaying = false;
                beatTimer.Stop();
            }
            else
            {
                Beat = song.beats[BeatIndex];
                BeatIndex++;
                Debug.Log("on beat " + BeatIndex);
            }
        }

        public void Dispose()
        {
            beatTimer.Stop();
            beatTimer.Dispose();
        }

        public SongPlayer(Song song)
        {
            this.song = song;
        }
        public SongPlayer()
        {

        }

    }



}