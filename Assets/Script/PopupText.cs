using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PopupText : MonoBehaviour
{
    public float moveSpeed = 8.0f;
    public float disappearSpeed = 0.5f;

    private Text _text;
    private Color _textColor = new Color32(134, 0, 16, 255);
    private Vector3 _moveVector3;


    private float _disappearTimer;
    private const float DisappearTimeMax = 1.0f;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _text.color = _textColor;
        _moveVector3 = Vector3.up;
        _disappearTimer = DisappearTimeMax;
    }

    private void Update()
    {
        transform.position += _moveVector3 * (Time.deltaTime * moveSpeed);
        _moveVector3 += _moveVector3 * Time.deltaTime;

        if (_disappearTimer > DisappearTimeMax * 0.5f)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }

        _disappearTimer -= Time.deltaTime;

        if (_disappearTimer > 0) return;

        _textColor.a -= Time.deltaTime * disappearSpeed;
        _text.color = _textColor;

        if (_textColor.a < 0)
        {
            Destroy(gameObject);
        }

    }

}
