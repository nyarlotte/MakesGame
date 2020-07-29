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

    void Start()
    {
        _rb =this.GetComponent<Rigidbody>();

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

                break;
            case State.Talk:

                break;
        }

    }

    void MoveAction()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this._rb.AddForce(transform.forward * 0);
            if (_rb.velocity.z < 10)
            {
                this._rb.AddForce(transform.forward * 20);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            this._rb.AddForce(transform.forward * 0);
            if (_rb.velocity.z > -10)
            {
                this._rb.AddForce(transform.forward * -20);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            this._rb.AddForce(transform.right * 0);
            if (_rb.velocity.x < 10)
            {
                this._rb.AddForce(transform.right * 20);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            this._rb.AddForce(transform.right * 0);
            if (_rb.velocity.x > -10)
            {
                this._rb.AddForce(transform.right * -20);
            }
        }
    }

    void OnCollisionStay(Collision _col) // 当たっているものを検知
    {
        if (_col.gameObject.tag == "Ground" && Input.GetKey(KeyCode.Space))　//Ground に触れている際にジャンプ
        {
            this._rb.AddForce(transform.up * 130);
        }

        if (_col.gameObject.tag == "Obstacle")　//障害物にあたったらデリート
        {
            Destroy(gameObject);
        }
    }

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
            SceneManager.UnloadSceneAsync("Talk");
            _state = State.Move;
        }
    }
}
