using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; set; }

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
    public bool _isObtainAllGrandmaUpgrade = false;
    public bool _isObtainAllRingUpgrade = false;
    public bool _isObtainAllSwordUpgrade = false;

    /// <summary>ストーリー</summary>
    public bool _isPlayedStory2 = false;

    float _goldenCookieInterval = 0f;
    float _timer = 0f;  
    [SerializeField] GameObject _goldenCookie;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
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
}
