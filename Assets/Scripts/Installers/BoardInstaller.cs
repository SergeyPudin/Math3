using UnityEngine;
using Zenject;

public class BoardInstaller : MonoInstaller
{
    [SerializeField] private Board _board;

    public override void InstallBindings()
    {
        Container.Bind<Board>().FromInstance(_board).AsSingle();
    }
}