using AudioUtilities;
using UnityEngine;

public class audioScript : MonoBehaviour
{

    private AudioSource audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SongImporter.Ready && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(SongImporter.MenuAudioClips[0]);
        }

    }
}
