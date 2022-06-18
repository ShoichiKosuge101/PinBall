using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    //�ŏ��T�C�Y
    private float _minimum = 1.0f;

    //�g��k���X�s�[�h
    private float _magSpeed = 10.0f;

    //�g�嗦
    private float _magnification = 0.07f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �_���g��k��
        // scale = ((min + Xsin(dt * t)) , y, (min + Xsin(dt * t)))
        this.transform.localScale = new Vector3(this._minimum + Mathf.Sin(Time.time * this._magSpeed) * this._magnification, this.transform.localScale.y, this._minimum + Mathf.Sin(Time.time * this._magSpeed) * this._magnification);
    }
}
