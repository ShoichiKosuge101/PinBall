using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlightnessRegulator : MonoBehaviour
{
    protected Material myMaterial;

    [Tooltip("emission �ŏ��l")]
    [Range(0,5)]
    [SerializeField] float minEmission = 0.2f;

    [Tooltip("emission �ő�l")]
    [Range(0,5)] 
    [SerializeField] float magEmission = 2.0f;

    [Tooltip("�������x")]
    [Range(0,10)]
    [SerializeField] int speed = 5;
    // �p�x
    protected int degree = 0;

    // �^�[�Q�b�g�̃f�t�H���g�F
    Color defaultColor =Color.white;
    private string _colorName = "_EmissionColor";

    // Start is called before the first frame update
    void Start()
    {
        // �^�O���Ƃɔ����F�𕪗�
        defaultColor = tag switch
        {
            TagName.SmallStarTag => Color.white,
            TagName.LargeStarTag => Color.yellow,
            TagName.SmallCloudTag => Color.cyan,
            TagName.LargeCloudTag => Color.cyan,
            _ => throw new InvalidOperationException($"tag: {tag} is not exist.")
        };

        // material���̎擾
        this.myMaterial = this.GetComponent<Renderer>().material;

        // �I�u�W�F�N�g�̍ŏ��̐F��ݒ�
        // SetColor(colorName,colorValue)
        myMaterial.SetColor(_colorName, this.defaultColor * minEmission);
    }

    // Update is called once per frame
    void Update()
    {
        ///<summary> 
        /// �Փˎ��̊p�x�����N�_�Ƃ��Ĕ�����ύX
        /// ���Ԍo�߂ɂ�蔭���������ω�(180�� -> 0��)
        /// �f�t�H���g * �ŏ������l�ɖ߂�
        /// </summary>
        if (this.degree >= 0)
        {
            // �f�t�H���g�F * (�ŏ�emission + sin((rad)�p�x)*�ő�emission)
            var emissionColor= this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);
            myMaterial.SetColor(_colorName, emissionColor);

            // �p�x�����X�ɏ���������
            this.degree -= this.speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �p�x��180�x�ɐݒ�
        this.degree = 180;
    }
}
