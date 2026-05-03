using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class WorkOrderRepositories:IWorkOrderRepositories
{
    private readonly InvenTrackerDbContext _dbContext;

    public WorkOrderRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<WorkOrder?> GetWorkOrder(Guid workOrderId) =>
        await _dbContext.WorkOrders.Include(x=>x.Items).FirstOrDefaultAsync(x => x.Id == workOrderId);
    
    public async Task<IEnumerable<WorkOrder>> GetWorkOrders() =>
        await _dbContext.WorkOrders.Include(x => x.Items).Include(x=>x.Wardrobe).ToListAsync();

    public async Task<WorkOrder?> GetWorkOrderByCode(string code) =>                                                                                                                                                                                                                                                 
        await _dbContext.WorkOrders                                                                                                                                                                                                                                                                                  
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Code == code);
    
    public async Task CreateWorkOrder(WorkOrder workOrder)
    {
        await _dbContext.WorkOrders.AddAsync(workOrder);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateWorkOrder(WorkOrder workOrder)
    {
        _dbContext.WorkOrders.Update(workOrder);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteWorkOrder(WorkOrder workOrder)
    {
        _dbContext.WorkOrders.Remove(workOrder);
        await _dbContext.SaveChangesAsync();
    }
}