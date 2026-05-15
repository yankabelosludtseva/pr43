using System;
using System.Collections.ObjectModel;
using System.Linq;
using TaskManager_Belosludtseva.Classes;
using TaskManager_Belosludtseva.Context;
using TaskManager_Belosludtseva.Models;

namespace TaskManager_Belosludtseva.ViewModels
{
    public class VM_Tasks : Notification
    {
        public TasksContext tasksContext { get; set; }
        public ObservableCollection<Tasks> Tasks { get; set; }

        public VM_Tasks()
        {
            tasksContext = new TasksContext();
            
            Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderBy(x => x.Done).ToList());
        }

        public RealyCommand OnAddTask
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    
                    Tasks newTask = new Tasks()
                    {
                        Name = "",
                        Priority = "",
                        DateExecute = DateTime.Now,
                        Comment = "",
                        Done = false
                       
                    };

                    Tasks.Add(newTask);

                    tasksContext.Tasks.Add(newTask);
                });
            }
        }
    }
}