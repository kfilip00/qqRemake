using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [field: SerializeField] public OkDialog OkDialog { get; private set; }
    [field: SerializeField] public YesNoDialog YesNoDialog { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
