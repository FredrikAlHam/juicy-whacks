using UnityEngine;

namespace AudioUtilities
{
    public class SongTestPlayer : MonoBehaviour
    {
        new AudioSource audio = null;
        Controls controls = null;
        // Start is called before the first frame update
        void Start()
        {
            controls = new Controls();
            controls.Whacks.Enable();
            audio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            //Binds the whack keys to play the first six songs loaded
            if (SongImporter.Ready && !audio.isPlaying)
            {
                if (controls.Whacks.Whack1.triggered) audio.PlayOneShot(SongImporter.Songs[0].clip);
                if (controls.Whacks.Whack2.triggered) audio.PlayOneShot(SongImporter.Songs[1].clip);
                if (controls.Whacks.Whack3.triggered) audio.PlayOneShot(SongImporter.Songs[2].clip);
                if (controls.Whacks.Whack4.triggered) audio.PlayOneShot(SongImporter.Songs[3].clip);
                if (controls.Whacks.Whack5.triggered) audio.PlayOneShot(SongImporter.Songs[4].clip);
                if (controls.Whacks.Whack6.triggered) audio.PlayOneShot(SongImporter.Songs[5].clip);
            }
        }
    }

}