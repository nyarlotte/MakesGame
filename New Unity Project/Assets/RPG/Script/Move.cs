using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody _rb;
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        MoveAction();
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
}
