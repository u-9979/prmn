using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingCharacter : MonoBehaviour
{
    private Rigidbody rb;

    // �]����͂̐ݒ�
    public float rollForce = 10f;
    public float rollTorque = 5f;

    void Start()
    {
        // Rigidbody���擾
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // �v���C���[��R���g���[���[�Ƃ̏Փ˂��m�F
        if (collision.gameObject.CompareTag("Player A"))
        {
            // �Փ˂����ʒu����������v�Z
            Vector3 direction = (transform.position - collision.transform.position).normalized;

            // Y�������𖳎��i�]����𐅕��ɕۂj
            direction.y = 0;

            // �͂�������
            rb.AddForce(direction * rollForce, ForceMode.Impulse);

            // ��]��������i�X�t�B�A���]����悤�Ɂj
            Vector3 torque = Vector3.Cross(direction, Vector3.up) * rollTorque;
            rb.AddTorque(torque, ForceMode.Impulse);

            // �͂ƃg���N�̕������m�F���邽�߂Ƀf�o�b�O
            Debug.DrawRay(transform.position, direction * 2, Color.red); // �͂̕������m�F
            Debug.DrawRay(transform.position, torque, Color.green); // �g���N�̕������m�F
        }
    }
}

