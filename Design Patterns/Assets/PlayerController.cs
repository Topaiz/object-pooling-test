using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Gun[] guns;

    [SerializeField] float moveSpeed;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    bool shoot;

    void Start() {
        guns = transform.GetComponentsInChildren<Gun>();
    }

    void Update()    {
        moveUp = Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.D);

        shoot = Input.GetKeyDown(KeyCode.Space);

        if (shoot) {
            shoot = false;
            foreach (Gun gun in guns) {
                gun.Shoot();
            }
        }
    }

    private void FixedUpdate() {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;

        if (moveUp) {
            move.y += moveAmount;
        }

        if (moveDown) {
            move.y -= moveAmount;
        }

        if (moveLeft) {
            move.x -= moveAmount;
        }

        if (moveRight) {
            move.x += moveAmount;
        }

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount) {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        pos += move;
        if (pos.x  <= -8.3f) {
            pos.x = -8.3f;
        }

        if (pos.x >= 8.4f) {
            pos.x = 8.4f;
        }

        if (pos.y <= -4.5f) {
            pos.y = -4.5f;
        }

        if (pos.y >= 4.5f) {
            pos.y = 4.5f;
        }

        transform.position = pos;
    }
}
