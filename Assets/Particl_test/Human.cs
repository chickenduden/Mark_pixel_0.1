using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{


    private Rigidbody2D _headRigidbody2D;

    void Start()
    {
        _headRigidbody2D = GetComponentsInChildren<Rigidbody2D>()[1];
    }

    //событие
    private void OnMouseDown()
    {
        Die();
    }

    private void Die()
    {
        _headRigidbody2D.simulated = true;
        _headRigidbody2D.AddForce(new Vector2(2, 2), ForceMode2D.Impulse);
        _headRigidbody2D.AddTorque(-10);
        GetComponentInChildren<ParticleSystem>().Play();
    }
}
