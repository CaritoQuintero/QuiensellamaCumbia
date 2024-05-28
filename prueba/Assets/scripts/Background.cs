using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class Background : MonoBehaviour
{
    [SerializeField] private Vector2 V;
    private Vector2 offset;
    private Vector2 offset1;
    public Material material;
    public Rigidbody2D PlaRB;
    public float D;
    public float R = 2;
    [SerializeField] float ypos;
    [SerializeField] private Vector2 V1;
    void Start()
    {
        PlaRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        ypos = transform.position.y;
        material = GetComponent<SpriteRenderer>().material;
    }
    private void Update()
    {
        if (gameObject.tag == "ocean")
        {
            transform.position = new Vector2(transform.position.x, ypos);
            offset1 = -0.05f * V1 * Time.deltaTime;
            offset = PlaRB.velocity.x * -0.05f * V * Time.deltaTime;
            material.mainTextureOffset += offset1 += offset;
        }
        else
        {
            transform.position = new Vector2(transform.position.x, ypos);
            offset = PlaRB.velocity.x * -0.05f * V * Time.deltaTime;

            material.mainTextureOffset += offset;
        }
    }
    public void background_reset()
    {
        material.mainTextureOffset = new Vector2(0, 0);
    }
}