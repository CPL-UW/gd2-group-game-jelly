﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is actually the player1 controller
public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public int tilesMoved = 0;

    public bool p1Turn;

    public Transform movePoint;
    public int SpeedInt;

    public LayerMask whatStopsMovement;

    public bool facingRight;


    private void Start()
    {
        movePoint.parent = null;

        // Ensure p1 is facing right to start
        if (gameObject.transform.localScale.x < 0)
        {
            Flip();
        }
        facingRight = true;

    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (p1Turn == true)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
            {

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    // Set player direction
                    if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
                    {
                        Flip();
                    }
                    else if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
                    {
                        Flip();
                    }

                    // Move Player
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        tilesMoved++; //counts tiles
                    }

                }
                else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {

                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        tilesMoved++;
                    }
                }

                SpeedInt = 0;
            }
            else
            {
                SpeedInt = 1;
            }

            if (tilesMoved == 5)
            {
                //p1Turn = false;
                //Debug.Log("Player 1's turn over!");
                //tilesMoved = 0;
            }
        }
    }


    // Flips players x direction
    private void Flip()
    {
        Vector3 currScale = gameObject.transform.localScale;
        currScale.x *= -1;
        gameObject.transform.localScale = currScale;
        facingRight = !facingRight;
    }
}