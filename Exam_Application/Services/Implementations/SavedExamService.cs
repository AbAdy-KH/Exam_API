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
        public SavedExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void SaveExam(CreateSaveExamDto savedExamDto)
        {
            SavedExam savedExamEntity = _mapper.Map<SavedExam>(savedExamDto);

            _unitOfWork.SavedExam.Add(savedExamEntity);
            _unitOfWork.Save();
        }

        public void UnsaveExam(string savedExamId)
        {
            SavedExam savedExamEntity = _unitOfWork.SavedExam.Get(se => se.Id == savedExamId);

            if(savedExamEntity == null) throw new Exception("Saved exam not found.");

            _unitOfWork.SavedExam.Delete(savedExamEntity);
            _unitOfWork.Save();
        }
    }
}
