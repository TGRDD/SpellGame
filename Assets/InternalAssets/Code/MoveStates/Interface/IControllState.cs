using System;

public interface IControllState
{
    event Action OnCastSpell_Performed;
    void Enter();
    void Exit();
    void Update();
}
