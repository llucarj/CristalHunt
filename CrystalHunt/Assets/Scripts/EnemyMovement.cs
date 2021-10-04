using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform limiteEsquerdo, limiteDireito;
    public float speed;
    public Transform startPos;

    private Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position == limiteEsquerdo.position)
        {
            nextPos = limiteDireito.position;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (transform.position == limiteDireito.position)
        {
            nextPos = limiteEsquerdo.position;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
