using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilGhostScript : MonoBehaviour
{
    private int direction = 0;
    private float moveSpeed = 5f;
    public Transform movePoint; 
    public LayerMask whatStopsMovement;
    public LayerMask playerLayer;
    private float tilesMoved = 0f;
    private bool start;
    public GameObject dadGhost;

    void Start()
    {
        movePoint.parent = null;
        start = true;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        if (dadGhost.GetComponent<dadGhostScript>().start == true)
        {
            start = true;
        }

        if (dadGhost.GetComponent<dadGhostScript>().ghostTurn == true && start == true)
        {
            StartCoroutine("GhostMove");
        }

        if (tilesMoved == 5)
        {
            StopCoroutine("GhostMove");
            //Debug.Log("Lil Ghost's turn over!");
            tilesMoved = 0;
        }
    }

    IEnumerator GhostMove()
    {
        start = false;
        
        direction = Random.Range(1,5);

        if (direction == 1) //north
        {
            if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement) && !Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), 0.2f, playerLayer)) {
                    movePoint.position += new Vector3(0f, 1f, 0f);
            } 
        }
        if (direction == 2) //east
        {
            if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement) && !Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), 0.2f, playerLayer)) {
                    movePoint.position += new Vector3(1f, 0f, 0f);
            } 
        }
        if (direction == 3) //south
        {
            if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement) && !Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), 0.2f, playerLayer)) {
                    movePoint.position += new Vector3(0f, -1f, 0f);
            } 
        }
        if (direction == 4) //west
        {
            if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement) && !Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), 0.2f, playerLayer)) {
                    movePoint.position += new Vector3(-1f, 0f, 0f);
            } 
        }

        tilesMoved += 1;
        //Debug.Log(tilesMoved);
        yield return new WaitForSeconds(0.5f);
        start = true;
    }
}
