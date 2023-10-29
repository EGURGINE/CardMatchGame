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

    //�̱���
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

        //�ִ� ī�� Ÿ�� ��
        cardMaxType = (xNum * yNum) / 2;

        //���� ī�� Ÿ�� ����
        for (int i = 0; i < cardMaxType; i++)
        {
            cardTypeGacha.Add(i);
            cardTypeGacha.Add(i);
            gameClearChecker.Add(false);
        }


        //�����ϸ� ī�����
        CreateCards();
    }



    //ī�� ������� üũ
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

            // ���� Ŭ���� �ߴ��� üũ
            GameClearCheck(cardChecker[0].cardType, isRight);

            cardChecker.Clear();
        }

    }

    //���� Ŭ���� �ߴ��� üũ
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

    //ī�� ����
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


        //����� ����

        transform.position = new Vector3(-xNum - 1, -yNum - 0.2f, 0);

    }

}
