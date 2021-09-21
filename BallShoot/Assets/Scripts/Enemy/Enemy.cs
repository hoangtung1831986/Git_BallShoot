using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject main;
    [SerializeField]
    private float speedRotation;
    private void Awake()
    {
        main = transform.GetChild(0).gameObject;
    }
    void Update()
    {
        main.transform.Rotate(new Vector3(0, 0, speedRotation * Time.deltaTime));
        //float zEula = main.transform.rotation.eulerAngles.z;
        //main.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zEula + speedRotation * Time.deltaTime));
    }
}
