using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAction : MonoBehaviour
{

    Rigidbody _rb;


    public enum State // キャラクターの状態を切り替える　
    {
        Move = 0, //default
        Menu,
        Talk
    }
    public State _state;

    void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    void Update() 
    {
        EscAction();
        switch (_state) 
        {
            case State.Move:
                MoveAction();
                break;
            case State.Menu:
                //該当命令ナシ
                break;
            case State.Talk:
                //該当命令ナシ
                break;
        }
    }

    void MoveAction()
    {
        int _limit = 5; //速度
        int _acceleration = 20;　//加速度

        if (Input.GetKey(KeyCode.LeftShift)) //シフトキーを押している間速度と加速度を増加
        {
             _limit = 10;     
             _acceleration = 40;　
        }

        if (Input.GetKey(KeyCode.W))
        {
            this._rb.AddForce(transform.forward * 0);//加速値0
            if (_rb.velocity.z < _limit)//limit速度まで加速させる
            {
                this._rb.AddForce(transform.forward * _acceleration);
                Debug.Log(_rb.velocity.z);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            this._rb.AddForce(transform.forward * 0);
            if (_rb.velocity.z > -_limit)
            {
                this._rb.AddForce(transform.forward * -_acceleration);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            this._rb.AddForce(transform.right * 0);
            if (_rb.velocity.x < _limit)
            {
                this._rb.AddForce(transform.right * _acceleration);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            this._rb.AddForce(transform.right * 0);
            if (_rb.velocity.x > -_limit)
            {
                this._rb.AddForce(transform.right * -_acceleration);
            }
        }
    }

    void OnCollisionStay(Collision _col) // 当たっているものを検知
    {
        int _jump = 130 ;//ジャンプ高度

        if (_col.gameObject.tag == "Ground" && Input.GetKey(KeyCode.Space))　// Ground に触れている際にジャンプ
        {
            this._rb.AddForce(transform.up * _jump);
        }
        if (_col.gameObject.tag == "Obstacle")　// 障害物にあたったらデリート 障害物クラスを作ったらそこに移動　
        {
            Destroy(gameObject);
        }
    }

    public int _type; // 0 人　　1　アイテム
    void EscAction()　//元menu()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&(_state == State.Menu))
        {
            SceneManager.UnloadSceneAsync("Menu");
            _state = State.Move;
        }else if(Input.GetKeyDown(KeyCode.Escape)&&(_state == State.Move))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            _state = State.Menu;
        }else　if(Input.GetKeyDown(KeyCode.Escape)&&(_state == State.Talk))
        {
            switch (_type)
            {
                case 0:
                    SceneManager.UnloadSceneAsync("Talk");
                    _state = State.Move;
                    break;
                case 1:
                    _state = State.Move;
                    break;
            }
        }
    }
}
