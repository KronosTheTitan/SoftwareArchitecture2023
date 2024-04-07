using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI headerField;
    [SerializeField] private TextMeshProUGUI contentField;
    [SerializeField] private LayoutElement layoutElement;

    [SerializeField] private int characterWrapLimit;

    [SerializeField] private RectTransform rectTransform;

    private void Start()
    {
        EventBus<ShowToolTip>.OnEvent += Show;
        EventBus<HideToolTip>.OnEvent += Hide;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = headerLength > characterWrapLimit || contentLength > characterWrapLimit;

        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
    }

    private void Show(ShowToolTip showToolTip)
    {
        headerField.text = showToolTip.trigger.GetHeader();
        contentField.text = showToolTip.trigger.GetContents();
        gameObject.SetActive(true);
    }

    private void Hide(HideToolTip hideToolTip)
    {
        gameObject.SetActive(false);
    }
}
