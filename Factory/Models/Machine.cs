using System.Collections.Generic;

namespace StringFactory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<MachineEngineer>();
    }

    public int MachineId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<MachineEngineer> JoinEntities { get; set; }
  }
}