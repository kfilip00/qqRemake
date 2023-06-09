using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class UIPVPPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI searchingText;
    [SerializeField] private Button cancelButton;

    public void Setup()
    {
        ManageInteractables(true);
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        ManageInteractables(true);
        StartCoroutine(SearchingAnimation());

        cancelButton.onClick.AddListener(Cancel);
        PhotonManager.OnILeftRoom += Close;
        PhotonManager.OnOpponentJoinedRoom += OpponentJoined;
    }

    private void OnDisable()
    {
        cancelButton.onClick.RemoveListener(Cancel);

        PhotonManager.OnILeftRoom -= Close;
        PhotonManager.OnOpponentJoinedRoom -= OpponentJoined;
    }

    private void Cancel()
    {
        ManageInteractables(false);
        PhotonManager.Instance.LeaveRoom();
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }

    private void OpponentJoined()
    {
        ManageInteractables(false);
        SceneManager.LoadPVPGameplay();
    }

    private IEnumerator SearchingAnimation()
    {
        while (gameObject.activeSelf)
        {
            int _counter = 0;
            string _sentence = "Searching for opponent";
            while (_counter < 6)
            {
                if (_counter < 3)
                {
                    _sentence += ".";
                }
                else
                {
                    _sentence = _sentence.Remove(_sentence.Length - 1);
                }
                _counter++;
                searchingText.text = _sentence;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    private void ManageInteractables(bool _status)
    {
        cancelButton.interactable = _status;
    }
}
