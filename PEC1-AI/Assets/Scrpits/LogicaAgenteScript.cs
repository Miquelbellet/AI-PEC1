using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LogicaAgenteScript : MonoBehaviour
{
    private NavMeshAgent navMesh;
    void Start() 
    {
        //Agafem el component NavMeshAgent del objecte d'aquest scrpit
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Quan cliques el mouse dret, fer que l'agent es mogui cap a on has clicat
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit; 
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if (Physics.Raycast(camRay, out hit, 100))
            {
                navMesh.destination = hit.point;
            }
        }
    }
}
