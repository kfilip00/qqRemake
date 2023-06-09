using System;
using System.Collections;
using UnityEngine;

public class CardReveal : MonoBehaviour
{
    public static Action<CardObject> ShowRevealCard;
    [SerializeField] private GameObject shadowObject;
    [SerializeField] private GameObject revealObject;
    private CardObject cardObject;

    public bool IsRevealing => shadowObject.activeSelf||revealObject.activeSelf;

    public void Setup(CardObject _cardObject)
    {
        cardObject = _cardObject;
    }


    public void PrepareForReveal()
    {
        shadowObject.SetActive(true);
    }

    public void CancelReveal()
    {
        shadowObject.SetActive(false);
    }

    public IEnumerator Reveal()
    {
        cardObject.CanChangePlace = false;
        CancelReveal();
        revealObject.SetActive(true);
        yield return new WaitForSeconds(1f);//duration of reveal animation
        revealObject.SetActive(false);
        cardObject.Display.ShowCardOnTable();
        ShowRevealCard?.Invoke(cardObject);
        yield return new WaitForSeconds(2.5f);//duration of showing reveal card
    }
}
