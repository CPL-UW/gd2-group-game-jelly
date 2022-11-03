using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dadGhostScript : MonoBehaviour
{
    public bool ghostTurn;
    public int direction = 0;
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public LayerMask playerLayer;
    public float tilesMoved = 0f;
    public bool start;
    public bool facingRight;
    public int rpsChoice;

    void Start()
    {
        movePoint.parent = null;
        start = true;

        // Ensure ghost is facing right to start
        if (gameObject.transform.localScale.x < 0)
        {
            Flip();
        }
        facingRight = false;
        rpsChoice = Random.Range(1,4);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (ghostTurn == true && start == true)
        {
            StartCoroutine("GhostMove");
        }

        if (tilesMoved == 11)
        {
            ghostTurn = false;
            StopCoroutine("GhostMove");
            //Debug.Log("Ghost's turn over!");
            tilesMoved = 0;
        }
    }

    IEnumerator GhostMove()
    {
        start = false;

        direction = Random.Range(1, 5);

        if (direction == 1) //north
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement) && !Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), 0.2f, playerLayer))
            {
                movePoint.position += new Vector3(0f, 1f, 0f);
            }
        }
        if (direction == 2) //east
        {
            if (!facingRight)
            {
                Flip();
            }

            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement) && !Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), 0.2f, playerLayer))
            {
                movePoint.position += new Vector3(1f, 0f, 0f);
            }
        }
        if (direction == 3) //south
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement) && !Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), 0.2f, playerLayer))
            {
                movePoint.position += new Vector3(0f, -1f, 0f);
            }
        }
        if (direction == 4) //west
        {
            if (facingRight)
            {
                Flip();
            }

            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement) && !Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), 0.2f, playerLayer))
            {
                movePoint.position += new Vector3(-1f, 0f, 0f);
            }
        }

        tilesMoved += 1;
        //Debug.Log(tilesMoved);
        yield return new WaitForSeconds(0.5f);
        start = true;
    }

    // Flips ghosts x direction
    private void Flip()
    {
        Vector3 currScale = gameObject.transform.localScale;
        currScale.x *= -1;
        gameObject.transform.localScale = currScale;
        facingRight = !facingRight;
    }
}
