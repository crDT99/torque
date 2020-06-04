using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Calculos : MonoBehaviour
{
    Quaternion quaternion;
    public GameObject Obj_2;
    public float radio, masa, Momento_de_Inercia, t;
    public  Vector3 posA_actual, posA_Sig, fTorque, Acel_ang, Vel_ang;


    public InputField aceleracion, torque ;

    void Start()
    {   
        Vector3 tmp = Obj_2.GetComponent<Transform>().position;
        radio = tmp.x;
        masa = 0.5f;
        Vel_ang.x = 0;
        Vel_ang.y = 0;
        Vel_ang.z = 0;
        t = 0.01f;
       
        
    }


    void Update()
    {

        Vector3 tmp = Obj_2.GetComponent<Transform>().position;
        radio = tmp.x;
        posA_actual = gameObject.GetComponent<Transform>().rotation.eulerAngles;   
        fTorque = Obj_2.GetComponent<mouse>().fAplicada * radio;
        Momento_de_Inercia = (masa * Mathf.Pow(radio, 2)) / 3;
        Acel_ang = fTorque / Momento_de_Inercia;
        Vel_ang = Vel_ang + Acel_ang * t;
        posA_actual = posA_actual + Vel_ang * t; posA_Sig = posA_actual;
        quaternion = Quaternion.Euler(posA_actual.x, posA_actual.y, posA_actual.z);
        gameObject.GetComponent<Transform>().rotation = quaternion;
        aceleracion.text = Acel_ang.y.ToString(); torque.text = fTorque.y.ToString();
    }
}