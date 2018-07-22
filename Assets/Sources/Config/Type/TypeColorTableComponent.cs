using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Config]
[Unique]
public sealed class TypeColorTableComponent : IComponent
{
    public List<Color> Value;
}