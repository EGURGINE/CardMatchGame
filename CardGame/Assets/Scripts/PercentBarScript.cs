using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PercentBarScript : MonoBehaviour {
    public Text text;

    // Start is called before the first frame update
    void Start() {
        text = gameObject.GetComponent<Text>();
    }
    // Update is called once per frame
    void Update() {
        text.text = "»ýÁ¸ È®·ü: " + RandPercent.thisPercent + "%";
    }


    public void increasePercent() {
        GameManager.gm.setPercent(10);
    }
    public void decreasePercent() {
        GameManager.gm.setPercent(-10);
    }
}
