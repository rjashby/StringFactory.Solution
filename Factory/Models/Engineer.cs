using System.Collections.Generic;

namespace StringFactory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.JoinEntities = new HashSet<MachineEngineer>();
    }
    public int EngineerId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<MachineEngineer> JoinEntities { get;}
  }
}