using HRLeaveManagement.Application.DTOs.Common;
using HRLeaveManagement.Application.DTOs.LeaveType;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest;

public class LeaveRequestDto : BaseDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveTypeDto LeaveType { get; set; } = null!;
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public DateTime DateActioned { get; set; }
    public bool? Approved { get; set; }
    public string RequestComments { get; set; } = null!;
    public bool Cancelled { get; set; }
}
