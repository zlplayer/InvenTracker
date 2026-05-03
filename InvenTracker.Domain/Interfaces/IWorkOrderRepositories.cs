using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IWorkOrderRepositories
{
    Task<WorkOrder?> GetWorkOrder(Guid workOrderId);
    Task<IEnumerable<WorkOrder>> GetWorkOrders();
    Task<WorkOrder?> GetWorkOrderByCode(string code);
    Task CreateWorkOrder(WorkOrder workOrder);
    Task UpdateWorkOrder(WorkOrder workOrder);
    Task DeleteWorkOrder(WorkOrder workOrder);
}