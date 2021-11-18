namespace SOLID_SimonMiller._3_L.Before
{

    public record class Employee(string Name);

    public record class WorkItem(string Description, Employee? Worker = null, bool IsComplete = false);

    public abstract class ManageWorkItemsBase
    {
        private readonly List<WorkItem> _workItems = new List<WorkItem>();

        public virtual WorkItem CreateWorkItem(string description) 
        {
            var workItem = new WorkItem(description);
            this._workItems.Add(workItem);
            return workItem;
        }

        public virtual WorkItem AssignWorkItem(WorkItem workItem, Employee employee)
        {
            var idx = this._workItems.IndexOf(workItem);
            var updatedWorkItem = workItem with { Worker = employee };
            this._workItems[idx] = updatedWorkItem;

            return updatedWorkItem;
        }

        public virtual WorkItem CloseWorkItem(WorkItem workItem)
        {
            var idx = this._workItems.IndexOf(workItem);
            var updatedWorkItem = workItem with { IsComplete = true };
            this._workItems[idx] = updatedWorkItem;

            return updatedWorkItem;
        }
    }

    public class Manager : ManageWorkItemsBase
    {
        public override WorkItem CloseWorkItem(WorkItem workItem) => throw new Exception("Managers don't close work items, the developers do that.");        
    }

    public class Developer : ManageWorkItemsBase
    {
        public override WorkItem CreateWorkItem(string description) => throw new Exception("Developers don't create work items.");
        public override WorkItem AssignWorkItem(WorkItem workItem, Employee employee) => throw new Exception("Developers don't assign work items.");
    }

    public class LeadDeveloper : ManageWorkItemsBase
    {
        public override WorkItem CreateWorkItem(string description) => throw new Exception("Lead Developers don't create work items.");
    }
}
