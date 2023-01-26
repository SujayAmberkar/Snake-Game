using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private int _directionVal = 1;
    private float _speed=1f;
    public Transform segmentPrefab;
    private List<Transform> _segments;
    private Vector2 startPos;
    private Vector2 endPos;

    void Start() {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    void Update(){
        // ChangeDirection();
        ChangeDirectionTouch();
    }

    void FixedUpdate() {
        Move();
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
        }else if(Input.GetKey(KeyCode.DownArrow) && _directionVal!=1){
            _direction = Vector2.down;
            _directionVal=2;
        }else if(Input.GetKey(KeyCode.RightArrow) && _directionVal!=4){
            _direction = Vector2.right;
            _directionVal=3;
        }else if(Input.GetKey(KeyCode.LeftArrow) && _directionVal!=3){
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

    public void SpeedIncrease(){
        _speed +=1f;
    }

    public void AddSegment(){
        Transform newSegment = Instantiate(this.segmentPrefab);
        newSegment.position = _segments[_segments.Count-1].position;
        _segments.Add(newSegment);        
    }

}




