using UnityEngine;
using UnityEngine.InputSystem;

public class WhackInput : MonoBehaviour
{
    /*Still learning about the new InputSystem, realized halfway through that there is an option to have both
     *the old and the new inputsystem at the same time. - F*/
    [SerializeField] int maxActiveWhacks = 99;
    int activeWhacks;

    public static Controls controls;

    void OnEnable()
    {
        controls = new Controls();
        controls.Whacks.Enable();
        controls.Whacks.Whack1.performed += Whack;
        controls.Whacks.Whack2.performed += Whack;
        controls.Whacks.Whack3.performed += Whack;
        controls.Whacks.Whack4.performed += Whack;
        controls.Whacks.Whack5.performed += Whack;
        controls.Whacks.Whack6.performed += Whack;

        controls.Whacks.Whack1.canceled += UnWhack;
        controls.Whacks.Whack2.canceled += UnWhack;
        controls.Whacks.Whack3.canceled += UnWhack;
        controls.Whacks.Whack4.canceled += UnWhack;
        controls.Whacks.Whack5.canceled += UnWhack;
        controls.Whacks.Whack6.canceled += UnWhack;
    }
    private void OnDisable()
    {
        controls.Whacks.Disable();
        controls.Whacks.Whack1.performed -= Whack;
        controls.Whacks.Whack2.performed -= Whack;
        controls.Whacks.Whack3.performed -= Whack;
        controls.Whacks.Whack4.performed -= Whack;
        controls.Whacks.Whack5.performed -= Whack;
        controls.Whacks.Whack6.performed -= Whack;

        controls.Whacks.Whack1.canceled -= UnWhack;
        controls.Whacks.Whack2.canceled -= UnWhack;
        controls.Whacks.Whack3.canceled -= UnWhack;
        controls.Whacks.Whack4.canceled -= UnWhack;
        controls.Whacks.Whack5.canceled -= UnWhack;
        controls.Whacks.Whack6.canceled -= UnWhack;
    }

    private void UnWhack(InputAction.CallbackContext obj)
    {
        int holeIndex = 0;
        switch (obj.action.name)
        {
            case "Whack 1":
                holeIndex = 1;
                break;
            case "Whack 2":
                holeIndex = 2;
                break;
            case "Whack 3":
                holeIndex = 3;
                break;
            case "Whack 4":
                holeIndex = 4;
                break;
            case "Whack 5":
                holeIndex = 5;
                break;
            case "Whack 6":
                holeIndex = 6;
                break;
        }
        holeIndex--;
        Hole hole = Holes.holes[holeIndex].GetComponent<Hole>();
        if (hole.IsHit)
        {
            activeWhacks--;
            hole.UnHit();
        }
    }

    private void Whack(InputAction.CallbackContext obj)
    {
        if (activeWhacks >= maxActiveWhacks) return;
        activeWhacks++;
        int holeIndex = 0;
        switch (obj.action.name)
        {
            case "Whack 1":
                holeIndex = 1;
                break;
            case "Whack 2":
                holeIndex = 2;
                break;
            case "Whack 3":
                holeIndex = 3;
                break;
            case "Whack 4":
                holeIndex = 4;
                break;
            case "Whack 5":
                holeIndex = 5;
                break;
            case "Whack 6":
                holeIndex = 6;
                break;
        }
        holeIndex--;
        Hole hole = Holes.holes[holeIndex].GetComponent<Hole>();
        hole.Hit();
    }
}
