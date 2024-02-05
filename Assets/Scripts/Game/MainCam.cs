using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MainCam : MonoBehaviour
{
    public InputPlayer player;
    
   
    private float smoothSpeed = 0.99f;
    private Vector3 offset= new(10, 4, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void LateUpdate()
    {        
        Vector3 desiredPosition = new Vector3(player.transform.position.x, player.transform.position.y,-1) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }






    // Update is called once per frame
    void Update()
    {
        
    }














    
}
