using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5f;
    public float tilesMoved = 0f;

    public bool p1Turn;
    public Transform movePoint;
	public int SpeedInt;

    public LayerMask whatStopsMovement;

    private void Start() {
        movePoint.parent = null;
    }
    
    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f) {

            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {

                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, whatStopsMovement)) {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    tilesMoved = tilesMoved + 1; //counts tiles
                } 

            } else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {

                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, whatStopsMovement)) {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    tilesMoved = tilesMoved + 1;
                } 
            }

            //anim.SetBool("moving", false);
			SpeedInt = 0;
        } else {
            //anim.SetBool("moving", true);
			SpeedInt = 1;
        }

        if (tilesMoved == 5)
            {
                p1Turn = false;
                Debug.Log("Player 1's turn over!");
                tilesMoved = 0;
            }
    }
}
