using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostFightUIScript : MonoBehaviour {

    //singleton
    public static GhostFightUIScript Instance {get; private set;}
    
    private int rockValue = 1;
    private int paperValue = 2;
    private int scissorsValue = 3;
    private Transform Image;
    private Transform Rock;
    private Transform Paper;
    private Transform Scissors;

    [SerializeField] private GameObject PlayerOne;
    [SerializeField] private GameObject PlayerTwo;


    private void Awake() {
        Instance = this;
        gameObject.SetActive(false); //initially hide if not hidden
        Image = transform.Find("Image");
        Rock = transform.Find("Rock");
        Paper = transform.Find("Paper");
        Scissors = transform.Find("Scissors");
    }

    public void TogglePlayerOneFight(GameObject ghost) {
        gameObject.SetActive(!gameObject.activeSelf);
        if(gameObject.activeSelf){
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
        if(!PlayerOne.GetComponent<PlayerController>().hasRock){
            //Debug.Log("Doesn't have a Rock");
            Rock.gameObject.SetActive(false);
        }
        if(!PlayerOne.GetComponent<PlayerController>().hasPaper){
            Paper.gameObject.SetActive(false);
        }
        if(!PlayerOne.GetComponent<PlayerController>().hasScissors){
            Scissors.gameObject.SetActive(false);
        }

        //below this resets it for when p2 uses a card that p1 also had
        if(PlayerOne.GetComponent<PlayerController>().hasRock){
            //Debug.Log("Doesn't have a Rock");
            Rock.gameObject.SetActive(true);
        }
        if(PlayerOne.GetComponent<PlayerController>().hasPaper){
            Paper.gameObject.SetActive(true);
        }
        if(PlayerOne.GetComponent<PlayerController>().hasScissors){
            Scissors.gameObject.SetActive(true);
        }
        PlayerOnefight(ghost);
    }

    public void TogglePlayerTwoFight(GameObject ghost) {
        gameObject.SetActive(!gameObject.activeSelf);
        if(gameObject.activeSelf){
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
        if(!PlayerTwo.GetComponent<Player2Controller>().hasRock){
            Rock.gameObject.SetActive(false);
        }
        if(!PlayerTwo.GetComponent<Player2Controller>().hasPaper){
            Paper.gameObject.SetActive(false);
        }
        if(!PlayerTwo.GetComponent<Player2Controller>().hasScissors){
            Scissors.gameObject.SetActive(false);
        }
        
        //below this resets it for when p1 uses a card that p2 also had
        if(PlayerTwo.GetComponent<Player2Controller>().hasRock){
            Rock.gameObject.SetActive(true);
        }
        if(PlayerTwo.GetComponent<Player2Controller>().hasPaper){
            Paper.gameObject.SetActive(true);
        }
        if(PlayerTwo.GetComponent<Player2Controller>().hasScissors){
            Scissors.gameObject.SetActive(true);
        }
        PlayerTwofight(ghost);
    }


    public void ToggleVisible() {


        gameObject.SetActive(!gameObject.activeSelf);
        if(gameObject.activeSelf){
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
        
    }

    /**
    * Rock = 1
    * Paper = 2
    * Scissors = 3
    * Generate ghost value and fight
    * If the ghost loses the player gets 2 ectoplasm
    * If the ghost wins the player loses 1 ectoplasm
    */
    private void PlayerOnefight(GameObject ghost) {
        
        Rock.GetComponent<Button>().onClick.AddListener(() => {
            PlayerOne.GetComponent<PlayerController>().hasRock = false;
            TogglePlayerOneFight(ghost);
            //ToggleVisible();
            if(GhostFight(rockValue)) {
                Destroy(ghost);
                //Debug.Log("Player Won");
            } else {
                //Debug.Log("Player Lost");
            }
        });
        Paper.GetComponent<Button>().onClick.AddListener(() => {
            PlayerOne.GetComponent<PlayerController>().hasPaper = false;
            TogglePlayerOneFight(ghost);
            if(GhostFight(paperValue)) {
                Destroy(ghost);
            }
        });
        Scissors.GetComponent<Button>().onClick.AddListener(() => {
            PlayerOne.GetComponent<PlayerController>().hasScissors = false;
            TogglePlayerOneFight(ghost);
            if(GhostFight(scissorsValue)) {
                Destroy(ghost);
            }
        });
    }

    private void PlayerTwofight(GameObject ghost) {
        Rock.GetComponent<Button>().onClick.AddListener(() => {
            PlayerTwo.GetComponent<Player2Controller>().hasRock = false;
            TogglePlayerTwoFight(ghost);
            if(GhostFight(rockValue)) {
                Destroy(ghost);
            }
        });
        Paper.GetComponent<Button>().onClick.AddListener(() => {
            PlayerTwo.GetComponent<Player2Controller>().hasPaper = false;
            TogglePlayerTwoFight(ghost);
            if(GhostFight(paperValue)) {
                Destroy(ghost);
            }
        });
        Scissors.GetComponent<Button>().onClick.AddListener(() => {
            PlayerTwo.GetComponent<Player2Controller>().hasScissors = false;
            TogglePlayerTwoFight(ghost);
            if(GhostFight(scissorsValue)) {
                Destroy(ghost);
            }
        });
    }

    private bool GhostFight(int playerChoice) {
        int ghostChoice = Random.Range(1,4);
        switch (playerChoice) {
            
            case 1: //Player picked rock
                if(ghostChoice == scissorsValue) return true; //ghost picked scissors so player wins
            break;
            case 2: //Player picked paper
                if(ghostChoice == rockValue) return true; //ghost picked rock so player wins
            break;
            case 3: //Player picked scissors
                if(ghostChoice == paperValue) return true; //ghost picked paper so player wins
            break;
        }
        //otherwise the player loses and the ghost wins
        return false;
    }
}
