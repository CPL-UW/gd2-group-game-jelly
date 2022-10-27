using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {

    public float moveSpeed = 5f;
    public Transform lilGhost;

    public LayerMask whatStopsMovement;
    //public Animator anim;

    private void Start() {
        lilGhost.parent = null;
    }
    
    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, lilGhost.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, lilGhost.position) <= 0.05f) {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) 
            {

                if (!Physics2D.OverlapCircle(lilGhost.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, whatStopsMovement)) 
                {
                    lilGhost.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                } 
            }  if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) 
            {

                if (!Physics2D.OverlapCircle(lilGhost.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, whatStopsMovement)) 
                {
                    lilGhost.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                } 
            }

            //anim.SetBool("moving", false);
        } else {
            //anim.SetBool("moving", true);
        }
    }
}
