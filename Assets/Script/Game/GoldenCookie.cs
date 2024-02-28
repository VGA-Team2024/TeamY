using System.Collections;
using System.Resources;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoldenCookie : MonoBehaviour, IPointerClickHandler
{
    ResourceManager _resourceManager = null;

    private void Start()
    {
        _resourceManager = ResourceManager.Instance;
        DestroySelf();
    }
    public IEnumerator DestroySelf()
    {
        yield return new WaitForSecondsRealtime(13f);
        Destroy(gameObject);
    }
    /// <summary>ƒNƒŠƒbƒN‚Ìˆ—</summary>
    void OnClick()
    {
        _resourceManager._isFever = true;
        gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}
