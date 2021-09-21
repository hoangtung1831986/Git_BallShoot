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

    public void MovingTarget(Vector2 vtTarget)
    {
        StartCoroutine(I_MovingTarget(vtTarget));
    }

    public IEnumerator I_MovingTarget(Vector2 vtTarget)
    {
        Vector2 point = transform.position;
        while (Vector2.Distance(vtTarget, transform.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, vtTarget, 5 * Time.deltaTime);
            yield return null;
        }
        transform.position = vtTarget;
    }
}
