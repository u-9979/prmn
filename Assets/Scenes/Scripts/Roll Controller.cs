using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingCharacter : MonoBehaviour
{
    private Rigidbody rb;

    // 転がる力の設定
    public float rollForce = 10f;
    public float rollTorque = 5f;

    void Start()
    {
        // Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // プレイヤーやコントローラーとの衝突を確認
        if (collision.gameObject.CompareTag("Player A"))
        {
            // 衝突した位置から方向を計算
            Vector3 direction = (transform.position - collision.transform.position).normalized;

            // Y軸方向を無視（転がりを水平に保つ）
            direction.y = 0;

            // 力を加える
            rb.AddForce(direction * rollForce, ForceMode.Impulse);

            // 回転を加える（スフィアが転がるように）
            Vector3 torque = Vector3.Cross(direction, Vector3.up) * rollTorque;
            rb.AddTorque(torque, ForceMode.Impulse);

            // 力とトルクの方向を確認するためにデバッグ
            Debug.DrawRay(transform.position, direction * 2, Color.red); // 力の方向を確認
            Debug.DrawRay(transform.position, torque, Color.green); // トルクの方向を確認
        }
    }
}

