using AutoMapper;
using Exam_Application.common.DTOs;
using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Exam, CreateExamDto>().ReverseMap();
            CreateMap<Exam, GetExamInfoDto>().ReverseMap();
            CreateMap<Question, CreateQuestionDto>().ReverseMap();
            CreateMap<Option, CreateOptionDto>().ReverseMap();
        }
    }
}
