using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICollisionBall
{
    private GameObject main;
    [SerializeField]
    private int numberChild;
    [SerializeField]
    private float disChild_Main; // khoảng cách giữa enemy con đến trung tâm
    [SerializeField]
    private float speedRotation;
    private void Awake()
    {
        main = transform.GetChild(0).gameObject;
    }
    private void Start()
    {
        Init();
    }
    void Update()
    {
        main.transform.Rotate(new Vector3(0, 0, speedRotation * Time.deltaTime));

    }

    private void Init()
    {
        Transform trFParen = main.transform;
        for(int i=0; i<numberChild; i++)
        {
            trFParen.GetChild(i).gameObject.SetActive(true);
        }
      
        switch (numberChild)
        {         
            case 2:
                trFParen.GetChild(0).localPosition = new Vector3( disChild_Main,0,0);
                trFParen.GetChild(1).localPosition = new Vector3(-disChild_Main, 0, 0);
                break;
            case 3:
                float disCos60 = Mathf.Cos(Mathf.PI/3)* disChild_Main;
                float disSin60 = Mathf.Sin(Mathf.PI / 3)*disChild_Main;
                trFParen.GetChild(0).localPosition = new Vector3(disChild_Main, 0, 0);
                trFParen.GetChild(1).localPosition = new Vector3(-disCos60, disSin60, 0);
                trFParen.GetChild(2).localPosition = new Vector3(-disCos60, -disSin60, 0);
                break;
            case 4:
                trFParen.GetChild(0).localPosition = new Vector3(disChild_Main, 0, 0);
                trFParen.GetChild(1).localPosition = new Vector3(-disChild_Main, 0, 0);
                trFParen.GetChild(2).localPosition = new Vector3(0, disChild_Main);
                trFParen.GetChild(3).localPosition = new Vector3(0, -disChild_Main);
                break;
            case 5:
                float angle72 = Mathf.PI * 72 / 180;
                float angle36 = Mathf.PI * 36 / 180;
                float disCos72 = Mathf.Cos(angle72) * disChild_Main;
                float disSin72 = Mathf.Sin(angle72) * disChild_Main;
                float disCos36 = Mathf.Cos(angle36) * disChild_Main;
                float disSin36 = Mathf.Sin(angle36) * disChild_Main;
                trFParen.GetChild(0).localPosition = new Vector3(disChild_Main, 0, 0);
                trFParen.GetChild(1).localPosition = new Vector3(disCos72, disSin72, 0);
                trFParen.GetChild(2).localPosition = new Vector3(disCos72, -disSin72, 0);
                trFParen.GetChild(3).localPosition = new Vector3(-disCos36, disSin36, 0);
                trFParen.GetChild(4).localPosition = new Vector3(-disCos36, -disSin36, 0);
                break;
            case 6:
                float disCos60_6 = Mathf.Cos(Mathf.PI / 3) * disChild_Main;
                float disSin60_6 = Mathf.Sin(Mathf.PI / 3) * disChild_Main;
                trFParen.GetChild(0).localPosition = new Vector3(disChild_Main, 0, 0);
                trFParen.GetChild(1).localPosition = new Vector3(-disChild_Main, 0, 0);
                trFParen.GetChild(2).localPosition = new Vector3(disCos60_6, disSin60_6);
                trFParen.GetChild(3).localPosition = new Vector3(-disCos60_6, disSin60_6);
                trFParen.GetChild(4).localPosition = new Vector3(disCos60_6, -disSin60_6);
                trFParen.GetChild(5).localPosition = new Vector3(-disCos60_6, -disSin60_6);

                break;
            default:
                trFParen.GetChild(0).localPosition = new Vector3(disChild_Main, 0, 0);
                trFParen.GetChild(1).localPosition = new Vector3(-disChild_Main, 0, 0);
                break;
        }
    }


    #region InterFace
    public void CollisionBall()
    {

    }
    #endregion
}
