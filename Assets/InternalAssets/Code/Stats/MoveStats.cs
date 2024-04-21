using System;

[Serializable]
public class MoveStats
{
    public float WalkMoveSpeed;
    public float RunWalkSpeed;

    public float GravityScale;
    public float RotationScale;
    public MoveStats(float moveSpeed, float jumpHeight, float rotationScale)
    {
        this.WalkMoveSpeed = moveSpeed;
        this.GravityScale = jumpHeight;
        RotationScale = rotationScale;
    }
}
