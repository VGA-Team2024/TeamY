using UnityEngine;

public class CountGrandma : MonoBehaviour
{
    EventManager _eventManager;

    bool _isNeverGoodBye = true;

    private void Start()
    {
        _eventManager = EventManager.Instance;
    }
    public void GoodByeGrandma()
    {
        if(_isNeverGoodBye)
        {
            _eventManager._isAchievedBBAoodBye = true;
            _eventManager.AchievedBBAGoodBye();
            _isNeverGoodBye = false;
        }
        else
        {
            return;
        }
    }
}
