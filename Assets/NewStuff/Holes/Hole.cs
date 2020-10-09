using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] bool isHittable = false;
    [SerializeField] AudioClip clip = null;
    SpriteRenderer sR;
    [SerializeField] public bool isHit { get; private set; } = false;
    new AudioSource audio = null;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        sR = GetComponent<SpriteRenderer>();
    }

    public void Play()
    {
        if (clip != null)
            audio.PlayOneShot(clip);
    }
    public void Hit()
    {
        Play();
        isHit = true;
        sR.color = Color.red;
    }
    public void UnHit()
    {
        isHit = false;
        sR.color = Color.white;
    }
}
