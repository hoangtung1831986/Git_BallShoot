using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    [Header ("param")]
    private bool isMouseDown = false;
    [SerializeField]
    private float area;
    [SerializeField]
    private int numberBall;

    private Ball ballShoot;
    [SerializeField]
    private Ball ballPrefabs;

    [SerializeField]
    private BarPowerShoot barPowerShoot;

    [SerializeField]
    private Transform trfParen_ListBall;
    [SerializeField]
    private GameObject dots;
    private List<Ball> listBallReady;

    private void Start()
    {
        listBallReady = new List<Ball>();
        for(int i=0; i<numberBall; i++)
        {
            Ball ball = Instantiate(ballPrefabs, trfParen_ListBall);
            listBallReady.Add(ball);
        }
        ballShoot = listBallReady[numberBall - 1];
        ballShoot.transform.position = transform.position;
        ballShoot.transform.SetParent(transform);
        listBallReady.RemoveAt(numberBall-1);
        numberBall -= 1;
       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pointMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(pointMouse, transform.position) > area)
                return;

            dots.SetActive(true);
            isMouseDown = true;
        }
        if (isMouseDown == true)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 pointMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = pointMouse - (Vector2)transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                dots.transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
            }
            if (Input.GetMouseButtonUp(0))
            {
                isMouseDown = false;
                dots.SetActive(false);
            }
        }
    }

    private void SetBarPowerShoot( float power)
    {

    }

    private void Shooter(Vector2 vtForce)
    {
        ballShoot.Shooter(vtForce);
    }

}
