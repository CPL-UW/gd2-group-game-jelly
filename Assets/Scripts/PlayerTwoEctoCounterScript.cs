using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTwoEctoCounterScript : MonoBehaviour {
    public static PlayerTwoEctoCounterScript Instance {get; private set;}
    
    private TextMeshProUGUI PlayerTwoEctoCounter;
    private int _ectoCounter = 2;
    private void Awake() {
        Instance = this;
        PlayerTwoEctoCounter = transform.Find("EctoCount").GetComponent<TextMeshProUGUI>();
    }
    private void Start() {
        PlayerTwoEctoCounter.SetText(_ectoCounter.ToString());
    }
    public void IncreasePlayerTwoEctoCount() {
        _ectoCounter++;
        PlayerTwoEctoCounter.SetText(_ectoCounter.ToString());
    }
    public void DecreasePlayerTwoEctoCount() {
        _ectoCounter--;
        PlayerTwoEctoCounter.SetText(_ectoCounter.ToString());
    }
}
