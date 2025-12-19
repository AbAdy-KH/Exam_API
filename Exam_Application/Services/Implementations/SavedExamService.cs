using AutoMapper;
using Exam_Application.common.DTOs.Exam;
using Exam_Application.common.DTOs.SavedExam;
using Exam_Application.common.interfaces;
using Exam_Application.Services.Interfaces;
using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Implementations
{
    public class SavedExamService : ISavedExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public SavedExamService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }
        public void SaveExam(CreateSaveExamDto savedExamDto)
        {
            SavedExam savedExamEntity = _mapper.Map<SavedExam>(savedExamDto);

            savedExamEntity.UserId = _userService.GetCurrentUserId();

            _unitOfWork.SavedExam.Add(savedExamEntity);
            _unitOfWork.Save();
        }

        public void UnsaveExam(string examId)
        {
            var userId = _userService.GetCurrentUserId();

            SavedExam savedExamEntity = _unitOfWork.SavedExam.Get(se => se.ExamId == examId && se.UserId == userId);

            if(savedExamEntity == null) throw new Exception("Saved exam not found.");

            _unitOfWork.SavedExam.Delete(savedExamEntity);
            _unitOfWork.Save();
        }

        public List<GetExamInfoDto> GetSavedExamsForUser(string userId, int pageNumber = 1, string filter = "", string subjectFilter = "-1")
        {
            string currentUserId = _userService.GetCurrentUserId();
            if(userId != currentUserId)
            {
                throw new UnauthorizedAccessException("You are not authorized to access these saved exams.");
            }

            var savedExams = _unitOfWork.SavedExam
                .GetAll(se => 
                       (se.UserId == userId)
                       && (filter == "" || se.Exam.Title.Contains(filter) || se.Exam.Subject.Name.Contains(filter) || se.Exam.CreatedBy.UserName.Contains(filter))
                       && (subjectFilter == "-1" || se.Exam.SubjectId == subjectFilter)
                , includeProperties: "Exam, Exam.Subject, Exam.CreatedBy")
                .Skip((pageNumber - 1) * 20)
                .Take(20);

            List<GetExamInfoDto> examsDtos = savedExams.Select(se => new GetExamInfoDto
            {
                Id = se.Exam.Id,
                Title = se.Exam.Title,
                Subject = se.Exam.Subject,
                Username = se.Exam.CreatedBy.UserName
            }).ToList();

            return examsDtos;
        }
    }
}
