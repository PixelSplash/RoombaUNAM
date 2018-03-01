﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensores : MonoBehaviour {
    public int numBasuras;
    Comportamiento _comportamiento;
    float _tiempo_quieto;
    Vector3 pos;
    public float tiempo_estancado;
    public float rango_de_vision;

    // Use this for initialization
    void Start () {
        pos = transform.position;
        _tiempo_quieto = 0;
        _comportamiento = GetComponent<Comportamiento>();
    }
	
	// Update is called once per frame
	void Update () {
        if(numBasuras <= 0)
        {
            //transform.position = new Vector3(1,transform.position.y,1);
        }
		if(pos == transform.position)
        {
            _tiempo_quieto++;
        }
        else
        {
            
           _tiempo_quieto = 0;
           pos = transform.position;
        }
        if(_tiempo_quieto > tiempo_estancado)
        {
            _tiempo_quieto = 0;
            _comportamiento.MeEstanque();
        }
	}
 
    public void VerLados()
    {
        RaycastHit hit;
        Vector3 aux;

        //Sensor de proximidad derecho atras

        aux = transform.position - transform.forward + transform.right * rango_de_vision;// * 3;
        if (Physics.Raycast(transform.position + transform.up - transform.forward, transform.right, out hit, rango_de_vision))
        {
            
            if(hit.transform.tag == "Pared")
            {
                //print(hit.point);
                _comportamiento.ViPared(aux);
            }
            
        }
        else
        {
            _comportamiento.ViEspacioVacio(aux);

            //Sensor de proximidad derecho atras 2

            aux = transform.position - transform.forward + transform.right * rango_de_vision * 2;// * 3;
            if (Physics.Raycast(transform.position + transform.up - transform.forward, transform.right, out hit, rango_de_vision * 2))
            {

                if (hit.transform.tag == "Pared")
                {
                    //print(hit.point);
                    _comportamiento.ViPared(aux);
                }

            }
            else
            {
                _comportamiento.ViEspacioVacio(aux);


            }
        }

        //Sensor de proximidad izquierdo atras

        aux = transform.position - transform.forward - transform.right * rango_de_vision;// * 3;
        if (Physics.Raycast(transform.position + transform.up - transform.forward, -transform.right, out hit, rango_de_vision))
        {
            
            if (hit.transform.tag == "Pared")
            {
                //print(hit.point);
                _comportamiento.ViPared(aux);
            }
            
        }
        else
        {
            _comportamiento.ViEspacioVacio(aux);

            //Sensor de proximidad izquierdo atras 2

            aux = transform.position - transform.forward - transform.right * rango_de_vision * 2;// * 3;
            if (Physics.Raycast(transform.position + transform.up - transform.forward, -transform.right, out hit, rango_de_vision * 2))
            {

                if (hit.transform.tag == "Pared")
                {
                    //print(hit.point);
                    _comportamiento.ViPared(aux);
                }

            }
            else
            {
                _comportamiento.ViEspacioVacio(aux);
            }
        }

        

        

        //Sensor de proximidad derecho

        aux = transform.position + transform.right * rango_de_vision;// * 3;
        if (Physics.Raycast(transform.position + transform.up, transform.right, out hit, rango_de_vision))
        {

            if (hit.transform.tag == "Pared")
            {
                //print(hit.point);
                _comportamiento.ViPared(aux);
            }

        }

        //Sensor de proximidad izquierdo

        aux = transform.position - transform.right * rango_de_vision;// * 3;
        if (Physics.Raycast(transform.position + transform.up, -transform.right, out hit, rango_de_vision))
        {

            if (hit.transform.tag == "Pared")
            {
                //print(hit.point);
                _comportamiento.ViPared(aux);
            }

        }

        //Sensor de proximidad frontal

        aux = transform.position + transform.forward * rango_de_vision * 1.5f;
        if (Physics.Raycast(transform.position + transform.up, transform.forward, out hit, rango_de_vision *1.5f))
        {

            if (hit.transform.tag == "Pared")
            {
                //print(hit.point);
                _comportamiento.ViPared(aux);
            }

        }
        else
        {
            //_comportamiento.ViEspacioVacio(aux);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        
        Vector3 aux;
        aux = transform.position - transform.right * rango_de_vision * 3;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, aux);

        aux = transform.position + transform.right * rango_de_vision * 3;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, aux);

        aux = transform.position + transform.forward * rango_de_vision * 1.5f;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, aux);
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Basura")
        {
            Destroy(other.gameObject);
            numBasuras--;
        }
    }
}
