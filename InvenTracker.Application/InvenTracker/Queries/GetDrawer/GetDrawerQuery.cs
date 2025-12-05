using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetDrawer;

public class GetDrawerQuery: IRequest<GetDetailsDrawerDto>
{
    public Guid Id { get; set; }
}