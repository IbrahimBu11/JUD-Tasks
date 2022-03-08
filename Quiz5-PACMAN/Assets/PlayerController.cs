using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnPositionChange(int row, int col);
public class PlayerController : MonoBehaviour
{
    public int row;
    public int col;



    private bool isMoving = false;
    private Vector3 originalPos, targetPos;
    private float timeToMove = 0.2f;

    private bool canUp = true, canRight= true, canDown=true, canLeft= true;

    GameManager game;

    private void Update()
    {
        if (rayCast(Vector3.up))
            canUp = true;
        else
            canUp = false;
        if (rayCast(Vector3.down))
            canDown = true;
        else
            canDown = false;
        if (rayCast(Vector3.left))
            canLeft = true;
        else
            canLeft = false;
        if (rayCast(Vector3.right))
            canRight = true;
        else
            canRight = false;

        if (Input.GetKey(KeyCode.W)  && !isMoving && canUp)
            StartCoroutine(MovePlayer(Vector3.up * 1.1f));
        if (Input.GetKey(KeyCode.S)  && !isMoving && canDown)
            StartCoroutine(MovePlayer(Vector3.down * 1.1f));
        if (Input.GetKey(KeyCode.A)  && !isMoving && canLeft)
            StartCoroutine(MovePlayer(Vector3.left * 1.1f));
        if (Input.GetKey(KeyCode.D)  && !isMoving && canRight)
            StartCoroutine(MovePlayer(Vector3.right * 1.1f));

        
    }


    public bool rayCast(Vector3 direction)
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        Debug.DrawRay(transform.position, transform.TransformDirection(direction) *Mathf.Infinity, Color.yellow);
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, Mathf.Infinity))
        {
            
            
            Debug.Log(hit.collider.name);

            return true;
        }
        else
            return false;
    }



    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        originalPos = transform.position;
        targetPos = originalPos + direction ;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }


}
