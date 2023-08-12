using HRLeaveManagement.Application.DTOs.Common;

namespace HRLeaveManagement.Application.DTOs.LeaveType;

public class LeaveTypeDto : BaseDto
{
    public string Name { get; set; } = null!;
    public int DefaultDays { get; set; }
}
