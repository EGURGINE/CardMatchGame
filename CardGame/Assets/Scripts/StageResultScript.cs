using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageResultScript : MonoBehaviour
{
    public Text time, percent;

    void Start() {
        GameManager.gm.stageResult = this;
        foreach (Text text in gameObject.GetComponentsInChildren<Text>()){
            if (text.gameObject.name.Equals("Time")){
                time = text;
            }
            else if (text.gameObject.name.Equals("Percent")){
                percent = text;
            }
        }
        gameObject.SetActive(false);
    }

    void Update() {
    }

    public void open() {
        time.text = "걸린 시간: " + (60 - GameManager.gm.timeLeft)+"초";
        percent.text = "생존 확률: " + GameManager.gm.survivePercent +"%";
        gameObject.SetActive(true);
    }


    public void openNextStage() {
        GameManager.gm.openNextStage();
    }
}
