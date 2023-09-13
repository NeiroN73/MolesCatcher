using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected void Show()
    {
        gameObject.SetActive(true);
    }

    protected void Hide()
    {
        gameObject.SetActive(false);
    }
}
