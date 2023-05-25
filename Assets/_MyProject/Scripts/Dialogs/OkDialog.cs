using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class OkDialog : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnOkPressed;
    [SerializeField] TextMeshProUGUI messageDisplay;
    [SerializeField] Button okButton;

    public void Setup(string _message)
    {
        messageDisplay.text = _message;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        okButton.onClick.AddListener(OkPressed);
    }

    private void OnDisable()
    {
        okButton.onClick.RemoveListener(OkPressed);
    }

    void OkPressed()
    {
        OnOkPressed?.Invoke();
        Close();
    }

    void Close()
    {
        OnOkPressed.RemoveAllListeners();
        gameObject.SetActive(false);
    }

}