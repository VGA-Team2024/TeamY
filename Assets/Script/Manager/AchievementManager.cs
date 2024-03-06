using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>���т��Ǘ�����N���X</summary>
public class AchievementManager : MonoBehaviour
{
    /// <summary>���уA�C�R��</summary>
    [Header("���т̃A�C�R��")]
    [SerializeField] public Sprite[] _achievementIcon;

    /// <summary>���і�</summary>
    [Header("���т̖��O")]
    [SerializeField] public string[] _achievementName;

    /// <summary>���уE�B���h�E�̃A�C�R��</summary>
    [Header("���уE�B���h�E�̃A�C�R��")] 
    [SerializeField] private Image _windowImage;

    /// <summary>���уE�B���h�E�̃e�L�X�g</summary>
    [Header("���уE�B���h�E�̃e�L�X�g")] 
    [SerializeField] TextMeshProUGUI _windowText;

    /// <summary>���уE�B���h�E�̃I�u�W�F�N�g</summary>
    [Header("���уE�B���h�E")] 
    [SerializeField] GameObject _achievementWindow;

    /// <summary>�C���X�^���X</summary>
    public static AchievementManager Instance { get; private set; }

    /// <summary>�C�x���g�Ǘ��N���X</summary>
    EventManager _eventManager = null;

    /// <summary>�T�E���h�Ǘ��N���X</summary>
    SoundManager _soundManager = null;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        // ���уE�B���h�E�𖳌��ɂ���
        _achievementWindow.SetActive(false);
        // �e�N���X�̃C���X�^���X���擾
        _eventManager = EventManager.Instance;
        _soundManager = SoundManager.Instance;
    }

    /// <summary>���т�B�������ۂɌĂ΂�鋤�ʏ���</summary>
    /// <param name="num">���т̎��ʔԍ�</param>
    public void Achieve(int num)
    {
        // ���уE�B���h�E��L���ɂ���
        _achievementWindow.SetActive(true);
        // ���уE�B���h�E�̃A�C�R�����X�V����
        _windowImage.sprite = _achievementIcon[num];
        // ���уE�B���h�E�̃e�L�X�g���X�V����
        _windowText.text = _achievementName[num];
        // ���уE�B���h�E�𖳌��ɂ���
        SetInactive();
    }

    /// <summary>���ђB������SE���Đ�����</summary>
    public void PlayAchievementSound()
    {
        _soundManager.PlayOtherSound(5);
    }

    /// <summary>���сF�u�A�|�J���v�X�v</summary>
    public void Apocalypse()
    {
        Achieve(0);
        PlayAchievementSound();
    }

    /// <summary>���сF�u�o�o�A�O�b�o�C�v</summary>
    public void GoodByeGrandma()
    {
        Achieve(1);
        PlayAchievementSound();
    }

    /// <summary>���сF�u���b�L�[�I�v</summary>
    public void Lucky()
    {
        Achieve(2);
        PlayAchievementSound();
    }

    /// <summary>���сF�u�]���ҁv</summary>
    public void ReLife()
    {
        Achieve(3);
        PlayAchievementSound();
    }

    /// <summary>���сF�u���E����v</summary>
    public void WorldEnd()
    {
        Achieve(4);
        PlayAchievementSound();
    }

    /// <summary>���сF�u�������[�v�v</summary>
    public void InfinityLoop()
    {
        Achieve(5);
        PlayAchievementSound();
    }

    /// <summary>���сF�u���ׂĂ�m��ҁv</summary>
    public void Almighty()
    {
        Achieve(6);
        PlayAchievementSound();
    }

    /// <summary>���сF�u�S�N���v</summary>
    public void Complete()
    {
        Achieve(7);
        PlayAchievementSound();
    }

    /// <summary>���уE�B���h�E�𖳌��ɂ���</summary>
    public IEnumerator SetInactive()
    {
        // 5�b�҂�
        yield return new WaitForSeconds(5);
        _achievementWindow.SetActive(false);
    }
}
