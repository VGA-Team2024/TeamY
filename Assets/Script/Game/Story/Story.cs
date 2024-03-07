using TMPro;
using UnityEngine;

/// <summary>ストーリーイベントを実行するクラス</summary>
public class Story : MonoBehaviour
{
    /// <summary>会話文</summary>
    string[,] _message = new string[4,2]
    {
        // ストーリー1
        {"グランマ\nはじめまして", 
         "グランマ\nおいしいクッキーを焼いてあげるよ"},
        // ストーリー2
        {"グランマ\nこんなブラック環境は初めてだよ", 
         "グランマ\nもうクッキー焼きたくないよ"}, 
        // ストーリー3
        {"あなた\nもうババアは笑ってくれない...", 
         "あなた\n過去に戻ってやり直すべきか...?"}, 
        // ストーリー4
        {"あなた\nどうしてこうなったんだ...", 
         "あなた\nもう何もかも終わりだ..."}
    };

    /// <summary>会話文を表示するテキスト</summary>
    [Header("会話文を表示するテキスト")]
    [SerializeField] TextMeshProUGUI _messageText;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>会話文を更新する。画面をクリックする度に呼ばれる。</summary>
    public void UpdateMessageText()
    {

    }
}
