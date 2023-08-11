using HRLeaveManagement.Domain.Entite.Common;

namespace HRLeaveManagement.Domain.Entites;

class LeaveRequest : BaseDomainEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveType LeaveType { get; set; } = null!;
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public DateTime DateActioned { get; set; }
    public bool? Approved { get; set; }
    public string RequestComments { get; set; } = null!;
    public bool Cancelled { get; set; }
}
