using UnityEngine.Events;
using UnityEngine.UI;

public static class ButtonExtension
{
    public static void Subscribe(this Button button, UnityAction call)
    {
        button.onClick.AddListener(call);
    }
}
