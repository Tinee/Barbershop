using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayout.Functions.DataHandlers;
using EntityModels.DataTransferObject;
using EntityModels.Models;

namespace BusinessLogicLayout.Functions.EventHandlers
{
    public class AbsenceHandler : EntityHandler
    {
        public bool CreateNewAbsence(AbsencePostForm absencePostForm)
        {
            return UnitOfWork.AbsenceRepository.Create(absencePostForm.ConvertToAbsence());
        }

        public List<AbsenceDTO> GetAbsences(int scheduleId)
        {
            return UnitOfWork.AbsenceRepository.Get(a => a.ScheduleId == scheduleId).Select(a => new AbsenceDTO()
            {
                AbsenceTypeName = a.AbsenceType.Name,
                DateFrom = a.DateFrom,
                DateTo = a.DataTo,
                Id = a.Id,
                ScheduleId = a.ScheduleId
            }).ToList();
                
        }

        public List<ScheduleDTO> GetSchedules(int employeeId)
        {
            return UnitOfWork.ScheduleRepository.Get(s => s.EmployeeId == employeeId).ToList().ConvertToScheduleDTO();
        }

        public bool CreateSchedule(SchedulePostForm schedule)
        {
            return UnitOfWork.ScheduleRepository.Create(schedule.ConvertToSchedule());
        }

        public List<AbsenceTypeDTO> GetAbsenceTypes()
        {
            return UnitOfWork.AbsenceTypeRepository.Get().ToList().ConvertToAbsenceTypeDTO();
        }
    }
}
