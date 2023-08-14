using HRLeaveManagement.Domain.Entite.Common;

namespace HRLeaveManagement.Domain.Entites;

public class LeaveType : BaseDomainEntity
{
    public string Name { get; set; } = null!;
    public int DefaultDays { get; set; }
}
