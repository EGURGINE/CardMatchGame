using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardMatchManager : MonoBehaviour
{
    public static CardMatchManager Instance;


    public int xNum, yNum;
    public float xSpacing, ySpacing;
    private int cardMaxType;
    [SerializeField] private Card card;

    private List<Card> cardChecker = new List<Card> ();
    private List<int> cardTypeGacha = new List<int> ();
    private List<bool> gameClearChecker = new List<bool> ();

    [SerializeField] private GameObject roulettePanel;

    //싱글톤
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
    }
    private void Start()
    {

        if (GameManager.gm.stageNum == 1) {
            RandPercent.thisPercent = 50f;
        }
        GameManager.gm.startTimer();

        //최대 카드 타입 수
        cardMaxType = (xNum * yNum) / 2;

        //랜덤 카드 타입 셋팅
        for (int i = 0; i < cardMaxType; i++)
        {
            cardTypeGacha.Add(i);
            cardTypeGacha.Add(i);
            gameClearChecker.Add(false);
        }


        //시작하면 카드생성
        CreateCards();
    }



    //카드 맞췄는지 체크
    public void CardCheck(Card cardType)
    {
        if (cardChecker.Count > 0 && cardChecker[0] == cardType) return;


        cardChecker.Add(cardType);

        if(cardChecker.Count == 2)
        {
            bool isRight = (cardChecker[0].cardType == cardChecker[1].cardType);

            RandPercent.AddPercent(isRight);

            foreach (var item in cardChecker)
            {
                item.IsRight(isRight);
            }

            // 게임 클리어 했는지 체크
            GameClearCheck(cardChecker[0].cardType, isRight);

            cardChecker.Clear();
        }

    }

    //게임 클리어 했는지 체크
    private void GameClearCheck(int cardType, bool isClear)
    {

        bool gameClear = true;

        gameClearChecker[cardType] = isClear;

        foreach (var card in gameClearChecker)
        {
            if (card == false) gameClear = card;
        }

        if (gameClear) roulettePanel.SetActive(gameClear);
    }

    //카드 생성
    private void CreateCards()
    {
        Vector3 cardPos = Vector3.zero;

        for (int j = 0; j < yNum; j++)
        {
            for (int i = 0; i < xNum; i++)
            {
                cardPos += new Vector3(xSpacing, 0);

                Card isCard = Instantiate(card,transform);
                isCard.transform.position = cardPos;

                int ranGachaNum = Random.Range(0, cardTypeGacha.Count);


                isCard.CardSet(cardTypeGacha[ranGachaNum]);

                cardTypeGacha.RemoveAt(ranGachaNum);
            }

            cardPos = new Vector2(0, cardPos.y + ySpacing);

        }


        //가운데로 정렬

        transform.position = new Vector3(-xNum - 1, -yNum - 0.2f, 0);

    }

}
