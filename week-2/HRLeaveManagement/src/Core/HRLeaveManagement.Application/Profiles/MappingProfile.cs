using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Domain.Entites;

namespace HRLeaveManagement.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LeaveType, LeaveTypeDto>();
        CreateMap<LeaveAllocation, LeaveAllocationDto>();
        CreateMap<LeaveRequest, LeaveRequestDto>();
        CreateMap<LeaveRequest, LeaveRequestListDto>();
    }
}
