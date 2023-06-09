using Photon.Pun.Demo.PunBasics;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FlagClickHandler : MonoBehaviour
{
    public static Action OnForefiet;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(Forfiet);
        GameplayManager.GameEnded += Disable;
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(Forfiet);
        GameplayManager.GameEnded -= Disable;
    }

    private void Disable(GameResult _result)
    {
        button.interactable = false;
    }

    private void Forfiet()
    {
        GameplayUI.Instance.YesNoDialog.Setup("Are you sure you\nwant to escape?", "No","Yes",GameplayYesNo.FONT_RED);
        GameplayUI.Instance.YesNoDialog.OnRightButtonPressed.AddListener(YesForefiet);
    }

    private void YesForefiet()
    {
        OnForefiet?.Invoke();
    }
}
