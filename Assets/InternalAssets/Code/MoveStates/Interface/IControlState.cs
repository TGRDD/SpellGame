using System;

public interface IControlState
{
    event Action OnCastSpell_Performed;
    void Enter();
    void Exit();
    void Update();
}
