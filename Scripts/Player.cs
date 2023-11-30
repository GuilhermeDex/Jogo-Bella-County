using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPaused;

    [SerializeField] public float speed;
    [SerializeField] public float RunSpeed;
    [SerializeField] public float RollSpeed;

    private Rigidbody2D rig;
    private PlayerItems playerItems;

    private float InitialSpeed;
    private bool _IsRunning;
    private bool _IsRolling;
    private bool _IsCutting;
    private bool _IsDigging;
    private bool _IsWatering;


    private Vector2 _direction;

     [HideInInspector] public int handlingObj;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public bool IsRunning
    {
        get { return _IsRunning; }
        set { _IsRunning = value; }
    }
    public bool IsRolling
    {
        get { return _IsRolling; }
        set { _IsRolling = value; }
    }

    public bool IsCutting 
    { 
        get => _IsCutting; 
        set => _IsCutting = value; 
    }
    public bool IsDigging
    {
        get => _IsDigging;
        set => _IsDigging = value;
    }
    public bool IsWatering {
        get => _IsWatering; 
        set => _IsWatering = value; 
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        InitialSpeed = speed;
        playerItems = GetComponent<PlayerItems>();

    }


    private void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                handlingObj = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                handlingObj = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                handlingObj = 2;
            }


            OnInput();
            OnRun();
            OnRoll();
            OnCutting();
            OnDig();
            OnWatering();
        }
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            OnMove();
        }

    }


    #region Movement

    void OnCutting()
    {
        if(handlingObj == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsCutting = true;
                speed = 0f;
            }
            if (Input.GetMouseButtonUp(0))
            {
                IsCutting = false;
                speed = InitialSpeed;
            }
        }
    }
    void OnDig()
    {
        if(handlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsDigging = true;
                speed = 0f;
            }
            if (Input.GetMouseButtonUp(0))
            {
                IsDigging = false;
                speed = InitialSpeed;
            }

        }
    }
    void OnWatering()
    {
        if (handlingObj == 2 )
        {
            if (Input.GetMouseButtonDown(0) && playerItems.currentWater > 0)
            {
                IsWatering = true;
                speed = 0f;
            }
            if (Input.GetMouseButtonUp(0) || playerItems.currentWater <= 0 )
            {
                IsWatering = false;
                speed = InitialSpeed;
            }

            if (IsWatering)
            {
                playerItems.currentWater -= 0.01f;
            }

        }
    }


    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);

    }

    void OnRun(){

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = RunSpeed;
                _IsRunning = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = InitialSpeed;
                _IsRunning = false;
             }
        
    }

    void OnRoll()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = RollSpeed;
            _IsRolling = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = InitialSpeed;
            _IsRolling = false;
        }
    }



    #endregion
}
