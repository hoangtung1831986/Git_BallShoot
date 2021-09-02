using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    [Header("param")]
    private bool isMouseDown = false;
    [SerializeField]
    private float area;
    [SerializeField]
    private int numberBall;
    private bool isShoot = false;

    // Biến xác định kết thúc một lần bắn ( khi bóng bắn xong mà bay đi xa, hoặc lực bắn yếu, hoặc chạm vào các mục tiêu đã xong)
    private bool isFinish=false;

    private Ball ballShoot;
    [SerializeField]
    private Ball ballPrefabs;

    [Header("BarPowerShoot")]
    [SerializeField]
    private BarPowerShoot barPowerShoot;
    private float valueBarPowerShoot = 0;
    private int boodBarPower = 1;


    [SerializeField]
    private Transform trfParen_ListBall;
    [SerializeField]
    private GameObject dots;
    private List<Ball> listBallReady;

    private void Start()
    {
        listBallReady = new List<Ball>();
        for (int i = 0; i < numberBall; i++)
        {
            Ball ball = Instantiate(ballPrefabs, trfParen_ListBall);
            listBallReady.Add(ball);
        }
        ballShoot = listBallReady[numberBall - 1];
        ballShoot.transform.position = transform.position;
        ballShoot.transform.SetParent(transform);
        listBallReady.RemoveAt(numberBall - 1);
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
                dots.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


                if (valueBarPowerShoot >= 1)
                {
                    boodBarPower = -1;
                }
                if (valueBarPowerShoot <= 0)
                {
                    boodBarPower = 1;
                }

                valueBarPowerShoot +=  boodBarPower * Time.deltaTime * 0.5f;
                SetBarPowerShoot();
            }
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 pointMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (pointMouse - (Vector2)transform.position).normalized;
                isMouseDown = false;
                dots.SetActive(false);
                BallShooter(direction, valueBarPowerShoot);
            }
        }

        if (isShoot == true)
        {
            Debug.Log(ballShoot.GetVelocity().magnitude);
        }
    }

    private void SetBarPowerShoot()
    {
        barPowerShoot.SetValueSlide(valueBarPowerShoot);
    }

    private void BallShooter(Vector2 direction, float valueBar)
    {
        isShoot = true;
        float powerBar = 0;
        float maxPower = 1000f;
        if(valueBar>=0 && valueBar <= 0.8f)
        {
            powerBar = (valueBar* maxPower) /0.8f;
        }
        if (valueBar > 0.8f)
        {
            powerBar = ((0.8f - (valueBar - 0.8f)) * maxPower)/0.8f ;
        }
        ballShoot.Shooter(powerBar * direction);
    }
    private void Reset()
    {
        isMouseDown = false;
        dots.SetActive(false);
        valueBarPowerShoot = 0;
        boodBarPower = 1;
        SetBarPowerShoot();
    }

}
