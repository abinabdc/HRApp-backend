using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roomie.Data;
using Roomie.Dtos.ForRequest;
using Roomie.Entity;
using Roomie.Extensions;
using Roomie.Interfaces;

namespace Roomie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILeaveRepository _leaveRepo;
        private readonly IUserRepository _userRepo;
        public LeaveController(DataContext ctx, IMapper mapper, ILeaveRepository leaveRepo, IUserRepository userRepository)
        {
            _context = ctx;
            _mapper = mapper;
            _leaveRepo = leaveRepo;
            _userRepo = userRepository;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leave>>> GetLeaves()
        {
            var result = await _leaveRepo.GetLeavesAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Leave>> GetLeaveById(int id)
        {
            var result = await _leaveRepo.GetLeaveByIdAsync(id);
            return Ok(result);
        }
        [HttpPost("approve-leave")]
        [Authorize(Policy = "Hr")]
        public async Task<ActionResult> ApproveLeave(ApproveLeaveDto approveLeaveDto)
        {
            var userApplying = await _userRepo.GetUserByIdInternalUse(approveLeaveDto.UserId);
            var leaveBeingEdited = await _leaveRepo.GetLeaveByIdAsync(approveLeaveDto.LeaevId);

            if (approveLeaveDto.Approve == true)
            {


                if (approveLeaveDto.LeaveType == "wfh")
                {
                    if (userApplying.WFHAvailable - approveLeaveDto.TotalDays >= 0)
                    {
                        leaveBeingEdited.Approved = true;

                        _context.Leaves.Update(leaveBeingEdited);
                        if (await _leaveRepo.SaveAllAsync())
                        {

                            userApplying.WFHAvailable = userApplying.WFHAvailable - approveLeaveDto.TotalDays;
                            _context.Users.Update(userApplying);
                            if (await _userRepo.SaveAllAsync())
                            {
                                return Ok("should work now");
                            }


                        }
                    }
                    else
                    {
                        return BadRequest("You have taken all you wfh leave.");
                    }

                }
                else if (approveLeaveDto.LeaveType == "day-off")
                {
                    if (userApplying.DayOffAvailable - approveLeaveDto.TotalDays >= 0)
                    {
                        leaveBeingEdited.Approved = true;

                        _context.Leaves.Update(leaveBeingEdited);
                        if (await _leaveRepo.SaveAllAsync())
                        {

                            userApplying.DayOffAvailable = userApplying.DayOffAvailable - approveLeaveDto.TotalDays;
                            _context.Users.Update(userApplying);
                            if (await _userRepo.SaveAllAsync())
                            {
                                return Ok("should work now");
                            }


                        }
                    }
                    else
                    {
                        return BadRequest("You have taken all you day off leave.");
                    }
                }
                else if (approveLeaveDto.LeaveType == "sick")
                {
                    if (userApplying.SickLeaveAvailable - approveLeaveDto.TotalDays >= 0)
                    {
                        leaveBeingEdited.Approved = true;

                        _context.Leaves.Update(leaveBeingEdited);
                        if (await _leaveRepo.SaveAllAsync())
                        {

                            userApplying.SickLeaveAvailable = userApplying.SickLeaveAvailable - approveLeaveDto.TotalDays;
                            _context.Users.Update(userApplying);
                            if (await _userRepo.SaveAllAsync())
                            {
                                return Ok("should work now");
                            }


                        }
                    }
                    else
                    {
                        return BadRequest("You have taken all you sick leaves please contact HR for this serious issue.");
                    }
                }
                else if (approveLeaveDto.LeaveType == "vacation")
                {
                    if (userApplying.VacationAvailable - approveLeaveDto.TotalDays >= 0)
                    {
                        leaveBeingEdited.Approved = true;

                        _context.Leaves.Update(leaveBeingEdited);
                        if (await _leaveRepo.SaveAllAsync())
                        {

                            userApplying.VacationAvailable = userApplying.VacationAvailable - approveLeaveDto.TotalDays;
                            _context.Users.Update(userApplying);
                            if (await _userRepo.SaveAllAsync())
                            {
                                return Ok("should work now");
                            }


                        }
                    }
                    else
                    {
                        return BadRequest("You have taken all you vacation leaves.");
                    }
                }
                





            }
            else if (approveLeaveDto.Approve == false)
            {
                leaveBeingEdited.Approved = false;
                _context.Leaves.Update(leaveBeingEdited);
                if (await _leaveRepo.SaveAllAsync())
                {
                    return Ok("Request has been rejected");
                }

            }
            return BadRequest();
        }



        [HttpPost("take-leave")]
        [Authorize]
        public async Task<ActionResult> CreateLeave(LeaveDto leaveDto)
        {
            var username = User.GetUsername();
            var userApplying = await _userRepo.GetUserByIdInternalUse(int.Parse(username));

            if (leaveDto.LeaveType == "wfh")
            {
                if (userApplying.WFHAvailable - leaveDto.TotalDays >= 0)
                {
                    var leave = new Leave
                    {
                        UserId = int.Parse(username),
                        /*FromDate = leaveDto.FromDate,*/
                        /*FromDate = new(year: 2022, month: 6, day: 19),*/
                        FromDate = DateTime.Now.ToString("MM/dd/yyyy"),


                        TotalDays = leaveDto.TotalDays,
                        LeaveType = leaveDto.LeaveType,
                        Approved = false

                    };

                    _context.Leaves.Add(leave);
                    if (await _leaveRepo.SaveAllAsync())
                    {
                        {
                            return Ok("Should work now");
                        }
                        /*userApplying.WFHAvailable = userApplying.WFHAvailable - leaveDto.TotalDays;
                        _context.Users.Update(userApplying);
                         if (await _userRepo.SaveAllAsync())
                        {
                            return Ok("should work now");
                        }*/


                    }
                }
                else
                {
                    return BadRequest("You have taken all you wfh leave.");
                }

            }
            else if (leaveDto.LeaveType == "day-off")
            {
                if (userApplying.DayOffAvailable - leaveDto.TotalDays >= 0)
                {
                    var leave = new Leave
                    {
                        UserId = int.Parse(username),
                        FromDate = DateTime.Now.ToString("MM/dd/yyyy"),
                        /*ToDate = leaveDto.ToDate,*/
                        TotalDays = leaveDto.TotalDays,
                        LeaveType = leaveDto.LeaveType

                    };
                    _context.Leaves.Add(leave);
                    if (await _leaveRepo.SaveAllAsync())
                    {
                        userApplying.DayOffAvailable = userApplying.WFHAvailable - leaveDto.TotalDays;
                        _context.Users.Update(userApplying);
                        if (await _userRepo.SaveAllAsync())
                        {
                            return Ok("should work now");
                        }


                    }
                }
                else
                {
                    return BadRequest("You have taken all you days off.");
                }
            }
            else if (leaveDto.LeaveType == "sick")
            {
                if (userApplying.SickLeaveAvailable - leaveDto.TotalDays >= 0)
                {
                    var leave = new Leave
                    {
                        UserId = int.Parse(username),
                        FromDate = DateTime.Now.ToString("MM/dd/yyyy"),
                        /*ToDate = leaveDto.ToDate,*/
                        TotalDays = leaveDto.TotalDays,
                        LeaveType = leaveDto.LeaveType

                    };
                    _context.Leaves.Add(leave);
                    if (await _leaveRepo.SaveAllAsync())
                    {
                        userApplying.SickLeaveAvailable = userApplying.WFHAvailable - leaveDto.TotalDays;
                        _context.Users.Update(userApplying);
                        if (await _userRepo.SaveAllAsync())
                        {
                            return Ok("should work now");
                        }
                    }
                }
                else
                {
                    return BadRequest("You have taken all you sick leaves");
                }
            }
            else if (leaveDto.LeaveType == "vacation")
            {
                if (userApplying.VacationAvailable - leaveDto.TotalDays >= 0)
                {
                    var leave = new Leave
                    {
                        UserId = int.Parse(username),
                        FromDate = DateTime.Now.ToString("MM/dd/yyyy"),
                        /*ToDate = leaveDto.ToDate,*/
                        TotalDays = leaveDto.TotalDays,
                        LeaveType = leaveDto.LeaveType

                    };
                    _context.Leaves.Add(leave);
                    if (await _leaveRepo.SaveAllAsync())
                    {
                        userApplying.SickLeaveAvailable = userApplying.WFHAvailable - leaveDto.TotalDays;
                        _context.Users.Update(userApplying);
                        if (await _userRepo.SaveAllAsync())
                        {
                            return Ok("should work now");
                        }


                    }
                }
                else
                {
                    return BadRequest("You have taken all your vacation leaves.");
                }
            }


            return BadRequest("Something went wrong.");
        }
    }
}
