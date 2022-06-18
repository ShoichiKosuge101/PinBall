using UnityEngine;

/// <summary>
/// �t���b�p�[����N���X
/// </summary>
public class FripperController : MonoBehaviour
{
    protected HingeJoint myHingeJoint;

    // �����̌X��
    protected float defaultAngle = 20;

    //�e�������̌X��
    protected float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = this.GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);
        
        // �A�N�Z�X���x���̃`�F�b�N
        // KeyboardController.LEFTFRIP = KeyCode.L;
    }

    // �t���b�p�[�̌X����ݒ�
    private void SetAngle(float angle)
    {
        // �X�v�����O�\���̂��擾����
        JointSpring jointSpring = this.myHingeJoint.spring;
        // �X�v�����O�̕ύX��p�x��n����
        jointSpring.targetPosition = angle;
        // �X�v�����O�̊p�x�𔽉f����
        this.myHingeJoint.spring = jointSpring;

        /* cf)�\���̃t�B�[���h�̒��ڕύX�͂ł��Ȃ�
        * _myHingeJoint.spring.targetPosition = this._flickAngle;
        * https://smdn.jp/programming/dotnet-samplecodes/collections/3a702b83024111eb907175842ffbe222/
        */
    }

    // Update is called once per frame
    void Update()
    {
        // �����L�[�ō��t���b�p�[�𓮂���
        // ������Ă���Ԃ̓t���b�p�[���オ�葱����(�t���O����͏���̂�)
        if (Input.GetKeyDown(KeyboardController.LEFTFRIP) && this.gameObject.CompareTag(TagName.LeftFripperTag))
        {
            SetAngle(this.flickAngle);
            //Debug.Log("Left Frip Up");
        }
        // �����L�[�𗣂��ƈʒu��߂�
        if (Input.GetKeyUp(KeyboardController.LEFTFRIP) && this.gameObject.CompareTag(TagName.LeftFripperTag))
        {
            SetAngle(this.defaultAngle);
        }

        //�E���L�[�ŉE�t���b�p�[�𓮂���
        // ������Ă���Ԃ̓t���b�p�[���オ�葱����(�t���O����͏���̂�)
        if (Input.GetKeyDown(KeyboardController.RIGHTFRIP) && this.gameObject.CompareTag(TagName.RightFripperTag))
        {
            SetAngle(this.flickAngle);
            //Debug.Log("Right Frip Up");
        }
        //�E���L�[�𗣂��ƈʒu��߂�
        if (Input.GetKeyUp(KeyboardController.RIGHTFRIP) && this.gameObject.CompareTag(TagName.RightFripperTag))
        {
            SetAngle(this.defaultAngle);
        }

        // ���t���b�p�[�𓮂���
        // �����L�[�̓o�C���h�ݒ�𖞂����Ȃ��Ă�����\
        // ������Ă���Ԃ̓t���b�p�[���オ�葱����(�t���O����͏���̂�)
        if ((Input.GetKeyDown(KeyboardController.BOTHFLIP) || Input.GetKeyDown(KeyCode.DownArrow)) && 
            ( this.gameObject.CompareTag(TagName.RightFripperTag) || this.gameObject.CompareTag(TagName.LeftFripperTag)))
        {
            SetAngle(this.flickAngle);
            //Debug.Log("Right Frip Up");
        }
        //�o�C���h�L�[�܂��͉����L�[�𗣂��ƈʒu��߂�
        if ((Input.GetKeyUp(KeyboardController.BOTHFLIP) || Input.GetKeyUp(KeyCode.DownArrow)) &&
             (this.gameObject.CompareTag(TagName.RightFripperTag) || this.gameObject.CompareTag(TagName.LeftFripperTag)))
        {
            SetAngle(this.defaultAngle);
        }

    }
}
