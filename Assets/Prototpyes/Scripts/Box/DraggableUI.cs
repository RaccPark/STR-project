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
        // previousParent를 부모의 transform으로 설정
        previousParent = transform.parent;

        previousPos = transform.position;

        // 부모를 canvas로 설정
        transform.SetParent(canvas);
        // 오브젝트를 앞으로 보이게 설정(늦게 출력)
        transform.SetAsLastSibling();

        // 해당 오브젝트의 알파값 조절
        canvasGroup.alpha = 0.6f;
        // Blocks Raycasts 옵션은 마우스 클릭시 보이지 않는 Ray가 발사되는데 이 Ray에 충돌을 일으킬 것인지 제어하는 옵션
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 해당 오브젝트의 위치를 eventData 즉 현재 드래그 되고있는 위치로 바꾼다?
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == canvas) // 부모의 transform이 canvas와 같다면(즉, 드랍을 받아 줄 오브젝트가 없을 경우)
        {
            // 해당 오브젝트의 부모를 previousParent로 설정
            transform.SetParent(previousParent);
            // 해당 오브젝트의 rectPosition을 previouseParent의 rectPosition으로 설정
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
