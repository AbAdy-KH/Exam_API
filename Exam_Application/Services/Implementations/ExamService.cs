using AutoMapper;
using Exam_Application.common.DTOs;
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
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateExam(CreateExamDto examDto)
        {
            var exam = _mapper.Map<Exam>(examDto);
            _unitOfWork.Exam.Add(exam);
            _unitOfWork.Save();
        }

        public IEnumerable<GetExamInfoDto> GetAllExams(string filter = "")
        {
            IEnumerable<Exam> examList = _unitOfWork.Exam.GetAll(e =>
                e.Title.Contains(filter) ||
                e.Subject.Name.Contains(filter),
                "Subject"
            );

            IEnumerable<GetExamInfoDto> examListDto = _mapper.Map<IEnumerable<GetExamInfoDto>>(examList);

            return examListDto;
        }
    }
}
