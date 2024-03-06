using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoldenCookie : MonoBehaviour, IPointerClickHandler
{
    /// <summary>ゲーム管理クラス</summary>
    GameManager _gameManager;
    EventManager _eventManager = null;
    AchievementManager _achievementManager = null;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _eventManager = EventManager.Instance;
        _achievementManager = AchievementManager.Instance;
        // 時間が経過したら破壊される
        DestroyByTime();
    }
    public IEnumerator DestroyByTime()
    {
        yield return new WaitForSecondsRealtime(13f);
        Destroy(gameObject);
    }
    /// <summary>クリック時の処理</summary>
    void OnClick()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}
