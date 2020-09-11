using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    //効果音
    public AudioClip Block;

    //効果音を鳴らすためのコンポーネントを入れる
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        //AudioSourceのコンポーネントを取得する
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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

    //キューブ衝突時に呼ばれる関数
    void OnCollisionEnter2D(Collision2D other)
    {
        //キューブ同士が積み重なる時効果音を鳴らす
        if (other.gameObject.tag == "Cube")
        {
            AudioSource.PlayClipAtPoint(Block, transform.position);
        }

        //キューブが地面に接触する時効果音を鳴らす
        if (other.gameObject.tag == "Ground")
        {
            AudioSource.PlayClipAtPoint(Block, transform.position);
        }
    }
}



