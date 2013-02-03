using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    public Character Character;
    private bool _wantToJump;
    private bool _isLanding;
    public bool _isRunning = false;
    public Vector3 vec;
    public float scrollWheel = 0f;
    public float velocity = 0f;
    public float CurDeltaXValue;
    public Transform SpeedBar;
    public bool IsTouchedActive = true;
    public Camera cameraHud;
    private GameState gameState = GameState.IntroCamera;

    private Transform speedBar;
    GameObject gameLogic;

    void Start()
    {
        Instance = this;
        speedBar = GameObject.Find("SpeedBar").transform;
        gameLogic = GameObject.Find("GameLogic");
    }

    // Update is called once per frame
    void Update()
    {
        if (Character != null && Character.RunningCurve != null)
        {
            if (Camera.mainCamera.animation.isPlaying)
            {
                return;
            }
            else if (!Repository.Instance.SkipIntro)
            {
                if (gameState == GameState.IntroCamera)

                    if (!speedBar.animation.isPlaying && gameState == GameState.IntroCamera)
                    {
                        gameState = GameState.SpeedBarAlphaFaded;
                        speedBar.animation.Play();
                    }
                    else if (!speedBar.animation.isPlaying && gameState == GameState.SpeedBarAlphaFaded)
                    {
                        gameState = GameState.Playing;
                    }
            }


            if (SpeedBar != null && IsTouchedActive)
            {
                RaycastHit hit = new RaycastHit();

                if (Application.platform == RuntimePlatform.Android)
                {
                    float val = Input.acceleration.y / 0.5f - 0.25f;

                    if (val < -1f)
                        val = -1f;
                    else if (val > 1f)
                        val = 1f;

                    Repository.Instance.percent = -val;

                    for (int i = 0; i < Input.touchCount; ++i)
                    {
                        Ray ray = cameraHud.ScreenPointToRay(Input.GetTouch(i).position);

                        if (SpeedBar.collider.Raycast(ray, out hit, 1000f))
                        {
                            float min = 163.07f;
                            float max = 163.58f;

                            val = -((hit.point.x - max) / (max - min) * 2f + 1f);

                            Repository.Instance.percent = val;
                        }
                    }
                }
                else
                {
                    Ray ray = cameraHud.ScreenPointToRay(Input.mousePosition);

                    if (SpeedBar.collider.Raycast(ray, out hit, 100f))
                    {
                        float min = 163.07f;
                        float max = 163.58f;

                        float val = -((hit.point.x - max) / (max - min) * 2f + 1f);

                        Repository.Instance.percent = val;
                    }
                }
            }
            else
            {
                if (Input.GetJoystickNames().Length == 0)
                {
                    scrollWheel += Input.GetAxis("Mouse ScrollWheel");

                    scrollWheel = Mathf.Clamp(scrollWheel, -1f, 1f);

                    Repository.Instance.percent = scrollWheel;
                }
                else
                {
                    Repository.Instance.percent = Input.GetAxis("Horizontal");
                }
            }

            Repository.Instance.percent = Mathf.Clamp(Repository.Instance.percent, -1f, 1f);



            if (!Character.Model.animation.IsPlaying("landing"))
            {
                _isLanding = false;
            }

            CurDeltaXValue = Character.RunningCurve.Evaluate(Repository.Instance.percent);
            Vector3 vecBaseSpeed = new Vector3(Character.BaseSpeed * Time.deltaTime, 0f, 0f);
            Vector3 vecRunningCurve = new Vector3(CurDeltaXValue, 0f, 0f);
            Vector3 vecJumping = new Vector3(0f, 0f, 0f);

            if (Input.GetButton("Jump"))
                Jump();


            if (_wantToJump && !Character.Model.animation.IsPlaying("jump"))
            {
                vecJumping = new Vector3(0f, Character.JumpingHeight, 0f);
                _wantToJump = false;
            }

            if (Repository.Instance.percent != 0f)
            {
                _isRunning = true;
            }

            Vector3 vecMoving = Vector3.zero;

            if (_isRunning)
            {
                Vector3 vecX = vecBaseSpeed + vecRunningCurve;
                //vec = vecX;

                vecMoving = vecX + vecJumping;
            }



            Character.Model.rigidbody.AddForce(vecMoving);

            Character.Model.rigidbody.velocity = new Vector3(Mathf.Clamp(Character.Model.rigidbody.velocity.x, -8f, 0f), Character.Model.rigidbody.velocity.y, Character.Model.rigidbody.velocity.z);

            velocity = Math.Abs(Character.Model.rigidbody.velocity.x);

            vec = Character.Model.rigidbody.GetPointVelocity(this.transform.position);

            //Debug.Log(velocity);

            //if (!Character.animation.IsPlaying("jump"))
            {
                if (velocity < 0.13f)
                    Character.Model.animation.CrossFade("tuto");
                else if (velocity < 2f)
                    Character.Model.animation.CrossFade("walk");
                else
                    Character.Model.animation.CrossFade("run");
            }
        }
    }

    public void Jump()
    {
        Character.Model.animation.CrossFade("jump");
        Character.Model.animation.Play("in the air", AnimationPlayMode.Queue);

        _wantToJump = true;
    }

    public void Landing()
    {
        Character.Model.animation.CrossFade("landing");
        Character.Model.animation.Play("run", AnimationPlayMode.Queue);

        _isLanding = true;
    }

    internal void Death()
    {
        Application.LoadLevel("Game_over");
    }

    internal void InstanciateModule()
    {
        //Debug.Log(Repository.Instance.CurrentModule.Nom.ToString());
        //Debug.Log("End:" + Repository.Instance.CurrentModule.EndHeight.ToString());

        List<Module> listModule = GetListFromArray<Module>(gameLogic.GetComponents<Module>());

        listModule = listModule.FindAll(module => module.StartHeight == Repository.Instance.CurrentModule.EndHeight && module.Nom != "Intro"  && module.enabled);

        System.Random rnd = new System.Random();

        Repository.Instance.CurrentModule = listModule[rnd.Next(0, listModule.Count)];

        Debug.Log(Repository.Instance.CurrentModule.Nom.ToString() + "   " + Repository.Instance.CurrentModule.StartHeight.ToString()+ " :: " +Repository.Instance.CurrentModule.EndHeight.ToString());

        Vector3 vec = new Vector3(-Repository.Instance.NbModule * 31 + Repository.Instance.Vecteur.x + Repository.Instance.CurrentModule.ModulePrefab.position.x, Repository.Instance.Vecteur.y + Repository.Instance.CurrentModule.ModulePrefab.position.y, Repository.Instance.Vecteur.z + Repository.Instance.CurrentModule.ModulePrefab.position.z);

        Repository.Instance.NbModule++;

        Instantiate(Repository.Instance.CurrentModule.ModulePrefab, vec, Quaternion.identity);
    }


    public List<T> GetListFromArray<T>(T[] tab)
    {
        List<T> list = new List<T>();

        foreach (T item in tab)
        {
            list.Add(item);
        }

        return list;
    }
}

public enum GameState
{
    IntroCamera,
    SpeedBarAlphaFaded,
    Playing,
    Dead
}