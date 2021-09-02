using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D theRigibody2D;
    private void Awake()
    {
        theRigibody2D = this.GetComponent<Rigidbody2D>();
    }

    public void Shooter(Vector2 force)
    {
        theRigibody2D.AddForce(force);
    }

    public Vector2 GetVelocity()
    {
        return theRigibody2D.velocity;
    }
}
