﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaunchableObject : MonoBehaviour
{
    private float _speed;
    private bool _isLaunched;
    private bool _isTrajectoryDrawn;
    private float _countTime;
    private int _numOfCollisions;

    private Rigidbody _ballRigidbody;//initialized in OnLaunch()
    private LineRenderer _trajectoryRenderer;

    private List<Vector3> _points;
    public Vector3 StartPosition { get; private set; }
    public Vector3 CarryPosition { get; private set; }
    public Vector3 TotalPosition { get; private set; }
    public Vector3 LaunchForce;

    private readonly float _preLaunchDelay = 0.25f;
    private readonly float _postLaunchDelay = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        _points = new List<Vector3>();

        CarryPosition = new Vector3(0, 0, 0);
        TotalPosition = new Vector3(0, 0, 0);
        StartPosition = new Vector3(0, 0, 0);

        _numOfCollisions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_ballRigidbody == null || _trajectoryRenderer == null)
            return;

        if (_isLaunched)
        {
            if (_speed < 0.1)
            {
                _ballRigidbody.velocity = new Vector3(0, 0, 0);

                _trajectoryRenderer.positionCount = _points.Count;

                _trajectoryRenderer.SetPositions(_points.ToArray());

                TotalPosition = _ballRigidbody.gameObject.transform.position;

                _isLaunched = false;

                _isTrajectoryDrawn = true;

                TrajectoryDataContent tdc = Camera.main.GetComponentInChildren<TrajectoryDataContent>();

                tdc.OnLaunchEvent(gameObject.transform.name + " Total: " + Vector3.Distance(TotalPosition, StartPosition).ToString());

                return;
            }
        }

        if (!_isTrajectoryDrawn)
        {
            if (Mathf.Abs(Time.time - _countTime) >= 0.05f)
            {
                _points.Add(_ballRigidbody.gameObject.transform.position);

                _countTime = Time.time;
            }
        }
    }

    public void OnLaunch(Vector3 force = default(Vector3))
    {
        _ballRigidbody = gameObject.GetComponent<Rigidbody>();

        if (_ballRigidbody == null)
            return;

        _trajectoryRenderer = gameObject.transform.GetComponentInChildren<LineRenderer>();

        if (_trajectoryRenderer == null)
            return;

        StartPosition = _ballRigidbody.gameObject.transform.position;

        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();

        if (eventTrigger != null)
        {
            eventTrigger.triggers.Clear();
        }

        StartCoroutine(Launch(_ballRigidbody, force));
    }

    private IEnumerator Launch(Rigidbody rigidbody, Vector3 force = default(Vector3))//called in OnLaunc() Startroutine
    {
        _countTime = Time.time;

        if (_trajectoryRenderer.positionCount > 0)
        {
            _points.Clear();

            _trajectoryRenderer.positionCount = 0;
            _trajectoryRenderer.SetPositions(_points.ToArray());
        }

        _isTrajectoryDrawn = false;

        yield return new WaitForSeconds(_preLaunchDelay);

        rigidbody.AddForce(force != default(Vector3) ? force : LaunchForce, ForceMode.Impulse);

        yield return new WaitForSeconds(_postLaunchDelay);

        _isLaunched = true;
    }

    public void ReceiveCollision(Collision c)
    {
        if (_ballRigidbody == null)
            return;

        if (_numOfCollisions == 0)
        {
            CarryPosition = _ballRigidbody.gameObject.transform.position;

            TrajectoryDataContent tdc = Camera.main.GetComponent<TrajectoryDataContent>();

            tdc.OnLaunchEvent(gameObject.transform.name + " Carry: " + Vector3.Distance(CarryPosition, StartPosition).ToString());
        }

        _numOfCollisions++;
    }
}
