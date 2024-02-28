using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; set; }
    AchievementManager _achievementManager = null;

    [Header("ストーリー")]
    [SerializeField] GameObject[] _storyPrefabs;

    [Header("ゲーム統括UI")]
    [SerializeField] GameObject[] _gameUI;

    [Header("ストーリー進行ボタン")]
    [SerializeField] GameObject[] _storyButton;

    /// <summary>実績</summary>
    public bool _isAchievedBBAoodBye = false;
    public bool _isAchievedApocalypse = false;
    public bool _isAchievedLucky = false;
    // 転生フラグ
    public bool _isAchievedRelife = false;
    public bool _isObtainAllGrandmaUpgrade = false;
    public bool _isObtainAllRingUpgrade = false;
    public bool _isObtainAllSwordUpgrade = false;

    /// <summary>ストーリー</summary>
    public bool _isPlayedStory1 = false;
    public bool _isPlayedStory2 = false;
    public bool _isPlayedStory3 = false;
    public bool _isPlayedStory4_1 = false;
    public bool _isPlayedStory4_2 = false;
    public bool _isPlayedStory4_3 = false;
    public bool _isPlayedAllStory = false;

    float _goldenCookieInterval = 0f;
    float _timer = 0f;  
    [SerializeField] GameObject _goldenCookie;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _achievementManager = AchievementManager.Instance;
        CalGoldenCookieTime();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= _goldenCookieInterval)
        {
            _timer = 0f;
            _goldenCookie.SetActive(true);
            _goldenCookie.transform.localPosition = new Vector2(CalGoldenCookiePosX(), CalGoldenCookiePosY());
            CalGoldenCookieTime();
        }

        CheckStory2();
        CheckAllStoryPlayed();
        CheckStory1Choice();
        CheckStory2Choice();
        CheckStory3Choice();
        CheckStory4Choice();
    }

    public void EnableStoryButton(int storyNum)
    {
        for(int i = storyNum - 1; i >= 0; i--)
        {
            _storyButton[i].SetActive(false);
        }
        _storyButton[storyNum].SetActive(true);
    }

    public void CallStory(int storyNum)
    {
        foreach(var UI in _gameUI)
        {
            UI.SetActive(false);
        }
        _storyPrefabs[storyNum].SetActive(true);
    }

    public void ActivateGameUI()
    {
        foreach (var UI in _gameUI)
        {
            UI.SetActive(true);
        }
    }

    public void AchievedBBAGoodBye()
    {
        Debug.Log("BBA Good Bye");
    }

    void CalGoldenCookieTime()
    {
        float interval = Random.Range(300f, 900f);
        _goldenCookieInterval = interval;
    }

    float CalGoldenCookiePosX()
    {
        return Random.Range(-750f, 750f);
    }

    float CalGoldenCookiePosY()
    {
        return Random.Range(-350f, 350f);
    }
    
    void CheckStory2()
    {
        if(_isObtainAllGrandmaUpgrade && _isAchievedApocalypse && _isAchievedBBAoodBye && !_isPlayedStory2)
        {
            _isPlayedStory2 = true;
            EnableStoryButton(1);
        }
    }

    void CheckAllStoryPlayed()
    {
        if(_isPlayedStory1 && _isPlayedStory2 && _isPlayedStory3 && _isPlayedStory4_1 && _isPlayedStory4_2 && _isPlayedStory4_3 && !_isPlayedAllStory)
        {
            _isPlayedAllStory = true;
            _achievementManager.AllChestnuts();
        }
    }

    void CheckStory1Choice()
    {
        if(_isAchievedApocalypse && _isAchievedRelife)
        {
            _storyPrefabs[0].GetComponent<StoryController>()._flugs[1] = true;
        }
    }

    void CheckStory2Choice()
    {
        if(_isAchievedRelife && _isPlayedStory2)
        {
            _storyPrefabs[1].GetComponent<StoryController>()._flugs[2] = true;
        }
    }

    void CheckStory3Choice()
    {
        if(_isPlayedStory3)
        {
            _storyPrefabs[2].GetComponent<StoryController>()._flugs[1] = true;
        }
    }

    void CheckStory4Choice()
    {
        if(_isPlayedStory4_1)
        {
            _storyPrefabs[3].GetComponent<StoryController>()._flugs[1] = true;
        }
        if(_isPlayedStory4_2)
        {
            _storyPrefabs[3].GetComponent<StoryController>()._flugs[2] = true;
        }
    }
}
