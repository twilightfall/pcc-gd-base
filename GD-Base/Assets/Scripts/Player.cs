using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int maxHp = 100;
    private int currentHp = 100;
    private float moveSpeed = 5f;
    private float jumpForce = 8f;

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }

    public float JumpForce
    {
        get { return jumpForce; }
    }

    public int GetMaxHP()
    {
        return maxHp;
    }

    public int GetCurrentHP()
    {
        return currentHp;
    }
}
