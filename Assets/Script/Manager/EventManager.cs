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
    public bool _isAchevedApocalypse = false;

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
    }

    public void EnableStoryButton(int storyNum)
    {
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
        float interval = Random.Range(3f, 9f);
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


}
