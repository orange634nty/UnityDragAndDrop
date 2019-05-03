using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isDroped;

    /// <summary>
    /// ドラッグ開始したときに呼び出して、パネルの色を変える
    /// DragPanelのEventTriggerコンポーネントの
    /// BeginDragイベントで呼び出すように設定
    /// </summary>
    /// <param name="data">PointerEventData</param>
    public void OnBeginDrag(BaseEventData data)
    {
        Image image = ((PointerEventData)data).pointerDrag.GetComponent<Image>();
        // ドラッグ中は半透明マゼンダ色
        image.color = new Color(1.0f, 0.0f, 1.0f, 0.5f);
        isDroped = false;
    }

    /// <summary>
    /// ドラッグした後の判定
    /// SafeAreaのEventTriggerコンポーネントの
    /// OnDropイベント時に呼び出すように設定
    /// </summary>
    /// <param name="data">PointerEventData</param>
    public void OnDrop(BaseEventData data)
    {
        isDroped = true;
    }

    /// <summary>
    /// ドラッグ終了したときに呼び出して状況に応じてパネルの色を変更
    /// DragPanelのEventTriggerコンポーネントの
    /// EndDragイベントで呼び出すように設定
    /// </summary>
    /// <param name="data">PointerEventData</param>
    public void OnEndDrag(BaseEventData data)
    {
        Image image = ((PointerEventData)data).pointerDrag.GetComponent<Image>();
        if (isDroped)
        {
            // 緑ゾーンに降りたらマゼンダ色になる
            image.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
        }
        else
        {
            // 通常状態
            image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        isDroped = false;
    }
}
