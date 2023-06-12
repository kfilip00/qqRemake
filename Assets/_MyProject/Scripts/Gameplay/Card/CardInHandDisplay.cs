using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class CardInHandDisplay : MonoBehaviour
{
    CardObject cardObject;

    [SerializeField] TMP_FontAsset valueIncreasedFont;
    [SerializeField] TMP_FontAsset valueDecreasedFont;
    [SerializeField] TMP_FontAsset normalFont;

    [Space()]
    [SerializeField] TextMeshProUGUI manaDisplay;
    [SerializeField] TextMeshProUGUI powerDisplay;
    [SerializeField] Image qommonDisplay;
    [SerializeField] GameObject manaHolder;
    [SerializeField] GameObject powerHolder;
    [SerializeField] GameObject borderShadow;

    public void Setup(CardObject _cardObject)
    {
        cardObject = _cardObject;
        qommonDisplay.sprite = cardObject.Details.Sprite;
        manaDisplay.font = normalFont;
        powerDisplay.font = normalFont;

        cardObject.Stats.UpdatedMana += ShowMana;
        cardObject.Stats.UpdatedPower += ShowPower;
    }

    private void OnEnable()
    {
        GameplayManager.Instance.MyPlayer.UpdatedEnergy += ShowIfPlayerHasEnaughtEnergy;
        cardObject.Stats.UpdatedMana += ShowIfPlayerHasEnaughtEnergy;
    }

    private void OnDisable()
    {
        cardObject.Stats.UpdatedMana -= ShowMana;
        cardObject.Stats.UpdatedPower -= ShowPower;
        GameplayManager.Instance.MyPlayer.UpdatedEnergy -= ShowIfPlayerHasEnaughtEnergy;
        cardObject.Stats.UpdatedMana -= ShowIfPlayerHasEnaughtEnergy;
    }

    private void ShowIfPlayerHasEnaughtEnergy(ChangeStatus status)
    {
        ShowIfPlayerHasEnaughtEnergy();
    }

    public void Show()
    {
        ShowMana(ChangeStatus.Same);
        ShowPower(ChangeStatus.Same);
        ShowIfPlayerHasEnaughtEnergy();
        gameObject.SetActive(true);
    }

    void ShowIfPlayerHasEnaughtEnergy()
    {
        Color _color = qommonDisplay.color;
        if (GameplayManager.Instance.MyPlayer.Energy < cardObject.Stats.Energy)
        {
            _color.a = 0.3f;
            borderShadow.SetActive(false);
        }
        else
        {
            _color.a = 1f;
            borderShadow.SetActive(true);
        }

        qommonDisplay.color = _color;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void ShowMana(ChangeStatus _status)
    {
        manaDisplay.text = cardObject.Stats.Energy.ToString();
        switch (_status)
        {
            case ChangeStatus.Same:
                break;
            case ChangeStatus.Increased:
                manaDisplay.font = valueIncreasedFont;
                break;
            case ChangeStatus.Decreased:
                manaDisplay.font = valueDecreasedFont;
                break;
            default:
                throw new System.Exception("Don't know how to resolve state: " + _status);
        }
    }

    void ShowPower(ChangeStatus _status)
    {
        powerDisplay.text = cardObject.Stats.Power.ToString();
        switch (_status)
        {
            case ChangeStatus.Same:
                break;
            case ChangeStatus.Increased:
                powerDisplay.font = valueIncreasedFont;
                break;
            case ChangeStatus.Decreased:
                powerDisplay.font = valueDecreasedFont;
                break;
            default:
                throw new System.Exception("Don't know how to resolve state: " + _status);
        }
    }

    public void ShowDrawnAnimation()
    {
        manaHolder.SetActive(false);
        powerHolder.SetActive(false);

        transform.position = new Vector3(
            Screen.width + 1000,
            transform.position.y,
            transform.position.z
            );

        transform.DOLocalMove(Vector3.zero, 1f).OnComplete(() =>
         {
             manaHolder.SetActive(true);
             powerHolder.SetActive(true);
         });
    }
}
