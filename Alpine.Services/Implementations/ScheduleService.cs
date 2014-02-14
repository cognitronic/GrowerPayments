using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Schedule;
using Alpine.Infrastructure.Querying;
using Alpine.Services.Interfaces;
using Alpine.Services.Messaging.ScheduleService;
using Alpine.Services.Mapping;
using Alpine.Services.Cache;
using Alpine.Services.ViewModels;
using Alpine.Infrastructure.UnitOfWork;

namespace Alpine.Services.Implementations
{
    public class ScheduleService: IScheduleService
    {
        private readonly IScheduleRepository _repository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public ScheduleService(IScheduleRepository repository, ICacheStorage cache, IUnitOfWork uow)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
        }
    
#region IScheduleService Members

public CreateScheduleResponse CreateSchedule(CreateScheduleRequest request)
{
    var response = new CreateScheduleResponse();
    var schedule = new Schedule();

    schedule = (Schedule)request.Schedule;
    var result = _repository.Add(schedule);
    _uow.Commit();
    if (result > 0)
    {
        response.Success = true;
        response.Message = "Variety Created Successfully!";
        response.View = schedule.ConvertToScheduleView();
        response.View.Schedule = schedule;
    }
    else
    {
        response.Success = false;
        response.Message = "Assessment Creation Failed!";
    }

    return response;
}

public UpdateScheduleResponse UpdateSchedule(UpdateScheduleRequest request)
{
    var response = new UpdateScheduleResponse();
    var result = _repository.Save((Schedule)request.Schedule);
    _uow.Commit();
    if (result > 0)
    {
        response.Success = true;
        response.Message = "Schedule Updated Successfully!";
        response.View = request.Schedule.ConvertToScheduleView();
    }
    else
    {
        response.Success = false;
        response.Message = "Schedule Update Failed!";
    }

    return response;
}

public DeleteScheduleResponse DeleteSchedule(DeleteScheduleRequest request)
{
    var response = new DeleteScheduleResponse();
    var result = _repository.Remove((Schedule)request.Schedule);
    _uow.Commit();
    if (result > 0)
    {
        response.Success = true;
        response.Message = "Schedule Deleted Successfully!";
        response.View = request.Schedule.ConvertToScheduleView();
    }
    else
    {
        response.Success = false;
        response.Message = "Schedule Delete Failed!";
    }

    return response;
}

public GetScheduleByIDResponse GetScheduleByID(GetScheduleByIDRequest request)
{
    var response = new GetScheduleByIDResponse();
    Query query = new Query();

    query.Add(new Criterion("ID", request.ScheduleID, CriteriaOperator.Equal));

    var schedule = _repository.FindByID(request.ScheduleID);
    if (schedule != null)
    {
        response.Success = true;
        response.Message = "Variety Retrieved Successfully!";
        response.View = ScheduleMapper.ConvertToScheduleView((ISchedule)schedule);
        response.View.Schedule = schedule;
    }
    else
    {
        response.Success = false;
        response.Message = "Variety Retrieved Failed!";
    }

    return response;
}

public GetSchedulesResponse GetSchedulesByCropYear(GetSchedulesByCropYearRequest request)
{
 	throw new NotImplementedException();
}

public GetSchedulesResponse GetAllSchedules()
{
    var response = new GetSchedulesResponse();
    var schedules = _repository.FindAll();
    response.Schedules = ScheduleMapper.ConvertToScheduleViewList((IList<ISchedule>)schedules);
    return response;
}

#endregion
}
}
