using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    //[Header("アポカリプス")]public bool IsApocalypse;
    //[Header("ババアグッバイ")] public bool IsBabaAgbye;
    //[Header("ラッキー")] public bool IsLucky;
    //[Header("転生者")] public bool IsReincarnatedPerson;
    ////あるかわからない
    //[Header("世界崩壊")] public bool IsWorldCollapse;
    //[Header("無限ループ")] public bool IsInfiniteLoop;
    //[Header("すべてを知るもの")] public bool IsKnowsEverything;
    //[Header("全クリ")] public bool IsAllChestnuts;

    //実績のアイコンを上の順番に入れて欲しい↑（boolの順番に）
    [SerializeField, Header("実績アイコン")] 
    public List<Sprite> _achieveIcon = new List<Sprite>();

    //実績の名前（TMPに表示するText）
    [SerializeField, Header("実績の名前")] 
    public List<string> _achieveName = new List<string>();

    //アイコンのimage
    [SerializeField, Header("アイコン")] Image _icon;
    //実績の名前
    [SerializeField, Header("テキスト")] TextMeshProUGUI _name;
    //実績の親image
    [SerializeField, Header("実績")] GameObject _achieve;
    //待って欲しい時間（実績が消えるまで）
    public int timeOut = 2;

    private void Start()
    {
        _achieve.SetActive(false);
    }

    //アポカリプス
    public void Apocalypse()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[0];
        _name.text = _achieveName[0];
        StartCoroutine(Hide());
    }
    //ババアグッバイ
    public void BabaAgbye()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[1];
        _name.text = _achieveName[1];
        StartCoroutine(Hide());
    }
    //ラッキー
    public void Lucky()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[2];
        _name.text = _achieveName[2];
        StartCoroutine(Hide());
    }
    //転生者
    public void ReincarnatedPerson()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[3];
        _name.text = _achieveName[3];
        StartCoroutine(Hide());
    }
    //世界崩壊
    public void WorldCollapse()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[4];
        _name.text = _achieveName[4];
        StartCoroutine(Hide());
    }
    //無限ループ
    public void InfiniteLoop()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[5];
        _name.text = _achieveName[5];
        StartCoroutine(Hide());
    }
    //すべてを知るもの
    public void KnowsEverything()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[6];
        _name.text = _achieveName[6];
        StartCoroutine(Hide());
    }
    //全クリ
    public void AllChestnuts()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[7];
        _name.text = _achieveName[7];
        StartCoroutine(Hide());
    }

    private IEnumerator Hide()
    {
        //
        yield return new WaitForSeconds(timeOut);

        _achieve.SetActive(false);
    }



    /*関係ない
    public void Achieve(int Number)
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[Number];
        _name.text = _achieveName[Number];
    StartCoroutine(Hide());
    }*/

}
