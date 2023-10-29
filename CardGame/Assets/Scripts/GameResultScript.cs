using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG;

public class GameResultScript : MonoBehaviour {
    public Text text;
    public List<Image> cats;


    // Start is called before the first frame update
    void Start() {
        GameManager.gm.gameResult = this;
        cats = new List<Image>();
        foreach (Image cat in gameObject.GetComponentsInChildren<Image>()) {
            if (cat.gameObject.tag.Equals("catResult")) {
                cats.Add(cat);
            }
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }

    public void open(int clearedStages) {
        if (clearedStages == 10) {
            text.text = "Game Clear!";
        } else {
            text.text = "Game Over!";
        }

        for (int i = 0; i < clearedStages; i++) {
            cats[i].color = Color.blue;
            //cats[i].sprite = GameManager.gm.catSprites[i];
        }
        for (int i = clearedStages; i < 10; i++) {
            //cats[i].color = Color.red;
            cats[i].sprite = GameManager.gm.concealedCat;
        }

        gameObject.SetActive(true);
    }

    public void openHomeScene() {
        GameManager.gm.openHomeScene();
    }
}
