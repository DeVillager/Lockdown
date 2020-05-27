using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float moveTime = 0.1f;
    private float inverseMoveTime;
    [SerializeField]
    private Vector2 startPosition = Vector2.zero;

    private Vector2 movement;
    private bool useInput;
    

    private PlayerState state;
    private Rigidbody2D rb;

    [HideInInspector]
    public GameObject collidedObject;
    [HideInInspector]
    public bool collidingToItem = false;

    private Animator animator;

    private void Awake()
    {
        state = PlayerState.Idle;
        rb = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
        animator = GetComponent<Animator>();
        SetStartPosition();
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
        //if (state == PlayerState.Idle)
        //{
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        //}
        animator.SetFloat("Speed", movement.sqrMagnitude);
        useInput = Input.GetButtonDown("Fire1");
    }

    public void Reset()
    {
        SetStartPosition();
        collidedObject = null;
        collidingToItem = false;
    }

    public void SetStartPosition()
    {
        rb.position = startPosition;
    }

    private void Move()
    {
        Vector2 start = transform.position;
        Vector2 direction = new Vector2(movement.x, movement.y);
        if (state == PlayerState.Idle && (movement.x != 0 || movement.y != 0))
        {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
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
        if (hit.collider != null)
        {
            collidedObject = hit.collider.gameObject;
            if (collidedObject.layer == LayerMask.NameToLayer("Item"))
            {
                collidingToItem = true;
            }
            else
            {
                collidingToItem = false;
            }
        }
        else
        {
            collidedObject = null;
        }
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
        if (useInput && collidedObject != null && collidingToItem)
        {
            Debug.Log("Item used");
            collidedObject.GetComponent<Item>().Use();
            //NeedManager.Instance.UpdateNeeds();
        }
    }

}
