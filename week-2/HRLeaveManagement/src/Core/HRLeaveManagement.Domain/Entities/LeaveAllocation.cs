using HRLeaveManagement.Domain.Entite.Common;

namespace HRLeaveManagement.Domain.Entites;

public class LeaveAllocation : BaseDomainEntity
{
    public int NumberOfDays { get; set; }
    public LeaveType LeaveType { get; set; } = null!;
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}
