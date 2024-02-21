using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
/// <summary>
/// Instance.Save()を呼ぶと
/// その時のゲーム内のデータがResourcesファイルの中にSaveData.jsonとして出力されます。
/// </summary>
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    //シングルトン
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField]
    GameObject _shopPanel;
    /// <summary>
    /// スコアと
    /// <para>Facilityの_name,_ownedNum,_currentPrice,_currentUpgradeFactorを、</para>
    /// <para>UpGradeの_name,gameObjectを、</para>
    /// ResourcesフォルダのSaveData.jsonに保存します。
    /// </summary>
    public void Save()
    {
        Facility[] facilities = _shopPanel.GetComponentsInChildren<Facility>();
        UpGrade[] upGrades = _shopPanel.GetComponentsInChildren<UpGrade>();
        List<FacilityData> facilitiesData = new();
        List<UpGradeData> upgGadesData = new();
        //ShopPanelの子のobjectに対応するコンポーネントがアタッチされていたら
        //Listに追加する。
        foreach (Facility facility in facilities)
        {
            facilitiesData.Add(new FacilityData()
            {//facility._nameがpublicじゃなかったから変更をお願いする
                name = facility._name,
                ownedNum = facility._ownedNum,
                currentPrice = facility._currentPrice,
                currentUpgradeFactor = facility._currentUpgradeFactor,
            }
            ) ;
        }
        foreach (UpGrade upgrade in upGrades)
        {
            upgGadesData.Add(new UpGradeData()
            {
                name = upgrade._name,
                gameObject = upgrade.gameObject,
            }) ;
        }

        //引っ張ってきたデータをSeveDataクラスでnew
        SaveData seveData = new()
        {
            score = ResourceManager.Instance.GetResource(),
            facilitiesDataList = facilitiesData,
            upGradsDataList = upgGadesData
        };
        String json = JsonUtility.ToJson(seveData, true);//ここでSeveDataをJsonに変換
        File.WriteAllText($"Assets/Resources/SaveData.json", json);
        Debug.Log($"セーブした");
    }
}
[Serializable]
class FacilityData
{
    public string name;
    public ulong ownedNum;
    public ulong currentPrice;
    public ulong currentUpgradeFactor;
}
[Serializable]
class UpGradeData
{
    public string name;
    public GameObject gameObject;
}
[Serializable]
class SaveData
{
    public ulong score;
    public List<FacilityData> facilitiesDataList;
    public List<UpGradeData> upGradsDataList;
}