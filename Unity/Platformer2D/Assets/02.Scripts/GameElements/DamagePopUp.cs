using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SubsystemsImplementation;

public class DamagePopUp : MonoBehaviour
{
    private TMP_Text _damageAmout;
    private float _fadeSpeed = 1.0f;
    private float _moveSpeedY = 0.5f;
    private Color _color;

    public static DamagePopUp Create(LayerMask layer, Vector3 pos,int damageAmount)
    {
        DamagePopUp damagePopUp = Instantiate(DamagePopUpAssets.instance[layer],
                                              pos,
                                              Quaternion.identity);
        damagePopUp._damageAmout.text= damageAmount.ToString();
        return damagePopUp;
    }

    private void Awake()
    {
        _damageAmout = GetComponent<TMP_Text>();
        _color = _damageAmout.color;
    }

    private void Update()
    {
        transform.position += Vector3.up * _moveSpeedY * Time.deltaTime;
        _color.a -= _fadeSpeed * Time.deltaTime;
        _damageAmout.color = _color;

        if (_color.a <= 0.0f) 
            Destroy(gameObject);
    }
}
