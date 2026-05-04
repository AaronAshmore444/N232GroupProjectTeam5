using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickableImage : MonoBehaviour, IPointerClickHandler
{

    public UnityEvent OnClick;

    // This method is called automatically when the image is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke();
    }
}
