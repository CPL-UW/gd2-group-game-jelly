using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopUp : MonoBehaviour {

    public static TextPopUp Create(Vector3 position, string text) {
        Transform textPopUpTransform = Instantiate(GameAssets.Instance.pfTextPopUp, position, Quaternion.identity);
        TextPopUp textPopUp = textPopUpTransform.GetComponent<TextPopUp>();
        textPopUp.Setup(text);

        return textPopUp;
    }

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;

    private void Awake() {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(string text) {
        textMesh.SetText(text);
        textColor = textMesh.color;
        disappearTimer = 2f;
    }

    private void Update() {
        float moveYSpeed = 2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0) {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0) Destroy(gameObject);
        }
    }
}
