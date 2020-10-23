using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Hole : MonoBehaviour
{
    [SerializeField] public bool IsHit { get; private set; } = false;

    [SerializeField] public List<int> queue = new List<int>();
    public int beatIndex = 0;
    public float timeSinceLastBeat = 0;
    // Start is called before the first frame update

    private bool isPopUp = false;
    public int points = 0;

    public Animator animator;  //animator that controls (beavers) when to animate
    public AnimationClip anim;

    public Animator animatorAxe;  //animator that controls (Axe) when to animate
    public AnimationClip axeAnim;

    public Animator animatorOSU;  //animator that controls (circle/feedback thingy) when to animate

    public AudioSource axeSource;


    SpriteRenderer sR = null;
    // Use this for initialization
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    public virtual void Hit()
    {
        animatorAxe.SetTrigger("Swing");  //when you hit (i.e. Press (L, K, J, F, D or S)) it will play this animation
        IsHit = true;  //Activate true/false statement so that the game knows that one of these keys are pressed
        axeSource.Play();
    }

    public virtual void UnHit()
    {
        animatorAxe.SetTrigger("UnSwing");
        IsHit = false;
    }

    public virtual void PrepareToPopup()
    {
        animatorOSU.SetTrigger("OSU");
    }
    public virtual void Popup()
    {

        animator.SetTrigger("PopUp");
        animatorOSU.SetTrigger("No");
        timeSinceLastBeat = 0f;
        sR.color = Color.green;
        isPopUp = true;
    }



    public virtual void UnPopup()
    {
        animator.SetTrigger("UnPopUp");
        timeSinceLastBeat += Time.deltaTime;
        sR.color = Color.white;
    }
    protected virtual void Update()
    {

        if (IsHit == true && isPopUp == true && queue[beatIndex + 1] > 0)
        {
            //gib points
            points++;
            Debug.Log("scoree" + points);
        }

        try
        {
            if (queue.Count == 0 || queue.Count < beatIndex) return;
            else if (queue[beatIndex] > 0)
            {
                Popup();
            }
            else if (queue[beatIndex - 3] > 0)
            {
                UnPopup();
            }
            else if (queue[beatIndex + 5] > 0)
            {
                PrepareToPopup();
            }
        }
        catch (ArgumentOutOfRangeException)
        {

        }
    }
}
