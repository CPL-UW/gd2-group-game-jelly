using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostFightUIScript : MonoBehaviour {

    //singleton
    public static GhostFightUIScript Instance {get; private set;}
    
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

    public void TogglePlayerOneFight() {
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
        PlayerOnefight();
    }

    public void TogglePlayerTwoFight() {
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
        PlayerTwofight();
    }


    // public void ToggleVisible() {


    //     gameObject.SetActive(!gameObject.activeSelf);
    //     if(gameObject.activeSelf){
    //         Time.timeScale = 0f;
    //     } else {
    //         Time.timeScale = 1f;
    //     }
    //     fight();
    // }

    private void PlayerOnefight() {
        Rock.GetComponent<Button>().onClick.AddListener(() => {
            PlayerOne.GetComponent<PlayerController>().hasRock = false;
            TogglePlayerOneFight();
        });
        Paper.GetComponent<Button>().onClick.AddListener(() => {
            PlayerOne.GetComponent<PlayerController>().hasPaper = false;
            TogglePlayerOneFight();
        });
        Scissors.GetComponent<Button>().onClick.AddListener(() => {
            PlayerOne.GetComponent<PlayerController>().hasScissors = false;
            TogglePlayerOneFight();
        });
    }

    private void PlayerTwofight() {
        Rock.GetComponent<Button>().onClick.AddListener(() => {
            PlayerTwo.GetComponent<Player2Controller>().hasRock = false;
            TogglePlayerTwoFight();
        });
        Paper.GetComponent<Button>().onClick.AddListener(() => {
            PlayerTwo.GetComponent<Player2Controller>().hasPaper = false;
            TogglePlayerTwoFight();
        });
        Scissors.GetComponent<Button>().onClick.AddListener(() => {
            PlayerTwo.GetComponent<Player2Controller>().hasScissors = false;
            TogglePlayerTwoFight();
        });
    }
}
