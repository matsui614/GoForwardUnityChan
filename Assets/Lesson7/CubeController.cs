using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float speed = -12;
    private float deadLine = -10;

    // AudioSourceコンポーネント
    private AudioSource audioSource;

    public AudioClip collisionSound;

    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    // 2D 衝突時に呼ばれるメソッド
    void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーと接触していない場合
        if (!collision.gameObject.CompareTag("Player"))
        {
            // 地面か障害物と接触した時に鳴らす
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cube"))
            {
                audioSource.PlayOneShot(collisionSound);
            }
        }
    }
}
