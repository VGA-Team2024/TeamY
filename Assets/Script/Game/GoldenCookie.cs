using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoldenCookie : MonoBehaviour, IPointerClickHandler
{
    /// <summary>�Q�[���Ǘ��N���X</summary>
    GameManager _gameManager;
    EventManager _eventManager = null;
    AchievementManager _achievementManager = null;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _eventManager = EventManager.Instance;
        _achievementManager = AchievementManager.Instance;
        // ���Ԃ��o�߂�����j�󂳂��
        DestroyByTime();
    }
    public IEnumerator DestroyByTime()
    {
        yield return new WaitForSecondsRealtime(13f);
        Destroy(gameObject);
    }
    /// <summary>�N���b�N���̏���</summary>
    void OnClick()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}
