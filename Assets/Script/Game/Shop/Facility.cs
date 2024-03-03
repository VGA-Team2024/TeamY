using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>�{�݃N���X</summary>
public class Facility : MonoBehaviour
{
    ///<summary>�{�ݖ�</summary>
    [Header("�{�݂̖��O")]
    [SerializeField] string _name;

    /// <summary>��{�N�b�L�[���Y��</summary>
    [Header("��{�N�b�L�[���Y��")]
    [SerializeField] float _baseCpS;

    ///<summary>��{�w�����z</summary>
    [Header("��{�w�����z")]
    [SerializeField] ulong _basePrice;

    ///<summary>�w�����Ƃ̍w�����z�̏㏸�{��</summary>
    const float _priceRate = 1.15f;

    ///<summary>�A�b�v�O���[�h�ɂ��CpS�̏㏸�{��</summary>
    const float _upgradeRate = 2f;

    ///<summary>���݂̏�����</summary>
    int _currentNum;

    ///<summary>�w���{�^��</summary>
    Button _button;

    ///<summary>�w���{�^���̃C���[�W</summary>
    Image _buttonImage;

    ///<summary>�{�݃A�C�R���̃C���[�W</summary>
    [SerializeField] private Image _iconImage;

    ///<summary>�e�L�X�g�̃C���[�W</summary>
    [SerializeField] private Image _textImage;

    ///<summary>�{�ݖ��̃e�L�X�g</summary>
    [SerializeField] private TextMeshProUGUI _nameText;

    ///<summary>�{�݉��i�̃e�L�X�g</summary>
    [SerializeField] private TextMeshProUGUI _priceText;

    ///<summary>�Q�[���Ǘ��N���X</summary>
    GameManager _gameManager;
    void Start()
    {
        // ������
        SetUp();
        // 
    }
    void Update()
    {
        
    }

    ///<summary>�f�[�^�̏�����</summary>
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

    ///<summary>���i�e�L�X�g��ݒ�</summary>
    void SetPriceText(ulong price)
    {
        _priceText.text = $"{price.UlongToComma()} C";
    }

    ///<summary>�{�݂��w������</summary>
    void Purchase()
    {

    }

    ///<summary>�w���{�^���̕\���E��\����ݒ肷��</summary>
    ///<param name="status">�ݒ肵�����{�^���̏�ԁB0 = ��\��, 1 = �\���i�������j, 2 = �\���i�s�����j</param>
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
                _button.enabled = false;
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
}
