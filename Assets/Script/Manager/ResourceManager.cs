using UnityEngine;
public class ResourceManager : MonoBehaviour
{
    /// <summary>ゲームのリソース</summary>
    private ulong _resource = 100000000000;

    /// <summary>インスタンス</summary>
    public static ResourceManager Instance { get; private set; }

    public bool _isFever = false;
    float _timer = 0f;
    private void Awake()
    {
        // ResourceManagerが存在しない場合
        if (Instance == null)
        {
            Instance = this;
        }
        // 既にResourceManagerが存在する場合
        else
        {
            Debug.LogError("ResourceManagerは既に存在しています");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_isFever)
        {

            _timer += Time.deltaTime;

            if( _timer >= 77f )
            {
                _timer = 0f;
                _isFever = false;
            }
        }
    }

    /// <summary>リソースの数値を取得するメソッド</summary>
    public ulong GetResource()
    {
        return _resource;
    }

    /// <summary>リソースの数値を設定するメソッド</summary>
    /// <param name="value">設定したいリソース量</param>
    public void SetResource(ulong value)
    {
        _resource = value;
    }

    /// <summary>リソースを増加させるメソッド</summary>
    /// <param name="value">増加量</param>
    public void AddResource(ulong value)
    {
        if(_isFever)
        {
            SetResource(GetResource() + value * 7);
        }
        else SetResource(GetResource() + value);
    }

    /// <summary>リソースを減少させるメソッド</summary>
    /// <param name="value">減少量</param>
    public void SubtractResource(ulong value)
    {
        SetResource(GetResource() - value);
    }
}