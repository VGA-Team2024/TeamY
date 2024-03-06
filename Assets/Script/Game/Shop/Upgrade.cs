using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>�A�b�v�O���[�h</summary>
public class Upgrade : MonoBehaviour
{
    /// <summary>�Ή�����{�݃N���X</summary>
    [Header("�Ή�����{�݃N���X")]
    [SerializeField] Facility _facility;

    /// <summary>�Q�[���Ǘ��N���X</summary>
    GameManager _gameManager;

    /// <summary>��{�w�����z</summary>
    ulong _basePrice;

    /// <summary>�w�����z�̏㏸�{��</summary>
    ulong[] _priceRate = { 10, 50, 500, 50000, 5000000 };

    /// <summary>�w�������ƂȂ�{�݂̏�����</summary>
    int[] _triggerNum = { 1, 5, 25, 50, 100 };

    /// <summary>�w���{�^��</summary>
    Button _button;

    /// <summary>�w���{�^���̃C���[�W</summary>
    Image _buttonImage;

    /// <summary>�A�b�v�O���[�h�̃A�C�R��</summary>
    [SerializeField] private Image _iconImage;

    /// <summary>�e�L�X�g�̃C���[�W</summary>
    [SerializeField] private Image _textImage;

    /// <summary>�A�b�v�O���[�h���̃e�L�X�g</summary>
    [SerializeField] private TextMeshProUGUI _nameText;

    /// <summary>�A�b�v�O���[�h���z�̃e�L�X�g</summary>
    [SerializeField] private TextMeshProUGUI _priceText;

    /// <summary>�ύX��̃X�v���C�g</summary>
    [Header("�V�����X�v���C�g")]
    [SerializeField] private Sprite[] _iconSprites;

    void Start()
    {
        // �����ݒ�
        SetUp();
    }

    void Update()
    {
        // �̔������̊m�F
        CheckEnablement();
    }

    /// <summary>�����ݒ�</summary>
    void SetUp()
    {
        // �Q�[���Ǘ��N���X�̃C���X�^���X��o�^
        _gameManager = GameManager.Instance;
        // ��{�w�����z�ɑΉ�����{�݃N���X�̊�{�w�����z��������
        _basePrice = _facility._basePrice;
        // �{�^��UI
        _button = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
        // �e�L�X�gUI
        _nameText.text = $"{_facility._name}�A�b�v�O���[�h";
        SetPriceText(_basePrice * _priceRate[0]);
        // �A�C�R��
        _iconImage.sprite = _iconSprites[0];
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

    /// <summary>�A�b�v�O���[�h�̍w�����ɌĂ΂�鏈��</summary>
    void Purchase()
    {
        // �A�b�v�O���[�h���z���̃N�b�L�[������������
        Payment();
        // �A�b�v�O���[�h�̃A�C�R�����X�V
        _iconImage.sprite = _iconSprites[_facility.GetUpgradeNum()];
        // �{�݃N���X�̃A�C�R�����X�V
        _facility._iconImage.sprite = _iconSprites[_facility.GetUpgradeNum()];
        // �{�݃N���X�̃A�b�v�O���[�h�������𑝉�������
        _facility.AddUpgradeNum();
        // �A�b�v�O���[�h��S�čw�����Ă���ꍇ�A�A�b�v�O���[�h�𖳌��ɂ���
        if (IsUpgradeCompleted()) gameObject.SetActive(false);
        // ���i�e�L�X�g��"���̒l�i"�ɍX�V
        _priceText.text = $"{CalPrice()} C";
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

    /// <summary>�A�b�v�O���[�h�̒l�i���v�Z����</summary>
    ulong CalPrice()
    {
        return _basePrice * _priceRate[_facility.GetUpgradeNum()];
    }

    /// <summary>�A�b�v�O���[�h�̒l�i�����N�b�L�[������������</summary>
    void Payment()
    {
        _gameManager.SubtractCookie(CalPrice());
    }

    /// <summary>�̔������𖞂����Ă��邩���m�F����</summary>
    void CheckEnablement()
    {
        if (_facility.GetFacilityNum() >= _triggerNum[_facility.GetUpgradeNum()])
        {
            SetButtonEnablement(2);
        }
        else SetButtonEnablement(0);
    }

    /// <summary>�A�b�v�O���[�h��S�Ĕ����������ǂ���</summary>
    bool IsUpgradeCompleted()
    {
        if(_facility.GetUpgradeNum() == 5)
        {
            return true;
        }
        else return false;
    }

    /// <summary>�]�����ɌĂ΂�鏈��</summary>
    public void Reset()
    {
        // ��{�w�����z�Ɏ{�݃N���X�̊�{�w�����z����
        _basePrice = _facility._basePrice;
        // �{�݃A�C�R����������
        _iconImage.sprite = _iconSprites[0];
        // ���i�e�L�X�g��������
        SetPriceText(_basePrice);
    }
}
