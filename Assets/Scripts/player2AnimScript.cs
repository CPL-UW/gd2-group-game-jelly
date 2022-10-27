using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2AnimScript : MonoBehaviour
{
    public Animator animator;

    void Start()
    {

    }

    void Update()
    {
        if (GameObject.Find("Player2").GetComponent<Player2Controller>().SpeedInt == 1)
        {
            animator.SetInteger("MoveInt", 1);
        }
        else
        {
            animator.SetInteger("MoveInt", 0);
        }
    }
}
