using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DroppableUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private Image image;
    private RectTransform rect;
    private Color tempColor;

    [SerializeField] private bool dropObjPosRandom = false;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        tempColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.grey;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            // 오브젝트를 drop하였을 때 위치를 droppable UI 안 랜덤으로 설정할 것인지
            //if (!dropObjPosRandom) { eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position; }
            //else
            //{
            //    // Get the rect transform of the dropped object
            //    RectTransform droppedObjectRect = eventData.pointerDrag.GetComponent<RectTransform>();

            //    // Calculate the random position within the droppable object's bounds
            //    float xPos = Random.Range(rect.rect.min.x, rect.rect.max.x - droppedObjectRect.rect.width);
            //    float yPos = Random.Range(rect.rect.min.y, rect.rect.max.y - droppedObjectRect.rect.height);

            //    // Set the position of the dropped object to the random position
            //    droppedObjectRect.anchoredPosition = new Vector2(xPos, yPos);
            //}
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = tempColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
