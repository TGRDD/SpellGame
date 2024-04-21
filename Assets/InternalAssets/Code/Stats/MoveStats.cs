using System;

[Serializable]
public class MoveStats
{
    public float WalkSpeed;
    public float RunSpeed;

    public float GravityScale;
    public float RotationScale;
    public MoveStats(float moveSpeed, float jumpHeight, float rotationScale)
    {
        this.WalkSpeed = moveSpeed;
        this.GravityScale = jumpHeight;
        RotationScale = rotationScale;
    }
}
