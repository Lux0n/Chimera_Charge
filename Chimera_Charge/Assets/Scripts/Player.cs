using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float speed = 1f;
    [SerializeField] float sideBoundary = 1f;

    Vector3 minScreenBounds;
    Vector3 maxScreenBounds;

    private void Start()
    {
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    private void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(0,translation,0);
        
        Vector3 clampedposition = transform.position;
        clampedposition.x = Mathf.Clamp(clampedposition.x, minScreenBounds.x + sideBoundary, maxScreenBounds.x - sideBoundary);
        transform.position = clampedposition;
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x,transform.position.y + 1,2), Quaternion.identity);
        }
    }
}
