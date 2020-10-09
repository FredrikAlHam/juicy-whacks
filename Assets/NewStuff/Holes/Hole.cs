using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] bool isHittable = false;
    SpriteRenderer sR;
    [SerializeField] public bool isHit { get; private set; } = false;
    new AudioSource audio = null;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        sR = GetComponent<SpriteRenderer>();
    }

    public void Hit()
    {
        isHit = true;
        sR.color = Color.red;
    }
    public void UnHit()
    {
        isHit = false;
        sR.color = Color.white;
    }
}
