using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour {
    public Text text;

    // Start is called before the first frame update
    void Start() {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "남은 시간: " +  GameManager.gm.timeLeft + "초";
    }

    public void startTimer() {
        GameManager.gm.startTimer();
    }
}
