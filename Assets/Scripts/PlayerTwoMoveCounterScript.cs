using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTwoMoveCounterScript : MonoBehaviour {
    public static PlayerTwoMoveCounterScript Instance {get; private set;}
    private TextMeshProUGUI MoveCounterText;
    [SerializeField] private GameObject PlayerTwo;

    private void Awake() {
        Instance = this;
        MoveCounterText = transform.Find("MovesLeftText").GetComponent<TextMeshProUGUI>();
    }
    private void Start() {
        MoveCounterText.SetText("Moves Left: " + (PlayerTwo.GetComponent<Player2Controller>().tilesMovedMax - 
                                PlayerTwo.GetComponent<Player2Controller>().tilesMoved));
    }
    private void Update() {
        MoveCounterText.SetText("Moves Left: " + (PlayerTwo.GetComponent<Player2Controller>().tilesMovedMax - 
                                PlayerTwo.GetComponent<Player2Controller>().tilesMoved));
    }
}
