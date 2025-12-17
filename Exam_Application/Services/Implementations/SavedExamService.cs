using AutoMapper;
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
            Console.WriteLine(userId == "c4e2455e-2daf-4687-832e-b7abee805ad1");

            SavedExam savedExamEntity = _unitOfWork.SavedExam.Get(se => se.ExamId == examId && se.UserId == userId);

            if(savedExamEntity == null) throw new Exception("Saved exam not found.");

            _unitOfWork.SavedExam.Delete(savedExamEntity);
            _unitOfWork.Save();
        }
    }
}
