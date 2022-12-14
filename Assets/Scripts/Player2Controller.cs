using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    public float moveSpeed = 5f;
    public int tilesMoved = 0;
    public int tilesMovedMax = 5;
    public bool p2Turn;
    public bool p2CanMove = true;
    public bool hasPupLight = false;
    public bool hasPupEMF = false;
    public bool hasPupVacuum = false;
    public bool hasBS = false;
    public bool hasRock = false;
    public bool hasPaper = false;
    public bool hasScissors = false;
    public GameObject Inventory;
    public GameObject CardInvy;
    public Transform movePoint;
    public int SpeedInt;
    public GameObject Bob;
    public GameObject Randomizer;

    public GameObject p2EctoCounter;
    public int p2Ecto;

    public LayerMask whatStopsMovement;

    public bool facingRight;


    private void Start()
    {
        movePoint.parent = null;

        // Ensure p2 is facing left to start
        if (gameObject.transform.localScale.x > 0)
        {
            Flip();
        }
        facingRight = false;
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        p2Ecto = p2EctoCounter.GetComponent<PlayerTwoEctoCounterScript>()._ectoCounter;

        if (p2Turn == true && tilesMoved < tilesMovedMax)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
            {

                if (Input.GetKey(KeyCode.LeftArrow) && p2CanMove == true || Input.GetKey(KeyCode.RightArrow) && p2CanMove == true )
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
                else if (Input.GetKey(KeyCode.UpArrow) && p2CanMove == true || Input.GetKey(KeyCode.DownArrow) && p2CanMove == true )
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
            p2CanMove = false;
        }
        else
        {
            p2CanMove = true;
        }

        if (p2Turn == false)
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

        if(gameObject.transform.localScale.x < 0) {
            Vector3 bobScale = Bob.transform.localScale;
            bobScale.x *= -1;
            Bob.transform.localScale = bobScale;
        } else {
            Vector3 bobScale = Bob.transform.localScale;
            bobScale.x *= -1;
            Bob.transform.localScale = bobScale;
        }
    }

    public Vector3 GetPlayerTwoPosition() {
        return gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("Collision");
        if(other.gameObject.tag.Equals("Ghost")) {
            //Debug.Log("Ghost Collision");
            if(hasRock || hasPaper || hasScissors) {
                PlayerTwoGhostFightUIScript.Instance.TogglePlayerTwoFight(other.gameObject);
                tilesMoved = tilesMovedMax;
            }
            else
            {
                TextPopUp.Create(GetPlayerTwoPosition(), "No cards!");
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
                Randomizer.GetComponent<randoControllerScript>().spawnCard();

                //Debug.Log("Flashlight!");
                
                tilesMoved = tilesMovedMax;
                Destroy(other.gameObject);
            }
        }
        
        if(!hasPaper) {
            if(other.gameObject.tag.Equals("Paper")) {
                hasPaper = true;
                CardInvy.GetComponent<CardInvyScript>().Paper.SetActive(true);
                Randomizer.GetComponent<randoControllerScript>().spawnCard();

                //Debug.Log("Flashlight!");
                
                tilesMoved = tilesMovedMax;
                Destroy(other.gameObject);
            }
        }

        if(!hasScissors) {
            if(other.gameObject.tag.Equals("Scissors")) {
                hasScissors = true;
                CardInvy.GetComponent<CardInvyScript>().Scissors.SetActive(true);
                Randomizer.GetComponent<randoControllerScript>().spawnCard();

                //Debug.Log("Flashlight!");
                
                tilesMoved = tilesMovedMax;
                Destroy(other.gameObject);
            }
        }
    }

    public void useLight(){
        tilesMovedMax = tilesMovedMax + 5;
        hasPupLight = false;
        Inventory.GetComponent<inventoryScript>().Flashlight.SetActive(false);
    }
}