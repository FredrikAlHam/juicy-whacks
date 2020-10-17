using AudioUtilities;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SongImporter : MonoBehaviour
{
    public static List<Song> Songs { get; private set; } = new List<Song>();
    public static List<AudioClip> MenuAudioClips { get; private set; } = new List<AudioClip>();

    public static bool Ready { get; private set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        bool x = false;
        //new Song() { beats = new Beat[] { new Beat() } , bpm = 100, songName = "rappasen", timeSig1 = 4, timeSig2 = 4 }.Log();

        //Gets song assets
        Addressables.LoadAssetsAsync<Song>("Song", null).Completed += objs =>
         {
             foreach (Song song in objs.Result)
             {
                 Debug.Log($"Found song {song.songName}");
                 Songs.Add(song);
             }
             if (x)
             {
                 Ready = true;
             }
             else x = true;
         };
        //Gets AudioClips for menu music
        Addressables.LoadAssetsAsync<AudioClip>("MenuAudio", null).Completed += objs =>
         {
             foreach (AudioClip aC in objs.Result)
             {
                 MenuAudioClips.Add(aC);
             }
             if (x)
             {
                 Ready = true;
             }
             else x = true;
         };


        //foreach (FileInfo fI in new DirectoryInfo(Path.Combine(Application.dataPath, "Resources", "songdata")).GetFiles("*.songdata"))
        //{
        //    StreamReader sR = new StreamReader(fI.OpenRead());
        //    Song song = new Song(sR.ReadToEnd());
        //    Songs.Add(song);
        //    song.Log();
        //}

    }
}
