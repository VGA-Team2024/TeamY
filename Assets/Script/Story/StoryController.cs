using System;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    [Header("会話文")]
    [Multiline(3)]
    public string[] _lines;
    [Header("選択肢の内容文")]
    public string[] _choices;

    [SerializeField] GameObject _choicePrefab;
    [SerializeField] Text _line;
    
    int _index = 0;
    void Start()
    {
        Conversation();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && _index < _lines.Length)
        {
            //ボタンを押したら会話が進む
            Conversation();
        }
        else if(_index >= _lines.Length)
        {
            Choice();
        }
    }
    /// <summary>会話イベント</summary>
    void Conversation()
    {
        _line.text = _lines[_index];
        _index++;
    }
    /// <summary>選択肢イベント</summary>
    void Choice()
    {
        for(int i = 0;i < _choices.Length; i++)//選択肢の数だけ処理
        {
            var child = _choicePrefab.transform.GetChild(i);
            Text text = child.GetChild(0).GetComponent<Text>();
            text.text = _choices[i];//ButtonのTextを変更
            //この後にフラグ条件を追加
            child.gameObject.SetActive(true);
        }
    }
}
