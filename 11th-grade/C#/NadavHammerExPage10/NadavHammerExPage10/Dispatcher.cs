using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage10
{
    class Dispatcher
    {
        private Stack<Task>[] tasks;

        internal Stack<Task>[] Tasks { get => tasks; set => tasks = value; }

        public Dispatcher()
        {
            tasks = new Stack<Task>[3];
        }

        public void AddTask(Task t)
        {
            tasks[t.Code % 3].Push(t);
        }

        public Task GetTask()
        {
            if (!tasks[0].IsEmpty())
            {
                return tasks[0].Pop();
            }
            else if (!tasks[1].IsEmpty())
            {
                return tasks[1].Pop();
            }
            else if (!tasks[2].IsEmpty())
            {
                return tasks[2].Pop();
            }
            return null;
        }
    }
}
