using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerOneMoveCounterScript : MonoBehaviour {
   
    public static PlayerOneMoveCounterScript Instance {get; private set;}
    private TextMeshProUGUI MoveCounterText;
    [SerializeField] private GameObject PlayerOne;

    private void Awake() {
        Instance = this;
        MoveCounterText = transform.Find("MovesLeftText").GetComponent<TextMeshProUGUI>();
    }
    private void Start() {
        MoveCounterText.SetText("Moves Left: " + (PlayerOne.GetComponent<PlayerController>().tilesMovedMax - 
                                PlayerOne.GetComponent<PlayerController>().tilesMoved));
    }
    private void Update() {
        MoveCounterText.SetText("Moves Left: " + (PlayerOne.GetComponent<PlayerController>().tilesMovedMax - 
                                PlayerOne.GetComponent<PlayerController>().tilesMoved));
    }

}
