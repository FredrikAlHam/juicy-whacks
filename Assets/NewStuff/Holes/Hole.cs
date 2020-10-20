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

    public Animator animator;
    public AnimationClip anim;


    public virtual void Hit()
    {

    }
    public virtual void UnHit()
    {

    }
    public virtual void PrepareToPopup()
    {

    }
    public virtual void Popup()
    {
        animator.SetTrigger("PopUp");
    }
    public virtual void UnPopup()
    {
        animator.SetTrigger("UnPopUp");
    }
    protected virtual void Update()
    {
        if (queue.Count == 0 || queue.Count < beatIndex) return;
        else if (queue[beatIndex] > 0)
        {
            Popup();
        }
        else if (queue[beatIndex - 1] > 0)
        {
            UnPopup();
        }
        else if (queue[beatIndex + 1] > 0)
        {
            PrepareToPopup();
        }
    }
}
