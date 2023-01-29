using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SnakeController : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private int _directionVal = 1;
    public Transform segmentPrefab;
    private List<Transform> _segments;
    private Vector2 startPos;
    private Vector2 endPos;
    PhotonView view;
    private int _playerID;

    void Start() {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        view = GetComponent<PhotonView>();
        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
    }

    void Update(){
        if(GameState.isMultiplayer){
            if(view.IsMine){
                ChangeDirection();
                ChangeDirectionTouch();
                // tempController();
            }
        }else{
            ChangeDirection();
            ChangeDirectionTouch();
        }
        
    }

    void FixedUpdate() {
        if(GameState.isMultiplayer==true){
            if(PhotonNetwork.CurrentRoom.PlayerCount==2){
                Move();
            }
        }else{
            Move();
        }

    }

    void Move(){
        for(int i=_segments.Count-1;i>0;i--){
            _segments[i].position = _segments[i-1].position;
        }

        transform.position = new Vector2(
            Mathf.Round(transform.position.x + _direction.x),
            Mathf.Round(transform.position.y + _direction.y)
        );
    }

    // for Keyboard inputs
    void ChangeDirection(){
        if(Input.GetKeyDown(KeyCode.UpArrow) && _directionVal!=2){
            _direction = Vector2.up;
            _directionVal=1;
        }else if(Input.GetKeyDown(KeyCode.DownArrow) && _directionVal!=1){
            _direction = Vector2.down;
            _directionVal=2;
        }else if(Input.GetKeyDown(KeyCode.RightArrow) && _directionVal!=4){
            _direction = Vector2.right;
            _directionVal=3;
        }else if(Input.GetKeyDown(KeyCode.LeftArrow) && _directionVal!=3){
            _direction = Vector2.left;
            _directionVal=4;
        }
    }

    // for touch inputs
    void ChangeDirectionTouch()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    startPos = touch.position;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    endPos = touch.position;
                    Vector2 swipe = endPos - startPos;

                    if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                    {
                        if (swipe.x > 0 && _directionVal != 4)
                        {
                            _direction = Vector2.right;
                            _directionVal = 3;
                        }
                        else if (swipe.x < 0 && _directionVal != 3)
                        {
                            _direction = Vector2.left;
                            _directionVal = 4;
                        }
                    }
                    else
                    {
                        if (swipe.y > 0 && _directionVal != 2)
                        {
                            _direction = Vector2.up;
                            _directionVal = 1;
                        }
                        else if (swipe.y < 0 && _directionVal != 1)
                        {
                            _direction = Vector2.down;
                            _directionVal = 2;
                        }
                    }
                }
            }
        }


    void tempController(){
         if(Input.GetKeyDown(KeyCode.UpArrow) ){
            transform.position = transform.position + new Vector3(0,1,0);
        }else if(Input.GetKeyDown(KeyCode.DownArrow) ){
            transform.position = transform.position + new Vector3(0,-1,0);
        }else if(Input.GetKeyDown(KeyCode.RightArrow) ){
            transform.position = transform.position + new Vector3(1,0,0);
        }else if(Input.GetKeyDown(KeyCode.LeftArrow) ){
            transform.position = transform.position + new Vector3(-1,0,0);
        }
    }

    public void AddSegment(){
        Transform newSegment = Instantiate(this.segmentPrefab);
        newSegment.position = _segments[_segments.Count-1].position;
        _segments.Add(newSegment);        
    }

}




