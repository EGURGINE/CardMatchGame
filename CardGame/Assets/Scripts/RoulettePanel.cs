using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RoulettePanel : MonoBehaviour
{

    [SerializeField] GameObject SURVIVAL_Txt;
    [SerializeField] GameObject DIE_Txt;
    [SerializeField] GameObject SURVIVAL;
    [SerializeField] GameObject DIE;
    [SerializeField] GameObject questionMark;
    [SerializeField] Transform textPos;
    [SerializeField] float posY;

    public bool clear;

    private void OnEnable()
    {
        StartCoroutine(StopTimer());
    }

    IEnumerator Event()
    {
                GameManager.gm.stopTimer();
        yield return new WaitForSeconds(0.5f);
        questionMark.transform.DOMoveY(25, 1f);
        yield return new WaitForSeconds(1f);
        SURVIVAL_Txt.transform.DOMoveY(posY, 0.125f).SetLoops(11,LoopType.Restart);
        yield return new WaitForSeconds(0.0625f);
        DIE_Txt.transform.DOMoveY(posY, 0.125f).SetLoops(11, LoopType.Restart).OnComplete(() =>
        {
            clear = RandPercent.GetResult();
            //clear = false;
            Debug.Log(clear);
            if (clear)
            {
                SURVIVAL.transform.DOMove(textPos.position, 1f);
                
            }
            else
            {
                DIE.transform.DOMove(textPos.position , 1f);
            }
        });
    }

    IEnumerator StopTimer() {
        yield return StartCoroutine(Event());
        yield return new WaitForSeconds(5f);
        Debug.Log(clear);
        if (clear) {
            GameManager.gm.stageResult.open();
        } else {
            GameManager.gm.gameResult.open(GameManager.gm.stageNum, clear);
            GameManager.gm.stageNum = 1;
        }
    }
}
