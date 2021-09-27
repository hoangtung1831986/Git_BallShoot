using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    private static Play instance;
    public static Play Instance
    {
        set { }
        get { return instance;  }
    }

    [Header("param")]
    private bool isMouseDown = false;
    [SerializeField]
    private float area;
    [SerializeField]
    private int numberBall;
    private bool isShoot = false;

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


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        listBallReady = new List<Ball>();
        for (int i = 0; i < numberBall; i++)
        {
            Ball ball = Instantiate(ballPrefabs, trfParen_ListBall);
            listBallReady.Add(ball);
        }
        InitBallShoot();

    }

    private void Update()
    {
        if (isShoot == true)
        {
            float speedBall = ballShoot.GetVelocity().magnitude;
            if(speedBall < 0.1f && speedBall > 0) // khi ban va moi thu dung lai thi ta bat dau ban dot khac
            {
                ballShoot.gameObject.SetActive(false);
                InitBallShoot();
                isShoot = false;
                Reset();
            }
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pointMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            HandleMouseDown(pointMouse);
        }
        if (isMouseDown == true)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 pointMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                HandleMouse(pointMouse);
            }
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 pointMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                HandleMouseUp(pointMouse);
            }
        }

        
    }

    #region HandleMouse

    private void HandleMouseDown(Vector2 pointMouse)
    { 
        if (Vector2.Distance(pointMouse, transform.position) > area)
            return;

        dots.SetActive(true);
        isMouseDown = true;
    }
    private void HandleMouse(Vector2 pointMouse)
    {
        Vector2 direction = pointMouse - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        dots.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        BarPowerChange();
    }

    private void BarPowerChange()
    {
        if (valueBarPowerShoot >= 1)
        {
            boodBarPower = -1;
        }
        if (valueBarPowerShoot <= 0)
        {
            boodBarPower = 1;
        }

        valueBarPowerShoot += boodBarPower * Time.deltaTime;
        SetBarPowerShoot();
    }

    private void HandleMouseUp(Vector2 pointMouse)
    {
        Vector2 direction = (pointMouse - (Vector2)transform.position).normalized;
        isMouseDown = false;
        dots.SetActive(false);
        BallShooting(direction, valueBarPowerShoot);
    }
    #endregion
    private void SetBarPowerShoot()
    {
        barPowerShoot.SetValueSlide(valueBarPowerShoot);
    }

    private void BallShooting(Vector2 direction, float valueBar)
    {      
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

        isShoot = true;
        //StartCoroutine(ShootingBall_AfterTime());
    }

    //private IEnumerator ShootingBall_AfterTime()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    isShoot = true;
    //}

    private void InitBallShoot()
    {
        if (numberBall <= 0)
        {
            GameOver();
            return;
        }
            
        ballShoot = listBallReady[numberBall - 1];      
        ballShoot.transform.SetParent(transform);
        listBallReady.RemoveAt(numberBall - 1);
        numberBall -= 1;
        ballShoot.MovingTarget(transform.position);
    }

    private void GameOver()
    {

    }
    private void Reset()
    {
        isMouseDown = false;
        dots.SetActive(false);
        valueBarPowerShoot = 0;
        boodBarPower = 1;
        SetBarPowerShoot();
    }

    public void Example()
    {
        Debug.Log(numberBall);
    }

}
