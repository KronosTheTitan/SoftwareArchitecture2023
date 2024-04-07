using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string header;
    [SerializeField,TextArea] private string contents;

    private bool exited = true;
    
    public string GetHeader()
    {
        return header;
    }

    public string GetContents()
    {
        return contents;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        exited = false;

        Invoke(nameof(DelayedShow), 0.5f);
    }

    private void DelayedShow()
    {
        if(exited)
            return;
        
        EventBus<ShowToolTip>.Publish(new ShowToolTip(this));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        exited = true;
        EventBus<HideToolTip>.Publish(new HideToolTip());
    }
}
