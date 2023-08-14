using HRLeaveManagement.Application.DTOs.Common;
using HRLeaveManagement.Application.DTOs.LeaveType;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest;

public class LeaveRequestListDto : BaseDto
{
    public LeaveTypeDto LeaveType { get; set; } = null!;
    public DateTime DateRequested { get; set; }
    public bool? Approved { get; set; }
}
