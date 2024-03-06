using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>�{�݃N���X</summary>
public class Facility : MonoBehaviour
{
    /// <summary>�{�ݖ�</summary>
    [Header("�{�݂̖��O")]
    [SerializeField] public string _name;

    /// <summary>��{�N�b�L�[���Y��</summary>
    [Header("��{�N�b�L�[���Y��")]
    [SerializeField] float _baseCpS;

    /// <summary>��{�w�����z</summary>
    [Header("��{�w�����z")]
    [SerializeField] public ulong _basePrice;

    /// <summary>�w�����Ƃ̍w�����z�̏㏸�{��</summary>
    const float _priceRate = 1.15f;

    /// <summary>�A�b�v�O���[�h�ɂ��CpS�̏㏸�{��</summary>
    const float _upgradeRate = 2f;

    /// <summary>���݂̎{�ݏ�����</summary>
    int _facilityNum;

    /// <summary>���݂̃A�b�v�O���[�h������</summary>
    int _upgradeNum;

    /// <summary>�w���{�^��</summary>
    Button _button;

    /// <summary>�w���{�^���̃C���[�W</summary>
    Image _buttonImage;

    /// <summary>�{�݃A�C�R���̃C���[�W</summary>
    [SerializeField] public Image _iconImage;

    /// <summary>�e�L�X�g�̃C���[�W</summary>
    [SerializeField] private Image _textImage;

    /// <summary>�{�ݖ��̃e�L�X�g</summary>
    [SerializeField] private TextMeshProUGUI _nameText;

    /// <summary>�{�݉��i�̃e�L�X�g</summary>
    [SerializeField] private TextMeshProUGUI _priceText;

    /// <summary>�A�C�R���̃X�v���C�g</summary>
    [SerializeField] Sprite _iconSprite;

    /// <summary>�ŏ��Ƀ{�^����L��������ۂ̃t���O</summary>
    bool _isEnabld = false;

    /// <summary>�Q�[���Ǘ��N���X</summary>
    GameManager _gameManager;
    void Start()
    {
        // ������
        SetUp();
        // �N�b�L�[�𑝉�������R���[�`���̌Ăяo��
        StartCoroutine(GenerateCookie());
    }
    void Update()
    {
        if(_gameManager.GetCookie() >= _basePrice && _isEnabld == false)
        {
            // �L�����t���O��؂�ւ���
            _isEnabld = true;
            SetButtonEnablement(2);
        }
        if(_gameManager.GetCookie() < CalPrice())
        {
            SetButtonEnablement(1);
        }
    }

    /// <summary>Start()�ŌĂ΂�鏉���ݒ�</summary>
    void SetUp()
    {
        // �Q�[���Ǘ��N���X�̃C���X�^���X���擾
        _gameManager = GameManager.Instance;
        // �{�^��UI
        _button = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
        // �e�L�X�gUI
        _nameText.text = _name;
        SetPriceText(_basePrice);
        // �{�^���̃C�x���g�o�^
        _button.onClick.AddListener(Purchase);
        // �{�^�����\���ɂ���
        SetButtonEnablement(0);
    }

    /// <summary>���i�e�L�X�g��ݒ�</summary>
    void SetPriceText(ulong price)
    {
        _priceText.text = $"{price.UlongToComma()} C";
    }

    /// <summary>�{�݂̍w�����ɌĂ΂�鏈��</summary>
    void Purchase()
    {
        // �{�݂̍w�����z���̃N�b�L�[������������
        Payment();
        // �{�݂̏������𑝉�������
        _facilityNum++;
        // ���i�e�L�X�g��"���̒l�i"�ɍX�V
        SetPriceText(CalPrice());
    }

    /// <summary>�{�݂̔��p���ɌĂ΂�鏈��</summary>
    public void Sell()
    {
        // �{�݂̏�����������������
        _facilityNum--;
        // �{�݂̒l�i��2/3���������N�b�L�[�ʂ𑝉�������
        PayBack();
    }

    /// <summary>�w���{�^���̕\���E��\����ݒ肷��</summary>
    /// <param name="status">�ݒ肵�����{�^���̏�ԁB0 = ��\��, 1 = �\���i�������j, 2 = �\���i�s�����j</param>
    void SetButtonEnablement(int status)
    {
        switch (status)
        {
            case 0:
                // �C���[�W�ƃe�L�X�g�̐F
                Color invisibleColor = new Color(1, 1, 1, 0);
                // �{�^���𖳌���
                _button.enabled = false;
                // �e�C���[�W���\���ɂ���
                _buttonImage.color = invisibleColor;
                _iconImage.color = invisibleColor;
                _textImage.color = invisibleColor;
                // �e�e�L�X�g���\���ɂ���
                _nameText.color = invisibleColor;
                _priceText.color = invisibleColor;

                break;

            case 1:
                // �C���[�W�ƃe�L�X�g�̐F
                Color translucentImageColor = new Color(1, 1, 1, 0.25f);
                Color translucentTextColor = new Color(0, 0, 0, 0.25f);
                // �{�^���𖳌���
                _button.enabled = false;
                // �e�C���[�W���\���ɂ���
                _buttonImage.color = translucentImageColor;
                _iconImage.color = translucentImageColor;
                _textImage.color = translucentImageColor;
                // �e�e�L�X�g���\���ɂ���
                _nameText.color = translucentTextColor;
                _priceText.color = translucentTextColor;

                break;

            case 2:
                // �C���[�W�ƃe�L�X�g�̐F
                Color opaqueImageColor = new Color(1, 1, 1, 1);
                Color opaqueTextColor = new Color(0, 0, 0, 1);
                // �{�^���𖳌���
                _button.enabled = true;
                // �e�C���[�W���\���ɂ���
                _buttonImage.color = opaqueImageColor;
                _iconImage.color = opaqueImageColor;
                _textImage.color = opaqueImageColor;
                // �e�e�L�X�g���\���ɂ���
                _nameText.color = opaqueTextColor;
                _priceText.color = opaqueTextColor;

                break;
        }
    }
    /// <summary>�A�b�v�O���[�h�{������Z����CpS���v�Z����</summary>
    /// <returns>���݂�CpS</returns>
    ulong CalCpS()
    {
        // �{�݂݂̂�CpS
        float facilityCpS;
        // �A�b�v�O���[�h�ɂ��CpS�̏㏸�{��
        float upgradeBuff;

        facilityCpS = _baseCpS * _facilityNum;
        // �A�b�v�O���[�h���w�����Ă��Ȃ��ꍇ1�ɂ���
        if (_upgradeNum == 0)
        {
            upgradeBuff = 1;
        }
        else
        {
            upgradeBuff = _upgradeRate * _upgradeNum;
        }
        return (ulong)(facilityCpS * upgradeBuff);
    }

    /// <summary>1�b���Ƃ�CpS�������N�b�L�[�𑝉�������</summary>
    IEnumerator GenerateCookie()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _gameManager.AddCookie(CalCpS());
            Debug.Log("AddCookie Called");
        }
    }

    /// <summary>�{�݂̒l�i���v�Z����</summary>
    ulong CalPrice()
    {
        return (ulong)(_basePrice * Mathf.Pow(_priceRate, _facilityNum));
    }

    /// <summary>�{�݂̒l�i�����N�b�L�[������������</summary>
    void Payment()
    {
        _gameManager.SubtractCookie(CalPrice());
    }

    /// <summary>�{�݂̔��p���ɌĂ΂�鏈��</summary>
    public void PayBack()
    {
        // �{�݂̒l�i��2/3�����N�b�L�[�𕥂��߂�
        _gameManager.AddCookie(CalPrice() * 2 / 3);
    }

    /// <summary>�]�����ɌĂ΂�鏈��</summary>
    public void Reset()
    {
        // �{�݂̏�������������
        _facilityNum = 0;
        // �A�b�v�O���[�h�̏�������������
        _upgradeNum = 0;
        // �{�݃A�C�R����������
        _iconImage.sprite = _iconSprite;
        // ���i�e�L�X�g��������
        SetPriceText(_basePrice);
        // �L�����t���O�̏�����
        _isEnabld = false;
    }

    /// <summary>�{�݂̏�������Ԃ�</summary>
    public int GetFacilityNum()
    {
        return _facilityNum;
    }

    /// <summary>�A�b�v�O���[�h�̏�������Ԃ�</summary>
    public int GetUpgradeNum()
    {
        return _upgradeNum;
    }

    /// <summary>�A�b�v�O���[�h�̏�������1���₷</summary>
    public void AddUpgradeNum()
    {
        _upgradeNum++;
    }
}
