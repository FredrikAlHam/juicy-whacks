using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] bool isHittable = false;
    [SerializeField] AudioClip clip;
    AudioSource audio = null;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if(clip != null)
        audio.PlayOneShot(clip);
    }
}
