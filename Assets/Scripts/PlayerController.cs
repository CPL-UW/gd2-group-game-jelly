using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is actually the player1 controller
public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public int tilesMoved = 0;
    public int tilesMovedMax = 5; //set to public so items can change max move tiles
    public bool p1Turn;
    public bool p1CanMove = true; //added this so that menus can pause movement
    public bool hasPupLight = false;
    public bool hasPupEMF = false;
    public bool hasPupVacuum = false;
    public bool hasBS = false;
    public bool hasRock = false;
    public bool hasPaper = false;
    public bool hasScissors = false;
    public GameObject Inventory;
    public GameObject CardInvy;
    public GameObject Bob;

    public Transform movePoint;
    public int SpeedInt;

    public LayerMask whatStopsMovement;

    public bool facingRight;

    //[SerializeField] private Collider2D playerCollider;
    

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

                if (Input.GetKey(KeyCode.A) && p1CanMove == true || Input.GetKey(KeyCode.D) && p1CanMove == true)
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
                else if (Input.GetKey(KeyCode.W) && p1CanMove == true || Input.GetKey(KeyCode.S) && p1CanMove == true )
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

            Bob.SetActive(true);
        }

        if (Inventory.activeInHierarchy == true || CardInvy.activeInHierarchy == true)
        {
            p1CanMove = false;
        }
        else
        {
            p1CanMove = true;
        }

        if (p1Turn == false)
        {
            Bob.SetActive(false);
        }

        if (hasRock == false)
        {
            CardInvy.GetComponent<CardInvyScript>().Rock.SetActive(false);
        }
        if (hasScissors == false)
        {
            CardInvy.GetComponent<CardInvyScript>().Scissors.SetActive(false);
        }
        if (hasPaper == false)
        {
            CardInvy.GetComponent<CardInvyScript>().Paper.SetActive(false);
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

    public void useLight(){
        tilesMovedMax = tilesMovedMax + 5;
        hasPupLight = false;
        Inventory.GetComponent<inventoryScript>().Flashlight.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("Collision");
        if(other.gameObject.tag.Equals("Ghost")) {
            //Debug.Log("Ghost Collision");
            
            if(hasRock || hasPaper || hasScissors) {
                GhostFightUIScript.Instance.TogglePlayerOneFight();
                tilesMoved = tilesMovedMax;
                Destroy(other.gameObject);
            }
            
        }

        if(other.gameObject.tag.Equals("pupLight")) {
            hasPupLight = true;
            Inventory.GetComponent<inventoryScript>().Flashlight.SetActive(true);

            //Debug.Log("Flashlight!");
            
            tilesMoved = tilesMovedMax;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag.Equals("pupEMF")) {
            hasPupEMF = true;
            Inventory.GetComponent<inventoryScript>().EMF.SetActive(true);

            //Debug.Log("EMF!");
            
            tilesMoved = tilesMovedMax;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag.Equals("pupVacuum")) {
            hasPupLight = true;
            Inventory.GetComponent<inventoryScript>().Vacuum.SetActive(true);

            //Debug.Log("Vacuum!");
            
            tilesMoved = tilesMovedMax;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag.Equals("pupBS")) {
            hasBS = true;
            Inventory.GetComponent<inventoryScript>().BrokenStopwatch.SetActive(true);

            //Debug.Log("Stopwatch!");
            
            tilesMoved = tilesMovedMax;
            Destroy(other.gameObject);
        }

        if(!hasRock) {
            if(other.gameObject.tag.Equals("Rock")) {
                hasRock = true;
                CardInvy.GetComponent<CardInvyScript>().Rock.SetActive(true);

                //Debug.Log("Flashlight!");
                
                tilesMoved = tilesMovedMax;
                Destroy(other.gameObject);
            }
        }
        
        if(!hasPaper) {
            if(other.gameObject.tag.Equals("Paper")) {
                hasPaper = true;
                CardInvy.GetComponent<CardInvyScript>().Paper.SetActive(true);

                //Debug.Log("Flashlight!");
                
                tilesMoved = tilesMovedMax;
                Destroy(other.gameObject);
            }
        }

        if(!hasScissors) {
            if(other.gameObject.tag.Equals("Scissors")) {
                hasScissors = true;
                CardInvy.GetComponent<CardInvyScript>().Scissors.SetActive(true);

                //Debug.Log("Flashlight!");
                
                tilesMoved = tilesMovedMax;
                Destroy(other.gameObject);
            }
        }
    }

}