using System.Collections;
using System.Resources;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoldenCookie : MonoBehaviour, IPointerClickHandler
{
    ResourceManager _resourceManager = null;
    EventManager _eventManager = null;
    AchievementManager _achievementManager = null;

    private void Start()
    {
        _resourceManager = ResourceManager.Instance;
        _eventManager = EventManager.Instance;
        _achievementManager = AchievementManager.Instance;
        DestroySelf();
    }
    public IEnumerator DestroySelf()
    {
        yield return new WaitForSecondsRealtime(13f);
        Destroy(gameObject);
    }
    /// <summary>ƒNƒŠƒbƒN‚Ìˆ—</summary>
    void OnClick()
    {
        if (_eventManager._isAchievedLucky == false)
        {
            _eventManager._isAchievedLucky = true;
            _achievementManager.Lucky();
        }
        _resourceManager._isFever = true;
        gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}
