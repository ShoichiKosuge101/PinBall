using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Star�̉�]����N���X
/// ��]�ʂ̓����_���Ō���
/// </summary>
public class StarController : MonoBehaviour
{
    // ��]���x
    // ��]�ʕύX�ł���悤�ɃA�N�Z�X�ύX
    [SerializeField] float rotSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // ��]�ʂ̐ݒ�
        this.transform.Rotate(0, Random.Range(0,360), 0);
    }

    // Update is called once per frame
    void Update()
    {
        // ��]
        this.transform.Rotate(0,this.rotSpeed,0);
    }
}
