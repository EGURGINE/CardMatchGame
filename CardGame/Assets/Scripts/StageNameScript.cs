using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageNameScript : MonoBehaviour {
    public Text text;

    // Start is called before the first frame update
    void Start() {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        text.text = "스테이지" + GameManager.gm.stageNum;
    }
}
