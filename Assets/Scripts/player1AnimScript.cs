using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1AnimScript : MonoBehaviour
{
    public Animator animator;

    void Start()
    {

    }

    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().SpeedInt == 1)
        {
            animator.SetInteger("MoveInt", 1);
        }
        else
        {
            animator.SetInteger("MoveInt", 0);
        }
    }
}
