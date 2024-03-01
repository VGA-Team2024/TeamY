using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CursorUpgrade : MonoBehaviour
{
    /// <summary>�w�����z</summary>
    [SerializeField] ulong _price = 0;

    /// <summary>�A�^�b�`��̃{�^��</summary>
    Button _button;

    /// <summary>�A�^�b�`��̉��i�e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _priceText;

    /// <summary>�A�b�v�O���[�h����{��</summary>
    [SerializeField] Facility _facility;

    /// <summary>�A�b�v�O���[�h����N���b�J�[</summary>
    [SerializeField] Clicker _clicker;

    /// <summary>�Q�[���Ǘ��N���X�̃C���X�^���X</summary>
    GameManager _gameManager;

    /// <summary>�A�b�v�O���[�h�Ǘ��N���X�̃C���X�^���X</summary>
    UpgradeManager _upgradeManager;

    /// <summary>�ύX���̃C���[�W</summary>
    [SerializeField] Image _facilityImage;

    /// <summary>�ύX���̃C���[�W</summary>
    [SerializeField] Image _listImage;

    /// <summary>�ύX��̃C���[�W</summary>
    [SerializeField] Sprite _newSprite;

    /// <summary>�ύX��̃J���[</summary>
    [SerializeField] float _red, _green, _blue, _alpha;

    /// <summary>�ύX���̃e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _facilityText;

    /// <summary>�ύX���̃e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _listText;

    /// <summary>�ύX��̃e�L�X�g</summary>
    [SerializeField] string _newText;

    [SerializeField] TextMeshProUGUI _thisNameText;

    [SerializeField] Image _thisIcon;

    [SerializeField] Image _thisTextImage;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _upgradeManager = UpgradeManager.Instance;
        _button = gameObject.GetComponent<Button>();

        // �e�L�X�g���X�V
        _priceText.text = $"{_price} C";

        // �N���b�N���̃C�x���g��ݒ�
        _button.onClick.AddListener(UpgradeFacility);

        gameObject.SetActive(false);
    }

    private void Update()
    {
        // ���\�[�X�ʂ����݂̍w�����z�ɖ����Ȃ��ꍇ�A�{�^���𔼓���������B
        if (_gameManager.GetResource() < _price)
        {
            // �{�^��
            _button.enabled = false;
            // �{�^���C���[�W
            GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
            // ���O�e�L�X�g
            _priceText.color = new Color(0, 0, 0, 0.25f);
            // ���i�e�L�X�g
            _thisNameText.color = new Color(0, 0, 0, 0.25f);
            // �A�C�R��
            _thisIcon.color = new Color(1, 1, 1, 0.25f);
            // �e�L�X�g�C���[�W
            _thisTextImage.color = new Color(1, 1, 1, 0.25f);
        }
        else
        {
            // �{�^��
            _button.enabled = true;
            // �{�^���C���[�W
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
            // ���O�e�L�X�g
            _priceText.color = new Color(0, 0, 0, 1);
            // ���i�e�L�X�g
            _thisNameText.color = new Color(0, 0, 0, 1);
            // �A�C�R��
            _thisIcon.color = new Color(_red, _green, _blue, _alpha);
            // �e�L�X�g�C���[�W
            _thisTextImage.color = new Color(1, 1, 1, 1);
        }
    }

    void UpgradeFacility()
    {
        // �{�݂��A�b�v�O���[�h
        if (_facility)
            _facility._currentUpgradeFactor *= 2;

        // �N���b�J�[���A�b�v�O���[�h
        if (_clicker)
            _clicker._currentUpgradeFactor *= 5;

        // �A�C�R�����X�V
        _facilityImage.sprite = _newSprite;
        _listImage.sprite = _newSprite;

        // �e�L�X�g���X�V
        _facilityText.text = _newText;
        _listText.text = _newText;

        // �w�����z�������\�[�X������
        _gameManager.SubtractResource(_price);

        if (_upgradeManager._cursorUpgradeNum <= 4)
        {
            _upgradeManager._cursorUpgradeNum++;
        }

        _upgradeManager._isCursorUGAllowed = false;

        // �{�^��������
        gameObject.SetActive(false);
    }
}