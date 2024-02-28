using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryController : MonoBehaviour
{
    [Header("会話文")]
    [Multiline(3)]
    public string[] _lines;
    [Header("選択肢の内容文")]
    public string[] _choices;

    /// <summary>選択肢をまとめたGameObjectを入れる</summary>
    [SerializeField] GameObject _choicePrefab;
    /// <summary>会話文を表示するUITextを入れる</summary>
    [SerializeField] TextMeshProUGUI _line;


    /// <summary>各選択肢が出現するか否かの配列</summary>
    public bool[] _flugs = new bool[3] { true, false, false };
    /// <summary>会話を進めるためのインデックス</summary>
    int _index = 0;
    void Start()
    {
        Conversation();
    }
    /// <summary>会話イベント。画面をクリックしたときに呼ばれる</summary>
    public void Conversation()
    {
        if(_index < _lines.Length)//会話文を表示
        {
            _line.text = _lines[_index];
            _index++;
        }
        else
        {
            Choice();//会話文が全て表示されたら選択肢に飛ぶ
        }
    }
    /// <summary>選択肢イベント</summary>
    void Choice()
    {
        for(int i = 0;i < _choices.Length; i++)//選択肢の数だけ処理
        {
            var child = _choicePrefab.transform.GetChild(i);
            TextMeshProUGUI text = child.GetChild(0).GetComponent<TextMeshProUGUI>();
            text.text = _choices[i];//ButtonのTextを変更
            child.gameObject.SetActive(_flugs[i]);//フラグがtrueになっている物だけ表示
        }
    }
    /// <summary>会話終了時に呼び出す</summary>
    public void StoryEnd()
    {
        Destroy(this.gameObject);//選択肢を選んだら自身を消す
    }
}
