using System.Collections;
using System.Resources;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoldenCookie : MonoBehaviour, IPointerClickHandler
{
    GameManager _gameManager = null;
    EventManager _eventManager = null;
    AchievementManager _achievementManager = null;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _eventManager = EventManager.Instance;
        _achievementManager = AchievementManager.Instance;
        DestroySelf();
    }
    public IEnumerator DestroySelf()
    {
        yield return new WaitForSecondsRealtime(13f);
        Destroy(gameObject);
    }
    /// <summary>�N���b�N���̏���</summary>
    void OnClick()
    {
        if (_eventManager._isAchievedLucky == false)
        {
            _eventManager._isAchievedLucky = true;
            _achievementManager.Lucky();
        }
        //_gameManager._isFever = true;
        gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}
