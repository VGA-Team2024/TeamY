using UnityEngine;

public class CountGrandma : MonoBehaviour
{
    EventManager _eventManager;
    AchievementManager _achievementManager;

    bool _isNeverGoodBye = true;

    int _grandmaCount = 0;

    private void Start()
    {
        _eventManager = EventManager.Instance;
        _achievementManager = AchievementManager.Instance;
    }
    public void GoodByeGrandma()
    {
        if(_isNeverGoodBye)
        {
            _eventManager._isAchievedBBAoodBye = true;
            _eventManager.AchievedBBAGoodBye();
            _achievementManager.BabaAgbye();
            _isNeverGoodBye = false;
        }
        else
        {
            return;
        }
    }

    public void AddGrandmaCount()
    {
        _grandmaCount++;
        if(_grandmaCount == 100)
        {
            _achievementManager.Apocalypse();
            _eventManager._isAchevedApocalypse = true;
        }
    }
}
