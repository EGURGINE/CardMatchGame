using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class Card : MonoBehaviour, IPointerClickHandler
{
    public int cardType;

    public bool isClear;
    public void CardSet(int type)
    {
        cardType = type;
    }

    //클릭했을때 인터페이스
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isClear) return;

        StartCoroutine(ClickEvent());
    }

    IEnumerator ClickEvent()
    {
        CardRotate(true);
        yield return new WaitForSeconds(0.5f);
        CardMatchManager.Instance.CardCheck(this);
    }

    //카드 회전
    private void CardRotate(bool isBack)
    {
        float rotY = (isBack) ? 180 : 0;


        transform.DORotate(new Vector3(0, rotY, 0), 0.5f);
    }

    public void IsRight(bool isRight)
    {
        isClear = isRight;

        if (isRight)
        {
            //맞춘 연출
        }
        else
        {
            CardRotate(false);
        }
    }
   
}
