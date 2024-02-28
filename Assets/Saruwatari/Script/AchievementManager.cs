using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    //[Header("�A�|�J���v�X")]public bool IsApocalypse;
    //[Header("�o�o�A�O�b�o�C")] public bool IsBabaAgbye;
    //[Header("���b�L�[")] public bool IsLucky;
    //[Header("�]����")] public bool IsReincarnatedPerson;
    ////���邩�킩��Ȃ�
    //[Header("���E����")] public bool IsWorldCollapse;
    //[Header("�������[�v")] public bool IsInfiniteLoop;
    //[Header("���ׂĂ�m�����")] public bool IsKnowsEverything;
    //[Header("�S�N��")] public bool IsAllChestnuts;

    //���т̃A�C�R������̏��Ԃɓ���ė~�������ibool�̏��ԂɁj
    [SerializeField, Header("���уA�C�R��")] 
    public List<Sprite> _achieveIcon = new List<Sprite>();

    //���т̖��O�iTMP�ɕ\������Text�j
    [SerializeField, Header("���т̖��O")] 
    public List<string> _achieveName = new List<string>();

    //�A�C�R����image
    [SerializeField, Header("�A�C�R��")] Image _icon;
    //���т̖��O
    [SerializeField, Header("�e�L�X�g")] TextMeshProUGUI _name;
    //���т̐eimage
    [SerializeField, Header("����")] GameObject _achieve;
    //�҂��ė~�������ԁi���т�������܂Łj
    public int timeOut = 2;

    private void Start()
    {
        _achieve.SetActive(false);
    }

    //�A�|�J���v�X
    public void Apocalypse()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[0];
        _name.text = _achieveName[0];
        StartCoroutine(Hide());
    }
    //�o�o�A�O�b�o�C
    public void BabaAgbye()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[1];
        _name.text = _achieveName[1];
        StartCoroutine(Hide());
    }
    //���b�L�[
    public void Lucky()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[2];
        _name.text = _achieveName[2];
        StartCoroutine(Hide());
    }
    //�]����
    public void ReincarnatedPerson()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[3];
        _name.text = _achieveName[3];
        StartCoroutine(Hide());
    }
    //���E����
    public void WorldCollapse()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[4];
        _name.text = _achieveName[4];
        StartCoroutine(Hide());
    }
    //�������[�v
    public void InfiniteLoop()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[5];
        _name.text = _achieveName[5];
        StartCoroutine(Hide());
    }
    //���ׂĂ�m�����
    public void KnowsEverything()
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[6];
        _name.text = _achieveName[6];
        StartCoroutine(Hide());
    }
    //�S�N��
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



    /*�֌W�Ȃ�
    public void Achieve(int Number)
    {
        _achieve.SetActive(true);
        _icon.sprite = _achieveIcon[Number];
        _name.text = _achieveName[Number];
    StartCoroutine(Hide());
    }*/

}
