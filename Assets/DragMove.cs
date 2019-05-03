using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ICanvasRaycastFilter
{
    private bool isDragging = false;

    /// <summary>
    /// IBeginDragHandlerのインターフェイス
    /// ドラック状態をonにする
    /// </summary>
    /// <param name="data">ドラッグ開始時に呼び出されるPointerEventData</param>
    public void OnBeginDrag(PointerEventData data)
    {
        isDragging = true;
    }

    /// <summary>
    /// IDragHandlerのインターフェイス
    /// PointerEventDataの移動差分をDragPanelのtransformに反映する
    /// </summary>
    /// <param name="data">ドラッグ中に呼び出されるPointerEventData</param>
    public void OnDrag(PointerEventData data)
    {
        transform.position += new Vector3(data.delta.x, data.delta.y);
    }

    /// <summary>
    /// IEndDragHandlerのインターフェイス
    /// ドラッグ状態をoffにする
    /// </summary>
    /// <param name="data">ドラッグが終了したときに呼び出されるPointerEventData</param>
    public void OnEndDrag(PointerEventData data)
    {
        isDragging = false;
    }

    /// <summary>
    /// ICanvasRaycastFilterのインターフェイス
    /// 移動中はRaycastを効かなくすることで、他のイベントを起こさせないようにする
    /// </summary>
    /// <param name="sp"></param>
    /// <param name="cam"></param>
    /// <returns></returns>
    public bool IsRaycastLocationValid(Vector2 sp, Camera cam)
    {
        return !isDragging;
    }
}
