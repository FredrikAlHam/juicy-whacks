using UnityEngine;
using UnityEngine.SceneManagement;


namespace AudioUtilities
{

    public class GameSongPlayer : MonoBehaviour
    {

        [SerializeField] bool playFirstSongOnStart = false; //Used úp until last moment when we didn't have a song selection screem - F

        SongPlayer player = null;
        new AudioSource audio = null; // Why is audio inheritet from MonoBehaviour and if it's marked as obsolete do I still need the new keyworkd >:( - F
        public static bool IsDone { get; private set; } = false;
        public bool IsPaused { get; private set; } = false;

        private void Start()
        {
            audio = GetComponent<AudioSource>();
        }
        private void Update()
        {
            if (SongImporter.Ready && player == null && playFirstSongOnStart) Play(song: SongImporter.Songs[0]); // REMOVE!!! THIS IS FOR TESTING ONLY
            if (SongImporter.Ready && player == null && SongSelection.selection != null) Play(song: SongSelection.selection);
            if(!(player == null) && player.BeatIndex != 0)
            {
                foreach (GameObject hole in Holes.holes)
                {
                    hole.GetComponent<Hole>().beatIndex = player.BeatIndex-1;
                }
            }
            if(!(player == null) && !player.IsPlaying)
            {
                audio.Stop();
                if (player.IsDone)
                {
                    IsDone = true;
                }
            }


            //harriets if the "ShoulPause" Variable is true - then the Pause function should start
            if (MenuScripts.ShouldPause && !IsPaused)
            {
                Pause();

            }
            //harriets if the "shouldPause" Variable is false - then the UnPause function should start
            if (MenuScripts.ShouldPause == false && IsPaused)
            {
                //Pause();
                UnPause();
            }

        }


        public void Play(Song song)
        {
            Debug.Log($"Playing {song.songName}");
            player = new SongPlayer();
            player.Play(song);
            audio.PlayOneShot(song.clip);
            for (int i = 0; i < Holes.holes.Length; i++)
            {
                //Debug.Log($"Filling hole {i}");
                Holes.holes[i].GetComponent<Hole>().queue = song.GetIntArray(i); // I don't like how this works - F
            }
        }
        public void Pause()
        {
            IsPaused = true;
            audio.Pause();
            player.Pause(); 
        }

        //Harriet gör saker för hon är trött och vill få detta donw with
        public void UnPause()
        {
            IsPaused = false;
            audio.UnPause();
            player.Pause();
        }

    }
}
