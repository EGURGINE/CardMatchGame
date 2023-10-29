using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gm = null;

    public int survivePercent = 50;
    public int survivedCatNum = 0;
    public int timeLeft = 60;
    public int stageNum = 0;
    public bool isTimerRunning = false;


    public StageResultScript stageResult;
    public GameResultScript gameResult;
    public List<Sprite> catSprites;
    public Sprite concealedCat;

    void Awake() {
        if(gm == null) {
            gm = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        timeLeft = 30;
        stageNum = 0;
        survivePercent = (int)RandPercent.thisPercent;
        isTimerRunning = false;
        startTimer();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void startTimer() {
        if (!isTimerRunning) {
            StartCoroutine(timerCoroutine());
        }
    }

    public IEnumerator timerCoroutine() {
        isTimerRunning = true;
        timeLeft = 60;
        for(int i = 0; i < 60; i++) {
            if (!isTimerRunning) {
                break;
            }
            timeLeft--;
            yield return new WaitForSeconds(1f);
        }

        isTimerRunning = false;



        if(timeLeft == 0) {
            gameResult.open(stageNum, false);
        }
    }

    public void stopTimer() {
        isTimerRunning = false;
    }

    public void setPercent(int diff) {
        survivePercent += diff;
    }

    public void setStageNum(int num) {
        stageNum = num;
        stopTimer();
    }

    public void openHomeScene() {
        gameResult.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void openNextStage() {
        isTimerRunning = false;
        stageNum++;
        timeLeft = 30;
        SceneManager.LoadScene(0);
    }
}
