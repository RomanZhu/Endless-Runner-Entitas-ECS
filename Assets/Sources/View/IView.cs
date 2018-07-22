using Entitas;
using UnityEngine;

public interface IView
{
    bool Enabled { get; set; }
    int Id { get; set; }
    Vector2 Position { get; set; }
    Transform Transform { get; }
    
    void InitializeView(Contexts contexts, GameEntity entity);
}
// CONGRATULATIONS! YOU FOUND THE CAT!
//               )\._.,--....,'``.       
// .b--.        /;   _.. \   _\  (`._ ,. 
//`=,-,-'~~~   `----(,_..'--(,_..'`-.;.'