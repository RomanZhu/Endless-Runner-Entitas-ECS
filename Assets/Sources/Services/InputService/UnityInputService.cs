using UnityEngine;

public sealed class UnityInputService : Service, IInputService
{    
    private          float   _holdingTimeLeft;
    private          bool    _isHoldingLeft;
    private          bool    _isReleasedLeft;
    private          bool    _isStartedHoldingLeft;
    
    private float   _holdingTimeRight;
    private bool    _isHoldingRight;
    private bool    _isReleasedRight;
    private bool    _isStartedHoldingRight;

    public UnityInputService(Contexts contexts) : base(contexts)
    {
    }

    public void Update(float delta)
    {
        var midPoint = Screen.width / 2f;

        var leftHitCounter  = 0;
        var rightHitCounter = 0;

        #region Mouse

        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < midPoint)
            {
                leftHitCounter++;
            }
            else
            {
                rightHitCounter++;
            }
        }

        #endregion

        #region Keyboard

        if (Input.GetKey(KeyCode.Space))
        {
            leftHitCounter++;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rightHitCounter++;
        }

        #endregion

        #region Touch

        foreach (var touch in Input.touches)
        {
            if (touch.position.x < midPoint)
            {
                leftHitCounter++;
            }
            else
            {
                rightHitCounter++;
            }
        }

        #endregion

        if (leftHitCounter > 0)
        {
            if (_isHoldingLeft)
            {
                _holdingTimeLeft      += delta;
                _isStartedHoldingLeft =  false;
            }
            else
            {
                _holdingTimeLeft      = 0f;
                _isStartedHoldingLeft = true;
            }

            _isHoldingLeft  = true;
            _isReleasedLeft = false;
        }
        else
        {
            if (_isHoldingLeft)
            {
                _isHoldingLeft  = false;
                _isReleasedLeft = true;
            }
            else
            {
                _isReleasedLeft = false;
            }
        }

        if (rightHitCounter > 0)
        {
            if (_isHoldingRight)
            {
                _holdingTimeRight      += delta;
                _isStartedHoldingRight =  false;
            }
            else
            {
                _holdingTimeRight      = 0f;
                _isStartedHoldingRight = true;
            }

            _isHoldingRight  = true;
            _isReleasedRight = false;
        }
        else
        {
            if (_isHoldingRight)
            {
                _isHoldingRight  = false;
                _isReleasedRight = true;
            }
            else
            {
                _isReleasedRight = false;
            }
        }
    }

    #region Interface Implementation
    
    #region Left
    public bool IsHoldingLeft()
    {
        return _isHoldingLeft;
    }

    public bool IsStartedHoldingLeft()
    {
        return _isStartedHoldingLeft;
    }

    public float HoldingTimeLeft()
    {
        return _holdingTimeLeft;
    }

    public bool IsReleasedLeft()
    {
        return _isReleasedLeft;
    }
    #endregion

    #region Right
    public bool IsHoldingRight()
    {
        return _isHoldingRight;
    }

    public bool IsStartedHoldingRight()
    {
        return _isStartedHoldingRight;
    }

    public float HoldingTimeRight()
    {
        return _holdingTimeRight;
    }

    public bool IsReleasedRight()
    {
        return _isReleasedRight;
    }
    #endregion

    #endregion
}