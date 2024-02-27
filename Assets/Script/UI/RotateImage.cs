using UnityEngine;
using UnityEngine.UI;

public class RotateImage : MonoBehaviour
{
    Image _image;
    float _currentRotation = 0f;

    void Start()
    {
        _image = GetComponent<Image>();
    }
    private void FixedUpdate()
    {
        _image.transform.Rotate(0f, 0f, _currentRotation);
        _currentRotation -= 0.0015f;
    }
}
