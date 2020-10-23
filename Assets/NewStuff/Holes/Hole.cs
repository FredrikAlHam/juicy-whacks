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

    public Animator animator;  //animator that controls (beavers) when to animate - Erik
    public AnimationClip anim;

    public Animator animatorAxe;  //animator that controls (Axe) when to animate - Erik
    public AnimationClip axeAnim;

    public Animator animatorOSU;  //animator that controls (circle/feedback thingy) when to animate - Erik

    public AudioSource axeSource;  //Audiosource that is connected to the axe swinging sound effect - Erik


    SpriteRenderer sR = null;
    // Use this for initialization
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    public virtual void Hit()
    {
        animatorAxe.SetTrigger("Swing");  //when you hit (i.e. Press (L, K, J, F, D or S)) it will play this animation - Erik
        IsHit = true;  //Activate TRUE/false statement so that the game knows that one of these keys are pressed - Erik
        axeSource.Play();  //Activates sound effect for when swinging the ax - Erik
    }

    public virtual void UnHit()
    {
        animatorAxe.SetTrigger("UnSwing"); //when you let go of (L, K, J, F, D or S) then this animation will play - Erik
        IsHit = false;  //Activate true/FALSE statement so that the game knows that one of these keys are pressed - Erik
    }

    public virtual void PrepareToPopup()
    {
        animatorOSU.SetTrigger("OSU");  //When the beatindex + (*Some number*) equals 1...
    }                                   //Or, at the time we set; this animation will play. Showing where beaver will pop up - Erik
    public virtual void Popup()
    {

        animator.SetTrigger("PopUp");  //Play "PopUp" animation when this is activated
        animatorOSU.SetTrigger("No");  //this will activate the "idle" animation for the OSU circle, moving it out of view - Erik
        //timeSinceLastBeat = 0f;  //(reset the time since last beat)(testCode)(Remove)
        //sR.color = Color.green;  //(blinks)(testCode)(Remove)
        isPopUp = true;  //activates bool, telling the game that a beaver has popped up - Erik
    }



    public virtual void UnPopup()
    {
        animator.SetTrigger("UnPopUp");  //play the "UnPopUp" Animation
        //timeSinceLastBeat += Time.deltaTime; 
        //sR.color = Color.white;
    }
    protected virtual void Update()
    {

        if (IsHit == true && isPopUp == true && queue[beatIndex + 1] > 0)
        {
            //gib points
            //points++;
            //Debug.Log("scoree" + points);
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
