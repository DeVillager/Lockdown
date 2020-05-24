using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Move,
        Act,
    }

    [SerializeField]
    private LayerMask layerMask;

    private Vector2 movement;
    private bool useInput;
    private PlayerState state;
    private Rigidbody2D rb;
    public float moveTime = 0.1f;
    private float inverseMoveTime;
    public GameObject collidedObject;

    private void Awake()
    {
        state = PlayerState.Idle;
        rb = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
    }

    void Update()
    {
        GetInputs();
        Actions();
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInputs()
    {
        movement.x = (int)(Input.GetAxisRaw("Horizontal"));
        movement.y = (int)(Input.GetAxisRaw("Vertical"));
        if (movement.x != 0)
        {
            movement.y = 0;
        }
        useInput = Input.GetButtonDown("Fire1");
    }

    private void Move()
    {
        Vector2 start = transform.position;
        Vector2 direction = new Vector2(movement.x, movement.y);
        if (state == PlayerState.Idle && (movement.x != 0 || movement.y != 0))
        {
            if (MoveEnabled(direction))
            {
                StartCoroutine(SmoothMovement(start, direction));
            }
        }
    }

    private bool MoveEnabled(Vector2 direction)
    {
        return !GetGameobjectInDirection(direction);
    }

    private GameObject GetGameobjectInDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, layerMask);
        collidedObject = hit.collider != null ? hit.collider.gameObject : null;
        NeedManager.Instance.UpdateInfo();
        return collidedObject;
    }

    protected IEnumerator SmoothMovement(Vector2 start, Vector2 direction)
    {
        state = PlayerState.Move;
        Vector3 end = start + direction;
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPostion = Vector3.MoveTowards(rb.position, end, inverseMoveTime * Time.deltaTime);
            rb.MovePosition(newPostion);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
        state = PlayerState.Idle;
        GetGameobjectInDirection(direction);
        
    }

    private void Actions()
    {
        if (useInput && collidedObject != null)
        {
            Debug.Log("Item used");
            collidedObject.GetComponent<Item>().Use();
            NeedManager.Instance.UpdateNeeds();
        }
    }

}
