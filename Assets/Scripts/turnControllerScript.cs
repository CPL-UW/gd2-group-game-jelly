using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnControllerScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject p1gui;
    public GameObject player2;
    public GameObject p2gui;
    //public GameObject player3;        //uncomment if/when more players added
    //public GameObject p3gui;
    //public GameObject player4;
    //public GameObject p4gui;
    public GameObject ghost;
    public GameObject ggui;

    void Start()
    {
        player1.GetComponent<PlayerController>().p1Turn = true;
        p1gui.SetActive(true);
        p2gui.SetActive(false);
        ggui.SetActive(false);
        player2.GetComponent<Player2Controller>().p2Turn = false;
        ghost.GetComponent<dadGhostScript>().ghostTurn = false;
    }

    void Update()
    {
        if (player1.GetComponent<PlayerController>().tilesMoved == 5) //if p1 moves 5 tiles
        {
            player1.GetComponent<PlayerController>().p1Turn = false; //end p1's turn
            p1gui.SetActive(false); //deactivate p1's gui
            //Debug.Log("Player 1's turn over!"); //debug line
            player1.GetComponent<PlayerController>().tilesMoved = 0; //reset p1's tiles
            p2gui.SetActive(true); //activate p2's gui

            // Unneeded after changing keybinding for each player - keep incase we change back
            //StartCoroutine(DelayPlayerChange()); // wait a bit before giving control to player2 

            player2.GetComponent<Player2Controller>().p2Turn = true; // give control to p2
        }

        if (player2.GetComponent<Player2Controller>().tilesMoved == 5)
        {
            player2.GetComponent<Player2Controller>().p2Turn = false;
            p2gui.SetActive(false);
            //Debug.Log("Player 2's turn over!");
            player2.GetComponent<Player2Controller>().tilesMoved = 0;
            ghost.GetComponent<dadGhostScript>().ghostTurn = true;
            ggui.SetActive(true);
        }

        if (ghost != null && ghost.GetComponent<dadGhostScript>().tilesMoved == 10) //dad ghost has like 10 tiles I think
        {
            ghost.GetComponent<dadGhostScript>().ghostTurn = false;
            ggui.SetActive(false);
            //Debug.Log("Ghost's turn over!");
            ghost.GetComponent<dadGhostScript>().tilesMoved = 0;
            player1.GetComponent<PlayerController>().p1Turn = true;
            p1gui.SetActive(true);
        }
    }

    /* IEnumerator DelayPlayerChange()
    {
        yield return new WaitForSeconds(0.75f);
        player2.GetComponent<Player2Controller>().p2Turn = true; //start p2's turn
    } */
}
