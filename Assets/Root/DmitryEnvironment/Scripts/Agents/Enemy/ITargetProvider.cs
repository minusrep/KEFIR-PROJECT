using UnityEngine;

namespace Root.Rak.Agents.Enemy
{
    public interface ITargetProvider
    {
        ITarget RequestTarget(Transform enemy);
    }
}