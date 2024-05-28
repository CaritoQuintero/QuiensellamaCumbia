using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Camera cam;
    public float ax;
    public float speed;
    public Rigidbody2D RB;
    public float Force;
    [SerializeField] bool JP = false;
    public Coins coins;
    public float moving_x;
    Animator animator;
    [SerializeField] Vector3 Box;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform ground_controller;
    [SerializeField] float speedY;
    [SerializeField] Transform right;
    [SerializeField] Vector3 box_right;
    [SerializeField] Transform left;
    [SerializeField] Vector3 box_left;
    [SerializeField] LayerMask obj;
    public AudioClip die;
    [SerializeField] bool jumping;
    [SerializeField] AudioClip jumpsound;
    [SerializeField] GameObject min_cam;
    [SerializeField] Button Pause;
    [SerializeField] Image Setup;
    [SerializeField] bool setup_toggle_state = false;
    [SerializeField] float setupY;
    public bool movX = true;
    void Start()
    {
        speedY = RB.velocity.y;
        ground = LayerMask.GetMask("ground");
        animator = gameObject.GetComponent<Animator>();
        Pause.onClick.AddListener(Setup_toggle);
        setupY = Setup.transform.position.y;
    }

    void Update()
    {
        animator.SetFloat("velocityY",RB.velocity.y);
        JP = Physics2D.OverlapBox(ground_controller.position, Box, 0f, ground);
            moving_x = math.abs(RB.velocity.x);
        animator.SetFloat("movingX", moving_x);
        animator.SetBool("isinground", JP);
        if (cam.transform.position.y >= min_cam.transform.position.y && GameObject.Find("D3")==null)
        {
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, -15f);
        }
        else if (GameObject.Find("D3") != null)
        {
            cam.transform.position = new Vector3(transform.position.x, -0.93f, -15f);
        }
        else
        {
            cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, -15f);  
        }
        ax = Input.GetAxis("Horizontal");

        if (!setup_toggle_state && movX)
        {
            RB.velocity = new Vector3(1f * speed * ax, RB.velocity.y, 0);
        }
        else
        {
            RB.velocity = new Vector3(0, RB.velocity.y, 0);
        }
        if (ax < 0)
        {

 if (Physics2D.OverlapBox(left.position, box_left, 0f,ground))
            {
                Debug.Log("left");
                RB.velocity = new Vector3(0, RB.velocity.y, 0);
            }
            transform.localScale = new Vector3(-0.1913774f,transform.localScale.y, transform.localScale.z);
        }
        if (ax > 0)
        {
 if (Physics2D.OverlapBox(right.position, box_right, 0f,ground))
            {
                Debug.Log("right");
                RB.velocity = new Vector3(0, RB.velocity.y, 0);
            }
            transform.localScale = new Vector3(0.1913774f, transform.localScale.y, transform.localScale.z);
        }
        if (JP == true && !setup_toggle_state)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB.AddForce(Vector2.up * Force, ForceMode2D.Impulse);
                SoundController.Instance.PlaySound(jumpsound);
            }
        }
        RB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
  public void Setup_toggle()
    {
        if (gameObject.GetComponent<Coins>().lives == 0) { }
        else
        {
            coins.pause_enabled = !coins.pause_enabled;
            if (setup_toggle_state)
            {
                LeanTween.moveY(Setup.GetComponent<RectTransform>(), setupY, 1f).setEase(LeanTweenType.easeInOutSine);
                setup_toggle_state = !setup_toggle_state;
            }
            else
            {
                LeanTween.moveY(Setup.GetComponent<RectTransform>(), 9, 1f).setEase(LeanTweenType.easeInOutCubic);
                setup_toggle_state = !setup_toggle_state;
            }
        }
    }
}
