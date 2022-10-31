using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostFightUIScript : MonoBehaviour {

    //singleton
    public static GhostFightUIScript Instance {get; private set;}
    
    private Transform Image;
    private Transform btnTransform;

    private void Awake() {
        Instance = this;
        gameObject.SetActive(false); //initially hide if not hidden
        Image = transform.Find("Image");
        btnTransform = transform.Find("Button");
    }

    public void ToggleVisible() {
        gameObject.SetActive(!gameObject.activeSelf);
        if(gameObject.activeSelf){
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
        fight();
    }

    private void fight() {
        btnTransform.GetComponent<Button>().onClick.AddListener(() => {
            ToggleVisible();
        });
    }
}
