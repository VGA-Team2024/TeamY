using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
/// <summary>
/// Instance.Save()���ĂԂ�
/// ���̎��̃Q�[�����̃f�[�^��Resources�t�@�C���̒���SaveData.json�Ƃ��ďo�͂���܂��B
/// </summary>
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    //�V���O���g��
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
    public void Save()
    {
        Facility[] facilities = _shopPanel.GetComponentsInChildren<Facility>();
        UpGrade[] upGrades = _shopPanel.GetComponentsInChildren<UpGrade>();
        List<FacilityData> facilitiesData = new();
        List<UpGradeData> upgGadesData = new();
        //ShopPanel�̎q��object�ɑΉ�����R���|�[�l���g���A�^�b�`����Ă�����
        //List�ɒǉ�����B
        foreach (Facility facility in facilities)
        {
            facilitiesData.Add(new FacilityData()
            {//facility._name��public����Ȃ���������ύX�����肢����
                name = facility._name,
                ownedNum = facility._ownedNum,
                isUpGraded = facility._isUpGraded,
            }
            );
        }
        foreach (UpGrade upgrade in upGrades)
        {
            upgGadesData.Add(new UpGradeData()
            {
                name = upgrade._name,
                //�e��gameobject��active�Ƃ��ė��Ă�A���Ƃŕς���
                isOwned = !upgrade.GameObject().activeSelf,
                gameObject = upgrade.gameObject,
            }) ;
        }

        //���������Ă����f�[�^��SeveData�N���X��new
        SaveData seveData = new()
        {
            score = ResourceManager.Instance.GetResource(),
            facilitiesDataList = facilitiesData,
            upGradsDataList = upgGadesData
        };
        String json = JsonUtility.ToJson(seveData, true);//������SeveData��Json�ɕϊ�
        File.WriteAllText($"Assets/Resources/SaveData.json", json);
        Debug.Log($"�Z�[�u����");
    }
}
[Serializable]
class FacilityData
{
    public string name;
    public ulong ownedNum;
    public bool isUpGraded;
}
[Serializable]
class UpGradeData
{
    public string name;
    public bool isOwned;
    public GameObject gameObject;
}
[Serializable]
class SaveData
{
    public ulong score;
    public List<FacilityData> facilitiesDataList;
    public List<UpGradeData> upGradsDataList;
}