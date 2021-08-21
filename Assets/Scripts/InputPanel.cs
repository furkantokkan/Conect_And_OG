using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPanel : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static InputPanel instance;
    private void Awake()
    {
        instance = this;
    }
    public static bool isMouseMoving = false;
    Vector2 lastPosition = Vector2.zero;
    float currentX, currentY;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - lastPosition;
        currentX = direction.x / Screen.width;
        currentY = direction.y / Screen.height;
        lastPosition = eventData.position;
        PlayerController.instance.MoveControl(currentX);
        //Debug.Log("SURUKLEME YAPILIYOR!");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isMouseMoving = true;
        lastPosition = eventData.position;
        //Debug.Log("SURUKLEME BASLADI!");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isMouseMoving = false;
        currentX = 0;
        lastPosition = Vector2.zero;
        //Debug.Log("SURUKLEME BITTI!");
    }
}
