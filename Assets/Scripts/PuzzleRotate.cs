using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRotate : MonoBehaviour
{
    [SerializeField]
    private KeyCode _Key;
    [SerializeField]
    private Transform _Rotateable;
    [SerializeField]
    private float _RotateBy;
    [SerializeField]
    private Vector3 _Axis;
    [SerializeField]
    private PlayerController _Player;
    [SerializeField]
    private List<Puzzle_Interaction_Trigger> _Triggers;

    private bool _CanRotate;


    private void Update()
    {
        if(!_CanRotate)
        {
            return;
        }     
        
        if(Input.GetKeyDown(_Key))
        {
            DoRotate();
        }
    }

    private void Awake()
    {
        _Player.OnEnter += OnAllowRotation;
        _Player.OnExit += OnNotAllowRotation;
    }
    private void OnAllowRotation(Puzzle_Interaction_Trigger trigger)

    {
        if(_Triggers.Contains(trigger))
            {
            _CanRotate=true;
            }
    }

    private void OnNotAllowRotation()

    {
        _CanRotate=false;
    }

    private void DoRotate()
    {
        _Rotateable.Rotate(_Axis, _RotateBy );
    }
}
