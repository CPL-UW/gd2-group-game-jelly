using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1AnimScript : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject.Find("ThePlayer").GetComponent<PlayerScript>().Health -= 10.0f;
        if (GameObject.Find("Player").GetComponent<PlayerController>().SpeedInt == 1)//Player.GetComponent<SpeedInt>() == 1)
        {
            animator.SetInteger("MoveInt", 1);
        }
        else
        {
            animator.SetInteger("MoveInt", 0);
        }
    }
}
