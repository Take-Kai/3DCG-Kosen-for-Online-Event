using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
//視点
    void Start()
    {

    }

    float sight_x = 0;
    float sight_y = 0;

    void Controller()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float angleH = Input.GetAxis("Horizontal2") * 5.0f;
        float angleV = Input.GetAxis("Vertical2") * 5.0f;

        if (sight_x >= 360)
        {
            sight_x = sight_x - 360;
        }
        else if (sight_x < 0)
        {
            sight_x = 360 - sight_x;
        }
        sight_x = sight_x + angleH;

        if (sight_y > 80)
        {
            if (angleV < 0)
            {
                sight_y = sight_y + angleV;
            }
        }
        else if (sight_y < -90)
        {
            if (angleV > 0)
            {
                sight_y = sight_y + angleV;
            }
        }
        else
        {
            sight_y = sight_y + angleV;
        }

        float dx = Mathf.Sin(sight_x * Mathf.Deg2Rad) * z + Mathf.Sin((sight_x + 90f) * Mathf.Deg2Rad) * x;

        float dz = Mathf.Cos(sight_x * Mathf.Deg2Rad) * z + Mathf.Cos((sight_x + 90f) * Mathf.Deg2Rad) * x;

        transform.Translate(dx, 0, dz, 0.0F);

        transform.localRotation = Quaternion.Euler(sight_y, sight_x, 0);

       // Debug.Log("sight_x:sight_y \n" + sight_x + " : " + sight_y);
        Debug.Log("dx:dz \n" + dx + " : " + dz);
    }
 
 //移動
    //移動関連のパラメータ
    [Header("速さの最低値")]
    [SerializeField]
    private float minSpeed = 3.0f;
    [Header("速さの最高値")]
    [SerializeField]
    private float maxSpeed = 5.0f;
    [Header("プレイヤーの方向転換スピードの調整値")]
    //0.0fだと一切向きが変わらず1.0fだと入力後すぐ入力された方向へ向く
    [SerializeField, Range(0.0f, 1.0f)]
    private float turnRate = 0.3f;

    //移動速度
    private Vector3 velocity;

    //キャラクターコントローラー
    private CharacterController controller;

    //InspectorにてRangeの値が指定の範囲に治るようにClamp処理
    private void OnValidate()
    {
        this.turnRate = Mathf.Clamp(this.turnRate, 0.0f, 1.0f);
    }

    //初期設定
    void Awake()
    {
        //キャラクターコントローラー取得
        this.controller = this.GetComponent<CharacterController>();

        //速度をゼロに設定
        this.velocity = Vector3.zero;

    }

    //更新処理
    void Update()
    { 
        Controller(); //視点
        Vector3 vec = this.velocity;
        float Speed = 0.0f;

        //床に接地していたら歩く
        if (this.controller.isGrounded)
        {
            //ゲームパッドのスティック入力値を取得して移動ベクトルを作成
            //..ついでに接地しているのでY軸の値をリセット
            vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            //入力値から得たベクトルの長さが0.1fを超えていれば速さを設定
            if (vec.magnitude > 0.1f)
            {
                //スティックの倒し具合によって速さを変更
                Speed = Mathf.Lerp(this.minSpeed, this.maxSpeed, vec.magnitude);

                //向きの変更
                Vector3 dir = vec.normalized;
                float rotate = Mathf.Acos(dir.z);
                if (dir.x < 0) rotate = -rotate;
                rotate *= Mathf.Rad2Deg;
                Quaternion Q = Quaternion.Euler(0, rotate, 0);
                //ここでモデルの向いている方向が徐々に変わるように処理しつつ
                //モデルの向きを変更
                this.transform.rotation = Quaternion.Slerp(
                          this.transform.rotation, Q, this.turnRate
                          );
            }

            //移動ベクトルを正規化
            vec = vec.normalized;
        }

        //移動速度を設定
        this.velocity.x = vec.x * Speed;
        this.velocity.y = vec.y;
        this.velocity.z = vec.z * Speed;

        //重力による落下を設定
        this.velocity.y += Physics.gravity.y * Time.deltaTime;

        //移動させる
        this.controller.Move(this.velocity * Time.deltaTime);

    }
}
