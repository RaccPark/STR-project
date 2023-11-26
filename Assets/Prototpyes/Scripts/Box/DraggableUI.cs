using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Transform canvas;
    private Transform previousParent;
    private Vector2 previousPos;

    private RectTransform rect;
    private CanvasGroup canvasGroup; 

    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // previousParent�� �θ��� transform���� ����
        previousParent = transform.parent;

        previousPos = transform.position;

        // �θ� canvas�� ����
        transform.SetParent(canvas);
        // ������Ʈ�� ������ ���̰� ����(�ʰ� ���)
        transform.SetAsLastSibling();

        // �ش� ������Ʈ�� ���İ� ����
        canvasGroup.alpha = 0.6f;
        // Blocks Raycasts �ɼ��� ���콺 Ŭ���� ������ �ʴ� Ray�� �߻�Ǵµ� �� Ray�� �浹�� ����ų ������ �����ϴ� �ɼ�
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �ش� ������Ʈ�� ��ġ�� eventData �� ���� �巡�� �ǰ��ִ� ��ġ�� �ٲ۴�?
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == canvas) // �θ��� transform�� canvas�� ���ٸ�(��, ����� �޾� �� ������Ʈ�� ���� ���)
        {
            // �ش� ������Ʈ�� �θ� previousParent�� ����
            transform.SetParent(previousParent);
            // �ش� ������Ʈ�� rectPosition�� previouseParent�� rectPosition���� ����
            // rect.position = previousParent.GetComponent<RectTransform>().position;

            rect.position = previousPos;
        }
        
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
