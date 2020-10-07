using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    [SerializeField] GameObject[] holePos = new GameObject[6];
    Controls controls;
    // Start is called before the first frame update
    void Start()
    {
        controls = new Controls();
        controls.Whacks.Enable();
        controls.Whacks.Whack1.performed += Whack;
        controls.Whacks.Whack2.performed += Whack;
        controls.Whacks.Whack3.performed += Whack;
        controls.Whacks.Whack4.performed += Whack;
        controls.Whacks.Whack5.performed += Whack;
        controls.Whacks.Whack6.performed += Whack;
    }

    private void Whack(InputAction.CallbackContext obj)
    {
        //GameObject g = null;
        int hole = 0;
        switch (obj.action.name)
        {
            case "Whack 1":
                hole = 1;
                break;
            case "Whack 2":
                hole = 2;
                break;
            case "Whack 3":
                hole = 3;
                break;
            case "Whack 4":
                hole = 4;
                break;
            case "Whack 5":
                hole = 5;
                break;
            case "Whack 6":
                hole = 6;
                break;
        }
        //g = new GameObject();
        transform.position = holePos[hole-1].transform.position;
        holePos[hole-1].GetComponent<Hole>().Play();
        Debug.Log(hole);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
