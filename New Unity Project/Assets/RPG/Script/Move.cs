using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    Rigidbody _rb;
    SaveData _saveData;

    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveAction();
        Menu();
    }

    void MoveAction()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this._rb.AddForce(transform.forward * 0);
            if (_rb.velocity.z < 10)
            {
                Debug.Log(_rb.velocity.z);
                this._rb.AddForce(transform.forward * 20);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            this._rb.AddForce(transform.forward * 0);
            if (_rb.velocity.z > -10)
            {
                Debug.Log(_rb.velocity.z);
                this._rb.AddForce(transform.forward * -20);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            this._rb.AddForce(transform.right * 0);
            if (_rb.velocity.x < 10)
            {
                Debug.Log(_rb.velocity.x);
                this._rb.AddForce(transform.right * 20);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            this._rb.AddForce(transform.right * 0);
            if (_rb.velocity.x > -10)
            {
                Debug.Log(_rb.velocity.x);
                this._rb.AddForce(transform.right * -20);
            }
        }
    }

    void OnCollisionStay(Collision _col)
    {
        if (_col.gameObject.tag == "Ground" && Input.GetKey(KeyCode.Space))
        {
            this._rb.AddForce(transform.up * 130);
        }
    }
    bool _menu;
    void Menu()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&(_menu == true))
        {
            SceneManager.UnloadSceneAsync("Menu");
            _menu = false;
        }else if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            _menu = true;
        }
    }
}
