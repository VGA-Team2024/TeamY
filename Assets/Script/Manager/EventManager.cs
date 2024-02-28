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

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
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
}
