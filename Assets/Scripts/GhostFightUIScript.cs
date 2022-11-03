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
        PlayerOnefight();
    }

    public void TogglePlayerTwoFight() {
        gameObject.SetActive(!gameObject.activeSelf);
        if(gameObject.activeSelf){
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
        if(!PlayerTwo.GetComponent<PlayerController>().hasRock){
            Rock.gameObject.SetActive(false);
        }
        if(!PlayerTwo.GetComponent<PlayerController>().hasPaper){
            Paper.gameObject.SetActive(false);
        }
        if(!PlayerTwo.GetComponent<PlayerController>().hasScissors){
            Scissors.gameObject.SetActive(false);
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
            TogglePlayerOneFight();
        });
        Paper.GetComponent<Button>().onClick.AddListener(() => {
            TogglePlayerOneFight();
        });
        Scissors.GetComponent<Button>().onClick.AddListener(() => {
            TogglePlayerOneFight();
        });
    }

    private void PlayerTwofight() {
        Rock.GetComponent<Button>().onClick.AddListener(() => {
            TogglePlayerTwoFight();
        });
        Paper.GetComponent<Button>().onClick.AddListener(() => {
            TogglePlayerTwoFight();
        });
        Scissors.GetComponent<Button>().onClick.AddListener(() => {
            TogglePlayerTwoFight();
        });
    }
}
