using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] CardInHandDisplay cardInHandDisplay;
    [SerializeField] CardOnTableDisplay cardOnTableMyDisplay;
    [SerializeField] CardOnTableDisplay cardOnTableOpponentDisplay;

    CardOnTableDisplay cardOnTableHandler;

    public void Setup(CardObject _cardObject)
    {
        cardOnTableHandler = _cardObject.IsMy ? cardOnTableMyDisplay : cardOnTableOpponentDisplay;
        cardInHandDisplay.Setup(_cardObject);
        cardOnTableHandler.Setup(_cardObject);
    }

    public void ShowDrawnAnimation()
    {
        ShowCardInHand();
        cardInHandDisplay.ShowDrawnAnimation();
    }

    public void ShowCardInHand()
    {
        cardInHandDisplay.Show();
        cardOnTableHandler.Hide();
    }

    public void ShowCardOnTable()
    {
        cardOnTableHandler.Show();
        cardInHandDisplay.Hide();
    }

    public void Hide()
    {
        cardOnTableHandler.Hide();
        cardInHandDisplay.Hide();
    }

    public void HideCardOnTable()
    {
        cardOnTableHandler.Hide();
    }
}