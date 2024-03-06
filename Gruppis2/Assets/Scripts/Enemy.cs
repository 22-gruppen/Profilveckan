using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy: MonoBehaviour
{
    public NavMeshAgent meshAgent;

    public List<GameObject> waypoints;

    private GameObject player;

    private float velocity = 4, index, distance, radius = 20;

    [Range(0, 360)]
    public float angle;

    private Vector3 next_pos, destination, rotation;

    public bool chasing = false, onpath = true, canSeePlayer = false, editing = false;

    public LayerMask targetMask, obstructionMask; //Layermsks som anv�nds f�r att visa vad som �r vad. Allts� vad som �r en v�gg och vad som �r en player.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1"); // S�tter player variabeln till ett gameobject med taggen "Player1"
        StartCoroutine(FOVRoutine()); //Startar cooldown metoden.
        // OnSceneGUI();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(rotation); //Anv�nder rotation variabeln f�r att visa positionen som enemyn ska kolla p�.

        if (canSeePlayer == true) // Om enemyn kan se playern s� b�rjar den jaga. 
            chasing = true;

        else // om den inte kan se s� jagar den inte
            chasing = false;

        if (chasing == false)
        {
            if (onpath == false)
            {

                meshAgent.SetDestination(destination); // Om enemyn inte �r inne p� pathen med waypoints som den anv�nder f�r att patrullera runt mappen s�
                                                       // s�tts meshagentens destination till den senaste punkten enemyn var p� innan den b�rjade jaga playern
                if (transform.position.x == destination.x && transform.position.z == destination.z) 
                {
                    onpath = true; // Om enemyn �r p� senaste waypointen s� s�tts onpath till true och den forts�tter patrullera
                }    
            }
            else if (onpath == true)
            {
                meshAgent.ResetPath(); // Resettar enemyns meshagebts path.

                // Rotation variablerna anv�nds f�r att s�tta vilket h�ll enemyn ska vara roterad mot.
                rotation.x = destination.x;
                rotation.z = destination.z;
                rotation.y = transform.position.y;

                destination = waypoints[(int)index].transform.position; // S�tter destinations transform.position till n�sta waypoints transform.position

                next_pos = Vector3.MoveTowards(transform.position, destination, velocity * Time.deltaTime); //S�tter nextpos till den positonen enemyn ska g�

                transform.position = next_pos; // s�tter enemyns position till nextpos position

                distance = Vector3.Distance(transform.position, destination); // R�knar ut distans mellan enemyn och waypointen den ska till
                if (distance <= 0.5)
                {
                    if (index < waypoints.Count - 1)
                        index++; 

                    else
                        index = 0;
                }
            }
        }

        else if (chasing == true)
        {
            meshAgent.SetDestination(player.transform.position); //Om enemyn ser playern s�tts meshagentens destination till playerns destination.

            // Rotationen s�tts till playerns kordinater.
            rotation.x = player.transform.position.x;
            rotation.z = player.transform.position.z;
            rotation.y = transform.position.y; // Beh�ller y rotationen som enemyn har f�r att inte enemyn ska vrida sig.

            onpath = false;
        }
    }
    private IEnumerator FOVRoutine() // En cooldown metod som anv�nds till playerns syn.
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck(); // K�r field of view metode efter 0,2 sekunder.
        }
    }

    private void FieldOfViewCheck() //Metod som anv�nds f�r att enemyn ska kunna se.
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask); //G�r den radien som enemyn kan se. Allts� hur l�ngt den kan se.
                         
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform; // S�tter target variabelns transform till rangechecks transform.
            Vector3 directionToTarget = (target.position - transform.position).normalized; // R�knar ut vilket h�ll playern �r fr�n enemyn.

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2) //R�knar ut vilken vinkel som enemyn kan se i. 
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position); // R�knar ut distansen till targeten.

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    //Skickar ut rays f�r att se om det �r n�got mellan enemyn och playern som blockar dens syn som tillexempel en v�gg. 
                    canSeePlayer = true; //Om det inte finns n�got mellan enemyn och playern s� kan den se playern
                else
                    canSeePlayer = false; //Om det �r n�got mellan enemyn och playern s� kan den inte se playern.
            }
            else
                canSeePlayer = false;
        }

        else if (canSeePlayer == true)
            canSeePlayer = false; // Om playern kommer utanf�r enemyns syn s� kan inte enemyn se playern l�ngre. 


    }

   /* private void OnSceneGUI() // En metod som skulle rita ut f�ltet som enemyn kunde se. Funkade inte i slut�ndan.
    {
        if (editing == true)
        {
            Handles.color = Color.white;
            Handles.DrawWireArc(transform.position, Vector3.up, Vector3.forward, 360, radius);
        }
    } */
}