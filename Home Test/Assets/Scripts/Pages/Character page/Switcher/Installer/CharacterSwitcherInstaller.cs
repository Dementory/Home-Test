using System;
using HomeTest.CharacterPage;
using UnityEngine;
using Zenject;

public class CharacterSwitcherInstaller : MonoInstaller
{
    [SerializeField] private CharacterSwitcher _characterSwitcher;

    public override void InstallBindings()
    {
        if (!_characterSwitcher)
            throw new NullReferenceException("Character switcher isn't assigned");

        Container.Bind<CharacterSwitcher>().FromInstance(_characterSwitcher).AsSingle();
    }
}