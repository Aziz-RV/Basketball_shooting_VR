using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GetNewBall : MonoBehaviour
{
    public SteamVR_Action_Boolean generate;
    public GameObject player;
    public GameObject vr_camera;
    public GameObject the_ball;
    public GameObject the_ball_parent;
    // Start is called before the first frame update

    private CharacterController characterController;
    private Queue<GameObject> ball_list;
    //private Vector3 distance_to_player = new Vector3(1, 0, 0);
    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
        ball_list = new Queue<GameObject>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (generate.stateDown || Input.GetKeyDown("r"))
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(0,0.3f,0.5f));
            Quaternion rotation = vr_camera.transform.rotation;
            GameObject temp_ball = Instantiate(the_ball, vr_camera.transform.position + direction, rotation, the_ball_parent.transform);
            ball_list.Enqueue(temp_ball);
        }

        if (ball_list.Count > 10)
        {
            GameObject temp_ball2 = ball_list.Dequeue();
            Destroy(temp_ball2);
        }
    }
}
