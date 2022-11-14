using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerOneEctoCounterScript : MonoBehaviour {

    public static PlayerOneEctoCounterScript Instance {get; private set;}
    
    private TextMeshProUGUI PlayerOneEctoCounter;
    private int _ectoCounter = 2;
    private void Awake() {
        Instance = this;
        PlayerOneEctoCounter = transform.Find("EctoCount").GetComponent<TextMeshProUGUI>();
    }
    private void Start() {
        PlayerOneEctoCounter.SetText(_ectoCounter.ToString());
    }
    public void IncreasePlayerOneEctoCount() {
        _ectoCounter++;
        PlayerOneEctoCounter.SetText(_ectoCounter.ToString());
    }
    public void DecreasePlayerOneEctoCount() {
        _ectoCounter--;
        PlayerOneEctoCounter.SetText(_ectoCounter.ToString());
    }

}
