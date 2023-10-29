using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageResultScript : MonoBehaviour
{
    public Text time, percent;
    public Image savedCat;
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

        foreach (Image image in gameObject.GetComponentsInChildren<Image>()) {
            if (image.gameObject.name.Equals("SavedCat")) {
                savedCat = image;
                break;
            }
        }

        gameObject.SetActive(false);

        
    }

    void Update() {
    }

    public void open() {
        time.text = "걸린 시간: " + (60 - GameManager.gm.timeLeft)+"초";
        percent.text = "생존 확률: " + GameManager.gm.survivePercent +"%";
        savedCat.sprite = GameManager.gm.catSprites[GameManager.gm.stageNum - 1];
        gameObject.SetActive(true);
    }


    public void openNextStage() {
        GameManager.gm.openNextStage();
    }
}
