using UnityEngine;
using TMPro;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameDisplay;
    [SerializeField] private GameObject[] glows;

    public void SetName(string _name)
    {
        nameDisplay.text = _name;
    }

    public void RemoveGlow()
    {
        foreach (var _glow in glows)
        {
            if (_glow.activeSelf)
            {
                _glow.SetActive(false);
                //return;
            }
        }
    }
}
