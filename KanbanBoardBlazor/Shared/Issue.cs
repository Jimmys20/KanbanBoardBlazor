using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
  public class Issue
  {
    public long id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string assignees { get; set; }

    public string stageKey { get; set; }
    //public Stage stage { get; set; }


    public Priority priority { get; set; }

    public DateTime deadline { get; set; }
  }

  public enum Priority
  {
    LOW,
    MEDIUM,
    HIGH,
    CRITICAL
  }
}
