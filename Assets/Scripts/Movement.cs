using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6;
    Vector3 moveDirection = Vector3.zero;
    MeshRenderer meshRenderer;
    int id;
    CharacterController controller;
    [SerializeField]
    Generator generator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        meshRenderer = GetComponent<MeshRenderer>();
        PainColor();
    }

    void FixedUpdate() 
    {
        var hori = Input.GetAxis("Horizontal");
        var verti = Input.GetAxis("Vertical");
        var direction = new Vector3( hori,0,verti);

        if(direction.magnitude >= 0.1f)
        {
            controller.Move(moveSpeed * Time.deltaTime * direction);
        }
    }

    void PainColor()
    {
        id = Random.Range(0, 3);
        switch (id)
        {
            case 0:
                meshRenderer.material.color = Color.red;
                break;
            case 1:
                meshRenderer.material.color = Color.green;
                break;
            case 2:
                meshRenderer.material.color = Color.blue;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Ball>(out Ball ball))
        {
            if(ball.id == id)
            {
                GameUIController.Instance.UpdateScore();
                PainColor();
                StartCoroutine(generator.CreateBall(id));
                Destroy(collision.gameObject);
            }
            else
            {
                GameUIController.Instance.EndGame(false);
                Time.timeScale = 0f;
            }
        }
    }
}
