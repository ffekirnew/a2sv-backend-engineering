using HRLeaveManagement.Domain.Entite.Common;

namespace HRLeaveManagement.Domain.Entites;

class LeaveType : BaseDomainEntity
{
    public string Name { get; set; } = null!;
    public int DefaultDays { get; set; }
}
